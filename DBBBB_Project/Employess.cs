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
    public partial class Employess : Form
    {
        public Employess()
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
        private void button9_Click(object sender, EventArgs e)
        {
            LogIN login = new LogIN();
            login.Show();
            this.Hide();
        }

        private void Employess_Load(object sender, EventArgs e)
        {
            Emp_checck_profile emp_Checck_Profile = new Emp_checck_profile();
            AddUserControl(emp_Checck_Profile);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Emp_checck_profile emp_Checck_Profile = new Emp_checck_profile();
            AddUserControl(emp_Checck_Profile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Emp_salary emp_Salary = new Emp_salary();
            AddUserControl(emp_Salary);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Emp_to_do_task emp_To_Do_Task = new Emp_to_do_task();
            AddUserControl(emp_To_Do_Task);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (LogIN.getrole() == "DRIVER" || LogIN.getrole() == "CASHIER")
            {
                MessageBox.Show("Access Denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Emp_Cust_support emp_Cust_Support = new Emp_Cust_support();
            AddUserControl(emp_Cust_Support);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (LogIN.getrole() == "DRIVER" || LogIN.getrole() == "CUSTOMER SUPPORT")
            {
                MessageBox.Show("Access Denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Emp_sell_ticket emp_Sell_Ticket = new Emp_sell_ticket();
            AddUserControl(emp_Sell_Ticket);

        }
    }
}