// CinemaBookingSystem/Forms/BookingForm.cs
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaBookingSystem.Forms
{
    public partial class BookingForm : Form
    {
        private readonly int    _showtimeId;
        private readonly string _movieTitle;
        private readonly string _cinemaName;
        private readonly string _slot;
        private readonly string _date;

        // Stored after price calculation for display breakdown
        private decimal _lastTotalPrice = 0m;

        public BookingForm(int showtimeId, string movieTitle, string cinemaName,
                           string slot, string date)
        {
            InitializeComponent();

            _showtimeId = showtimeId;
            _movieTitle = movieTitle;
            _cinemaName = cinemaName;
            _slot       = slot;
            _date       = date;

            lblMovieInfo.Text = _movieTitle + " | " + _cinemaName;
            lblDateInfo.Text  = _date + " | " + _slot;

            cmbPayment.Items.AddRange(new object[] { "Credit Card", "Cash", "Vodafone Cash" });
            cmbPayment.SelectedIndex = 0;

            LoadAvailableSeats();
        }

        private void LoadAvailableSeats()
        {
            try
            {
                DataTable dt = DBHelper.GetAvailableSeats(_showtimeId);

                DataTable display = new DataTable();
                display.Columns.Add("Seat Number");
                display.Columns.Add("Seat Type");
                display.Columns.Add("Base Price");

                foreach (DataRow src in dt.Rows)
                {
                    DataRow row = display.NewRow();
                    row["Seat Number"] = src["seat_no"];
                    row["Seat Type"]   = src["seat_type"];
                    row["Base Price"]  = src["seat_price"];
                    display.Rows.Add(row);
                }

                dgvSeats.DataSource = display;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading seats: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (dgvSeats.SelectedRows.Count == 0)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text      = "Please select a seat first.";
                return;
            }

            try
            {
                int seatNo = Convert.ToInt32(dgvSeats.SelectedRows[0].Cells["Seat Number"].Value);
                decimal total = DBHelper.CalcTicketPrice(_showtimeId, seatNo);

                // Retrieve base seat price from grid for display
                decimal seatPrice = Convert.ToDecimal(dgvSeats.SelectedRows[0].Cells["Base Price"].Value);
                decimal slotPrice = total - seatPrice;

                _lastTotalPrice         = total;
                lblPriceSummary.Text    = "Seat base price:  " + seatPrice.ToString("F2") + " EGP";
                lblSlotPrice.Text       = "Slot surcharge:   " + slotPrice.ToString("F2") + " EGP";
                lblTotalPrice.Text      = "Total:  " + total.ToString("F2") + " EGP";

                lblResult.Text = "";
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text      = "Price calculation error: " + ex.Message;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvSeats.SelectedRows.Count == 0)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text      = "Please select a seat first.";
                return;
            }

            int    seatNo        = Convert.ToInt32(dgvSeats.SelectedRows[0].Cells["Seat Number"].Value);
            string paymentMethod = cmbPayment.SelectedItem?.ToString() ?? "Credit Card";

            try
            {
                int    newBookingId;
                string errorMessage;

                DBHelper.MakeBooking(Program.CurrentCustomerID, _showtimeId, seatNo,
                    paymentMethod, out newBookingId, out errorMessage);

                if (newBookingId > 0)
                {
                    lblResult.ForeColor = System.Drawing.Color.DarkGreen;
                    lblResult.Text      = "Booking confirmed! Booking ID: " + newBookingId;
                    btnConfirm.Enabled  = false;
                    LoadAvailableSeats(); // Refresh to remove booked seat
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text      = "Booking failed: " + errorMessage;
                }
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text      = "Error: " + ex.Message;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMovieInfo_Click(object sender, EventArgs e)
        {

        }

        private void BookingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
