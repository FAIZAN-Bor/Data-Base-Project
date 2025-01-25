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
    public partial class Emp_checck_profile : UserControl
    {
        public Emp_checck_profile()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        string image_location;
        private void Emp_checck_profile_Load(object sender, EventArgs e)
        {
            string namee = LogIN.getusername();

            DataTable a = Connection.Load_Employee_Data(namee);
            textBox1.Text = a.Rows[0][0].ToString();
            textBox2.Text = a.Rows[0][1].ToString();
            textBox3.Text = a.Rows[0][2].ToString();
            textBox4.Text = a.Rows[0][3].ToString();
            textBox5.Text = a.Rows[0][4].ToString();
            textBox6.Text = a.Rows[0][5].ToString();
            textBox7.Text = a.Rows[0][6].ToString();


            byte[] img = a.Rows[0]["EMP_PIC"] as byte[];
            if (img == null || img.Length == 0)
            {
                pictureBox1.Image = null;
            }
            else
            {
                using (MemoryStream memoryStream = new MemoryStream(img))
                {
                    pictureBox1.Image = Image.FromStream(memoryStream);
                }
            }

            //byte[] img = a.Rows[0]["EMP_PIC"] as byte[];
            //if (img == null)
            //{
            //    pictureBox1.Image = null;
            //}
            //else
            //{
            //    using (MemoryStream memoryStream = new MemoryStream(img))
            //    {
            //        pictureBox1.Image = Image.FromStream(memoryStream);
            //    }
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            


            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            string email = textBox3.Text;
            string pass = textBox4.Text;
            string contact = textBox5.Text;
            string address = textBox6.Text;

            
            Connection.Update_emp_own_Details(id, name, email, pass, contact, address);
            MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    pictureBox1.ImageLocation = image_location;
                }

                byte[] images = null;
                FileStream streem = new FileStream(image_location, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(streem);
                images = br.ReadBytes((int)streem.Length);
                int id = int.Parse(textBox1.Text);

                Connection.Update_emp_pic(id, images);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
