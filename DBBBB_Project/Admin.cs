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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Admin_profile chk_prof = new Admin_profile();
            AddUserControl(chk_prof);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_profile chk_prof = new Admin_profile();
            AddUserControl (chk_prof);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LogIN login = new LogIN();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Admin_empl emp = new Admin_empl();
            AddUserControl(emp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_trains ad_train = new Admin_trains();
            AddUserControl(ad_train);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Revenue admin_Revenue = new Admin_Revenue();
            AddUserControl(admin_Revenue);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Admin_Assign_Tasks admin_Assign_Tasks = new Admin_Assign_Tasks();
            AddUserControl(admin_Assign_Tasks);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin_Feedback admin = new Admin_Feedback();
            AddUserControl (admin);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Admin_Assign_Tasks admin_Assign_Tasks = new Admin_Assign_Tasks();
            AddUserControl(admin_Assign_Tasks);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            LogIN login = new LogIN();
            login.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Admin_Dashboard admin_Dashboard = new Admin_Dashboard();
            AddUserControl(admin_Dashboard);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin_profile chk_prof = new Admin_profile();
            AddUserControl(chk_prof);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Admin_empl admin_Empl = new Admin_empl();
            AddUserControl(admin_Empl);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Admin_trains admin_Trains = new Admin_trains();
            AddUserControl(admin_Trains);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Admin_Revenue admin_Revenue = new Admin_Revenue();
            AddUserControl(admin_Revenue);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Admin_Feedback admin_Feedback = new Admin_Feedback();
            AddUserControl(admin_Feedback);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Admin_Dashboard admin_Dashboard = new Admin_Dashboard();
            AddUserControl(admin_Dashboard);
        }
    }
}