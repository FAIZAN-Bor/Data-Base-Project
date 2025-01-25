using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBBBB_Project
{
    public partial class Pass_Check_profile : UserControl
    {
        public Pass_Check_profile()
        {
            InitializeComponent();
        }

        private void Pass_Check_profile_Load(object sender, EventArgs e)
        {
            string username = LogIN.getusername();
            DataTable a = Connection.Load_Pass_Data(username);
            textBox1.Text = a.Rows[0][5].ToString();
            textBox2.Text = a.Rows[0][0].ToString();
            textBox3.Text = a.Rows[0][1].ToString();
            textBox4.Text = a.Rows[0][2].ToString();
            textBox5.Text = a.Rows[0][4].ToString();
            textBox6.Text = a.Rows[0][3].ToString();
        }
    }
}
