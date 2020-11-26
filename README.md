ContactApp

In order to run the project on your machine, follow the following steps:
1. Download the contents of this repository on your local machine.
2. In Microsoft SQL Server Management Studio, run the scripts contained in DBScripts folder.
3. In Visual Studio (2015 or later), open the EvolentApp solution.
4. Run the solution to check the port number.
5. Change the key 'ApiUrl' in EvolentApp/Web.config to use the correct port number.
6. Update the connection string named 'AppContacts' in the Web.config to point to your SQL Server instance.
7. Run the solution.
