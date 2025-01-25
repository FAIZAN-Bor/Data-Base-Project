using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBBBB_Project
{
    public partial class Admin_Assign_Tasks : UserControl
    {
        public Admin_Assign_Tasks()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int task_id = int.Parse(textBox1.Text);
            string descrip = textBox2.Text;
            //int emp = int.Parse(textBox3.Text);
            string status = comboBox1.Text;

            //Connection.Insert_Task_Details(emp,descrip,status);
            //MessageBox.Show("Successfully DONE");


            try
            {
                // Validate description
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please enter a description for the task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate employee ID
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Please enter an employee ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parse employee ID
                int emp;
                if (!int.TryParse(textBox3.Text, out emp))
                {
                    MessageBox.Show("Invalid employee ID. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate status
                if (string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Please select a status for the task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insert task details into the database
                Connection.Insert_Task_Details(emp, descrip, status);
                MessageBox.Show("Task details inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
