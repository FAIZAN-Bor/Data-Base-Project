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
    public partial class Pass_track_trainscs : UserControl
    {
        public Pass_track_trainscs()
        {
            InitializeComponent();
        }

        private void Pass_track_trainscs_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Connection.Show_train_Details();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int keyword))
            {
                dataGridView1.DataSource = Connection.search_trains(keyword);
            }
            else
            {
                MessageBox.Show("Input ID is not INTEGER", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Connection.Show_train_Details();
        }
    }
}
