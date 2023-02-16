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
