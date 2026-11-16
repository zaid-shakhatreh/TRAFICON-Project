# TRAFICON – Traffic Administration & Driving License System

A desktop application that automates traffic administration and driving license
management, built with C#, Windows Forms, and SQL Server using a 3-tier architecture.

## Features
- Local and international driving license applications
- Multi-stage driving tests
- License renewal
- Violation-based license suspension
- People and driver management
- Login system and user management

## Screenshots
| Login | Main Screen |
|-------|-------------|
| ![Login](photo%20for%20TRAFICON%20Project/Login%20screen.png) | ![Main](photo%20for%20TRAFICON%20Project/Main%20Screen.png) |

| License Application | Driver Test |
|---------------------|-------------|
| ![Application](photo%20for%20TRAFICON%20Project/License%20Application.png) | ![Driver Test](photo%20for%20TRAFICON%20Project/Driver%20test.png) |

## Architecture
The project follows a **3-tier architecture**:

- **Presentation Layer:** Windows Forms with Guna UI2 (37 screens)
- **Business Logic Layer:** classes that contain the business rules and validation
- **Data Access Layer:** ADO.NET code that communicates with SQL Server

The database has **14 tables**. Separating the layers keeps the UI independent
from the business rules and the database.

## Tech Stack
- C# / .NET Framework
- Windows Forms, Guna UI2
- Microsoft SQL Server, ADO.NET

## How to Run
1. Install Visual Studio and SQL Server.
2. Clone the repository:
   `git clone https://github.com/zaid-shakhatreh/TRAFICON-Project.git`
3. In SSMS, create an empty database named `DVLD`, then open `TRAFICON.sql` and run it to create the tables and data.
4. Open `App.config` and update the connection string with your server name (keep `Database=DVLD`).
5. Open the `.sln` file in Visual Studio and press **F5**.

Default login: `zezenio05` / `2005`

## What I Learned
- Applying OOP and 3-tier architecture in a real project
- Designing a relational database and writing data access code with ADO.NET

## Author
**Zaid Shakhatreh** – Computer Science student, Al-Balqa Applied University
[LinkedIn](https://www.linkedin.com/in/zaid-shakhatreh-177966324)
