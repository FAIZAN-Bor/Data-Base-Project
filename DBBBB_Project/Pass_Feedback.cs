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
    public partial class Pass_Feedback : UserControl
    {
        public Pass_Feedback()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input values from text boxes
                string emp_id = textBox1.Text.Trim();
                string feedback = textBox2.Text.Trim();
                string issues = textBox3.Text.Trim();

                // Validate input fields
                if (string.IsNullOrWhiteSpace(feedback) || string.IsNullOrWhiteSpace(issues))
                {
                    MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insert feedback details into the database
                Connection.Insert_feeback_Details(emp_id, feedback, issues);
                MessageBox.Show("Feedback details inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //string emp_id = textBox1.Text.ToString();
            //string feedback = textBox2.Text.ToString();
            //string issues = textBox3.Text.ToString();

            //Connection.Insert_feeback_Details(emp_id, feedback, issues);
        }

        private void Pass_Feedback_Load(object sender, EventArgs e)
        {
            string name = LogIN.getusername();
            int id = Connection.get_passen_id(name);
            textBox1.Text = id.ToString();
        }
    }
}
