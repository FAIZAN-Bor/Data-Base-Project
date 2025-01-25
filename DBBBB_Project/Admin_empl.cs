using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBBBB_Project
{
    public partial class Admin_empl : UserControl
    {
        public Admin_empl()
        {
            InitializeComponent();
        }

        private void Admin_empl_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Connection.Show_Emp_Details();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            string email = textBox3.Text;
            string password = textBox4.Text;
            string contact = textBox5.Text;
            string address = textBox6.Text;
            string role = comboBox1.Text;

            Connection.Insert_Emp_Details(id, name, email, password, contact, address, role);
            MessageBox.Show("Added Successfully");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
        }

        static bool IsValidEmail(string email)
        {
           string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) ||
                    string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id;
                if (!int.TryParse(textBox1.Text, out id))
                {
                    MessageBox.Show("Invalid format for ID. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string email = textBox3.Text.Trim();
                bool valid = IsValidEmail(email);
                if (!valid)
                {
                    MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string name = textBox2.Text;
                string password = textBox4.Text;
                string contact = textBox5.Text;
                string address = textBox6.Text;
                string role = comboBox1.Text;

                Connection.Insert_Emp_Details(id, name, email, password, contact, address, role);
                MessageBox.Show("Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //int id = int.Parse(textBox1.Text);
            //string name = textBox2.Text;
            //string email = textBox3.Text;

            //bool valid = IsValidEmail(email);
            //if(!valid)
            //{
            //    MessageBox.Show("Invalid Credentials");
            //    return;
            //}
            //string password = textBox4.Text;
            //string contact = textBox5.Text;
            //string address = textBox6.Text;
            //string role = textBox7.Text;

            //Connection.Insert_Emp_Details(id, name, email, password, contact, address, role);
            //MessageBox.Show("Added Successfully");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Enter the ID of the employee to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id;
                if (!int.TryParse(textBox1.Text, out id))
                {
                    MessageBox.Show("Invalid format for ID. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Connection.delete_emp_details(id);
                MessageBox.Show("Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                //textBox7.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //int id = int.Parse(textBox1.Text);
            //Connection.delete_emp_details(id);
            //MessageBox.Show("Deleted Successfully");
            //textBox1.Clear();
            //textBox2.Clear();
            //textBox3.Clear();
            //textBox4.Clear();
            //textBox5.Clear();
            //textBox6.Clear();
            //textBox7.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            //comboBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) ||
                    string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id;
                if (!int.TryParse(textBox1.Text, out id))
                {
                    MessageBox.Show("Invalid format for ID. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string email = textBox3.Text.Trim();
                bool valid = IsValidEmail(email);
                if (!valid)
                {
                    MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string name = textBox2.Text;
                string password = textBox4.Text;
                string contact = textBox5.Text;
                string address = textBox6.Text;
                string role = comboBox1.Text;

                Connection.Update_emp_Details(id, name, email, password, contact, address, role);
                MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //int id = int.Parse(textBox1.Text);
            //string name = textBox2.Text;
            //string email = textBox3.Text;

            //bool valid = IsValidEmail(email);
            //if (!valid)
            //{
            //    MessageBox.Show("Invalid Credentials");
            //    return;
            //}

            //string password = textBox4.Text;
            //string contact = textBox5.Text;
            //string address = textBox6.Text;
            //string role = textBox7.Text;

            //Connection.Update_emp_Details(id, name, email, password, contact, address, role);
            //MessageBox.Show("Updated Successfully");
        }
    }
}
