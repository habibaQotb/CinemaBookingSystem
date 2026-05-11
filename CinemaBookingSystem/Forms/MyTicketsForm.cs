// CinemaBookingSystem/Forms/MyTicketsForm.cs
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaBookingSystem.Forms
{
    public partial class MyTicketsForm : Form
    {
        public MyTicketsForm()
        {
            InitializeComponent();
            LoadTickets();
        }

        private void LoadTickets()
        {
            try
            {
                DataTable dt = DBHelper.GetMyTickets(Program.CurrentCustomerID);

                DataTable display = new DataTable();
                display.Columns.Add("Ticket ID");
                display.Columns.Add("Booking ID");
                display.Columns.Add("Movie Title");
                display.Columns.Add("Cinema Name");
                display.Columns.Add("City");
                display.Columns.Add("Slot");
                display.Columns.Add("Show Date");
                display.Columns.Add("Seat No");
                display.Columns.Add("Seat Type");
                display.Columns.Add("Ticket Price");
                display.Columns.Add("Booking Status");
                display.Columns.Add("Booking Date");

                foreach (DataRow src in dt.Rows)
                {
                    DataRow row = display.NewRow();
                    row["Ticket ID"]      = src["ticket_id"];
                    row["Booking ID"]     = src["booking_id"];
                    row["Movie Title"]    = src["movie_title"];
                    row["Cinema Name"]    = src["cinema_name"];
                    row["City"]           = src["city"];
                    row["Slot"]           = src["slot"];
                    row["Show Date"]      = src["show_date"];
                    row["Seat No"]        = src["seat_no"];
                    row["Seat Type"]      = src["seat_type"];
                    row["Ticket Price"]   = src["ticket_price"];
                    row["Booking Status"] = src["booking_status"];
                    row["Booking Date"]   = src["booking_date"];
                    display.Rows.Add(row);
                }

                dgvTickets.DataSource    = display;
                lblTicketCount.Text      = "Total Tickets: " + display.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tickets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTickets();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
