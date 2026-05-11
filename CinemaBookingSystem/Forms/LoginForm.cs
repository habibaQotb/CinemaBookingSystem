// CinemaBookingSystem/Forms/LoginForm.cs
using System;
using System.Data;
using System.Windows.Forms;

namespace CinemaBookingSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email    = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblError.Text    = "Please enter both email and password.";
                lblError.Visible = true;
                return;
            }

            try
            {
                DataRow customer = DBHelper.GetCustomerByEmailPassword(email, password);

                if (customer == null)
                {
                    lblError.Text    = "Invalid email or password.";
                    lblError.Visible = true;
                    return;
                }

                // Set session state
                Program.CurrentCustomerID   = Convert.ToInt32(customer["customer_id"]);
                Program.CurrentCustomerName = customer["first_name"] + " " + customer["last_name"];

                lblError.Visible = false;
                this.Hide();
                MainForm main = new MainForm();
                main.FormClosed += (s, args) => this.Close();
                main.Show();
            }
            catch (Exception ex)
            {
                lblError.Text    = "Connection error: " + ex.Message;
                lblError.Visible = true;
            }
        }
    }
}
