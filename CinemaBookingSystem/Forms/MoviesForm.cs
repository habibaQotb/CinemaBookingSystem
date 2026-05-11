// CinemaBookingSystem/Forms/MoviesForm.cs
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaBookingSystem.Forms
{
    public partial class MoviesForm : Form
    {
        public MoviesForm()
        {
            InitializeComponent();

            // Populate genre combo
            cmbGenre.Items.AddRange(new object[] { "All", "Sci-Fi", "Animation", "Family", "Classic", "Comedy" });
            cmbGenre.SelectedIndex = 0;

            LoadAllMovies();
        }

        private void LoadAllMovies()
        {
            try
            {
                DataTable dt = DBHelper.GetAllMovies();
                BindMoviesGrid(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movies: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindMoviesGrid(DataTable dt)
        {
            // Build display table with Duration Label column added
            DataTable display = new DataTable();
            display.Columns.Add("movie_id");
            display.Columns.Add("Title");
            display.Columns.Add("Duration (min)");
            display.Columns.Add("Duration Label");
            display.Columns.Add("Language");
            display.Columns.Add("Genre");

            foreach (DataRow src in dt.Rows)
            {
                string label = string.Empty;
                try
                {
                    label = DBHelper.GetMovieDurationLabel(Convert.ToInt32(src["movie_id"]));
                }
                catch { label = "Unknown"; }

                DataRow row = display.NewRow();
                row["movie_id"]       = src["movie_id"];
                row["Title"]          = src["title"];
                row["Duration (min)"] = src["duration_min"];
                row["Duration Label"] = label;
                row["Language"]       = src["language"];
                row["Genre"]          = src["Mgenre"];
                display.Rows.Add(row);
            }

            dgvMovies.DataSource = display;

            // Hide internal ID column
            if (dgvMovies.Columns.Contains("movie_id"))
                dgvMovies.Columns["movie_id"].Visible = false;

            lblCount.Text    = "Showing " + display.Rows.Count + " movies";
            lblSelected.Text = "Selected: (none)";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string genre = cmbGenre.SelectedItem?.ToString() ?? "All";
            try
            {
                if (genre == "All")
                {
                    LoadAllMovies();
                }
                else
                {
                    DataTable dt = DBHelper.GetMoviesByGenre(genre);
                    BindMoviesGrid(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering movies: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbGenre.SelectedIndex = 0;
            LoadAllMovies();
        }

        private void dgvMovies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count > 0)
            {
                string title = dgvMovies.SelectedRows[0].Cells["Title"].Value?.ToString() ?? "";
                lblSelected.Text = "Selected: " + title;
            }
            else
            {
                lblSelected.Text = "Selected: (none)";
            }
        }

        private void btnViewShowtimes_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a movie first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selected = dgvMovies.SelectedRows[0];
            int    movieId    = Convert.ToInt32(selected.Cells["movie_id"].Value);
            string movieTitle = selected.Cells["Title"].Value?.ToString() ?? "";

            new ShowtimesForm(movieId, movieTitle).ShowDialog(this);
        }
    }
}
