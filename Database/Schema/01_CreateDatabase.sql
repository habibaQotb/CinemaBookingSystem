-- ============================================
-- Cinema Booking System Database Schema
-- Generated from SQL Server Management Studio
-- ============================================
-- This script creates the complete database schema
-- 
-- Tables:
-- - CUSTOMER
-- - HALL
-- - SEAT
-- - SEAT_TYPE_VALUE
-- - MOVIE_GENRE
-- - BOOKING
-- - PAYMENT
-- - TICKET
-- - RESERVATION
--
-- Functions:
-- - fn_GetMoviesByCinema
-- - fn_GetCustomerBookingDetails
--
-- Stored Procedures:
-- - sp_MakeBooking
-- - sp_CancelBooking
-- - sp_ConfirmPayment
-- - sp_GetAllMovies
-- - sp_GetAvailableSeats
-- - sp_GetMoviesByGenre
-- - sp_GetShowtimesByMovie
-- - sp_GetMyBookings
-- - sp_GetMyTickets
--
-- ============================================
-- SQL SCRIPT
-- ============================================
USE [master]
GO
/****** Object:  Database [CinemaTicketBooking]    Script Date: 5/11/2026 6:18:16 AM ******/
CREATE DATABASE [CinemaTicketBooking]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CinemaTicketBooking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CinemaTicketBooking.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CinemaTicketBooking_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CinemaTicketBooking_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CinemaTicketBooking] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CinemaTicketBooking].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CinemaTicketBooking] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET ARITHABORT OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET AUTO_UPDATE_STATISTICS OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CinemaTicketBooking] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CinemaTicketBooking] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CinemaTicketBooking] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET RECOVERY FULL 
GO
ALTER DATABASE [CinemaTicketBooking] SET  MULTI_USER 
GO
ALTER DATABASE [CinemaTicketBooking] SET PAGE_VERIFY TORN_PAGE_DETECTION  
GO
ALTER DATABASE [CinemaTicketBooking] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CinemaTicketBooking] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CinemaTicketBooking] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CinemaTicketBooking] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CinemaTicketBooking] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CinemaTicketBooking', N'ON'
GO
ALTER DATABASE [CinemaTicketBooking] SET QUERY_STORE = ON
GO
ALTER DATABASE [CinemaTicketBooking] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CinemaTicketBooking]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CalcTicketPrice]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_CalcTicketPrice]
(
    @ShowtimeID INT,
    @SeatNo     INT
)
RETURNS MONEY
AS
BEGIN
    DECLARE @SeatPrice MONEY;
    DECLARE @SlotPrice MONEY;
    DECLARE @HallNo    INT;
    DECLARE @CinemaID  INT;

    SELECT  @HallNo   = hall_no,
            @CinemaID = cinema_id
    FROM    SHOWTIME
    WHERE   showtime_id = @ShowtimeID;

    SELECT  @SeatPrice = STV.seat_price
    FROM    SEAT ST
    INNER JOIN SEAT_TYPE_VALUE STV ON ST.seat_type = STV.seat_type
    WHERE   ST.seat_no   = @SeatNo
      AND   ST.hall_no   = @HallNo
      AND   ST.cinema_id = @CinemaID;

    SELECT  @SlotPrice = SP.slot_price
    FROM    SHOWTIME S
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot = SP.slot
    WHERE   S.showtime_id = @ShowtimeID;

    RETURN ISNULL(@SeatPrice, 0) + ISNULL(@SlotPrice, 0);
END;

