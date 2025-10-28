# Driving License Management System (DVLD System)

> A comprehensive desktop application developed using **C#** and **.NET Framework** to manage all aspects of the driving license issuance process — from applicant registration to exam scheduling and license services.

---

## Table of Contents
- About the Project
- Folder Structure
- Key Features
- Technologies Used
- Prerequisites
- Setup & Installation
- Database Configuration
- Connection String Setup
- Default Login Credentials
- Contact Information
- License

---

## About the Project
This project is a full simulation of a Driving License Management System (DVLD). It was developed individually as part of my learning journey to master **Object-Oriented Programming (OOP)**, **data structures**, and **advanced database handling** in the **.NET environment**. The goal of the project is to build a robust and reliable system capable of handling all necessary procedures in traffic departments.

---

## Folder Structure
- **Presentation Layer** — Contains all user interface components (WinForms).
- **Business Layer** — Contains business logic and core application rules.
- **Data Access Layer (SLDVLD_DataAccess)** — Handles database operations and ADO.NET functionality.
- **DVLD.sln** — The main solution file. Open this file to launch the project in Visual Studio.

---

## Key Features
- **Comprehensive Management:** Manage personal profiles, users, and drivers.
- **License Services:** Full handling for local and international license requests, renewals, replacements for lost/damaged licenses, and license unblocking.
- **Examination System:** Schedule, manage, and track results for the three types of exams (vision, written, and practical).
- **User & Role Management:** Secure login system with role-based access control.
- **Interactive UI:** Clean and user-friendly interface built with Windows Forms.

---

## Technologies Used
- C#
- .NET Framework
- Windows Forms (WinForms)
- ADO.NET
- SQL Server

---

## Prerequisites
Before running the project, ensure you have:
1. **Visual Studio 2019 or later**
2. **SQL Server** and **SQL Server Management Studio (SSMS)**
3. Sufficient permissions to create databases and execute SQL scripts

---

## Setup & Installation
### Step 1: Clone the Project
```bash
git clone https://github.com/randamohammed/DVLD_Project-.git
```

### Step 2: Open the Project
- Open `DVLD.sln` in **Visual Studio**.

### Step 3: Configure the Database
Follow the instructions below to set up your local SQL Server database.

### Step 4: Configure the Connection String
Update the connection string in `clsDataAccessSettings` to match your local environment.

### Step 5: Run the Application
Click **Start** or press **F5** in Visual Studio to build and launch the application.

---

## Database Configuration (Using DVLD.sql)
1. Open **SQL Server Management Studio (SSMS)**.
2. Create a new database named **DVLD_DB**.
3. Open the script file `DVLD.sql` from the project folder.
4. Click **Execute** to run the script — it will create all tables and insert the required initial data.

> If you use a different database name, remember to update your connection string accordingly.

---

## Connection String Setup
Open the `clsDataAccessSettings` file inside the **SLDVLD_DataAccess** folder and modify it as needed.

**Example (Windows Authentication):**
```csharp
Data Source=YOUR_SQL_SERVER;Initial Catalog=DVLD_DB;Integrated Security=True;
```

**Example (SQL Server Authentication):**
```csharp
Data Source=YOUR_SQL_SERVER;Initial Catalog=DVLD_DB;User ID=sa;Password=your_password;
```

---

## Default Login Credentials
Use the following credentials to log in after running the application:
- **Username:** Msaqer77
- **Password:** 1234

> For security reasons, it’s recommended to change these credentials after first login.

---

## Contact Information
If you have any questions or feedback about the project, feel free to reach out:

**LinkedIn:** [Randa Mohammed – Profile](https://www.linkedin.com/in/randa-mohammed-sharif)  
**Email:** randamuhammad79@gmail.com

---

## License
You may add a `LICENSE` file to specify the license type (e.g., MIT, Apache 2.0) or include your preferred license text here.

---

*Developed by Randa Mohammed*

