// CinemaBookingSystem/Forms/MoviesForm.Designer.cs
namespace CinemaBookingSystem.Forms
{
    partial class MoviesForm
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
            this.lblTitle        = new System.Windows.Forms.Label();
            this.lblGenre        = new System.Windows.Forms.Label();
            this.cmbGenre        = new System.Windows.Forms.ComboBox();
            this.btnFilter       = new System.Windows.Forms.Button();
            this.btnClearFilter  = new System.Windows.Forms.Button();
            this.dgvMovies       = new System.Windows.Forms.DataGridView();
            this.lblSelected     = new System.Windows.Forms.Label();
            this.lblCount        = new System.Windows.Forms.Label();
            this.btnViewShowtimes = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Text      = "Browse Movies";
            this.lblTitle.Size      = new System.Drawing.Size(820, 36);
            this.lblTitle.Location  = new System.Drawing.Point(20, 10);
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.lblTitle.TabIndex  = 0;

            // lblGenre
            this.lblGenre.Name     = "lblGenre";
            this.lblGenre.Text     = "Filter by Genre:";
            this.lblGenre.Size     = new System.Drawing.Size(110, 24);
            this.lblGenre.Location = new System.Drawing.Point(20, 58);
            this.lblGenre.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGenre.TabIndex = 1;

            // cmbGenre
            this.cmbGenre.Name          = "cmbGenre";
            this.cmbGenre.Size          = new System.Drawing.Size(160, 24);
            this.cmbGenre.Location      = new System.Drawing.Point(135, 55);
            this.cmbGenre.Font          = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.TabIndex      = 2;

            // btnFilter
            this.btnFilter.Name      = "btnFilter";
            this.btnFilter.Text      = "Filter";
            this.btnFilter.Size      = new System.Drawing.Size(80, 28);
            this.btnFilter.Location  = new System.Drawing.Point(305, 53);
            this.btnFilter.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.TabIndex  = 3;
            this.btnFilter.Click    += new System.EventHandler(this.btnFilter_Click);

            // btnClearFilter
            this.btnClearFilter.Name      = "btnClearFilter";
            this.btnClearFilter.Text      = "Show All";
            this.btnClearFilter.Size      = new System.Drawing.Size(80, 28);
            this.btnClearFilter.Location  = new System.Drawing.Point(395, 53);
            this.btnClearFilter.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.TabIndex  = 4;
            this.btnClearFilter.Click    += new System.EventHandler(this.btnClearFilter_Click);

            // dgvMovies
            this.dgvMovies.Name                  = "dgvMovies";
            this.dgvMovies.Size                  = new System.Drawing.Size(820, 400);
            this.dgvMovies.Location              = new System.Drawing.Point(20, 95);
            this.dgvMovies.ReadOnly              = true;
            this.dgvMovies.AllowUserToAddRows    = false;
            this.dgvMovies.AllowUserToDeleteRows = false;
            this.dgvMovies.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovies.MultiSelect           = false;
            this.dgvMovies.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovies.BackgroundColor       = System.Drawing.Color.White;
            this.dgvMovies.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvMovies.TabIndex              = 5;
            this.dgvMovies.SelectionChanged     += new System.EventHandler(this.dgvMovies_SelectionChanged);

            // lblSelected
            this.lblSelected.Name     = "lblSelected";
            this.lblSelected.Text     = "Selected: (none)";
            this.lblSelected.Size     = new System.Drawing.Size(500, 22);
            this.lblSelected.Location = new System.Drawing.Point(20, 505);
            this.lblSelected.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSelected.TabIndex = 6;

            // lblCount
            this.lblCount.Name     = "lblCount";
            this.lblCount.Text     = "Showing 0 movies";
            this.lblCount.Size     = new System.Drawing.Size(300, 22);
            this.lblCount.Location = new System.Drawing.Point(540, 505);
            this.lblCount.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.TabIndex = 7;

            // btnViewShowtimes
            this.btnViewShowtimes.Name      = "btnViewShowtimes";
            this.btnViewShowtimes.Text      = "View Showtimes →";
            this.btnViewShowtimes.Size      = new System.Drawing.Size(180, 32);
            this.btnViewShowtimes.Location  = new System.Drawing.Point(660, 530);
            this.btnViewShowtimes.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewShowtimes.BackColor = System.Drawing.Color.FromArgb(30, 30, 80);
            this.btnViewShowtimes.ForeColor = System.Drawing.Color.White;
            this.btnViewShowtimes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewShowtimes.TabIndex  = 8;
            this.btnViewShowtimes.Click    += new System.EventHandler(this.btnViewShowtimes_Click);

            // Controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.dgvMovies);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnViewShowtimes);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).EndInit();

            // Form
            this.ClientSize    = new System.Drawing.Size(860, 580);
            this.Text          = "Movies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name          = "MoviesForm";
            this.BackColor     = System.Drawing.Color.WhiteSmoke;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label           lblTitle;
        private System.Windows.Forms.Label           lblGenre;
        private System.Windows.Forms.ComboBox        cmbGenre;
        private System.Windows.Forms.Button          btnFilter;
        private System.Windows.Forms.Button          btnClearFilter;
        private System.Windows.Forms.DataGridView    dgvMovies;
        private System.Windows.Forms.Label           lblSelected;
        private System.Windows.Forms.Label           lblCount;
        private System.Windows.Forms.Button          btnViewShowtimes;
    }
}
