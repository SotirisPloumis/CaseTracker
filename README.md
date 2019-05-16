# CaseTracker

This is the group project for the AfDEmp Coding Bootcamp 7 in C# and ASP.NET (Feb. to May 2019)  

To install:
1. Create a .env file in the solution folder in the following format:

	AdminEmail = "your-admin-email"  
	AdminPass = "your-admin-password"  

and fill in the email and password for the admin account. This will be used by the Seed method 
after the migrations are completed

2. (Optional, only for production release) Create a Web.Release.config file in the solution folder in the following format:

	<?xml version="1.0"?>
	<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
		<connectionStrings>
		  <add
			name="DefaultConnection"
			connectionString="Data Source=<>;
							  Initial Catalog=<>;
							  User Id=<>; 
							  Password=<>" 
			providerName="System.Data.SqlClient"
			xdt:Transform="SetAttributes" 
			xdt:Locator="Match(name)"/>
		</connectionStrings>
	  <system.web>
		<compilation xdt:Transform="RemoveAttributes(debug)" />
	  </system.web>
	</configuration>

Replace:  
a) the value for "Data Source" with the url to your DB,  
b) the "initial Catalog" with the name of your DB,  
c) the "user Id" and "Password" with the credentials to your DB  

3. run "update-database" from PowerShell. This will create the database from the migration file  
to your local machine

4. (Optional, only for production release) Migrate the DB to your preferred hosting service

# CaseTracker
This project aims to facilitate the job of Process Servers, i.e. the people responsible for  
delivering the legal documents and proceedings of cases from the attornies to the recipients.  

In CaseTracker a Process Server (user) can manage his/her cases, by adding new cases, editing existing or deleting.  
The user can also do CRUD operations on parties, courts, attornies and also download case details into PDF Files.  

The whole system is translated in both English and Greek. 