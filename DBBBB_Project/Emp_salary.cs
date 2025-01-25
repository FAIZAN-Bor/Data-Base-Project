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
    public partial class Emp_salary : UserControl
    {
        public Emp_salary()
        {
            InitializeComponent();
        }

        private void Emp_salary_Load(object sender, EventArgs e)
        {
            textBox1.Text = LogIN.getusername();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the username
                string name = LogIN.getusername();

                // Get the employee ID
                int ids = Connection.get_emp_id(name);

                // Get the counts
                int counts = Connection.get_counts(ids);

                // Calculate the base salary
                float sal = counts * 5000;
                textBox2.Text = sal.ToString();

                // Check if the employee has worked at least once
                if (counts >= 1)
                {
                    // Initialize bonus
                    float bonus = 0;

                    // Determine bonus based on role
                    if (LogIN.getrole() == "DRIVER")
                    {
                        bonus = 3000;
                    }
                    else if (LogIN.getrole() == "CASHIER")
                    {
                        bonus = 7000;
                    }
                    else
                    {
                        bonus = 5000;
                    }

                    // Display bonus
                    textBox3.Text = bonus.ToString();

                    // Calculate total salary
                    sal += bonus;
                    textBox4.Text = sal.ToString();
                }

            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //string name = LogIN.getusername();
            //int ids = Connection.get_emp_id(name);
            //int counts = Connection.get_counts(ids);

            //float sal = counts * 5000;
            //textBox2.Text = sal.ToString();

            //if (counts >= 1)
            //{
            //    float bonus = 0;
            //    if (LogIN.getrole() == "DRIVER")
            //    {
            //        bonus = 3000;
            //    }
            //    else if (LogIN.getrole() == "CASHIER")
            //    {
            //        bonus = 7000;
            //    }
            //    else
            //    {
            //        bonus = 5000;
            //    }

            //    textBox3.Text = bonus.ToString();
            //    sal = sal + bonus;
            //    textBox4.Text = sal.ToString();
            //}
            //MessageBox.Show("Successfully Done");
        }
    }
}
