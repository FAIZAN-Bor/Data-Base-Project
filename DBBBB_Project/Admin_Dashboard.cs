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
    public partial class Admin_Dashboard : UserControl
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
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
    }
}
