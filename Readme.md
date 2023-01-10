## Time Management Application WPF

<br>

***

_Author: Daniel Pienaar_

***

This is the desktop wpf version of the project found here:
https://github.com/danielpienaar/TimeManagementWebAppMVC

^^ The updated web app version

<br>

### How to run the program:

<br>

NOTE: All data is configured to be stored in an sql relational database. If you would like to run this program on your machine, please connect a database to the application and change the connection string value in settings.settings in the properties folder (also check if it gets updated properly in settings.designer.cs). You can recreate the necessary tables using the TablesBackup sql file.

<br>

* Open Visual Studio. Make sure you have .NET version 5 installed as this program uses that version. In the program folder, there are 2 project folders, one containing the application, and the other for the class library. Open the file named "TimeManagementApp.sln" in the TimeManagementApp folder to see the application in the IDE. Alternatively, you could go to TimeManagementApp\bin\Debug\net5.0-windows and run the exe directly, if you would prefer to not open visual studio.
* Click the "Start Without Debugging" button at the top of the editor, or alternatively press ctrl+f5.
* The login page appears first, allowing you to login with an existing account from the database or to register. If you select register, the register page will appear to allow you to create a new account.
* Once you log in, the semester selection window appears, allowing you to select a semester, create a new one, or delete one.
* To create a semester, a new window appears with input controls, including a box to add and subtract modules from the created semester.
* Once you are done, click submit. The semester should now show in the combobox, and also be saved in the database along with its modules and study hours.
* Once you select the semester, the semester modules get displayed in a data grid on a new window. Here you can create and delete modules for the semester, go back to the semester selection screen, view single modules by selecting one and then clicking "view module", or view all semester modules by not selecting anything before pressing "view module".
* Clicking view module shows the details for the selected module. If no module was selected, a list of all modules and their data are displayed. If a specific module was selected, the data is displayed, as well as controls to enter hours worked on a specific date. This will update the module data in the database and the local memory.

<br>

***
