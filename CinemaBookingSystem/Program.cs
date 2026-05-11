// CinemaBookingSystem/Program.cs
using System;
using System.Windows.Forms;
using CinemaBookingSystem.Forms;

namespace CinemaBookingSystem
{
    static class Program
    {
        // Session state — set at login, cleared on logout
        public static int CurrentCustomerID = 0;
        public static string CurrentCustomerName = string.Empty;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
