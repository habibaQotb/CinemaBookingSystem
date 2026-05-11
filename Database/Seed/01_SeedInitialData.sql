-- ============================================
-- Cinema Booking System - Seed Data
-- ============================================
-- This script populates initial test data
-- Run after 01_CreateDatabase.sql
-- ============================================

-- Insert Movie Genres
INSERT INTO MOVIE_GENRE (GenreName) VALUES ('Action');
INSERT INTO MOVIE_GENRE (GenreName) VALUES ('Drama');
INSERT INTO MOVIE_GENRE (GenreName) VALUES ('Comedy');
INSERT INTO MOVIE_GENRE (GenreName) VALUES ('Thriller');
INSERT INTO MOVIE_GENRE (GenreName) VALUES ('Horror');
INSERT INTO MOVIE_GENRE (GenreName) VALUES ('Romance');
INSERT INTO MOVIE_GENRE (GenreName) VALUES ('Animation');
INSERT INTO MOVIE_GENRE (GenreName) VALUES ('Documentary');

-- Insert Cinema Halls
INSERT INTO HALL (HallName, TotalSeats) VALUES ('Hall A - Standard', 100);
INSERT INTO HALL (HallName, TotalSeats) VALUES ('Hall B - Premium', 80);
INSERT INTO HALL (HallName, TotalSeats) VALUES ('Hall C - IMAX', 150);

-- Insert Sample Customers
INSERT INTO CUSTOMER (CustomerName, Email, Phone) VALUES ('Ahmed Hassan', 'ahmed.hassan@email.com', '01001234567');
INSERT INTO CUSTOMER (CustomerName, Email, Phone) VALUES ('Fatima Mohamed', 'fatima.mohamed@email.com', '01102345678');
INSERT INTO CUSTOMER (CustomerName, Email, Phone) VALUES ('John Smith', 'john.smith@email.com', '01203456789');
INSERT INTO CUSTOMER (CustomerName, Email, Phone) VALUES ('Sarah Johnson', 'sarah.johnson@email.com', '01304567890');
INSERT INTO CUSTOMER (CustomerName, Email, Phone) VALUES ('Ali Ibrahim', 'ali.ibrahim@email.com', '01405678901');

-- Insert Seat Types
INSERT INTO SEAT_TYPE_VALUE (SeatType, PriceMultiplier) VALUES ('Standard', 1.0);
INSERT INTO SEAT_TYPE_VALUE (SeatType, PriceMultiplier) VALUES ('VIP', 1.5);
INSERT INTO SEAT_TYPE_VALUE (SeatType, PriceMultiplier) VALUES ('Premium', 2.0);

-- Insert Seats for Hall A (100 seats)
-- Standard seats: 80 seats (rows A-H, columns 1-10)
-- VIP seats: 20 seats (rows I-J, columns 1-10)
DECLARE @HallID INT = 1;
DECLARE @RowNum INT = 1;
DECLARE @SeatNum INT = 1;
DECLARE @SeatType INT;

-- Standard seats
WHILE @RowNum <= 8
BEGIN
    SET @SeatNum = 1;
    WHILE @SeatNum <= 10
    BEGIN
        INSERT INTO SEAT (HallID, SeatNumber, RowNumber, SeatTypeID, IsAvailable) 
        VALUES (@HallID, @SeatNum, @RowNum, 1, 1);
        SET @SeatNum = @SeatNum + 1;
    END;
    SET @RowNum = @RowNum + 1;
END;

-- VIP seats
WHILE @RowNum <= 10
BEGIN
    SET @SeatNum = 1;
    WHILE @SeatNum <= 10
    BEGIN
        INSERT INTO SEAT (HallID, SeatNumber, RowNumber, SeatTypeID, IsAvailable) 
        VALUES (@HallID, @SeatNum, @RowNum, 2, 1);
        SET @SeatNum = @SeatNum + 1;
    END;
    SET @RowNum = @RowNum + 1;
END;

-- Insert Seats for Hall B (80 seats - all standard)
SET @HallID = 2;
SET @RowNum = 1;
WHILE @RowNum <= 8
BEGIN
    SET @SeatNum = 1;
    WHILE @SeatNum <= 10
    BEGIN
        INSERT INTO SEAT (HallID, SeatNumber, RowNumber, SeatTypeID, IsAvailable) 
        VALUES (@HallID, @SeatNum, @RowNum, 1, 1);
        SET @SeatNum = @SeatNum + 1;
    END;
    SET @RowNum = @RowNum + 1;
END;

-- Insert Seats for Hall C (150 seats - mixed)
SET @HallID = 3;
SET @RowNum = 1;
SET @SeatNum = 1;

-- Standard seats for Hall C
WHILE @RowNum <= 10
BEGIN
    SET @SeatNum = 1;
    WHILE @SeatNum <= 10
    BEGIN
        INSERT INTO SEAT (HallID, SeatNumber, RowNumber, SeatTypeID, IsAvailable) 
        VALUES (@HallID, @SeatNum, @RowNum, 1, 1);
        SET @SeatNum = @SeatNum + 1;
    END;
    SET @RowNum = @RowNum + 1;
END;

-- Premium seats for Hall C
WHILE @RowNum <= 15
BEGIN
    SET @SeatNum = 1;
    WHILE @SeatNum <= 10
    BEGIN
        INSERT INTO SEAT (HallID, SeatNumber, RowNumber, SeatTypeID, IsAvailable) 
        VALUES (@HallID, @SeatNum, @RowNum, 3, 1);
        SET @SeatNum = @SeatNum + 1;
    END;
    SET @RowNum = @RowNum + 1;
END;

-- Insert Sample Bookings
INSERT INTO BOOKING (CustomerID, BookingDate, TotalAmount, Status) VALUES (1, '2026-05-10', 300.00, 'Confirmed');
INSERT INTO BOOKING (CustomerID, BookingDate, TotalAmount, Status) VALUES (2, '2026-05-10', 450.00, 'Confirmed');
INSERT INTO BOOKING (CustomerID, BookingDate, TotalAmount, Status) VALUES (3, '2026-05-11', 150.00, 'Pending');

-- Insert Sample Payments
INSERT INTO PAYMENT (BookingID, PaymentAmount, PaymentDate, PaymentMethod, Status) VALUES (1, 300.00, '2026-05-10', 'Credit Card', 'Completed');
INSERT INTO PAYMENT (BookingID, PaymentAmount, PaymentDate, PaymentMethod, Status) VALUES (2, 450.00, '2026-05-10', 'Debit Card', 'Completed');

-- Insert Sample Tickets
INSERT INTO TICKET (BookingID, SeatID, ShowTime, MovieTitle) VALUES (1, 1, '2026-05-15 18:00:00', 'Sample Movie 1');
INSERT INTO TICKET (BookingID, SeatID, ShowTime, MovieTitle) VALUES (1, 2, '2026-05-15 18:00:00', 'Sample Movie 1');
INSERT INTO TICKET (BookingID, SeatID, ShowTime, MovieTitle) VALUES (2, 15, '2026-05-16 20:00:00', 'Sample Movie 2');

-- Insert Sample Reservations
INSERT INTO RESERVATION (CustomerID, SeatID, ReservationDate, ExpiryDate, Status) VALUES (4, 21, '2026-05-11', '2026-05-13', 'Active');
INSERT INTO RESERVATION (CustomerID, SeatID, ReservationDate, ExpiryDate, Status) VALUES (5, 22, '2026-05-11', '2026-05-13', 'Active');
