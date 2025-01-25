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
    public partial class LogIN : Form
    {
        public static string cashierusername = "";
        public LogIN()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        static string username, rolee;

        private void button1_Click(object sender, EventArgs e)
        {
            string role = comboBox1.Text;
            username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();

            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Invalid Details");
                return;
            }
            if (comboBox1.Text == "ADMIN")
            {
                if (Connection.AuthenticateAdminPassword(username) == password)
                {
                    this.Hide();
                    Admin admin = new Admin();
                    admin.Show();
                }
                else
                {
                    MessageBox.Show(" Incorrect Details !... ");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            else if (comboBox1.Text == "EMPLOYEE")
            {
                if (Connection.AuthenticateEmployeePassword(username) == password)
                {
                    rolee = Connection.fetch_role(username);
                    
                    this.Hide();
                    Employess employess = new Employess();
                    employess.Show();

                }
                else
                {
                    MessageBox.Show(" Incorrect Details !... ");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            else if (comboBox1.Text == "PASSENGER")
            {
                if (Connection.AuthenticatePassengerPassword(username) == password)
                {
                    Hide();
                    Passenger passenger = new Passenger();
                    passenger.Show();
                }
                else
                {
                    MessageBox.Show(" Incorrect Details !... ");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Select Role");
            }
        }

        private void LogIN_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_up sign_Up = new Sign_up();
            sign_Up.Show();
        }
        public static string getusername()
        {
            return username;
        }

        public static string getrole()
        {
            return rolee;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}