// CinemaBookingSystem/Forms/MyBookingsForm.cs
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaBookingSystem.Forms
{
    public partial class MyBookingsForm : Form
    {
        public MyBookingsForm()
        {
            InitializeComponent();

            cmbFilter.Items.AddRange(new object[] { "All", "Confirmed", "Cancelled" });
            cmbFilter.SelectedIndex = 0;

            LoadData();
        }

        private void LoadData()
        {
            LoadBookings("All");
            LoadSummaryLabels();
        }

        private void LoadBookings(string summaryType)
        {
            try
            {
                // Always use GetCustomerBookingSummary for consistent columns
                // (includes movie_title, show_date, slot, payment_method)
                DataTable dt = DBHelper.GetCustomerBookingSummary(Program.CurrentCustomerID, summaryType);
                BindSummaryBookings(dt);
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text      = "Error loading bookings: " + ex.Message;
            }
        }

        private void BindBasicBookings(DataTable dt)
        {
            DataTable display = new DataTable();
            display.Columns.Add("Booking ID");
            display.Columns.Add("Booking Date");
            display.Columns.Add("Booking Status");
            display.Columns.Add("Amount Paid");
            display.Columns.Add("Payment Method");
            display.Columns.Add("Payment Status");

            foreach (DataRow src in dt.Rows)
            {
                DataRow row = display.NewRow();
                row["Booking ID"]      = src["booking_id"];
                row["Booking Date"]    = src["booking_date"];
                row["Booking Status"]  = src["booking_status"];
                row["Amount Paid"]     = src["amount"];
                row["Payment Method"]  = src["payment_method"];
                row["Payment Status"]  = src["payment_status"];
                display.Rows.Add(row);
            }

            dgvBookings.DataSource = display;
        }

        private void BindSummaryBookings(DataTable dt)
        {
            DataTable display = new DataTable();
            display.Columns.Add("Booking ID");
            display.Columns.Add("Booking Date");
            display.Columns.Add("Booking Status");
            display.Columns.Add("Movie Title");
            display.Columns.Add("Show Date");
            display.Columns.Add("Slot");
            display.Columns.Add("Amount Paid");
            display.Columns.Add("Payment Status");

            foreach (DataRow src in dt.Rows)
            {
                DataRow row = display.NewRow();
                row["Booking ID"]     = src["booking_id"];
                row["Booking Date"]   = src["booking_date"];
                row["Booking Status"] = src["booking_status"];
                row["Movie Title"]    = src["movie_title"];
                row["Show Date"]      = src["show_date"];
                row["Slot"]           = src["slot"];
                row["Amount Paid"]    = src["amount"];
                row["Payment Status"] = src["payment_status"];
                display.Rows.Add(row);
            }

            dgvBookings.DataSource = display;
        }

        private void LoadSummaryLabels()
        {
            try
            {
                decimal totalSpent   = DBHelper.GetCustomerTotalSpent(Program.CurrentCustomerID);
                int     bookingCount = DBHelper.CountCustomerBookings(Program.CurrentCustomerID);

                lblTotalSpent.Text   = "Total Spent: " + totalSpent.ToString("F2") + " EGP";
                lblBookingCount.Text = "Total Bookings: " + bookingCount;
            }
            catch (Exception ex)
            {
                lblTotalSpent.Text   = "Total Spent: —";
                lblBookingCount.Text = "Total Bookings: —";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = cmbFilter.SelectedItem?.ToString() ?? "All";
            lblResult.Text = "";
            LoadBookings(filter);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text      = "Please select a booking to cancel.";
                return;
            }

            DataGridViewRow selected = dgvBookings.SelectedRows[0];
            object bookingIdObj = selected.Cells["Booking ID"].Value;
            if (bookingIdObj == null) return;

            int bookingId = Convert.ToInt32(bookingIdObj);

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to cancel booking #" + bookingId + "?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool   success;
                string errorMessage;
                DBHelper.CancelBooking(bookingId, Program.CurrentCustomerID, out success, out errorMessage);

                if (success)
                {
                    lblResult.ForeColor = System.Drawing.Color.DarkGreen;
                    lblResult.Text      = "Booking #" + bookingId + " has been cancelled.";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text      = "Cancel failed: " + errorMessage;
                }

                LoadData();
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text      = "Error: " + ex.Message;
            }
        }

        private void btnConfirmPay_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text      = "Please select a booking to confirm payment.";
                return;
            }

            DataGridViewRow selected = dgvBookings.SelectedRows[0];
            object bookingIdObj = selected.Cells["Booking ID"].Value;
            if (bookingIdObj == null) return;

            int bookingId = Convert.ToInt32(bookingIdObj);

            try
            {
                bool   success;
                string errorMessage;
                DBHelper.ConfirmPayment(bookingId, Program.CurrentCustomerID, out success, out errorMessage);

                if (success)
                {
                    lblResult.ForeColor = System.Drawing.Color.DarkGreen;
                    lblResult.Text      = "Payment confirmed for booking #" + bookingId + ".";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text      = "Confirm failed: " + errorMessage;
                }

                LoadData();
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text      = "Error: " + ex.Message;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            cmbFilter.SelectedIndex = 0;
            LoadData();
        }
    }
}
