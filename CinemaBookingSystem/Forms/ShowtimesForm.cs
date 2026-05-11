// CinemaBookingSystem/Forms/ShowtimesForm.cs
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaBookingSystem.Forms
{
    public partial class ShowtimesForm : Form
    {
        private readonly int    _movieId;
        private readonly string _movieTitle;

        public ShowtimesForm(int movieId, string movieTitle)
        {
            InitializeComponent();

            _movieId    = movieId;
            _movieTitle = movieTitle;

            lblTitle.Text = "Showtimes for: " + _movieTitle;

            cmbSlotFilter.Items.AddRange(new object[] { "All", "Today", "Weekend" });
            cmbSlotFilter.SelectedIndex = 0;

            LoadShowtimes();
        }

        private void LoadShowtimes()
        {
            try
            {
                DataTable dt = DBHelper.GetShowtimesByMovie(_movieId);
                BindShowtimesGrid(dt, new string[]
                    { "showtime_id", "Cinema Name", "City", "Hall No", "Slot", "Date", "Slot Price" },
                    new string[]
                    { "showtime_id", "cinema_name", "city", "hall_no", "slot", "date", "slot_price" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading showtimes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindShowtimesGrid(DataTable dt,
            string[] displayHeaders, string[] sourceColumns)
        {
            DataTable display = new DataTable();
            foreach (string h in displayHeaders)
                display.Columns.Add(h);

            foreach (DataRow src in dt.Rows)
            {
                DataRow row = display.NewRow();
                for (int i = 0; i < displayHeaders.Length; i++)
                    row[displayHeaders[i]] = src[sourceColumns[i]];
                display.Rows.Add(row);
            }

            dgvShowtimes.DataSource = display;

            if (dgvShowtimes.Columns.Contains("showtime_id"))
                dgvShowtimes.Columns["showtime_id"].Visible = false;

            lblSelected.Text = "Selected: (none)";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string slotType = cmbSlotFilter.SelectedItem?.ToString() ?? "All";
            try
            {
                if (slotType == "All")
                {
                    LoadShowtimes();
                    return;
                }

                DataTable dt = DBHelper.GetMoviesBySlotType(slotType);

                // Filter to only show rows matching this movie's title, then bind
                DataTable display = new DataTable();
                display.Columns.Add("showtime_id");
                display.Columns.Add("Cinema Name");
                display.Columns.Add("City");
                display.Columns.Add("Hall No");
                display.Columns.Add("Slot");
                display.Columns.Add("Date");
                display.Columns.Add("Slot Price");

                foreach (DataRow src in dt.Rows)
                {
                    // fn_GetMoviesBySlotType returns movie_title — filter to current movie
                    if (src["movie_title"].ToString() != _movieTitle) continue;

                    DataRow row = display.NewRow();
                    row["showtime_id"] = src["showtime_id"];
                    row["Cinema Name"] = src["cinema_name"];
                    row["City"]        = src["city"];
                    row["Hall No"]     = DBNull.Value;   // not returned by the TVF
                    row["Slot"]        = src["slot"];
                    row["Date"]        = src["show_date"];
                    row["Slot Price"]  = src["slot_price"];
                    display.Rows.Add(row);
                }

                dgvShowtimes.DataSource = display;

                if (dgvShowtimes.Columns.Contains("showtime_id"))
                    dgvShowtimes.Columns["showtime_id"].Visible = false;

                lblSelected.Text = "Selected: (none)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering showtimes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvShowtimes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShowtimes.SelectedRows.Count > 0)
            {
                DataGridViewRow r    = dgvShowtimes.SelectedRows[0];
                string cinemaName   = r.Cells["Cinema Name"].Value?.ToString() ?? "";
                string date         = r.Cells["Date"].Value?.ToString() ?? "";
                string slot         = r.Cells["Slot"].Value?.ToString() ?? "";
                lblSelected.Text    = $"Selected: {cinemaName} | {date} | {slot}";
            }
            else
            {
                lblSelected.Text = "Selected: (none)";
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (dgvShowtimes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a showtime first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selected = dgvShowtimes.SelectedRows[0];
            int    showtimeId  = Convert.ToInt32(selected.Cells["showtime_id"].Value);
            string cinemaName  = selected.Cells["Cinema Name"].Value?.ToString() ?? "";
            string slot        = selected.Cells["Slot"].Value?.ToString() ?? "";
            string date        = selected.Cells["Date"].Value?.ToString() ?? "";

            new BookingForm(showtimeId, _movieTitle, cinemaName, slot, date).ShowDialog(this);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
