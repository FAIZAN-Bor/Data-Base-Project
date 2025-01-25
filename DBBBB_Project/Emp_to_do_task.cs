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
    public partial class Emp_to_do_task : UserControl
    {
        public Emp_to_do_task()
        {
            InitializeComponent();
        }

        private void Emp_to_do_task_Load(object sender, EventArgs e)
        {
            int id = Connection.get_emp_id(LogIN.getusername());
            
            string name = LogIN.getusername();

            textBox1.Text = id.ToString();
            textBox2.Text = name.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the employee ID using the username from the login information
                int id = Connection.get_emp_id(LogIN.getusername());

                // Set the employee ID and username to text boxes
                textBox1.Text = id.ToString();
                textBox2.Text = LogIN.getusername();

                // Populate DataGridView with tasks associated with the employee ID
                dataGridView1.DataSource = Connection.search_tasks(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Please enter the Task ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parse the task ID from textBox1
                if (!int.TryParse(textBox3.Text, out int task_id))
                {
                    MessageBox.Show("Invalid Task ID format. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the employee ID associated with the current username
                int id = Connection.get_emp_id(LogIN.getusername());

                // Get the selected task from comboBox1
                string taskk = comboBox1.Text;


                
                // Check if a task role is selected
                if (string.IsNullOrWhiteSpace(taskk))
                {
                    MessageBox.Show("Please select a task role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the task role
                Connection.Update_task_role(task_id, id, taskk);

                MessageBox.Show("Task Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //int task_id = int.Parse(textBox1.Text);
            //int id = Connection.get_emp_id(LogIN.getusername());
            //string taskk = comboBox1.Text;
            //Connection.Update_task_role(task_id, id, taskk);
            //MessageBox.Show("Task Updated");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
