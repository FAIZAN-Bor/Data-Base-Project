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
    public partial class Passenger : Form
    {
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public Passenger()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            LogIN login = new LogIN();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pass_Check_profile pass_Check_Profile = new Pass_Check_profile();
            AddUserControl (pass_Check_Profile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pass_Book_seats pass_Book_Seats = new Pass_Book_seats();
            AddUserControl(pass_Book_Seats);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pass_prev_reserv pass_Prev_Reserv = new Pass_prev_reserv();
            AddUserControl(pass_Prev_Reserv);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Pass_track_trainscs track_trains= new Pass_track_trainscs();
            AddUserControl(track_trains);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pass_Feedback pass_Feedback = new Pass_Feedback();
            AddUserControl(pass_Feedback);
        }

        private void Passenger_Load(object sender, EventArgs e)
        {
            Pass_Check_profile pass_Check_Profile = new Pass_Check_profile();
            AddUserControl(pass_Check_Profile);
        }
    }
}
