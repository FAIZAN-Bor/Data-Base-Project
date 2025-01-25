//using Oracle.DataAccess.Client;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using System.Web.UI.WebControls;
//using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DBBBB_Project
{
    public partial class no_use : UserControl
    {
        public no_use()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        string image_location;
        private void Admin_chechk_profile_Load(object sender, EventArgs e)
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

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    int id = int.Parse(textBox1.Text);
        //    string name  = textBox2.Text;
        //    string email = textBox3.Text;
        //    string password = textBox4.Text;
        //    string contact = textBox5.Text;
        //    string address = textBox6.Text;

        //    Connection.UpdateAdminDetails(id,name, email, password, contact, address) ;
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            bool valid = IsValidEmail(email);

            if(!valid)
            {
                MessageBox.Show("Invalid Credentials");
                return;
            }
            string password = textBox3.Text;
            string contact = textBox4.Text;
            string address = textBox5.Text;

            byte[] images = null;
            FileStream streem = new FileStream(image_location, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(streem);
            images = br.ReadBytes((int)streem.Length);



            Connection.UpdateAdminDetails(1, name, email, password, contact, address);
            MessageBox.Show("Updated Successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text= string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PNG files (.png)|.png|JPG files (.jpg)|.jpg|All files (.)|.";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    image_location = openFileDialog.FileName;
                    pictureBox1.ImageLocation = image_location;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
