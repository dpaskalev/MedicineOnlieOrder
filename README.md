# MedicineOnlieOrder

The project is about registering different types of medicine & registering pharmacies where they can be sold locally.

There are a few medicines, pharmacies & a admin account initially prepared for seeding in the "ApplicationDbContext".
The project can be downloaded from the "master" branch and have it's migrations runned, to build the database.
Asside from that, nothing else is required.

The project is developed on ASP.Net Core version 8.

The application has an index page where all registered medicines can be seen, even without being registered.
There is an option for viewing detailed information about each medicine trough "Details" button, which the user can access without being logged in.
There's also a "Search" option which allow the user to search for a specific medicine by inputing the name of that medicine.
This action can be accessed without being logged in.

Should the user log into an account they can create new medicines, by clocking on the "Create" button, and fill in the form.
Each medicine, created by the user, have the options to be "Assined" to an existing pharmacy, and the option to be deleted.
These actions are availabe only to medicines that are owned by the user, or if the user is the Admin.
Assigning medicine to a pharmacy, or multiple pharmacies works by featuring the existing pharmacies, the user wants this medicine to be distributed to.
The user can withraw the distribution of their medicine from any pharmacy they want, by simply repeating the "Assign" operation, but this time to not feature the pharmacies they want to disinclude.

On the other hand

The application also possesses an index page where all registered pharmacies can be seen even if the user isn't logged in.
Each pharmacy has a "Details" button which provides detailed infromation about the pharmacy even if the user isn't logged in.

Should the user logg in, they can create new pharmacies by clicking on the button "add new pharmacy", which is located at the very top, right above all listed pharmacies & bellow the navigation bar.
After fillin in the form the new pharmacy can be created.
Each pharmaciy can be deleted only by it's own creator & the admin.
Each pharmacy shows which medicines are assined to it into it's "Details" page, which alos inlcudes a button with which each user, or the admin, can remove the assined medicines from the user's own pharmacy.
If the user does not own the current pharmacy, they can not remove the featured medicines trought the "Details" page of the pharmacy.

There is "Delete" option for Medicine & Pharmacies, provided only to the owner of the MEicine/Pharmacy & the admin.
There is a "Comfirm delete" page, uppon attemting to delete an item.
Pressing "Cansel" on the "Confirm delete" page will redirect the user to the "Details" page of the item.

Each logged in user can buy the medicine they do not own, by clicking on the button labeled "buy", which will add this medicine to the user's cart.
The user can access their cart trought the navigation bar. Once there they can remove medicines from their cart by pressing the "remove" button.

The application is separated on 4 layers:
the presentation layer: where the controllers & views are located.
the service layer: where the services are located.
the data layer: where the data models & the appicationContext are located.
The test layer: where all the tests are located.

The imputed data from the user to the application is being validated both, at the client side & server side of the application - inside the services.

There are also written tests for the services of the application, located into the "Tests" layer of the application.

There are partial views for severaw of the pages.
There are sections providing details about the page itself (usually where the buttons are located).

There are alos creadted custom Errors for "404 not found" & "400 bad request"

The application has several NuGet packages installed:
Microsoft.AspNetCore.Diagnostics.EntityFramew
Microsoft.AspNetCore.Identity.EntityFrame
Microsoft.AspNetCore.Identity.UI
Microsoft.EntityFrameworkCore.InMemory
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.Extensions.DependencyInjection.Abstr
Microsoft.NET.Test.Sdk
Microsoft.VisualStudio.Web.CodeGeneration.Design
Newtonsoft.Json
NUnit
NUnit.Analyzers
NUnit3TestAdapter
Microsoft.Extensions.DependencyInjection.Abstraction
etc.
