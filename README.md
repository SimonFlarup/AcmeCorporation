# Acme Corporation
This web application has been created using Visual Studio 2019 using ASP.NET Core as part of a handout assignment.

Setting the project up is detailed at the bottom of this document.

## Assignment description
(Shortened from handout) <br>
Using Visual Studio, create an ASP.NET web application with a SQL Server for persistence. Host a git repository at github.com

Create a landing page for a fictional company called "Acme Corporation".
The webpage should include a way for people to enter a draw using a serial number. Each serial number can be used twice.
Participation requires the participant to be at least 18 years old.

No specific requirements for frameworks, tools and other dependencies. Managing dependencies must be done using NuGet and yarn or npm

## Prior to implementation
I've used the following information and tutorials from microsoft to getting started in ASP.NET:<br><br>
_Tutorial: Get started with Razor Pages in ASP.NET Core_<br>
https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-2.2&tabs=visual-studio <br>
_Get started with ASP.NET Core MVC_<br>
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-2.2&tabs=visual-studio<br>
_Introduction to Identity on ASP.NET Core_<br>
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-2.2&tabs=visual-studio<br>
_Tutorial: Create a web API with ASP.NET Core MVC_<br>
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio<br>

## Implementation
The application consists of a ASP.NET Core MVC webpage with views as Razor pages. It has three controllers, one for frontpage and privacy one for the draw CRUD and another for movie CRUD. The valid serial numbers are generated from the list of episodes from the Looney Tunes *Wile E. Coyote and the Road Runner*. The application has implemented Identity/Authentication through scaffolding and has been limited to Login, Logout and Register. The Identity pages are not implemented as MVC but through Razor Pages with PageModels. The application also includes a REST api for the creation of new draw entries using a AJAX call.

## Setting up
Make sure to download the latest .NET Core (v2.2) from https://dotnet.microsoft.com/download (Beware! If you're using Visual Studio 17 not all versions are compatiable)

.mdf and .ldf files for the SQL server database is available from my personal google drive: https://drive.google.com/open?id=1Ac8ZptcTn_La2RuOyRJQtA6kIHTSeO2p

To attach these files in Visual Studio open the Server Explorer window and press the Connect to Database icon: ![image](https://user-images.githubusercontent.com/26866680/57581195-51fd4980-74b4-11e9-9e82-2ffe75d2be88.png)<br> The Data Source should be **Microsoft SQL Server Database File**, browse for the .mdf file you downloaded above. You should now see a new database under Data Connections<br> ![image](https://user-images.githubusercontent.com/26866680/57581223-b6200d80-74b4-11e9-87b1-850f8fe18bf3.png)
<br>
Right click this new Data Connection and press Browse In SQL Server Object Explorer, expand the database folder and right click the AcmeCorporation database - Select the *properties* option<br> ![image](https://user-images.githubusercontent.com/26866680/57581263-42cacb80-74b5-11e9-9556-0e949c3e92d8.png) <br>
In your property window copy the connection string <br>
![image](https://user-images.githubusercontent.com/26866680/57581292-989f7380-74b5-11e9-99ea-a5ce19eb2861.png)<br>
This string should be inserted into the appsettings.json file at *"AcmeCorporationContext"* <br>![image](https://user-images.githubusercontent.com/26866680/57581309-d3a1a700-74b5-11e9-9f27-d47b18ffe786.png)<br>

Before building the project make sure to have node.js installed for NPM and open the Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console) and type in *Update-Package*



### Identity (login):
**Default user:** hello@acme.dk<br>
**Default password:** Acme1234!<br>
