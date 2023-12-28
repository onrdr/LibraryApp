# Library Management Web Project 

![library](https://github.com/onrdr/LibraryApp/assets/106915107/b03d8170-f9d1-43a1-b497-26606dbee02e)

This projects enables library attendant to 
  - List all the books in the library
  - Add new books to library database
  - Lend books to library users
  - Return books from users
  - Check the due-date of the book 
  
    
This projects enables library users to 
  - Lend books from library
  - Decide the due-date of the book
  - Returns books to library


# Project Structure
  ![event-app-structure-1](https://user-images.githubusercontent.com/106915107/228821415-7b3820ec-3d6c-4662-b60d-e63f8a6bb07e.png)

### How I solved case and created the project structure
- First I decided the Entity Structure. I decided to have Book and Author Entities which have One-to-Many Relation
- Next step was to decide to choose the technologies to be used. You may see them in the below section
- Then I wrote down the business logics. Lets list some of them.
  - What should happen if the library attendant chose a return date which is in the past
  - What should happen if the book that library attendant try to add alreadys exists in the database
  - What should happen if the user returns the book after due-date
- After finishing to deside the logics I implemented them in the code.
- I have decided the end-points to be used
- Once the back-end completed, I implemented front-end so that it should be user friendly
  
# Used Technologies and Tools:
Backend
- Monolith Architecture / NTier
- ASP.NET Core MVC
- Entity Framework Core
- MSSQL Server
- AutoMapper
- Initial Database Seeding with Migration
  
Frontend
- Razor Pages
- Partial Views
- Javascript
- JQuery
- HTML, CSS
- Bootstrap, BootsIcons
- Ajax Requests
- DataTables
- Toastr
- Sweet Alert

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
 start LibraryApp.sln
```

### 4- Open WebUI Project Folders
- Find appsettings.Development.json file and change the connection string with yours.

### 5- Open Package Manager Console and Run Command Below
```
 update-database
```
- All data will be seeded to your database

Hope you would get a good experince :)
