namespace PetClinicWinApp.Forms.Appointments
{
    partial class AppointmentsListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.ddlStatusFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnCancelAppointment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDateFilter
            // 
            this.dtpDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFilter.Location = new System.Drawing.Point(534, 28);
            this.dtpDateFilter.Name = "dtpDateFilter";
            this.dtpDateFilter.Size = new System.Drawing.Size(194, 24);
            this.dtpDateFilter.TabIndex = 0;
            // 
            // ddlStatusFilter
            // 
            this.ddlStatusFilter.FormattingEnabled = true;
            this.ddlStatusFilter.Items.AddRange(new object[] {
            "الكل",
            "Scheduled",
            "Completed",
            "Cancelled"});
            this.ddlStatusFilter.Location = new System.Drawing.Point(534, 85);
            this.ddlStatusFilter.Name = "ddlStatusFilter";
            this.ddlStatusFilter.Size = new System.Drawing.Size(194, 24);
            this.ddlStatusFilter.TabIndex = 1;
            this.ddlStatusFilter.SelectedIndexChanged += new System.EventHandler(this.ddlStatusFilter_SelectedIndexChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(138, 85);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(164, 43);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "تصفية";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(585, 395);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(164, 43);
            this.btnBook.TabIndex = 2;
            this.btnBook.Text = "حجز موعد";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(333, 85);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(164, 43);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvAppointments.Location = new System.Drawing.Point(41, 147);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowTemplate.Height = 26;
            this.dgvAppointments.Size = new System.Drawing.Size(719, 227);
            this.dgvAppointments.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "تاريخ الموعد";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "اسم الحيوان";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "المالك";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "الطبيب";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "السبب";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "الحالة";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(60, 395);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(164, 43);
            this.btnCheckIn.TabIndex = 2;
            this.btnCheckIn.Text = "تسجيل الحضور";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(262, 28);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(194, 24);
            this.dtpTo.TabIndex = 0;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(754, 28);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(26, 17);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "من";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(471, 28);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(29, 17);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "الى";
            // 
            // btnCancelAppointment
            // 
            this.btnCancelAppointment.Location = new System.Drawing.Point(398, 395);
            this.btnCancelAppointment.Name = "btnCancelAppointment";
            this.btnCancelAppointment.Size = new System.Drawing.Size(151, 43);
            this.btnCancelAppointment.TabIndex = 5;
            this.btnCancelAppointment.Text = "إلغاء الموعد";
            this.btnCancelAppointment.UseVisualStyleBackColor = true;
            this.btnCancelAppointment.Click += new System.EventHandler(this.btnCancelAppointment_Click);
            // 
            // AppointmentsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 473);
            this.Controls.Add(this.btnCancelAppointment);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.ddlStatusFilter);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpDateFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AppointmentsListForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "قائمة المواعيد";
            this.Load += new System.EventHandler(this.AppointmentsListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateFilter;
        private System.Windows.Forms.ComboBox ddlStatusFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnCancelAppointment;
    }
}