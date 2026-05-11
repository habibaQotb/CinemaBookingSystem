// CinemaBookingSystem/Forms/MyTicketsForm.Designer.cs
namespace CinemaBookingSystem.Forms
{
    partial class MyTicketsForm
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
            this.lblTitle       = new System.Windows.Forms.Label();
            this.lblSubtitle    = new System.Windows.Forms.Label();
            this.dgvTickets     = new System.Windows.Forms.DataGridView();
            this.lblTicketCount = new System.Windows.Forms.Label();
            this.btnRefresh     = new System.Windows.Forms.Button();
            this.btnBack        = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "My Tickets";
            this.lblTitle.Size      = new System.Drawing.Size(910, 36);
            this.lblTitle.Location  = new System.Drawing.Point(20, 10);
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.lblTitle.TabIndex  = 0;

            // lblSubtitle
            this.lblSubtitle.Name     = "lblSubtitle";
            this.lblSubtitle.Text     = "All your reservations in one place";
            this.lblSubtitle.Size     = new System.Drawing.Size(910, 22);
            this.lblSubtitle.Location = new System.Drawing.Point(20, 50);
            this.lblSubtitle.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.TabIndex = 1;

            // dgvTickets
            this.dgvTickets.Name                  = "dgvTickets";
            this.dgvTickets.Size                  = new System.Drawing.Size(910, 400);
            this.dgvTickets.Location              = new System.Drawing.Point(20, 78);
            this.dgvTickets.ReadOnly              = true;
            this.dgvTickets.AllowUserToAddRows    = false;
            this.dgvTickets.AllowUserToDeleteRows = false;
            this.dgvTickets.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTickets.MultiSelect           = false;
            this.dgvTickets.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.BackgroundColor       = System.Drawing.Color.White;
            this.dgvTickets.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTickets.TabIndex              = 2;

            // lblTicketCount
            this.lblTicketCount.Name     = "lblTicketCount";
            this.lblTicketCount.Text     = "Total Tickets: 0";
            this.lblTicketCount.Size     = new System.Drawing.Size(400, 22);
            this.lblTicketCount.Location = new System.Drawing.Point(20, 488);
            this.lblTicketCount.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTicketCount.TabIndex = 3;

            // btnRefresh
            this.btnRefresh.Name      = "btnRefresh";
            this.btnRefresh.Text      = "↻ Refresh";
            this.btnRefresh.Size      = new System.Drawing.Size(100, 30);
            this.btnRefresh.Location  = new System.Drawing.Point(720, 510);
            this.btnRefresh.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.TabIndex  = 4;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            // btnBack
            this.btnBack.Name      = "btnBack";
            this.btnBack.Text      = "← Back to Menu";
            this.btnBack.Size      = new System.Drawing.Size(140, 30);
            this.btnBack.Location  = new System.Drawing.Point(830, 510);
            this.btnBack.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.TabIndex  = 5;
            this.btnBack.Click    += new System.EventHandler(this.btnBack_Click);

            // Controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.lblTicketCount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBack);

            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();

            // Form
            this.ClientSize    = new System.Drawing.Size(950, 560);
            this.Text          = "My Tickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name          = "MyTicketsForm";
            this.BackColor     = System.Drawing.Color.WhiteSmoke;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.Label        lblSubtitle;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Label        lblTicketCount;
        private System.Windows.Forms.Button       btnRefresh;
        private System.Windows.Forms.Button       btnBack;
    }
}
