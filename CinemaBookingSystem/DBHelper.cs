// CinemaBookingSystem/DBHelper.cs
using System;
using System.Data;
using System.Data.SqlClient;

namespace CinemaBookingSystem
{
    public static class DBHelper
    {
        private static readonly string connectionString =
            "Data Source=localhost;Initial Catalog=CinemaTicketBooking;Integrated Security=True;Encrypt=False";

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // -------------------------------------------------------
        // AUTHENTICATION
        // -------------------------------------------------------
        /// <summary>
        /// Returns a DataRow for the matched customer, or null if not found.
        /// </summary>
        public static DataRow GetCustomerByEmailPassword(string email, string password)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT customer_id, first_name, last_name, email FROM CUSTOMER WHERE email = @Email AND password = @Password",
                    conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.Parameters.Add(new SqlParameter("@Password", password));

                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Columns.Add("customer_id");
                tbl.Columns.Add("first_name");
                tbl.Columns.Add("last_name");
                tbl.Columns.Add("email");

                DataRow row = null;
                if (rdr.Read())
                {
                    row = tbl.NewRow();
                    row["customer_id"] = rdr["customer_id"];
                    row["first_name"]  = rdr["first_name"];
                    row["last_name"]   = rdr["last_name"];
                    row["email"]       = rdr["email"];
                    tbl.Rows.Add(row);
                }
                rdr.Close();
                return row;
            }
            finally
            {
                conn.Close();
            }
        }

        // -------------------------------------------------------
        // MOVIES
        // -------------------------------------------------------
        /// <summary>sp_GetAllMovies</summary>
        public static DataTable GetAllMovies()
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetAllMovies", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Columns.Add("movie_id");
                tbl.Columns.Add("title");
                tbl.Columns.Add("description");
                tbl.Columns.Add("duration_min");
                tbl.Columns.Add("language");
                tbl.Columns.Add("Mgenre");

                while (rdr.Read())
                {
                    DataRow row = tbl.NewRow();
                    row["movie_id"]     = rdr["movie_id"];
                    row["title"]        = rdr["title"];
                    row["description"]  = rdr["description"];
                    row["duration_min"] = rdr["duration_min"];
                    row["language"]     = rdr["language"];
                    row["Mgenre"]       = rdr["Mgenre"];
                    tbl.Rows.Add(row);
                }
                rdr.Close();
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>sp_GetMoviesByGenre</summary>
        public static DataTable GetMoviesByGenre(string genre)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetMoviesByGenre", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Genre", genre));

                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Columns.Add("movie_id");
                tbl.Columns.Add("title");
                tbl.Columns.Add("duration_min");
                tbl.Columns.Add("language");
                tbl.Columns.Add("Mgenre");

                while (rdr.Read())
                {
                    DataRow row = tbl.NewRow();
                    row["movie_id"]     = rdr["movie_id"];
                    row["title"]        = rdr["title"];
                    row["duration_min"] = rdr["duration_min"];
                    row["language"]     = rdr["language"];
                    row["Mgenre"]       = rdr["Mgenre"];
                    tbl.Rows.Add(row);
                }
                rdr.Close();
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>SELECT dbo.fn_GetMovieDurationLabel(@MovieID)</summary>
        public static string GetMovieDurationLabel(int movieId)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT dbo.fn_GetMovieDurationLabel(@MovieID)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@MovieID", movieId));

                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Unknown";
            }
            finally
            {
                conn.Close();
            }
        }

        // -------------------------------------------------------
        // SHOWTIMES
        // -------------------------------------------------------
        /// <summary>sp_GetShowtimesByMovie</summary>
        public static DataTable GetShowtimesByMovie(int movieId)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetShowtimesByMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MovieID", movieId));

                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Columns.Add("showtime_id");
                tbl.Columns.Add("title");
                tbl.Columns.Add("cinema_name");
                tbl.Columns.Add("city");
                tbl.Columns.Add("hall_no");
                tbl.Columns.Add("slot");
                tbl.Columns.Add("date");
                tbl.Columns.Add("slot_price");

                while (rdr.Read())
                {
                    DataRow row = tbl.NewRow();
                    row["showtime_id"] = rdr["showtime_id"];
                    row["title"]       = rdr["title"];
                    row["cinema_name"] = rdr["cinema_name"];
                    row["city"]        = rdr["city"];
                    row["hall_no"]     = rdr["hall_no"];
                    row["slot"]        = rdr["slot"];
                    row["date"]        = rdr["date"];
                    row["slot_price"]  = rdr["slot_price"];
                    tbl.Rows.Add(row);
                }
                rdr.Close();
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>SELECT * FROM dbo.fn_GetMoviesBySlotType(@SlotType)</summary>
        public static DataTable GetMoviesBySlotType(string slotType)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM dbo.fn_GetMoviesBySlotType(@SlotType)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@SlotType", slotType));

                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Columns.Add("showtime_id");
                tbl.Columns.Add("movie_title");
                tbl.Columns.Add("cinema_name");
                tbl.Columns.Add("city");
                tbl.Columns.Add("slot");
                tbl.Columns.Add("show_date");
                tbl.Columns.Add("slot_price");

                while (rdr.Read())
                {
                    DataRow row = tbl.NewRow();
                    row["showtime_id"] = rdr["showtime_id"];
                    row["movie_title"] = rdr["movie_title"];
                    row["cinema_name"] = rdr["cinema_name"];
                    row["city"]        = rdr["city"];
                    row["slot"]        = rdr["slot"];
                    row["show_date"]   = rdr["show_date"];
                    row["slot_price"]  = rdr["slot_price"];
                    tbl.Rows.Add(row);
                }
                rdr.Close();
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }

        // -------------------------------------------------------
        // SEATS
        // -------------------------------------------------------
        /// <summary>sp_GetAvailableSeats</summary>
        public static DataTable GetAvailableSeats(int showtimeId)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetAvailableSeats", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ShowtimeID", showtimeId));

                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Columns.Add("seat_no");
                tbl.Columns.Add("seat_type");
                tbl.Columns.Add("seat_price");

                while (rdr.Read())
                {
                    DataRow row = tbl.NewRow();
                    row["seat_no"]    = rdr["seat_no"];
                    row["seat_type"]  = rdr["seat_type"];
                    row["seat_price"] = rdr["seat_price"];
                    tbl.Rows.Add(row);
                }
                rdr.Close();
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>SELECT dbo.fn_CalcTicketPrice(@ShowtimeID, @SeatNo)</summary>
        public static decimal CalcTicketPrice(int showtimeId, int seatNo)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT dbo.fn_CalcTicketPrice(@ShowtimeID, @SeatNo)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@ShowtimeID", showtimeId));
                cmd.Parameters.Add(new SqlParameter("@SeatNo", seatNo));

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0m;
            }
            finally
            {
                conn.Close();
            }
        }

        // -------------------------------------------------------
        // BOOKING
        // -------------------------------------------------------
        /// <summary>sp_MakeBooking — OUTPUT params: @NewBookingID, @ErrorMessage</summary>
        public static void MakeBooking(int customerId, int showtimeId, int seatNo,
            string paymentMethod, out int newBookingId, out string errorMessage)
        {
            newBookingId   = -1;
            errorMessage   = string.Empty;

            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_MakeBooking", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CustomerID",    customerId));
                cmd.Parameters.Add(new SqlParameter("@ShowtimeID",    showtimeId));
                cmd.Parameters.Add(new SqlParameter("@SeatNo",        seatNo));
                cmd.Parameters.Add(new SqlParameter("@PaymentMethod", paymentMethod));

                SqlParameter pNewBookingId = new SqlParameter("@NewBookingID", SqlDbType.Int);
                pNewBookingId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pNewBookingId);

                SqlParameter pErrorMessage = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 255);
                pErrorMessage.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pErrorMessage);

                // Need to consume the result set before reading output params
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();

                newBookingId = pNewBookingId.Value != DBNull.Value ? Convert.ToInt32(pNewBookingId.Value) : -1;
                errorMessage = pErrorMessage.Value != DBNull.Value ? pErrorMessage.Value.ToString() : string.Empty;
            }
            finally
            {
                conn.Close();
            }
        }

        // -------------------------------------------------------
        // MY BOOKINGS
        // -------------------------------------------------------
        /// <summary>sp_GetMyBookings</summary>
        public static DataTable GetMyBookings(int customerId)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetMyBookings", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CustomerID", customerId));

                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Columns.Add("booking_id");
                tbl.Columns.Add("booking_date");
                tbl.Columns.Add("booking_status");
                tbl.Columns.Add("payment_method");
                tbl.Columns.Add("payment_status");
                tbl.Columns.Add("amount");

                while (rdr.Read())
                {
                    DataRow row = tbl.NewRow();
                    row["booking_id"]      = rdr["booking_id"];
                    row["booking_date"]    = rdr["booking_date"];
                    row["booking_status"]  = rdr["booking_status"];
                    row["payment_method"]  = rdr["payment_method"];
                    row["payment_status"]  = rdr["payment_status"];
                    row["amount"]          = rdr["amount"];
                    tbl.Rows.Add(row);
                }
                rdr.Close();
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>SELECT * FROM dbo.fn_GetCustomerBookingSummary(@CustomerID, @SummaryType)</summary>
        public static DataTable GetCustomerBookingSummary(int customerId, string summaryType)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM dbo.fn_GetCustomerBookingSummary(@CustomerID, @SummaryType)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@CustomerID",  customerId));
                cmd.Parameters.Add(new SqlParameter("@SummaryType", summaryType));

                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Columns.Add("booking_id");
                tbl.Columns.Add("booking_date");
                tbl.Columns.Add("booking_status");
                tbl.Columns.Add("movie_title");
                tbl.Columns.Add("show_date");
                tbl.Columns.Add("slot");
                tbl.Columns.Add("amount");
                tbl.Columns.Add("payment_status");

                while (rdr.Read())
                {
                    DataRow row = tbl.NewRow();
                    row["booking_id"]     = rdr["booking_id"];
                    row["booking_date"]   = rdr["booking_date"];
                    row["booking_status"] = rdr["booking_status"];
                    row["movie_title"]    = rdr["movie_title"];
                    row["show_date"]      = rdr["show_date"];
                    row["slot"]           = rdr["slot"];
                    row["amount"]         = rdr["amount"];
                    row["payment_status"] = rdr["payment_status"];
                    tbl.Rows.Add(row);
                }
                rdr.Close();
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>SELECT dbo.fn_GetCustomerTotalSpent(@CustomerID)</summary>
        public static decimal GetCustomerTotalSpent(int customerId)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT dbo.fn_GetCustomerTotalSpent(@CustomerID)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@CustomerID", customerId));

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0m;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>SELECT dbo.fn_CountCustomerBookings(@CustomerID)</summary>
        public static int CountCustomerBookings(int customerId)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT dbo.fn_CountCustomerBookings(@CustomerID)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@CustomerID", customerId));

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>sp_CancelBooking — OUTPUT: @Success, @ErrorMessage</summary>
        public static void CancelBooking(int bookingId, int customerId,
            out bool success, out string errorMessage)
        {
            success      = false;
            errorMessage = string.Empty;

            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CancelBooking", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@BookingID",  bookingId));
                cmd.Parameters.Add(new SqlParameter("@CustomerID", customerId));

                SqlParameter pSuccess = new SqlParameter("@Success", SqlDbType.Bit);
                pSuccess.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pSuccess);

                SqlParameter pError = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 255);
                pError.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pError);

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();

                success      = pSuccess.Value != DBNull.Value && Convert.ToBoolean(pSuccess.Value);
                errorMessage = pError.Value   != DBNull.Value ? pError.Value.ToString() : string.Empty;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>sp_ConfirmPayment — OUTPUT: @Success, @ErrorMessage</summary>
        public static void ConfirmPayment(int bookingId, int customerId,
            out bool success, out string errorMessage)
        {
            success      = false;
            errorMessage = string.Empty;

            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ConfirmPayment", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@BookingID",  bookingId));
                cmd.Parameters.Add(new SqlParameter("@CustomerID", customerId));

                SqlParameter pSuccess = new SqlParameter("@Success", SqlDbType.Bit);
                pSuccess.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pSuccess);

                SqlParameter pError = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 255);
                pError.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pError);

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Close();

                success      = pSuccess.Value != DBNull.Value && Convert.ToBoolean(pSuccess.Value);
                errorMessage = pError.Value   != DBNull.Value ? pError.Value.ToString() : string.Empty;
            }
            finally
            {
                conn.Close();
            }
        }

        // -------------------------------------------------------
        // MY TICKETS
        // -------------------------------------------------------
        /// <summary>sp_GetMyTickets</summary>
        public static DataTable GetMyTickets(int customerId)
        {
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetMyTickets", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CustomerID", customerId));

                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable tbl = new DataTable();
                tbl.Columns.Add("ticket_id");
                tbl.Columns.Add("booking_id");
                tbl.Columns.Add("booking_date");
                tbl.Columns.Add("movie_title");
                tbl.Columns.Add("cinema_name");
                tbl.Columns.Add("city");
                tbl.Columns.Add("slot");
                tbl.Columns.Add("show_date");
                tbl.Columns.Add("seat_no");
                tbl.Columns.Add("seat_type");
                tbl.Columns.Add("ticket_price");
                tbl.Columns.Add("booking_status");

                while (rdr.Read())
                {
                    DataRow row = tbl.NewRow();
                    row["ticket_id"]      = rdr["ticket_id"];
                    row["booking_id"]     = rdr["booking_id"];
                    row["booking_date"]   = rdr["booking_date"];
                    row["movie_title"]    = rdr["movie_title"];
                    row["cinema_name"]    = rdr["cinema_name"];
                    row["city"]           = rdr["city"];
                    row["slot"]           = rdr["slot"];
                    row["show_date"]      = rdr["show_date"];
                    row["seat_no"]        = rdr["seat_no"];
                    row["seat_type"]      = rdr["seat_type"];
                    row["ticket_price"]   = rdr["ticket_price"];
                    row["booking_status"] = rdr["booking_status"];
                    tbl.Rows.Add(row);
                }
                rdr.Close();
                return tbl;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
