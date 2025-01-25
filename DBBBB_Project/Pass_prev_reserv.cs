using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBBBB_Project
{
    public partial class Pass_prev_reserv : UserControl
    {
        public Pass_prev_reserv()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox3.Text);
                dataGridView1.DataSource = Connection.search_ticket_reservation(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // dataGridView1.DataSource = Connection.search_ticket_reservation(id);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pass_prev_reserv_Load(object sender, EventArgs e)
        {
            string name = LogIN.getusername();
            int id = Connection.get_passen_id(name);
            textBox3.Text = id.ToString();
        }
    }
}