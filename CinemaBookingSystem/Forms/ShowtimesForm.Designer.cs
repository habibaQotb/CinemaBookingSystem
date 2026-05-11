// CinemaBookingSystem/Forms/ShowtimesForm.Designer.cs
namespace CinemaBookingSystem.Forms
{
    partial class ShowtimesForm
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
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblSlotFilter = new System.Windows.Forms.Label();
            this.cmbSlotFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter     = new System.Windows.Forms.Button();
            this.dgvShowtimes  = new System.Windows.Forms.DataGridView();
            this.lblSelected   = new System.Windows.Forms.Label();
            this.btnBook       = new System.Windows.Forms.Button();
            this.btnBack       = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvShowtimes)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "Showtimes for: ";
            this.lblTitle.Size      = new System.Drawing.Size(820, 36);
            this.lblTitle.Location  = new System.Drawing.Point(20, 10);
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.lblTitle.TabIndex  = 0;

            // lblSlotFilter
            this.lblSlotFilter.Name     = "lblSlotFilter";
            this.lblSlotFilter.Text     = "Show:";
            this.lblSlotFilter.Size     = new System.Drawing.Size(50, 24);
            this.lblSlotFilter.Location = new System.Drawing.Point(20, 58);
            this.lblSlotFilter.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSlotFilter.TabIndex = 1;

            // cmbSlotFilter
            this.cmbSlotFilter.Name          = "cmbSlotFilter";
            this.cmbSlotFilter.Size          = new System.Drawing.Size(130, 24);
            this.cmbSlotFilter.Location      = new System.Drawing.Point(75, 55);
            this.cmbSlotFilter.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSlotFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSlotFilter.TabIndex      = 2;

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

            // dgvShowtimes
            this.dgvShowtimes.Name                  = "dgvShowtimes";
            this.dgvShowtimes.Size                  = new System.Drawing.Size(820, 380);
            this.dgvShowtimes.Location              = new System.Drawing.Point(20, 95);
            this.dgvShowtimes.ReadOnly              = true;
            this.dgvShowtimes.AllowUserToAddRows    = false;
            this.dgvShowtimes.AllowUserToDeleteRows = false;
            this.dgvShowtimes.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowtimes.MultiSelect           = false;
            this.dgvShowtimes.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowtimes.BackgroundColor       = System.Drawing.Color.White;
            this.dgvShowtimes.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvShowtimes.TabIndex              = 4;
            this.dgvShowtimes.SelectionChanged     += new System.EventHandler(this.dgvShowtimes_SelectionChanged);

            // lblSelected
            this.lblSelected.Name     = "lblSelected";
            this.lblSelected.Text     = "Selected: (none)";
            this.lblSelected.Size     = new System.Drawing.Size(600, 22);
            this.lblSelected.Location = new System.Drawing.Point(20, 485);
            this.lblSelected.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSelected.TabIndex = 5;

            // btnBook
            this.btnBook.Name      = "btnBook";
            this.btnBook.Text      = "Book This Showtime →";
            this.btnBook.Size      = new System.Drawing.Size(200, 32);
            this.btnBook.Location  = new System.Drawing.Point(610, 510);
            this.btnBook.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.TabIndex  = 6;
            this.btnBook.Click    += new System.EventHandler(this.btnBook_Click);

            // btnBack
            this.btnBack.Name      = "btnBack";
            this.btnBack.Text      = "← Back";
            this.btnBack.Size      = new System.Drawing.Size(90, 32);
            this.btnBack.Location  = new System.Drawing.Point(20, 510);
            this.btnBack.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.TabIndex  = 7;
            this.btnBack.Click    += new System.EventHandler(this.btnBack_Click);

            // Controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSlotFilter);
            this.Controls.Add(this.cmbSlotFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dgvShowtimes);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnBack);

            ((System.ComponentModel.ISupportInitialize)(this.dgvShowtimes)).EndInit();

            // Form
            this.ClientSize    = new System.Drawing.Size(860, 560);
            this.Text          = "Showtimes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name          = "ShowtimesForm";
            this.BackColor     = System.Drawing.Color.WhiteSmoke;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.Label        lblSlotFilter;
        private System.Windows.Forms.ComboBox     cmbSlotFilter;
        private System.Windows.Forms.Button       btnFilter;
        private System.Windows.Forms.DataGridView dgvShowtimes;
        private System.Windows.Forms.Label        lblSelected;
        private System.Windows.Forms.Button       btnBook;
        private System.Windows.Forms.Button       btnBack;
    }
}
