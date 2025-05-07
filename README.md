# Train Management System

This project is a Train Management System developed using C# and Oracle database. It provides functionalities for administrators, employees, and passengers to manage and interact with the train system.

## Features

* **Admin Dashboard**: Admins can manage employees, trains, tasks, and view feedback and revenue.
* **Employee Dashboard**: Employees can view their profile, tasks, salary, and handle customer support and ticket sales.
* **Passenger Dashboard**: Passengers can view their profile, book seats, track trains, and provide feedback.

## Project Structure

* `DBBBB_Project.sln`: The main solution file for the project.
* `DBBBB_Project/`: Contains all the source code and resources for the project.
  * `DBBBB_Project/Admin_Assign_Tasks.cs`: Code for assigning tasks to employees.
  * `DBBBB_Project/Admin_Dashboard.cs`: Code for the admin dashboard.
  * `DBBBB_Project/Admin_empl.cs`: Code for managing employees.
  * `DBBBB_Project/Admin_Feedback.cs`: Code for handling feedback.
  * `DBBBB_Project/Admin_profile.cs`: Code for admin profile management.
  * `DBBBB_Project/Admin_Revenue.cs`: Code for viewing revenue.
  * `DBBBB_Project/Admin_trains.cs`: Code for managing trains.
  * `DBBBB_Project/Admin.cs`: Main admin form.
  * `DBBBB_Project/Connection.cs`: Contains database connection and query methods.
  * `DBBBB_Project/Employess.cs`: Main employee form.
  * `DBBBB_Project/Emp_checck_profile.cs`: Code for employee profile management.
  * `DBBBB_Project/Emp_Cust_support.cs`: Code for customer support.
  * `DBBBB_Project/Emp_salary.cs`: Code for viewing employee salary.
  * `DBBBB_Project/Emp_sell_ticket.cs`: Code for selling tickets.
  * `DBBBB_Project/Emp_to_do_task.cs`: Code for managing employee tasks.
  * `DBBBB_Project/LogIN.cs`: Code for login functionality.
  * `DBBBB_Project/Passenger.cs`: Main passenger form.
  * `DBBBB_Project/Pass_Book_seats.cs`: Code for booking seats.
  * `DBBBB_Project/Pass_Check_profile.cs`: Code for passenger profile management.
  * `DBBBB_Project/Pass_Feedback.cs`: Code for providing feedback.
  * `DBBBB_Project/Pass_prev_reserv.cs`: Code for viewing previous reservations.
  * `DBBBB_Project/Pass_track_trainscs.cs`: Code for tracking trains.
  * `DBBBB_Project/Sign_up.cs`: Code for user sign-up functionality.
  * `DBBBB_Project/Splash.cs`: Code for splash screen.

## Database

The project uses Oracle database for storing and managing data. The connection string and database queries are defined in `DBBBB_Project/Connection.cs`.

## Dependencies

The project uses the following NuGet packages:
* EntityFramework 6.0.0
* Guna.UI2.WinForms 2.0.4.6
* Microsoft.Bcl.AsyncInterfaces 6.0.0
* Oracle.ManagedDataAccess 21.14.0
* Oracle.ManagedDataAccess.EntityFramework 21.9.0
* System.Buffers 4.5.1
* System.Formats.Asn1 8.0.0
* System.Memory 4.5.5
* System.Numerics.Vectors 4.5.0
* System.Runtime.CompilerServices.Unsafe 6.0.0
* System.Text.Encodings.Web 6.0.0
* System.Text.Json 6.0.1
* System.Threading.Tasks.Extensions 4.5.4
* System.ValueTuple 4.5.0

## Setup

1. Clone the repository.
2. Open the solution file `DBBBB_Project.sln` in Visual Studio.
3. Restore NuGet packages.
4. Update the connection string in `DBBBB_Project/Connection.cs` with your Oracle database credentials.
5. Build and run the project.

## Usage

* **Admin**: Login as admin to manage employees, trains, tasks, and view feedback and revenue.
* **Employee**: Login as employee to view profile, tasks, salary, and handle customer support and ticket sales.
* **Passenger**: Login as passenger to view profile, book seats, track trains, and provide feedback.

## Contributing

Contributions are welcome!

## License

This project is licensed under the MIT License.
