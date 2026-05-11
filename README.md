# Cinema Booking System

A comprehensive C# application for managing cinema bookings, seat reservations, and ticket sales with an integrated SQL Server database backend.

## 📋 Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Database Setup](#database-setup)
- [Installation](#installation)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)

---

## ✨ Features

- **Customer Management**: Register and manage customer profiles
- **Hall & Seat Management**: Multiple cinema halls with configurable seating layouts
- **Movie Management**: Add and categorize movies by genre
- **Booking System**: Reserve and book cinema seats
- **Payment Processing**: Secure payment confirmation and tracking
- **Ticket Generation**: Digital ticket creation for confirmed bookings
- **Reservation System**: Hold seats with expiry dates
- **Reporting**: View booking history, available seats, and showtimes

---

## 🛠️ Tech Stack

- **Language**: C# (.NET Framework/Core)
- **Database**: SQL Server 2019+
- **ORM**: Entity Framework (recommended)
- **IDE**: Visual Studio 2019+
- **Version Control**: Git & GitHub

---

## 📁 Project Structure

```
CinemaBookingSystem/
├── Database/                          # Database scripts and setup
│   ├── README.md                      # Database setup guide
│   ├── Schema/
│   │   └── 01_CreateDatabase.sql      # Database schema and stored procedures
│   └── Seed/
│       └── 01_SeedInitialData.sql     # Sample data for testing
├── README.md                          # This file
└── [C# Project Files]                 # Your application source code
```

---

## 🗄️ Database Setup

### Prerequisites

- SQL Server 2019 or later
- SQL Server Management Studio (SSMS)
- Appropriate database creation permissions

### Quick Start

1. **Open SQL Server Management Studio**
   ```
   Connect to your local SQL Server instance
   ```

2. **Create the Database**
   ```sql
   -- Run Database/Schema/01_CreateDatabase.sql
   ```
   This creates:
   - 9 core tables (CUSTOMER, HALL, SEAT, BOOKING, PAYMENT, TICKET, RESERVATION, MOVIE_GENRE, SEAT_TYPE_VALUE)
   - 2 functions (fn_GetMoviesByCinema, fn_GetCustomerBookingDetails)
   - 9 stored procedures for business logic

3. **Populate Sample Data (Optional)**
   ```sql
   -- Run Database/Seed/01_SeedInitialData.sql
   ```
   This inserts:
   - 8 movie genres
   - 3 sample cinema halls (100, 80, 150 seats)
   - 5 test customers
   - Seat layouts and bookings

### Database Schema Overview

**Core Tables:**

| Table | Purpose |
|-------|---------|
| `CUSTOMER` | Stores customer information |
| `HALL` | Cinema halls/screens |
| `SEAT` | Individual seats with type and availability |
| `SEAT_TYPE_VALUE` | Seat categories (Standard, VIP, Premium) with pricing |
| `MOVIE_GENRE` | Movie categories |
| `BOOKING` | Customer booking records |
| `PAYMENT` | Payment transactions |
| `TICKET` | Generated tickets for bookings |
| `RESERVATION` | Seat reservations with expiry |

**Key Stored Procedures:**

- `sp_MakeBooking` - Create new booking
- `sp_CancelBooking` - Cancel existing booking
- `sp_ConfirmPayment` - Process payment
- `sp_GetAllMovies` - Retrieve movies
- `sp_GetAvailableSeats` - Check seat availability
- `sp_GetMoviesByGenre` - Filter movies by category
- `sp_GetShowtimesByMovie` - Get showtimes for a movie
- `sp_GetMyBookings` - Customer booking history
- `sp_GetMyTickets` - Customer tickets

---

## 💻 Installation

### 1. Clone the Repository

```bash
git clone https://github.com/habibaQotb/CinemaBookingSystem.git
cd CinemaBookingSystem
```

### 2. Set Up the Database

Follow the **Database Setup** section above to create and populate the database.

### 3. Configure Connection String

Update your application's `appsettings.json` or `App.config`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CinemaBookingSystem;Integrated Security=true;"
  }
}
```

### 4. Build the Solution

```bash
dotnet build
```

Or in Visual Studio:
- Open `CinemaBookingSystem.sln`
- Press `Ctrl+Shift+B` to build

### 5. Run the Application

```bash
dotnet run
```

---

## 🎯 Usage

### Basic Workflow

1. **Register a Customer**
   ```
   Customer creates account with name, email, phone
   ```

2. **Browse Movies & Showtimes**
   ```
   View available movies filtered by genre and showtime
   ```

3. **Select Seats**
   ```
   Check available seats and choose preferred seats
   Standard: Base price
   VIP: 1.5x base price
   Premium: 2x base price
   ```

4. **Create Booking**
   ```
   Proceed to booking with selected seats
   ```

5. **Make Payment**
   ```
   Process payment via credit/debit card
   ```

6. **Get Ticket**
   ```
   Receive digital ticket confirmation
   ```

---

## 📚 API Documentation

### Key Functions

#### `fn_GetMoviesByCinema`
Retrieves all movies showing at a specific cinema.

```sql
SELECT * FROM fn_GetMoviesByCinema(@CinemaID)
```

#### `fn_GetCustomerBookingDetails`
Gets detailed booking information for a customer.

```sql
SELECT * FROM fn_GetCustomerBookingDetails(@CustomerID)
```

### Example Stored Procedure Usage

#### Make a Booking
```sql
EXEC sp_MakeBooking 
    @CustomerID = 1, 
    @SeatID = 5, 
    @ShowTime = '2026-05-15 18:00:00',
    @MovieTitle = 'Avengers'
```

#### Confirm Payment
```sql
EXEC sp_ConfirmPayment 
    @BookingID = 1, 
    @PaymentAmount = 300.00, 
    @PaymentMethod = 'Credit Card'
```

#### Get Available Seats
```sql
EXEC sp_GetAvailableSeats @HallID = 1
```

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add YourFeature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a Pull Request

### Guidelines

- Write clean, documented code
- Test changes in a development environment
- Update documentation for new features
- Follow C# naming conventions

---

## 📝 License

This project is open source and available under the MIT License.

---

## 📞 Support

For issues, questions, or suggestions:
- Open an [Issue](https://github.com/habibaQotb/CinemaBookingSystem/issues)
- Check existing documentation in the `Database/` folder

---

## 👤 Author

**Habiba Kotb**
- GitHub: [@habibaQotb](https://github.com/habibaQotb)
- Email: 24P0196@eng.asu.edu.eg

---

**Last Updated**: May 11, 2026
