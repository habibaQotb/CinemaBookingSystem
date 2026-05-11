// CinemaBookingSystem/Forms/MainForm.cs
using System;
using System.Windows.Forms;

namespace CinemaBookingSystem.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblWelcome.Text = "Welcome, " + Program.CurrentCustomerName + "!";
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            new MoviesForm().ShowDialog(this);
        }

        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            new MyBookingsForm().ShowDialog(this);
        }

        private void btnMyTickets_Click(object sender, EventArgs e)
        {
            new MyTicketsForm().ShowDialog(this);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.CurrentCustomerID   = 0;
            Program.CurrentCustomerName = string.Empty;
            this.Close();
        }
    }
}
