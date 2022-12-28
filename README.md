# RannLab

There are two Projects named API and TradingApp_1. Run both the projects simultaneously. 
To the projects simultaneously:
1.	Right click on Solutions Explorer and then click on Properties at the last.
2.	Select Multiple Start up projects and select both the projects API and tradingApp_1.

 We need to make database also. I have used SQL database and uploaded the database script as well, just execute that script in SSMS to create the database.
 For API project, database name is “DeviceRegister” and for TradingApp_1 database name is “tradingApp”. Both the database scripts are provided.

 After creating database, we need to bind the database with the .Net Application. I Have used Entity framework for it.
 Copy the project location, by right clicking on project, and then click on “Open project in file explorer”. 
 Open CMD and execute the following commands:

1.	Cd [“paste project path”]
2.	Dotnet add package Microsoft.entityframeworkcore –v 6.0.0
3.	Dotnet add package Microsoft.entityframeworkcore.design –v 6.0.0
4.	Dotnet add package Microsoft.entityframeworkcore.tools –v 6.0.0
5.	Dotnet add package Microsoft.entityframeworkcore.sqlserver –v 6.0.0
6.	dotnet ef dbcontext scaffold "Data Source=.; Initial Catalog=[“database name”]; Integrated Security=SSPI;" Microsoft.EntityFrameworkcore.sqlserver -o Models
