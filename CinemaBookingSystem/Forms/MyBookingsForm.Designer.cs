// CinemaBookingSystem/Forms/MyBookingsForm.Designer.cs
namespace CinemaBookingSystem.Forms
{
    partial class MyBookingsForm
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
            this.lblTitle         = new System.Windows.Forms.Label();
            this.lblFilter        = new System.Windows.Forms.Label();
            this.cmbFilter        = new System.Windows.Forms.ComboBox();
            this.btnFilter        = new System.Windows.Forms.Button();
            this.dgvBookings      = new System.Windows.Forms.DataGridView();
            this.lblTotalSpent    = new System.Windows.Forms.Label();
            this.lblBookingCount  = new System.Windows.Forms.Label();
            this.btnCancel        = new System.Windows.Forms.Button();
            this.btnConfirmPay    = new System.Windows.Forms.Button();
            this.btnRefresh       = new System.Windows.Forms.Button();
            this.lblResult        = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "My Bookings";
            this.lblTitle.Size      = new System.Drawing.Size(860, 36);
            this.lblTitle.Location  = new System.Drawing.Point(20, 10);
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.lblTitle.TabIndex  = 0;

            // lblFilter
            this.lblFilter.Name     = "lblFilter";
            this.lblFilter.Text     = "Show:";
            this.lblFilter.Size     = new System.Drawing.Size(50, 24);
            this.lblFilter.Location = new System.Drawing.Point(20, 58);
            this.lblFilter.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilter.TabIndex = 1;

            // cmbFilter
            this.cmbFilter.Name          = "cmbFilter";
            this.cmbFilter.Size          = new System.Drawing.Size(130, 24);
            this.cmbFilter.Location      = new System.Drawing.Point(75, 55);
            this.cmbFilter.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.TabIndex      = 2;

            // btnFilter
            this.btnFilter.Name      = "btnFilter";
            this.btnFilter.Text      = "Filter";
            this.btnFilter.Size      = new System.Drawing.Size(80, 28);
            this.btnFilter.Location  = new System.Drawing.Point(215, 53);
            this.btnFilter.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.TabIndex  = 3;
            this.btnFilter.Click    += new System.EventHandler(this.btnFilter_Click);

            // dgvBookings
            this.dgvBookings.Name                  = "dgvBookings";
            this.dgvBookings.Size                  = new System.Drawing.Size(860, 360);
            this.dgvBookings.Location              = new System.Drawing.Point(20, 95);
            this.dgvBookings.ReadOnly              = true;
            this.dgvBookings.AllowUserToAddRows    = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.MultiSelect           = false;
            this.dgvBookings.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.BackgroundColor       = System.Drawing.Color.White;
            this.dgvBookings.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvBookings.TabIndex              = 4;

            // lblTotalSpent
            this.lblTotalSpent.Name     = "lblTotalSpent";
            this.lblTotalSpent.Text     = "Total Spent: —";
            this.lblTotalSpent.Size     = new System.Drawing.Size(300, 22);
            this.lblTotalSpent.Location = new System.Drawing.Point(20, 465);
            this.lblTotalSpent.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalSpent.TabIndex = 5;

            // lblBookingCount
            this.lblBookingCount.Name     = "lblBookingCount";
            this.lblBookingCount.Text     = "Total Bookings: —";
            this.lblBookingCount.Size     = new System.Drawing.Size(300, 22);
            this.lblBookingCount.Location = new System.Drawing.Point(340, 465);
            this.lblBookingCount.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBookingCount.TabIndex = 6;

            // btnCancel
            this.btnCancel.Name      = "btnCancel";
            this.btnCancel.Text      = "Cancel Selected Booking";
            this.btnCancel.Size      = new System.Drawing.Size(200, 30);
            this.btnCancel.Location  = new System.Drawing.Point(20, 495);
            this.btnCancel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.TabIndex  = 7;
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);

            // btnConfirmPay
            this.btnConfirmPay.Name      = "btnConfirmPay";
            this.btnConfirmPay.Text      = "Confirm Payment";
            this.btnConfirmPay.Size      = new System.Drawing.Size(180, 30);
            this.btnConfirmPay.Location  = new System.Drawing.Point(235, 495);
            this.btnConfirmPay.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnConfirmPay.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConfirmPay.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPay.TabIndex  = 8;
            this.btnConfirmPay.Click    += new System.EventHandler(this.btnConfirmPay_Click);

            // btnRefresh
            this.btnRefresh.Name      = "btnRefresh";
            this.btnRefresh.Text      = "↻ Refresh";
            this.btnRefresh.Size      = new System.Drawing.Size(100, 30);
            this.btnRefresh.Location  = new System.Drawing.Point(430, 495);
            this.btnRefresh.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.TabIndex  = 9;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            // lblResult
            this.lblResult.Name     = "lblResult";
            this.lblResult.Text     = "";
            this.lblResult.Size     = new System.Drawing.Size(860, 40);
            this.lblResult.Location = new System.Drawing.Point(20, 530);
            this.lblResult.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResult.TabIndex = 10;

            // Controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dgvBookings);
            this.Controls.Add(this.lblTotalSpent);
            this.Controls.Add(this.lblBookingCount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmPay);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblResult);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();

            // Form
            this.ClientSize    = new System.Drawing.Size(900, 580);
            this.Text          = "My Bookings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name          = "MyBookingsForm";
            this.BackColor     = System.Drawing.Color.WhiteSmoke;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.Label        lblFilter;
        private System.Windows.Forms.ComboBox     cmbFilter;
        private System.Windows.Forms.Button       btnFilter;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Label        lblTotalSpent;
        private System.Windows.Forms.Label        lblBookingCount;
        private System.Windows.Forms.Button       btnCancel;
        private System.Windows.Forms.Button       btnConfirmPay;
        private System.Windows.Forms.Button       btnRefresh;
        private System.Windows.Forms.Label        lblResult;
    }
}
