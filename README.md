# MedicineOnlieOrder

The project is about registering different types of medicine & registering pharmacies where thy can be sold locally.

There are a few medicines, pharmacies & a admin account initially prepared for seeding in the "ApplicationDbContext".
The project can be downloaded from the "master" branch and have it's migrations runned, to build the database.
Asside from that nothing else is required.

The project is developed on ASP.Net Core version 8.

The application has an index page where all registered medicines can be seen, even without being registered.
There is an option for viewing detailed information about each medicine trought "Details" button, which the user can access without being logged in.
There's also a "Search" option which allow the user to search for a specific medicine by inputing the name of that medicine.
This action can be accessed without being logged in.

Should the user log into an account they can create new medicines, by clocking on the "Create" button, and fill in the form.
Each medicine, created by the user, have the options to be "Assined" to an existing pharmacy, and the option to be deleted.
These actions are availabe only to medicines that are olned by the user, or if the user is the Admin.
Assigning medicine to a pharmacy, or multiple pharmacies works by featuring the existing pharmacies, the user wants this medicine to be distributed to.
The user can withraw the distribution of their medicine from any pharmacy they want, by simply repeating the "Assign" operation, but this time to not feature the pharmacies they want to disinclude.

On the other hand

The application also possesses an index page where all registered pharmacies can be seen even if the user isn't logged in.
Each pharmacy has a "Details" button which provides detailed infromation about the pharmacy even if the user isn't logged in.

Should the user logg in, they can create new pharmacies by clicking on the link named "add new pharmacy", which is located at the very top, right above all listed pharmacies & bellow the navigation bar.
After fillin in the form the new pharmacy can be created.
Each pharmaciy can be deleted only by it's oln creator & the admin.
Each pharmacy shows which medicines are assined to it into it's "Details" page, which alos inlcudes a button with which each user, or the admin, can remove the assined medicines from the user's own pharmacy.
