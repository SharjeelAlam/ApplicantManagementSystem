# ApplicantManagementSystem
A web application to allow information management of job applicants. The application constitutes an ASP.NET MVC front-end and a REST API based back-end with a SQL Server database.

--------Connection Details----------
1)Entity Framework code first approach used. By default it will create database by the name "JobCandidateManagementDB" in local machine.
2)Connection string present in App.config file of project JCMS."DataModelLayer", and Web.config file of projects "JCMS.RestAPI" and "JCMS.Web.MVC" respectively.
3)REST API url is being read from the Web.config of "JCMS.Web.MVC". The property name is "RestApiURL".

--------Run Guidelines---------------
1) Open the solution "JobCandidateManagementSystem".
2) Modify the database connection string in the config files appropriately.
3) Set the project "JCMS.RestAPI" as the start up project.
4) Run the project.
5) Copy the URL of from the opened browser window.
5) Open the solution "JobCandidateManagementSystem.Web.UI".
6) Replace the RestApiURL value with the copied URL in the Web.config file.
7) Run the project and use the UI to perform actions.  
