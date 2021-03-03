# Avantica
challenge forRoofstock
If you will run the net core solution in krestel you will use the port 5001
If you will run the net core solution in IIS you will use the port 44317

In the angular project open the file
#shared.service.ts
You must change the value variable
readonly APIUrl ="https://localhost:5001";
for Krestel 
5001
for IIS
44317

#DataBase
You can create the database running the queries in the TestFullStack solution into "migration" folder
	- Open the nuget package console
	- Run UPDATE-DATABASE
	- To validate open the SQL Server Object Panel to check if the DB was created successfuly
	- If the command throws an exception review the #Notes section, you must install EntityFramework packages.
	
Review the "appsettings.json" file to validate the "PropertyDBConnection" value 

#Notes
Packages used:
Newtonsoft.Json
Swashbuckle.AspNetCore
Swashbuckle.AspNetCore.Swagger
Swashbuckle.AspNetCore.SwaggerGen
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.SqlServer

#UI
code .
ng serve --open