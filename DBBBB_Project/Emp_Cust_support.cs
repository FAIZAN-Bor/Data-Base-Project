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
    public partial class Emp_Cust_support : UserControl
    {
        public Emp_Cust_support()
        {
            InitializeComponent();
        }

        private void Emp_Cust_support_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Connection.Show_Feedback_Details();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out int keyword))
            {
                dataGridView1.DataSource = Connection.search_feedback(keyword);
            }
            else
            {
                MessageBox.Show("Input ID is not INTEGER", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Connection.Show_Feedback_Details();
        }
    }
}
