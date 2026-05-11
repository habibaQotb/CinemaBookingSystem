# Database Setup Guide

This folder contains all database scripts needed to set up the Cinema Booking System database.

## Structure

- **Schema/**: Contains the main database schema and table creation scripts
- **Seed/**: Contains seed data scripts for initial data population

## Setup Instructions

### Prerequisites
- SQL Server 2019 or later
- SQL Server Management Studio (SSMS)

### Steps to Set Up

1. **Create the Database:**
   - Open SQL Server Management Studio
   - Connect to your SQL Server instance
   - Right-click on "Databases" → New Database
   - Name it `CinemaBookingSystem`

2. **Run the Schema Script:**
   - Open `Schema/01_CreateDatabase.sql` in SSMS
   - Execute the script to create all tables, relationships, and stored procedures

3. **Seed Initial Data (Optional):**
   - Open `Seed/01_SeedInitialData.sql` in SSMS
   - Execute to populate initial data

## Database Objects

The schema includes:
- **Tables**: CUSTOMER, HALL, SEAT, MOVIE_GENRE, BOOKING, PAYMENT, TICKET, RESERVATION, SEAT_TYPE_VALUE
- **Functions**: fn_GetMoviesByCinema, fn_GetCustomerBookingDetails
- **Stored Procedures**: sp_MakeBooking, sp_CancelBooking, sp_ConfirmPayment, sp_GetAllMovies, sp_GetAvailableSeats, sp_GetMoviesByGenre, sp_GetShowtimesByMovie, sp_GetMyBookings, sp_GetMyTickets

## Notes

- All scripts are generated from SQL Server using the "Generate Scripts" feature
- Maintain script numbering for proper execution order
- Test in a development environment first
