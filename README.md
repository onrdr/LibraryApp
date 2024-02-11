# Library Management Web Project 
![libraryApp](https://github.com/onrdr/LibraryApp/assets/106915107/3a224877-5f54-4b1d-b62d-ef778fb22cb2)


This project facilitates library attendants in managing the library's book inventory, lending books to users, and tracking their return.

## Key Features
1. Listing all books in the library, indicating whether they are available or currently on loan.
2. Adding new books to the library with associated authors.
3. Facilitating the lending of books to users, capturing the borrower's details and return date.
4. Enabling users to borrow books, set the due date, and return books to the library.
5. Displaying due dates and borrower information when listing books that are currently on loan.

## Project Structure

![event-app-structure-1](https://user-images.githubusercontent.com/106915107/228821415-7b3820ec-3d6c-4662-b60d-e63f8a6bb07e.png)

### How I Solved the Case and Created the Project Structure

1. **Entity Structure Decision:**
   - Defined entities: **Author**, **Book**, and **Borrower**.
   - Established clear relationships, including a One-to-Many relationship between **Author** and **Book** and also between **Book** and **Borrower**.

2. **Technology Stack:**
   - Chose technologies for the backend, including ASP.NET Core MVC, Entity Framework Core, and MSSQL Server.
   - Selected frontend tools such as Razor Pages, JavaScript, JQuery, HTML, CSS, Bootstrap, and DataTables.

3. **Business Logic Definition:**
   - Defined business logics, addressing scenarios like past return dates and existing books in the database.

4. **Implementation of Business Logic:**
   - Implemented defined business logics in the codebase to ensure desired behaviors.

5. **Endpoint Specification:**
   - Clearly defined endpoints for various functionalities within the application.

6. **Frontend Development:**
   - Developed user-friendly frontend using Razor Pages, partial views, JavaScript, JQuery, and popular frontend libraries.

## Used Technologies and Tools:

### Backend
- **Architecture:** Monolith Architecture / NTier
- **Framework:** ASP.NET Core MVC
- **Database Access:** Entity Framework Core
- **Database:** MSSQL Server
- **Object-Object Mapping:** AutoMapper
- **Logging:** SeriLog
- **Initial Database Seeding:** Migration

### Frontend
- **UI Framework:** Razor Pages
- **View Structure:** Partial Views
- **Scripting Languages:** JavaScript, JQuery
- **Markup Languages:** HTML, CSS
- **Styling Frameworks:** Bootstrap, BootsIcons
- **Asynchronous Requests:** Ajax
- **Data Presentation:** DataTables
- **Notification Libraries:** Toastr, Sweet Alert

# How to run the project in your local  

### 1- Clone the repository
```
 git clone https://github.com/onrdr/LibraryApp
```

### 2- Navigate to the API Directory
```
 cd LibraryApp
```

### 3- Open the LibraryApp.sln file with a code editor (preferably Visual Studio)
```
 start LibraryManagement.sln
```

### 4- Open WebUI project folders
- Find appsettings.Development.json file and change the connection string with yours.

### 5- Open Package Manager Console and Run Command Below
```
- update-database
```
- All data will be seeded to your database

### 5- Run the program
Login Credential
- username:
```
admin@test.com
```
- password:
```
Admin1*
```
