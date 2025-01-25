using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DBBBB_Project
{
    internal static class Connection
    {
        public static OracleConnection MyConnection()
        {
            string connstring = @"DATA SOURCE = localhost:1521/XE; USER ID= DB_PROJECT ;PASSWORD=1234"; 
            OracleConnection MyConnect = new OracleConnection(connstring);
            MyConnect.Open();
            return MyConnect;
        }
        public static string AuthenticateAdminPassword(string username)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT Password FROM ADMIN WHERE name = '" + username + "' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;

            string count = Convert.ToString(cmd.ExecuteScalar());
            myconnection.Close();
            return count;
        }

        public static string AuthenticateEmployeePassword(string username)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT EMP_PASSWORD FROM Employees WHERE Emp_name = :username";
            OracleCommand cmd = new OracleCommand(query, myconnection);

            // Add parameter for username
            cmd.Parameters.Add(new OracleParameter(":username", OracleDbType.Varchar2, username, ParameterDirection.Input));

            string password = cmd.ExecuteScalar() as string;

            myconnection.Close();

            return password ?? ""; // Return an empty string if password is NULL
        }

        public static string AuthenticatePassengerPassword(string username)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT Password FROM Passengers WHERE name = '" + username + "' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;

            string count = Convert.ToString(cmd.ExecuteScalar());
            myconnection.Close();
            return count;
        }


        public static int get_counts(int id)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT COUNT(*) FROM TASKS WHERE emp_id = '" + id + "' AND TASK_STATUS = 'COMPLETE' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);

            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            myconnection.Close();
            return count;
        }

        public static int get_revenue(DateTime from, DateTime to)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT SUM(TOTAL) FROM TICKETS_RESERVATION WHERE TICKET_DATE BETWEEN :fromDate AND :toDate";
            OracleCommand cmd = new OracleCommand(query, myconnection);

            cmd.Parameters.Add(new OracleParameter(":fromDate", OracleDbType.Date)).Value = from;
            cmd.Parameters.Add(new OracleParameter(":toDate", OracleDbType.Date)).Value = to;

            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;

            if (myAdapter != null)
            {
                DataTable dataTable = new DataTable();
                myAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0 && dataTable.Rows[0][0] != DBNull.Value)
                {
                    int count = Convert.ToInt32(dataTable.Rows[0][0]);
                    myconnection.Close();
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int get_passen_id(string username)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT PASSENGER_ID FROM PASSENGERS WHERE NAME = '" + username + "' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);

            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            myconnection.Close();
            return count;
        }

        public static int get_emp_id(string username)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT EMP_ID FROM EMPLOYEES WHERE emp_name = '" + username + "' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);

            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            myconnection.Close();
            return count;
        }

        public static string fetch_role(string username)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT EMP_ROLE FROM EMPLOYEES WHERE emp_name = '" + username + "' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);

            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            string ans = myTable.Rows[0][0].ToString();
            return ans;
        }

        public static DataTable Load_Admin_Data()
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT * FROM Admin";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable myTable = new DataTable();
            myTable.Load(reader);
            reader.Close();
            myconnection.Close();
            return myTable;
        }

        public static DataTable Load_Pass_Data(string username)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT * FROM Passengers where Name = '" + username + "' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataReader reader = cmd.ExecuteReader();
            DataTable myTable = new DataTable();
            myTable.Load(reader);
            reader.Close();
            myconnection.Close();
            return myTable;
        }

        public static DataTable Load_Employee_Data(string username)
        {
            OracleConnection myconnection = MyConnection();
            string query = "SELECT * FROM EMPLOYEES where EMP_Name = '" + username + "' ";
           
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter();
            oracleDataAdapter.SelectCommand = cmd;
            OracleDataReader reader = cmd.ExecuteReader();
            
            DataTable myTable = new DataTable();
            oracleDataAdapter.Fill(myTable);
            myTable.Load(reader);
            reader.Close();
            myconnection.Close();
            return myTable;
        }

        public static void Insert_Emp_Details(int id,string name , string email, string password, string contact, string address, string role)
        {
            OracleConnection myconnection = MyConnection();
            string query = "INSERT INTO Employees (emp_id, emp_name, emp_email, emp_password, emp_contact, emp_address,emp_role) VALUES ('" + id + "','" + name + "','" + email + "','" + password + "','" + contact + "','" + address + "','" + role + "')";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
            myconnection.Close();
        }

        public static void Insert_feeback_Details(string id, string feed, string issue)
        {
            OracleConnection myconnection = MyConnection();
            string query = "INSERT INTO SUPPORT (Passenger_ID, Feedback, Issues) VALUES ('" + id + "','" + feed + "','" + issue + "')";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
            myconnection.Close();
        }

        public static void Insert_Train_Details(int id, string name, string status, string arrival_time, string departure_time)
        {
            OracleConnection myconnection = MyConnection();
            string query = "INSERT INTO Trains (Train_id, Train_name, status, arrival_time, departure_time) VALUES ('" + id + "','" + name + "','" + status + "','" + arrival_time + "','" + departure_time + "')";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
            myconnection.Close();
        }
        public static void Insert_Pass_Details(int id, string email, string password, string contact,string cnic, string name, string address)
        {
            OracleConnection myconnection = MyConnection();
            string query = "INSERT INTO Passengers (name, passenger_id, email, password, phone_number, cnic, address) VALUES ('" + name + "','" + id + "','" + email + "','" + password + "','" + contact + "','" + cnic + "','" + address + "')";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
            myconnection.Close();
        }

        public static void Insert_Task_Details(int emp_id, string descrip, string status)
        {
            OracleConnection myconnection = MyConnection();
            string query = "INSERT INTO Tasks (EMP_ID, TASK_DESCRIPTION, TASK_STATUS) VALUES ('" + emp_id + "','" + descrip + "','" + status + "')";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
            myconnection.Close();
        }


        public static void Insert_reservation_Details(int pass, int total, DateTime dtime)
        {
            OracleConnection myconnection = MyConnection();
            string query = "INSERT INTO TICKETS_RESERVATION (Passenger_ID, Total,Ticket_date) VALUES ('" + pass + "','" + total + "',:dtime)";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.Parameters.Add("dtime", OracleDbType.Date).Value = dtime;

            cmd.ExecuteNonQuery();
            myconnection.Close();
        }


        public static void UpdateAdminDetails(int id, string name, string email, string password, string contact, string address)
        {
            OracleConnection myconnection = MyConnection();
            string query = "UPDATE Admin SET Name = :name, Email = :email, Password = :password, Contact = :contact, Address = :address WHERE id = :id";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.BindByName = true; // Set BindByName to true

            cmd.Parameters.Add(new OracleParameter(":name", OracleDbType.Varchar2, name, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":email", OracleDbType.Varchar2, email, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":password", OracleDbType.Varchar2, password, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":contact", OracleDbType.Varchar2, contact, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":address", OracleDbType.Varchar2, address, ParameterDirection.Input));
          //  cmd.Parameters.Add(new OracleParameter(":imagee", OracleDbType.Blob, imagee, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32, id, ParameterDirection.Input));

            cmd.ExecuteNonQuery();
            myconnection.Close();
        }

        public static void Update_Admin_Pic(int id, byte[] imagee)
        {
            OracleConnection myconnection = MyConnection();
            string query = "UPDATE Admin SET PICTURE = :imagee WHERE id = :id";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.BindByName = true; // Set BindByName to true

            cmd.Parameters.Add(new OracleParameter(":imagee", OracleDbType.Blob, imagee, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32, id, ParameterDirection.Input));

            cmd.ExecuteNonQuery();
            myconnection.Close();
        }

        public static void Update_emp_Details(int id, string name, string email, string password, string contact, string address, string role)
        {
            OracleConnection myconnection = MyConnection();
            string query = "UPDATE EMPLOYEES SET EMP_Name = '" + name + "' ,EMP_Email = '" + email + "',EMP_Password = '" + password + "',EMP_Contact = '" + contact + "', EMP_Address = '" + address + "', EMP_ROLE = '"+ role +"' WHERE EMP_id = " + id;
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
            myconnection.Close();
        }

        public static void Update_emp_own_Details(int id, string name, string email, string password, string contact, string address)
        {
            OracleConnection myconnection = MyConnection();
            string query = "UPDATE EMPLOYEES SET EMP_Name = :name, EMP_Email = :email, EMP_Password = :password, EMP_Contact = :contact, EMP_Address = :address WHERE EMP_id = :id";
            OracleCommand cmd = new OracleCommand(query, myconnection);

            // Add parameters with explicit types
            cmd.Parameters.Add(new OracleParameter(":name", OracleDbType.Varchar2, name, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":email", OracleDbType.Varchar2, email, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":password", OracleDbType.Varchar2, password, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":contact", OracleDbType.Varchar2, contact, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":address", OracleDbType.Varchar2, address, ParameterDirection.Input));
           // cmd.Parameters.Add(new OracleParameter(":imaage", OracleDbType.Blob, imaage, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32, id, ParameterDirection.Input));

            cmd.ExecuteNonQuery();
            myconnection.Close();
        }

        public static void Update_emp_pic(int id, byte[] imaage)
        {
            OracleConnection myconnection = MyConnection();
            string query = "UPDATE EMPLOYEES SET EMP_PIC = :imaage WHERE EMP_id = :id";
            OracleCommand cmd = new OracleCommand(query, myconnection);

            // Add parameters with explicit types
            cmd.Parameters.Add(new OracleParameter(":imaage", OracleDbType.Blob, imaage, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter(":id", OracleDbType.Int32, id, ParameterDirection.Input));

            cmd.ExecuteNonQuery();
            myconnection.Close();
        }


        //public static void Update_emp_own_Details(int id, string name, string email, string password, string contact, string address, byte[] imaage)
        //{
        //    OracleConnection myconnection = MyConnection();
        //    string query = "UPDATE EMPLOYEES SET EMP_Name = '" + name + "' ,EMP_Email = '" + email + "',EMP_Password = '" + password + "',EMP_Contact = '" + contact + "', EMP_Address = '" + address + "', EMP_PIC = :imaage WHERE EMP_id = " + id;
        //    OracleCommand cmd = new OracleCommand(query, myconnection);
        //    cmd.ExecuteNonQuery();
        //    myconnection.Close();
        //}

        public static void Update_train_Details(int id, string name, string status, string arrival_time, string departure_time)
        {
            OracleConnection myconnection = MyConnection();
            string query = "UPDATE Trains SET Train_Name = '" + name + "',status = '" + status + "',Arrival_time = '" + arrival_time + "', Departure_time = '" + departure_time + "' WHERE train_id = '"+id+"' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
            myconnection.Close();
        }

        public static void Update_task_role(int task_id, int id, string role)
        {
            OracleConnection myconnection = MyConnection();
            string query = "UPDATE TASKS SET TASK_STATUS = '" + role + "' WHERE EMP_ID = '" + id + "' AND TASK_ID = '" + task_id + "'";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
            myconnection.Close();
        }


        public static void delete_task_details(int id)
        {
            OracleConnection myconnection = MyConnection();
            string query = "DELETE from Tasks WHERE TASK_ID = " + id + "";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
        }

        public static void delete_emp_details(int id)
        {
            OracleConnection myconnection = MyConnection();
            string query = "DELETE from Employees WHERE Emp_ID = " + id + "";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
        }

        public static void delete_train_details(int id)
        {
            OracleConnection myconnection = MyConnection();
            string query = "DELETE from Trains WHERE Train_ID = " + id + "";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            cmd.ExecuteNonQuery();
        }

        public static DataTable Show_Emp_Details()
        {
            OracleConnection myconnection = MyConnection();
            string query = "Select EMP_ID,EMP_NAME,EMP_EMAIL, EMP_PASSWORD,EMP_CONTACT,EMP_ADDRESS,EMP_ROLE from Employees";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            return myTable;
        }


        public static DataTable Show_Tickets_Details()
        {
            OracleConnection myconnection = MyConnection();
            string query = "Select * from Tickets";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            return myTable;
        }

        public static DataTable Show_Feedback_Details()
        {
            OracleConnection myconnection = MyConnection();
            string query = "Select * from Support";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            return myTable;
        }


        public static DataTable Show_train_Details()
        {
            OracleConnection myconnection = MyConnection();
            string query = "Select * from trains";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            return myTable;
        }

        public static DataTable search_feedback(int id)
        {
            OracleConnection myconnection = MyConnection();
            string query = "Select * FROM SUPPORT WHERE PASSENGER_ID = '"+id+"' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            return myTable;
        }

        public static DataTable search_tasks(int id)
        {
            OracleConnection myconnection = MyConnection();
            string query = "Select * FROM TASKS WHERE EMP_ID = '" + id + "' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            return myTable;
        }

        public static DataTable search_trains(int id)
        {
            OracleConnection myconnection = MyConnection();
            string query = "Select * FROM Trains WHERE TRAIN_ID = '" + id + "' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            return myTable;
        }


        public static DataTable search_ticket_reservation(int id)
        {
            OracleConnection myconnection = MyConnection();
            string query = "Select * FROM Tickets_Reservation WHERE PASSENGER_ID = '" + id + "' ";
            OracleCommand cmd = new OracleCommand(query, myconnection);
            OracleDataAdapter myAdapter = new OracleDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable myTable = new DataTable();
            myAdapter.Fill(myTable);
            return myTable;
        }

    }
}