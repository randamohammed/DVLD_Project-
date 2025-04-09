
Driving License Management System (DVLD System)
A comprehensive desktop application developed using C# and .NET Framework to manage all aspects of the driving license issuance process, from applicant registration to exam scheduling and license services.

The first folder is for the Presentation Layer.
The second one is for the Business Layer.
The third one is for the Data Access Layer.

Then open the DVLD folder — just run the DVLD.sln file.

About the Project
This project is a full simulation of a driving license management system. It was developed individually as part of my learning journey to master Object-Oriented Programming (OOP), data structures, and advanced database handling in the .NET environment. The goal of the project is to build a robust and reliable system capable of handling all necessary procedures in traffic departments.

Key Features
Comprehensive Management: Integrated modules for managing personal profiles, users, and drivers.

License Services: Full processing for local and international license requests, including renewal, replacement for lost/damaged licenses, and license unblocking.

Examination System: Scheduling, managing, and tracking results for the three types of exams (vision, written, and practical).

User and Role Management: Secure login system with role-based access control for users.

Interactive UI: A clean and user-friendly interface built using Windows Forms.

Technologies Used
C#

.NET Framework

Windows Forms (WinForms)

ADO.NET

SQL Server

How to Run the Project
To run a local copy of the project on your machine, follow the steps below:

Prerequisites
Visual Studio (2019 or later recommended)

SQL Server and SQL Server Management Studio (SSMS)

Setup Steps
Clone the Project


git clone https://github.com/randamohammed/DVLD_Project-.git
Set Up the Database (Using DVLD.sql File)

Open SQL Server Management Studio (SSMS).

Create a new empty database named DVLD_DB.

Open the script file DVLD.sql (or the name you've given it) from the project folder in SSMS.

Click Execute to run the script. This will create all tables and insert the required initial data.

Configure the Connection String

Open the project in Visual Studio.

Locate the file clsDataAccessSettings in the SLDVLD_DataAccess folder.

Update the connectionString line to match your local SQL Server configuration:


public static string ConntaionString = "Server=.;Database=DVLD;User Id=your_id;Password=your_password;";
Run the Application

Click the Start button in Visual Studio to build and run the application.

Login Credentials
To log in after launching the application, use the default user credentials:

Username: Msaqer77

Password: 1234

Contact Me
If you have any questions or feedback about the project, feel free to reach out on LinkedIn:

Randa Mohammed – My LinkedIn Profile
www.linkedin.com/in/randa-mohammed-52607b344