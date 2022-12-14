# Hot Desk

Implementation of app allowing employees of the company to reserve a working place for one or several days and to come to work at it.

## User Manual

#### 1. Run project
#### 2. In Reservation List click option 'Create New' above the table
#### 3. Choose Employee and desired Workplace from select lists and pick dates in which you would like to book the position
#### 3a. If you Employee and Workplace select menus are empty, fill other tables in your database using relevant views (suggested order: Equipment, Workplace, add Equipment to Workplace(above Workplace List next to 'Create New'), Employee and finally the Reservation) 
#### 4. Click button 'Create' to save Reservation in database
#### 5. Correct data if it did not pass validation
#### 6. App has implemented CRUD operations for each table in database
##
![Reservation List](https://github.com/dtamon/Task3_WorkplaceReservation/blob/master/Screenoshots/ReservationList.png?raw=true)
#### Each data List View contains table showing most important data from the relevant db table, to add new record you need to click on 'Create New' component above table
#### In table column called 'Actions' you can decide what operation you want to perform on a database specific record, in each List View you can move to edit form, delete record. Reservation List has additional option to show all details about reservation including equipment that is assigned to reserved workplace.
##
![Workplace list](https://github.com/dtamon/Task3_WorkplaceReservation/blob/master/Screenoshots/WorkplaceList.png?raw=true)
#### Workplace List as only one has additional actions within its view. You can call actions corresponding to the assignment of Equipment to specific workplace. In addition to 'Create New' above the table (that relates to adding new workplace to the database), you can see 'Add Equipment' which will redirect to form where you can choose what type of equipment you want to assign to which workplace and in what count. In 'Equipment on workplace' Column you have equipment that is already assigned to workplace and actions to manage it.
##
![Reservation form](https://github.com/dtamon/Task3_WorkplaceReservation/blob/master/Screenoshots/ReservationForm.png?raw=true)
#### All forms contain components used to enter the necessary data required to succesfully save a record in database.
![Reservation form validation](https://github.com/dtamon/Task3_WorkplaceReservation/blob/master/Screenoshots/ReservationFormValidation.png?raw=true)
#### If the form didn't pass validation, you will see messages telling which fields caused the problems 
## Configuration
#### 1. Change your database connection string in [appsettings.json](https://github.com/dtamon/Task3_WorkplaceReservation/blob/master/Task3_WorkplaceReservation/appsettings.json)
````json
"ConnectionStrings": {
    "connection": ""Server=localhost\\SQLEXPRESS;Database=workplace_reservation;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  ````
#### 2. Initiate database
In your Package Manager Console run `update-database` command
![Package Manager Console](https://i.imgur.com/WM08rJ9.png)



## Architecture

- I used Entity Framework Core for easy communication with database
- For validation purpose I used [Fluent Validation](https://docs.fluentvalidation.net/en/latest/) library
- [Controllers](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation/Controllers) job is to communicate between relevant [Views](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation/Views) and [Services](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation/Services), check if data passed validation rules specified in [Validators](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation/Validators) and to catch an Exception if the data didn't pass validation related to other records in the database
- [Services](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation/Services) job is to call [Repositories](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation.DataAccess/Repositories) to access data that will be cast to [ViewModels](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation/Models) and displayed in [Views](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation/Views), and the other way to cast ViewModels to [Entity Models](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation.DataAccess/Domain) ready to be saved in database.
- [Repositories](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation.DataAccess/Repositories) job is to get needed data from database using LINQ, each repository corresponds to a table from the database
- [ViewModels](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation/Models) are complex models, that may contain data from more than one table in database, which will be displayed in the related [Views](https://github.com/dtamon/Task3_WorkplaceReservation/tree/master/Task3_WorkplaceReservation/Views)

## Database (MS SQL Server)
### Database schema
![Database Schema](https://github.com/dtamon/Task3_WorkplaceReservation/blob/master/Screenoshots/DBSchema.png?raw=true)