GO
/****** Object:  UserDefinedFunction [dbo].[fn_CountCustomerBookings]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_CountCustomerBookings]
(
    @CustomerID INT
)
RETURNS INT
AS
BEGIN
    DECLARE @BookingCount INT;

    SELECT  @BookingCount = COUNT(*)
    FROM    BOOKING
    WHERE   customer_id = @CustomerID;

    RETURN ISNULL(@BookingCount, 0);
END;

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetCustomerBookingSummary]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetCustomerBookingSummary]
(
    @CustomerID  INT,
    @SummaryType VARCHAR(15)
)
RETURNS @SummaryTable TABLE
(
    booking_id      INT,
    booking_date    DATE,
    booking_status  VARCHAR(20),
    movie_title     VARCHAR(200),
    show_date       DATE,
    slot            VARCHAR(20),
    amount          MONEY,
    payment_status  VARCHAR(20)
)
AS
BEGIN
    IF @SummaryType = 'Confirmed'
    BEGIN
        INSERT INTO @SummaryTable
        SELECT  B.booking_id, B.booking_date, B.booking_status,
                M.title, S.date, S.slot, P.amount, P.payment_status
        FROM    BOOKING B
        INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
        INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
        INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
        INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
        LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
        WHERE   B.customer_id    = @CustomerID
          AND   B.booking_status = 'confirmed';
    END
    ELSE IF @SummaryType = 'Cancelled'
    BEGIN
        INSERT INTO @SummaryTable
        SELECT  B.booking_id, B.booking_date, B.booking_status,
                M.title, S.date, S.slot, P.amount, P.payment_status
        FROM    BOOKING B
        INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
        INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
        INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
        INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
        LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
        WHERE   B.customer_id    = @CustomerID
          AND   B.booking_status = 'cancelled';
    END
    ELSE
    BEGIN
        INSERT INTO @SummaryTable
        SELECT  B.booking_id, B.booking_date, B.booking_status,
                M.title, S.date, S.slot, P.amount, P.payment_status
        FROM    BOOKING B
        INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
        INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
        INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
        INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
        LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
        WHERE   B.customer_id = @CustomerID;
    END;

    RETURN;
END;

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetCustomerTotalSpent]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetCustomerTotalSpent]
(
    @CustomerID INT
)
RETURNS MONEY
AS
BEGIN
    DECLARE @TotalSpent MONEY;

    SELECT  @TotalSpent = SUM(P.amount)
    FROM    PAYMENT  P
    INNER JOIN BOOKING B ON P.booking_id = B.booking_id
    WHERE   B.customer_id    = @CustomerID
      AND   P.payment_status = 'completed';

    RETURN ISNULL(@TotalSpent, 0);
END;

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetMovieDurationLabel]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetMovieDurationLabel]
(
    @MovieID INT
)
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @Duration INT;
    DECLARE @Label    VARCHAR(20);

    SELECT  @Duration = duration_min
    FROM    MOVIE
    WHERE   movie_id = @MovieID;

    IF @Duration < 90
        SET @Label = 'Short';
    ELSE IF @Duration BETWEEN 90 AND 140
        SET @Label = 'Standard';
    ELSE
        SET @Label = 'Long';

    RETURN ISNULL(@Label, 'Unknown');
END;

GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetMoviesBySlotType]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetMoviesBySlotType]
(
    @SlotType VARCHAR(10)
)
RETURNS @MovieTable TABLE
(
    showtime_id  INT,
    movie_title  VARCHAR(200),
    cinema_name  VARCHAR(100),
    city         VARCHAR(100),
    slot         VARCHAR(20),
    show_date    DATE,
    slot_price   MONEY
)
AS
BEGIN
    IF @SlotType = 'Today'
    BEGIN
        INSERT INTO @MovieTable
        SELECT  S.showtime_id, M.title, C.name, C.city,
                S.slot, S.date, SP.slot_price
        FROM    SHOWTIME S
        INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
        INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
        INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
        WHERE   S.date = CAST(GETDATE() AS DATE);
    END
    ELSE IF @SlotType = 'Weekend'
    BEGIN
        INSERT INTO @MovieTable
        SELECT  S.showtime_id, M.title, C.name, C.city,
                S.slot, S.date, SP.slot_price
        FROM    SHOWTIME S
        INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
        INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
        INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
        WHERE   DATEPART(weekday, S.date) IN (6, 7, 1);
    END
    ELSE
    BEGIN
        INSERT INTO @MovieTable
        SELECT  S.showtime_id, M.title, C.name, C.city,
                S.slot, S.date, SP.slot_price
        FROM    SHOWTIME S
        INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
        INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
        INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
        WHERE   S.date >= CAST(GETDATE() AS DATE);
    END;

    RETURN;
END;

GO
/****** Object:  Table [dbo].[MOVIE]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOVIE](
	[movie_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](200) NOT NULL,
	[description] [varchar](max) NULL,
	[duration_min] [int] NOT NULL,
	[language] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[movie_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CINEMA]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CINEMA](
	[cinema_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[address] [varchar](200) NOT NULL,
	[city] [varchar](100) NOT NULL,
	[phone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[cinema_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHOWTIME_SLOT_PRICE]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHOWTIME_SLOT_PRICE](
	[slot] [varchar](20) NOT NULL,
	[slot_price] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[slot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHOWTIME]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHOWTIME](
	[showtime_id] [int] IDENTITY(1,1) NOT NULL,
	[movie_id] [int] NOT NULL,
	[hall_no] [int] NOT NULL,
	[cinema_id] [int] NOT NULL,
	[slot] [varchar](20) NOT NULL,
	[date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[showtime_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetShowtimesByDate]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetShowtimesByDate]
(
    @ShowDate DATE
)
RETURNS TABLE
AS
RETURN
(
    SELECT  S.showtime_id,
            M.title         AS movie_title,
            C.name          AS cinema_name,
            C.city,
            S.slot,
            S.date,
            SP.slot_price
    FROM    SHOWTIME S
    INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
    INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
    WHERE   S.date = @ShowDate
);

GO
/****** Object:  Table [dbo].[MOVIE_GENRE]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOVIE_GENRE](
	[movie_id] [int] NOT NULL,
	[Mgenre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[movie_id] ASC,
	[Mgenre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetMoviesByCinema]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetMoviesByCinema]
(
    @CinemaID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT  DISTINCT
            M.movie_id,
            M.title,
            M.duration_min,
            M.language,
            MG.Mgenre
    FROM    MOVIE M
    INNER JOIN SHOWTIME     S  ON M.movie_id  = S.movie_id
    LEFT  JOIN MOVIE_GENRE  MG ON M.movie_id  = MG.movie_id
    WHERE   S.cinema_id = @CinemaID
);

GO
/****** Object:  Table [dbo].[SEAT]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEAT](
	[seat_no] [int] NOT NULL,
	[hall_no] [int] NOT NULL,
	[cinema_id] [int] NOT NULL,
	[seat_type] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[seat_no] ASC,
	[hall_no] ASC,
	[cinema_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BOOKING]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BOOKING](
	[booking_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[booking_date] [date] NOT NULL,
	[booking_status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[booking_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAYMENT]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAYMENT](
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
	[booking_id] [int] NOT NULL,
	[payment_method] [varchar](50) NOT NULL,
	[payment_date] [date] NOT NULL,
	[amount] [money] NOT NULL,
	[payment_status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[booking_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TICKET]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TICKET](
	[ticket_id] [int] IDENTITY(1,1) NOT NULL,
	[booking_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVATION]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVATION](
	[ticket_id] [int] NOT NULL,
	[seat_no] [int] NOT NULL,
	[showtime_id] [int] NOT NULL,
	[hall_no] [int] NOT NULL,
	[cinema_id] [int] NOT NULL,
	[price] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ticket_id] ASC,
	[seat_no] ASC,
	[showtime_id] ASC,
	[hall_no] ASC,
	[cinema_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetCustomerBookingDetails]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetCustomerBookingDetails]
(
    @CustomerID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT  B.booking_id,
            B.booking_date,
            B.booking_status,
            M.title             AS movie_title,
            C.name              AS cinema_name,
            C.city,
            S.slot,
            S.date              AS show_date,
            R.seat_no,
            ST.seat_type,
            P.amount,
            P.payment_method,
            P.payment_status
    FROM    BOOKING B
    INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
    INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
    INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
    INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
    INNER JOIN CINEMA       C   ON S.cinema_id   = C.cinema_id
    INNER JOIN SEAT         ST  ON R.seat_no     = ST.seat_no
                                AND R.hall_no    = ST.hall_no
                                AND R.cinema_id  = ST.cinema_id
    LEFT  JOIN PAYMENT      P   ON B.booking_id  = P.booking_id
    WHERE   B.customer_id = @CustomerID
);

GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[phone] [varchar](20) NULL,
	[password] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HALL]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HALL](
	[hall_no] [int] NOT NULL,
	[cinema_id] [int] NOT NULL,
	[capacity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[hall_no] ASC,
	[cinema_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SEAT_TYPE_VALUE]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEAT_TYPE_VALUE](
	[seat_type] [varchar](20) NOT NULL,
	[seat_price] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[seat_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BOOKING] ADD  DEFAULT ('pending') FOR [booking_status]
GO
ALTER TABLE [dbo].[PAYMENT] ADD  DEFAULT ('pending') FOR [payment_status]
GO
ALTER TABLE [dbo].[BOOKING]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[CUSTOMER] ([customer_id])
GO
ALTER TABLE [dbo].[HALL]  WITH CHECK ADD FOREIGN KEY([cinema_id])
REFERENCES [dbo].[CINEMA] ([cinema_id])
GO
ALTER TABLE [dbo].[MOVIE_GENRE]  WITH CHECK ADD FOREIGN KEY([movie_id])
REFERENCES [dbo].[MOVIE] ([movie_id])
GO
ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD FOREIGN KEY([booking_id])
REFERENCES [dbo].[BOOKING] ([booking_id])
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD FOREIGN KEY([showtime_id])
REFERENCES [dbo].[SHOWTIME] ([showtime_id])
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD FOREIGN KEY([ticket_id])
REFERENCES [dbo].[TICKET] ([ticket_id])
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD FOREIGN KEY([seat_no], [hall_no], [cinema_id])
REFERENCES [dbo].[SEAT] ([seat_no], [hall_no], [cinema_id])
GO
ALTER TABLE [dbo].[SEAT]  WITH CHECK ADD FOREIGN KEY([hall_no], [cinema_id])
REFERENCES [dbo].[HALL] ([hall_no], [cinema_id])
GO
ALTER TABLE [dbo].[SEAT]  WITH CHECK ADD FOREIGN KEY([seat_type])
REFERENCES [dbo].[SEAT_TYPE_VALUE] ([seat_type])
GO
ALTER TABLE [dbo].[SHOWTIME]  WITH CHECK ADD FOREIGN KEY([hall_no], [cinema_id])
REFERENCES [dbo].[HALL] ([hall_no], [cinema_id])
GO
ALTER TABLE [dbo].[SHOWTIME]  WITH CHECK ADD FOREIGN KEY([movie_id])
REFERENCES [dbo].[MOVIE] ([movie_id])
GO
ALTER TABLE [dbo].[SHOWTIME]  WITH CHECK ADD FOREIGN KEY([slot])
REFERENCES [dbo].[SHOWTIME_SLOT_PRICE] ([slot])
GO
ALTER TABLE [dbo].[TICKET]  WITH CHECK ADD FOREIGN KEY([booking_id])
REFERENCES [dbo].[BOOKING] ([booking_id])
GO
ALTER TABLE [dbo].[BOOKING]  WITH CHECK ADD CHECK  (([booking_status]='cancelled' OR [booking_status]='pending' OR [booking_status]='confirmed'))
GO
ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD CHECK  (([payment_status]='failed' OR [payment_status]='completed' OR [payment_status]='pending'))
GO
/****** Object:  StoredProcedure [dbo].[sp_CancelBooking]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_CancelBooking]
    @BookingID    INT,
    @CustomerID   INT,
    @Success      BIT         OUTPUT,
    @ErrorMessage VARCHAR(255) OUTPUT
AS
BEGIN
    SET @Success      = 0;
    SET @ErrorMessage = '';

    -- Validate booking belongs to this customer and is not already cancelled
    IF NOT EXISTS (
        SELECT 1 FROM BOOKING
        WHERE  booking_id   = @BookingID
          AND  customer_id  = @CustomerID
          AND  booking_status <> 'cancelled'
    )
    BEGIN
        SET @ErrorMessage = 'Booking not found or already cancelled.';
        RETURN;
    END;

    UPDATE BOOKING
    SET    booking_status = 'cancelled'
    WHERE  booking_id = @BookingID;

    UPDATE PAYMENT
    SET    payment_status = 'failed'
    WHERE  booking_id = @BookingID;

    SET @Success = 1;

    -- Return updated booking row to the GUI
    SELECT  B.booking_id,
            B.booking_status,
            P.payment_status
    FROM    BOOKING B
    INNER JOIN PAYMENT P ON B.booking_id = P.booking_id
    WHERE   B.booking_id = @BookingID;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_ConfirmPayment]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ConfirmPayment]
    @BookingID    INT,
    @CustomerID   INT,
    @Success      BIT          OUTPUT,
    @ErrorMessage VARCHAR(255) OUTPUT
AS
BEGIN
    SET @Success      = 0;
    SET @ErrorMessage = '';

    -- Validate booking belongs to this customer
    IF NOT EXISTS (
        SELECT 1 FROM BOOKING
        WHERE  booking_id  = @BookingID
          AND  customer_id = @CustomerID
    )
    BEGIN
        SET @ErrorMessage = 'Booking not found for this customer.';
        RETURN;
    END;

    -- Validate not already confirmed
    IF EXISTS (
        SELECT 1 FROM BOOKING
        WHERE  booking_id     = @BookingID
          AND  booking_status = 'confirmed'
    )
    BEGIN
        SET @ErrorMessage = 'Booking is already confirmed.';
        RETURN;
    END;

    UPDATE PAYMENT
    SET    payment_status = 'completed'
    WHERE  booking_id = @BookingID;

    UPDATE BOOKING
    SET    booking_status = 'confirmed'
    WHERE  booking_id = @BookingID;

    SET @Success = 1;

    -- Return updated booking row to the GUI
    SELECT  B.booking_id,
            B.booking_status,
            P.payment_status,
            P.amount
    FROM    BOOKING B
    INNER JOIN PAYMENT P ON B.booking_id = P.booking_id
    WHERE   B.booking_id = @BookingID;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllMovies]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllMovies]
AS
BEGIN
    SELECT  M.movie_id,
            M.title,
            M.description,
            M.duration_min,
            M.language,
            MG.Mgenre
    FROM    MOVIE M
    LEFT JOIN MOVIE_GENRE MG ON M.movie_id = MG.movie_id
    ORDER BY M.title;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAvailableSeats]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAvailableSeats]
    @ShowtimeID INT
AS
BEGIN
    DECLARE @HallNo   INT;
    DECLARE @CinemaID INT;

    SELECT  @HallNo   = hall_no,
            @CinemaID = cinema_id
    FROM    SHOWTIME
    WHERE   showtime_id = @ShowtimeID;

    SELECT  ST.seat_no,
            ST.seat_type,
            STV.seat_price
    FROM    SEAT ST
    INNER JOIN SEAT_TYPE_VALUE STV ON ST.seat_type = STV.seat_type
    WHERE   ST.hall_no   = @HallNo
      AND   ST.cinema_id = @CinemaID
      AND   ST.seat_no NOT IN (
                SELECT  R.seat_no
                FROM    RESERVATION R
                WHERE   R.showtime_id = @ShowtimeID
                  AND   R.hall_no     = @HallNo
                  AND   R.cinema_id   = @CinemaID
            )
    ORDER BY ST.seat_no;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_GetMoviesByGenre]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetMoviesByGenre]
    @Genre VARCHAR(50)
AS
BEGIN
    SELECT  M.movie_id,
            M.title,
            M.duration_min,
            M.language,
            MG.Mgenre
    FROM    MOVIE M
    INNER JOIN MOVIE_GENRE MG ON M.movie_id = MG.movie_id
    WHERE   MG.Mgenre = @Genre
    ORDER BY M.title;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_GetMyBookings]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetMyBookings]
    @CustomerID INT
AS
BEGIN
    SELECT  B.booking_id,
            B.booking_date,
            B.booking_status,
            P.payment_method,
            P.payment_status,
            P.amount
    FROM    BOOKING B
    LEFT JOIN PAYMENT P ON B.booking_id = P.booking_id
    WHERE   B.customer_id = @CustomerID
    ORDER BY B.booking_date DESC;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_GetMyTickets]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetMyTickets]
    @CustomerID INT
AS
BEGIN
    SELECT  T.ticket_id,
            B.booking_id,
            B.booking_date,
            M.title             AS movie_title,
            C.name              AS cinema_name,
            C.city,
            S.slot,
            S.date              AS show_date,
            R.seat_no,
            ST.seat_type,
            R.price             AS ticket_price,
            B.booking_status
    FROM    BOOKING B
    INNER JOIN TICKET       T   ON B.booking_id  = T.booking_id
    INNER JOIN RESERVATION  R   ON T.ticket_id   = R.ticket_id
    INNER JOIN SHOWTIME     S   ON R.showtime_id = S.showtime_id
    INNER JOIN MOVIE        M   ON S.movie_id    = M.movie_id
    INNER JOIN CINEMA       C   ON S.cinema_id   = C.cinema_id
    INNER JOIN SEAT         ST  ON R.seat_no     = ST.seat_no
                                AND R.hall_no    = ST.hall_no
                                AND R.cinema_id  = ST.cinema_id
    WHERE   B.customer_id = @CustomerID
    ORDER BY S.date DESC;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_GetShowtimesByMovie]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetShowtimesByMovie]
    @MovieID INT
AS
BEGIN
    SELECT  S.showtime_id,
            M.title,
            C.name          AS cinema_name,
            C.city,
            S.hall_no,
            S.slot,
            S.date,
            SP.slot_price
    FROM    SHOWTIME S
    INNER JOIN MOVIE            M   ON S.movie_id  = M.movie_id
    INNER JOIN CINEMA           C   ON S.cinema_id = C.cinema_id
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot    = SP.slot
    WHERE   S.movie_id = @MovieID
    ORDER BY S.date, S.slot;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_MakeBooking]    Script Date: 5/11/2026 6:18:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_MakeBooking]
    @CustomerID    INT,
    @ShowtimeID    INT,
    @SeatNo        INT,
    @PaymentMethod VARCHAR(50),
    @NewBookingID  INT          OUTPUT,
    @ErrorMessage  VARCHAR(255) OUTPUT
AS
BEGIN
    DECLARE @HallNo      INT;
    DECLARE @CinemaID    INT;
    DECLARE @SeatPrice   MONEY;
    DECLARE @SlotPrice   MONEY;
    DECLARE @TotalPrice  MONEY;
    DECLARE @NewTicketID INT;

    SET @NewBookingID = -1;
    SET @ErrorMessage = '';

    -- Validate Customer
    IF NOT EXISTS (SELECT 1 FROM CUSTOMER WHERE customer_id = @CustomerID)
    BEGIN
        SET @ErrorMessage = 'Customer not found.';
        RETURN;
    END;

    -- Validate Showtime
    SELECT  @HallNo    = S.hall_no,
            @CinemaID  = S.cinema_id,
            @SlotPrice = SP.slot_price
    FROM    SHOWTIME S
    INNER JOIN SHOWTIME_SLOT_PRICE SP ON S.slot = SP.slot
    WHERE   S.showtime_id = @ShowtimeID;

    IF @HallNo IS NULL
    BEGIN
        SET @ErrorMessage = 'Showtime not found.';
        RETURN;
    END;

    -- Validate Seat exists
    SELECT  @SeatPrice = STV.seat_price
    FROM    SEAT ST
    INNER JOIN SEAT_TYPE_VALUE STV ON ST.seat_type = STV.seat_type
    WHERE   ST.seat_no   = @SeatNo
      AND   ST.hall_no   = @HallNo
      AND   ST.cinema_id = @CinemaID;

    IF @SeatPrice IS NULL
    BEGIN
        SET @ErrorMessage = 'Seat not found in this hall.';
        RETURN;
    END;

    -- Validate Seat is not already reserved
    IF EXISTS (
        SELECT 1 FROM RESERVATION
        WHERE  showtime_id = @ShowtimeID
          AND  seat_no     = @SeatNo
          AND  hall_no     = @HallNo
          AND  cinema_id   = @CinemaID
    )
    BEGIN
        SET @ErrorMessage = 'Seat is already reserved for this showtime.';
        RETURN;
    END;

    -- All checks passed — insert
    SET @TotalPrice = @SeatPrice + @SlotPrice;

    INSERT INTO BOOKING (customer_id, booking_date, booking_status)
    VALUES (@CustomerID, CAST(GETDATE() AS DATE), 'pending');
    SET @NewBookingID = SCOPE_IDENTITY();

    INSERT INTO PAYMENT (booking_id, payment_method, payment_date, amount, payment_status)
    VALUES (@NewBookingID, @PaymentMethod, CAST(GETDATE() AS DATE), @TotalPrice, 'pending');

    INSERT INTO TICKET (booking_id)
    VALUES (@NewBookingID);
    SET @NewTicketID = SCOPE_IDENTITY();

    INSERT INTO RESERVATION (ticket_id, seat_no, showtime_id, hall_no, cinema_id, price)
    VALUES (@NewTicketID, @SeatNo, @ShowtimeID, @HallNo, @CinemaID, @TotalPrice);

    -- Return the new booking details to the GUI
    SELECT  B.booking_id,
            B.booking_date,
            B.booking_status,
            P.amount,
            P.payment_method,
            P.payment_status
    FROM    BOOKING B
    INNER JOIN PAYMENT P ON B.booking_id = P.booking_id
    WHERE   B.booking_id = @NewBookingID;
END;

GO
USE [master]
GO
ALTER DATABASE [CinemaTicketBooking] SET  READ_WRITE 
GO
