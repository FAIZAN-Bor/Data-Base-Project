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
    public partial class Pass_Book_seats : UserControl
    {
        public Pass_Book_seats()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Pass_Book_seats_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Connection.Show_Tickets_Details();
            string name = LogIN.getusername();
            int id = Connection.get_passen_id(name);
            textBox2.Text = id.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse quantity
                int quantity = int.Parse(textBox3.Text);

                // Get the selected class
                string classi = comboBox1.Text;

                // Validate the selected class
                if (string.IsNullOrWhiteSpace(classi))
                {
                    MessageBox.Show("Please select a class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculate total based on class
                int total = 0;
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
                    MessageBox.Show("Invalid class selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Display total
                textBox4.Text = total.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //int quantity = int.Parse(textBox3.Text);
            //string classi = comboBox1.Text;
            //int total = 0;


            //if(classi == "Economy Class")
            //{
            //    total = quantity * 1500;
            //    textBox4.Text = total.ToString();
            //}
            //else if(classi == "Business Class")
            //{
            //    total = quantity * 2000;
            //    textBox4.Text = total.ToString();
            //}
            //else if(classi == "First Class")
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


            //DateTime dtime = dateTimePicker1.Value;
            //int res_id = int.Parse(textBox1.Text);
            //int pass_id = int .Parse(textBox2.Text);
            //int total = int .Parse(textBox4.Text);
            //Connection.Insert_reservation_Details(res_id, pass_id, total, dtime);
            //MessageBox.Show("Added Succesfully");
        }
    }
}
