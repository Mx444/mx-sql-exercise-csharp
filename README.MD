# Booking Management System

This repository contains a simple Windows Forms application developed in C# for managing bookings or reservations. It utilizes a SQL Server LocalDB database to store booking information.

## Repository Structure

The main application files are located within the `Prenotazioni/` directory. Key files and folders include:

-   **Prenotazioni.csproj**: The C# project file.
-   **Form1.cs**, **Form1.Designer.cs**, **Form1.resx**: Files for the main application form (likely the entry point or main menu).
-   **Form2.cs**, **Form2.Designer.cs**, **Form2.resx**: Files for the form used to manage bookings (add, view, edit, delete).
-   **Program.cs**: The application's entry point.
-   **App.config**: Configuration file, including the database connection string.
-   **Database1.mdf**, **Database1_log.ldf**: The SQL Server LocalDB database files.
-   **dbo.Prenotazione.sql**: SQL script for creating the `Prenotazione` table.
-   **Properties/**: Contains project properties, resources, and settings.
-   **Theme/**: Contains custom UI theme components (e.g., MetroFramework, FlatUI).

## Features

The Booking Management System offers the following features:

-   **Booking Management**
    -   Add new bookings (Nome, Cognome, Data, Stato).
    -   View existing bookings in a DataGridView.
    -   Edit booking details directly in the DataGridView.
    -   Delete bookings.
    -   Search bookings by Name.
-   **Database Integration**
    -   Connects to a SQL Server LocalDB database.
    -   Persists booking data.

## How to Use

1.  **Adding Bookings**:
    -   Navigate to the booking management section (likely via "Servizi Sociali" button on the main form).
    -   Enter the Name, Surname, Date, and Status in the provided fields.
    -   Click "Conferma" to add the booking to the list and database.
    -   The booking will appear in the table.

2.  **Managing Bookings**:
    -   View all bookings in the table.
    -   Double-click or select a cell to edit its value. Changes are saved automatically or upon closing the form (based on implementation).
    -   Right-click a row and confirm deletion to remove a booking.
    -   Use the search box to filter bookings by Name.

## Technical Implementation

The application is built using:
-   C#
-   Windows Forms
-   SQL Server LocalDB for data storage
-   MetroFramework and custom themes for UI styling.

## Requirements

-   Windows Operating System
-   .NET Framework (version 4.5.2 or compatible)
-   SQL Server LocalDB (installed and accessible)

## Getting Started

To use the Booking Management System:

1.  Clone this repository.
2.  Open the `Prenotazioni.sln` file in Visual Studio (or a compatible C# IDE).
3.  Ensure SQL Server LocalDB is installed and the database files (`Database1.mdf`, `Database1_log.ldf`) are correctly placed or configured (the application attempts to copy them to `C:\SQLDB` on first run).
4.  Build and run the project from Visual Studio.

---

*This repository was created as part of an educational journey.*