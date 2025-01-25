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
    public partial class Emp_sell_ticket : UserControl
    {
        public Emp_sell_ticket()
        {
            InitializeComponent();
        }

        private void Emp_sell_ticket_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Connection.Show_Tickets_Details();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if quantity is provided
                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Please enter the quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parse quantity
                int quantity;
                if (!int.TryParse(textBox3.Text, out quantity))
                {
                    MessageBox.Show("Invalid quantity. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string classi = comboBox1.Text;
                int total = 0;

                // Calculate total based on class
                if (classi == "Economy Class")
                {
                    total = quantity * 1500;
                }
                else if (classi == "Business Class")
                {
                    total = quantity * 2000;
                }
                else if (classi == "First Class")
                {
                    total = quantity * 5000;
                }
                else
                {
                    // Handle invalid class selection
                    MessageBox.Show("Please select a valid class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Display total
                textBox4.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //int quantity = int.Parse(textBox3.Text);
            //string classi = comboBox1.Text;
            //int total = 0;


            //if (classi == "Economy Class")
            //{
            //    total = quantity * 1500;
            //    textBox4.Text = total.ToString();
            //}
            //else if (classi == "Business Class")
            //{
            //    total = quantity * 2000;
            //    textBox4.Text = total.ToString();
            //}
            //else if (classi == "First Class")
            //{
            //    total = quantity * 5000;
            //    textBox4.Text = total.ToString();
            //}
            //else
            //{

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtime = dateTimePicker1.Value;
                int pass_id = int.Parse(textBox2.Text);
                int total = int.Parse(textBox4.Text);

                // Assuming Connection.Insert_reservation_Details() method throws exceptions
                Connection.Insert_reservation_Details(pass_id, total, dtime);

                MessageBox.Show("Added Successfully");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values in the text boxes.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
