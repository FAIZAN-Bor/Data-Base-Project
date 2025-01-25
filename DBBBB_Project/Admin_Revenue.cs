using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBBBB_Project
{
    public partial class Admin_Revenue : UserControl
    {
        public Admin_Revenue()
        {
            InitializeComponent();
        }

        private void Admin_Revenue_Load(object sender, EventArgs e)
        {

        }

        private DateTime from, to;
        private int sum;
        private void button1_Click(object sender, EventArgs e)
        {
             from = dateTimePicker1.Value;
             to = dateTimePicker2.Value;

            sum = Connection.get_revenue(from, to);
            if(string.IsNullOrEmpty(sum.ToString()))
            {
                MessageBox.Show("Revenue Not Found !!");
                return;
            }
            textBox2.Text = sum.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Calculate Revenue First !!!");
                }
                else
                {
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Generating PDF" + ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Railway Management System", new Font("Showcard Gothic", 30, FontStyle.Bold), Brushes.Red, new Point(100, 20));
            e.Graphics.DrawString("Revenue", new Font("Arial", 25, FontStyle.Bold), Brushes.Black, new Point(340, 80));
            e.Graphics.DrawString("\n\nFrom \t:\t" + "    " + from + " ", new Font("Cambria", 18, FontStyle.Regular), Brushes.Black, new Point(20, 120));
            e.Graphics.DrawString("To \t:\t" + "    " + to + " ", new Font("Cambria", 18, FontStyle.Regular), Brushes.Black, new Point(20, 220));
            e.Graphics.DrawString("Total \t:\t" + "    " + sum + " ", new Font("Cambria", 18, FontStyle.Regular), Brushes.Black, new Point(20, 300));
            
            int yPos = 540;


           // e.Graphics.DrawString("\n<=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=>", new Font("Cambria", 12, FontStyle.Regular), Brushes.Black, new Point(0, yPos));

            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Cambria", 12, FontStyle.Regular), Brushes.Black, new Point(0, yPos));
            e.Graphics.DrawString("Anonymous Developers", new Font("Cambria", 25, FontStyle.Bold), Brushes.Goldenrod, new Point(100, 1050));
            e.Graphics.DrawString("+923011206519", new Font("Cambria", 23, FontStyle.Bold), Brushes.Goldenrod, new Point(500, 1050));
        }
    }
}
