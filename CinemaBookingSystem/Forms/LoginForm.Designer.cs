// CinemaBookingSystem/Forms/LoginForm.Designer.cs
namespace CinemaBookingSystem.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle    = new System.Windows.Forms.Label();
            this.lblEmail    = new System.Windows.Forms.Label();
            this.txtEmail    = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin    = new System.Windows.Forms.Button();
            this.lblError    = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "🎬 Cinema Booking System";
            this.lblTitle.Size      = new System.Drawing.Size(380, 36);
            this.lblTitle.Location  = new System.Drawing.Point(20, 20);
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.TabIndex  = 0;

            // lblEmail
            this.lblEmail.Name     = "lblEmail";
            this.lblEmail.Text     = "Email";
            this.lblEmail.Size     = new System.Drawing.Size(360, 20);
            this.lblEmail.Location = new System.Drawing.Point(30, 80);
            this.lblEmail.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.TabIndex = 1;

            // txtEmail
            this.txtEmail.Name     = "txtEmail";
            this.txtEmail.Size     = new System.Drawing.Size(360, 24);
            this.txtEmail.Location = new System.Drawing.Point(30, 102);
            this.txtEmail.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.TabIndex = 2;

            // lblPassword
            this.lblPassword.Name     = "lblPassword";
            this.lblPassword.Text     = "Password";
            this.lblPassword.Size     = new System.Drawing.Size(360, 20);
            this.lblPassword.Location = new System.Drawing.Point(30, 140);
            this.lblPassword.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.TabIndex = 3;

            // txtPassword
            this.txtPassword.Name         = "txtPassword";
            this.txtPassword.Size         = new System.Drawing.Size(360, 24);
            this.txtPassword.Location     = new System.Drawing.Point(30, 162);
            this.txtPassword.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.TabIndex     = 4;

            // btnLogin
            this.btnLogin.Name      = "btnLogin";
            this.btnLogin.Text      = "Login";
            this.btnLogin.Size      = new System.Drawing.Size(360, 36);
            this.btnLogin.Location  = new System.Drawing.Point(30, 210);
            this.btnLogin.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.TabIndex  = 5;
            this.btnLogin.Click    += new System.EventHandler(this.btnLogin_Click);

            // lblError
            this.lblError.Name      = "lblError";
            this.lblError.Text      = "";
            this.lblError.Size      = new System.Drawing.Size(360, 40);
            this.lblError.Location  = new System.Drawing.Point(30, 258);
            this.lblError.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Visible   = false;
            this.lblError.TabIndex  = 6;

            // Controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblError);

            // Form
            this.ClientSize         = new System.Drawing.Size(420, 320);
            this.Text               = "Cinema Booking System — Login";
            this.StartPosition      = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle    = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox        = false;
            this.Name               = "LoginForm";
            this.BackColor          = System.Drawing.Color.WhiteSmoke;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label   lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button  btnLogin;
        private System.Windows.Forms.Label   lblError;
    }
}
