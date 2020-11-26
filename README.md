ContactApp

The solution consists of a single project called EvolentApp; the folder structure is briefly described as follows:
1. The AppStart folder contains the web API congofuration details, including routing.
2. Models class contains the data models that correspond directly to the DB schema.
3. DataAccessLayer contains classes for direct DB access. 
4. ViewModels class contains the business models that correspond to the model that acts as a base for the presentation layer i.e. the views.
5. BusinessAccessLayer contains the logic for mapping the data model to the view model. This layer will contain all business logic.
6. Controllers folder contains the web API controller(EvolentApp/Controllers/api/) and the MVC controller(EvolentApp/Controllers/) which consumes the Web API.
7. Views folder contain the various views that form part of the MVC presentation layer.
8. The DIResolver folder contains the NInject classes for dependency injection.

In order to run the project on your machine, follow the following steps:
1. Download the contents of this repository on your local machine.
2. In Microsoft SQL Server Management Studio, run the scripts contained in DBScripts folder.
3. In Visual Studio (2015 or later), open the EvolentApp solution.
4. Run the solution to check the port number.
5. Change the key 'ApiUrl' in EvolentApp/Web.config to use the correct port number.
6. Update the connection string named 'AppContacts' in the Web.config to point to your SQL Server instance.
7. Run the solution.
