# DoctorWhoCore - An Entity Framework Core Project

## Introduction


DoctorWhoCore is a project that uses Entity Framework Core to manage and manipulate data in a database. This project has a focus on the popular British television show, Doctor Who. The database created by this project contains information about the various characters, enemies, authors, and episodes that have been featured in the show.

## Things to be familiar with

Before diving into the project, it is recommended that you have prior knowledge in the following areas:

- C# programming language
- Entity Framework Core
- SQL (Structured Query Language)

## Project Structure
The project consists of several classes and repositories that handle different aspects of the database.

## DoctorWho.Db class library
contains the database related code for the Doctor Who application. It includes the following components:

### Migrations
The DoctorWho.Db class library contains the database migrations for the Doctor Who application. These migrations are used to create and update the database schema as the application evolves.

### Repositories
The DoctorWho.Db class library also contains the repository classes which handle the database operations. These classes include the AuthorsRepository, EpisodeCompanionsRepository, DBFunctionsViewsAndStoredProceduresRepository and others. Each repository class is responsible for performing specific database operations such as creating, updating and deleting records in the database.

### DoctorWhoDbContext.cs
The DoctorWhoDbContext class is the main context class for the Doctor Who application. It provides a connection to the database and allows access to the entities through LINQ queries. The DoctorWhoDbContext class also includes the methods for executing database functions, views, and stored procedures.

## Step 1: Clone the project
The first step is to clone the project to your local machine. You can do this by using the following git command in the terminal:
```
git clone https://github.com/OthmanMohammad/Doctor-Who-Core.git
```

## Step 2: Open the project in Visual Studio
Once you have cloned the project, open Visual Studio and go to **File** > **Open** > **Project/Solution**. Navigate to the location where you cloned the project, select the **DoctorWhoCore.sln** file and click **Open**.

## Step 3: Set the default connection string
The next step is to set the default connection string in the **appsettings.json** file. This file can be found in the **DoctorWhoCore** project. You need to replace the placeholder {**YourDbConnectionString**} with your own SQL Server connection string.

```
{
  "ConnectionStrings": {
    "DoctorWhoCoreDbContext": "Server=(localdb)\\mssqllocaldb;Database=DoctorWhoCore;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  ...
}
```

## Step 4: Create the database
Next, you need to create the database using Entity Framework Core. You can do this by running the following command in the Package Manager Console:

```
Add-Migration InitialCreate
Update-Database
```

# Authors
This project was created by **Mohammad Othman**.
