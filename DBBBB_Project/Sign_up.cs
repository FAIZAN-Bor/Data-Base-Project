using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace DBBBB_Project
{
    public partial class Sign_up : Form
    {
        //String randomCode;
        //public static String to;

        string otp = "";

        public Sign_up()
        {
            InitializeComponent();
        }

        private void Sign_up_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }

        private string GenerateOTP()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }

        private bool SendOTP(string email, string otp)
        {
            try
            {
                string senderEmail = "faizanafzaal868@gmail.com";
                string senderPassword = "gqve cnbj yvso agjx";


                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {


                    client.Port = 587;
                    client.EnableSsl = true;


                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);


                    MailMessage message = new MailMessage(senderEmail, email);


                    message.Subject = "OTP for Railway Management System";
                    message.Body = "OTP\t:\t" + otp;


                    client.Send(message);


                    //client.Port = 587;
                    //client.EnableSsl = true;


                    //client.Credentials = new NetworkCredential(senderEmail, senderPassword);


                    //MailMessage message = new MailMessage(senderEmail, email);

                    //message.Subject = "OTP for Railway Management System\n";
                    //message.Body = "OTP == " + otp;

                    //client.Send(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending OTP: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) ||
                    string.IsNullOrEmpty(textBox2.Text) ||
                    string.IsNullOrEmpty(textBox3.Text) ||
                    string.IsNullOrEmpty(textBox4.Text) ||
                    string.IsNullOrEmpty(textBox5.Text) ||
                    string.IsNullOrEmpty(textBox6.Text) ||
                    string.IsNullOrEmpty(comboBox1.Text) ||
                    string.IsNullOrEmpty(textBox8.Text))
                {
                    MessageBox.Show("Fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(comboBox1.Text == "EMPLOYEE")
                {
                    if(string.IsNullOrEmpty(comboBox2.Text))
                    {
                        MessageBox.Show("Fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if(comboBox1.Text == "PASSENGER" )
                {
                    if(string.IsNullOrEmpty(textBox7.Text))
                    {
                        MessageBox.Show("Fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                int id;
                if (!int.TryParse(textBox1.Text, out id))
                {
                    MessageBox.Show("Invalid ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string enter_OTP = textBox8.Text.ToString();

                if(enter_OTP != otp)
                {
                    MessageBox.Show("Incorrect OTP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string email = textBox3.Text.Trim();
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               if (comboBox1.Text == "EMPLOYEE")
               {
                    Connection.Insert_Emp_Details(id, textBox2.Text, email, textBox4.Text, textBox5.Text, textBox6.Text, comboBox2.Text);
                    MessageBox.Show("Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (comboBox1.Text == "PASSENGER")
                {
                    Connection.Insert_Pass_Details(id, email, textBox4.Text, textBox5.Text, textBox7.Text, textBox2.Text, textBox6.Text);
                    MessageBox.Show("Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //int id = int.Parse(textBox1.Text);
            //string name = textBox2.Text;
            //string email= textBox3.Text;
            //bool isValidEmail = IsValidEmail(email);

            //if(!isValidEmail)
            //{
            //    MessageBox.Show("Invalid Credentials");
            //    return;
            //}
            //string password = textBox4.Text;
            //string contact = textBox5.Text;
            //string address = textBox6.Text;
            //string cnic = textBox7.Text;
            //string innerrole = comboBox2.Text;

            //if (comboBox1.Text == "EMPLOYEE")
            //{
            //     Connection.Insert_Emp_Details(id,name, email, password, contact, address, innerrole);
            //    MessageBox.Show("Added Successfully");
            //}
            //else if (comboBox1.Text == "PASSENGER")
            //{
            //    Connection.Insert_Pass_Details(id, email, password, contact,cnic, name, address);
            //    MessageBox.Show("Added Successfully");
            //}
            //else
            //{
            //    MessageBox.Show("Select Role");
            //}
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIN logIN = new LogIN();
            logIN.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "EMPLOYEE")
            {

                textBox7.Visible = false;
                label7.Visible = false;
                
                label9.Visible = true;
                comboBox2.Visible = true;

                //label7.Location = new Point(43, 312);
                //textBox7.Location = new Point(153, 312);
                //label7.Location = new Point(419, 312);
                //textBox7.Location = new Point(535, 312);

            }
            if (comboBox1.Text == "PASSENGER")
            {
                label9.Visible = false;
                comboBox2.Visible = false;

                textBox7.Visible = true;
                label7.Visible = true;
            }
            else if (comboBox1.Text == "SELECT ROLE")
            {
                textBox7.Visible = true;
                label7.Visible = true;
                label9.Visible = true;
                comboBox2.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            otp = GenerateOTP();
            bool otpSent = SendOTP(textBox3.Text, otp);

            if (!otpSent)
            {
                return;
            }
            else
            {
                MessageBox.Show("Verify OTP from your mail", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
