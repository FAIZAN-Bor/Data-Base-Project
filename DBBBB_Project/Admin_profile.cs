using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBBBB_Project
{
    public partial class Admin_profile : UserControl
    {
        public Admin_profile()
        {
            InitializeComponent();
        }

        private void Admin_profile_Load(object sender, EventArgs e)
        {
            DataTable a = Connection.Load_Admin_Data();
            textBox1.Text = a.Rows[0][0].ToString();
            textBox2.Text = a.Rows[0][1].ToString();
            textBox3.Text = a.Rows[0][2].ToString();
            textBox4.Text = a.Rows[0][3].ToString();
            textBox5.Text = a.Rows[0][4].ToString();
            textBox6.Text = a.Rows[0][5].ToString();

            byte[] img = a.Rows[0]["PICTURE"] as byte[];
            if (img == null)
            {
                pictureBox2.Image = null;
            }
            else
            {
                using (MemoryStream memoryStream = new MemoryStream(img))
                {
                    pictureBox2.Image = Image.FromStream(memoryStream);
                }
            }

        }

        static bool IsValidEmail(string email)
        {
           string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

           return Regex.IsMatch(email, pattern);
        }

        string image_location;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id;
                if (!int.TryParse(textBox1.Text, out id))
                {
                    MessageBox.Show("Invalid format for ID. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string email = textBox3.Text.Trim();
                bool valid = IsValidEmail(email);
                if (!valid)
                {
                    MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string name = textBox2.Text;
                string password = textBox4.Text;
                string contact = textBox5.Text;
                string address = textBox6.Text;
                //byte[] images = null;
                //FileStream streem = new FileStream(image_location, FileMode.Open, FileAccess.Read);
                //BinaryReader br = new BinaryReader(streem);
                //images = br.ReadBytes((int)streem.Length);

                Connection.UpdateAdminDetails(id, name, email, password, contact, address);
                MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //int id = int.Parse(textBox1.Text);
            //string name = textBox2.Text;
            //string email = textBox3.Text;

            //bool valid = IsValidEmail(email);
            //if (!valid)
            //{
            //    MessageBox.Show("Invalid Credentials");
            //    return;
            //}

            //string password = textBox4.Text;
            //string contact = textBox5.Text;
            //string address = textBox6.Text;
            //Connection.UpdateAdminDetails(id, name, email, password, contact, address);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text= string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PNG files (*.png)|*.png|JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    image_location = openFileDialog.FileName;
                    pictureBox2.ImageLocation = image_location;
                }

                int id = int.Parse(textBox1.Text);
                byte[] images = null;
                FileStream streem = new FileStream(image_location, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(streem);
                images = br.ReadBytes((int)streem.Length);

                Connection.Update_Admin_Pic(id, images);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
