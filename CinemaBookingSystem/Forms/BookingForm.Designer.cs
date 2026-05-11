// CinemaBookingSystem/Forms/BookingForm.Designer.cs
namespace CinemaBookingSystem.Forms
{
    partial class BookingForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMovieInfo = new System.Windows.Forms.Label();
            this.lblDateInfo = new System.Windows.Forms.Label();
            this.lblSelectSeat = new System.Windows.Forms.Label();
            this.dgvSeats = new System.Windows.Forms.DataGridView();
            this.lblPriceSummary = new System.Windows.Forms.Label();
            this.lblSlotPrice = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblPayMethod = new System.Windows.Forms.Label();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(660, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Book Your Seat";
            // 
            // lblMovieInfo
            // 
            this.lblMovieInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMovieInfo.Location = new System.Drawing.Point(20, 52);
            this.lblMovieInfo.Name = "lblMovieInfo";
            this.lblMovieInfo.Size = new System.Drawing.Size(660, 24);
            this.lblMovieInfo.TabIndex = 1;
            this.lblMovieInfo.Click += new System.EventHandler(this.lblMovieInfo_Click);
            // 
            // lblDateInfo
            // 
            this.lblDateInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateInfo.Location = new System.Drawing.Point(20, 76);
            this.lblDateInfo.Name = "lblDateInfo";
            this.lblDateInfo.Size = new System.Drawing.Size(660, 24);
            this.lblDateInfo.TabIndex = 2;
            // 
            // lblSelectSeat
            // 
            this.lblSelectSeat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectSeat.Location = new System.Drawing.Point(20, 108);
            this.lblSelectSeat.Name = "lblSelectSeat";
            this.lblSelectSeat.Size = new System.Drawing.Size(200, 22);
            this.lblSelectSeat.TabIndex = 3;
            this.lblSelectSeat.Text = "Available Seats:";
            // 
            // dgvSeats
            // 
            this.dgvSeats.AllowUserToAddRows = false;
            this.dgvSeats.AllowUserToDeleteRows = false;
            this.dgvSeats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSeats.BackgroundColor = System.Drawing.Color.White;
            this.dgvSeats.ColumnHeadersHeight = 34;
            this.dgvSeats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvSeats.Location = new System.Drawing.Point(20, 133);
            this.dgvSeats.MultiSelect = false;
            this.dgvSeats.Name = "dgvSeats";
            this.dgvSeats.ReadOnly = true;
            this.dgvSeats.RowHeadersWidth = 62;
            this.dgvSeats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeats.Size = new System.Drawing.Size(350, 220);
            this.dgvSeats.TabIndex = 4;
            // 
            // lblPriceSummary
            // 
            this.lblPriceSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPriceSummary.Location = new System.Drawing.Point(390, 133);
            this.lblPriceSummary.Name = "lblPriceSummary";
            this.lblPriceSummary.Size = new System.Drawing.Size(290, 22);
            this.lblPriceSummary.TabIndex = 5;
            // 
            // lblSlotPrice
            // 
            this.lblSlotPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSlotPrice.Location = new System.Drawing.Point(390, 160);
            this.lblSlotPrice.Name = "lblSlotPrice";
            this.lblSlotPrice.Size = new System.Drawing.Size(290, 22);
            this.lblSlotPrice.TabIndex = 6;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(390, 190);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(290, 28);
            this.lblTotalPrice.TabIndex = 7;
            // 
            // lblPayMethod
            // 
            this.lblPayMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPayMethod.Location = new System.Drawing.Point(390, 240);
            this.lblPayMethod.Name = "lblPayMethod";
            this.lblPayMethod.Size = new System.Drawing.Size(130, 24);
            this.lblPayMethod.TabIndex = 8;
            this.lblPayMethod.Text = "Payment Method:";
            // 
            // cmbPayment
            // 
            this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPayment.Location = new System.Drawing.Point(390, 264);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(180, 40);
            this.cmbPayment.TabIndex = 9;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(390, 305);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(140, 30);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "Calculate Price";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(480, 480);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(180, 32);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Confirm Booking";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.Location = new System.Drawing.Point(20, 480);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 32);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "← Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(20, 520);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(660, 40);
            this.lblResult.TabIndex = 13;
            // 
            // BookingForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(700, 570);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMovieInfo);
            this.Controls.Add(this.lblDateInfo);
            this.Controls.Add(this.lblSelectSeat);
            this.Controls.Add(this.dgvSeats);
            this.Controls.Add(this.lblPriceSummary);
            this.Controls.Add(this.lblSlotPrice);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblPayMethod);
            this.Controls.Add(this.cmbPayment);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblResult);
            this.Name = "BookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book a Seat";
            this.Load += new System.EventHandler(this.BookingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.Label        lblMovieInfo;
        private System.Windows.Forms.Label        lblDateInfo;
        private System.Windows.Forms.Label        lblSelectSeat;
        private System.Windows.Forms.DataGridView dgvSeats;
        private System.Windows.Forms.Label        lblPriceSummary;
        private System.Windows.Forms.Label        lblSlotPrice;
        private System.Windows.Forms.Label        lblTotalPrice;
        private System.Windows.Forms.Label        lblPayMethod;
        private System.Windows.Forms.ComboBox     cmbPayment;
        private System.Windows.Forms.Button       btnCalculate;
        private System.Windows.Forms.Button       btnConfirm;
        private System.Windows.Forms.Button       btnBack;
        private System.Windows.Forms.Label        lblResult;
    }
}
