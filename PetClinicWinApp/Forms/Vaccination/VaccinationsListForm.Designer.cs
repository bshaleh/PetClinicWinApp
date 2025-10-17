namespace PetClinicWinApp.Forms.Vaccination
{
    partial class VaccinationsListForm
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
            this.ddlPetFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnAddVaccination = new System.Windows.Forms.Button();
            this.dgvVaccinations = new System.Windows.Forms.DataGridView();
            this.btnPrintReminder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlPetCode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinations)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlPetFilter
            // 
            this.ddlPetFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetFilter.FormattingEnabled = true;
            this.ddlPetFilter.Location = new System.Drawing.Point(432, 12);
            this.ddlPetFilter.Name = "ddlPetFilter";
            this.ddlPetFilter.Size = new System.Drawing.Size(211, 24);
            this.ddlPetFilter.TabIndex = 0;
            this.ddlPetFilter.SelectedIndexChanged += new System.EventHandler(this.ddlPetFilter_SelectedIndexChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(283, 19);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(107, 32);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "تصفية";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnAddVaccination
            // 
            this.btnAddVaccination.Location = new System.Drawing.Point(658, 397);
            this.btnAddVaccination.Name = "btnAddVaccination";
            this.btnAddVaccination.Size = new System.Drawing.Size(107, 32);
            this.btnAddVaccination.TabIndex = 1;
            this.btnAddVaccination.Text = "تسجيل تطعيم";
            this.btnAddVaccination.UseVisualStyleBackColor = true;
            this.btnAddVaccination.Click += new System.EventHandler(this.btnAddVaccination_Click);
            // 
            // dgvVaccinations
            // 
            this.dgvVaccinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccinations.Location = new System.Drawing.Point(31, 76);
            this.dgvVaccinations.Name = "dgvVaccinations";
            this.dgvVaccinations.ReadOnly = true;
            this.dgvVaccinations.RowTemplate.Height = 26;
            this.dgvVaccinations.Size = new System.Drawing.Size(740, 297);
            this.dgvVaccinations.TabIndex = 2;
            // 
            // btnPrintReminder
            // 
            this.btnPrintReminder.Location = new System.Drawing.Point(31, 397);
            this.btnPrintReminder.Name = "btnPrintReminder";
            this.btnPrintReminder.Size = new System.Drawing.Size(107, 32);
            this.btnPrintReminder.TabIndex = 1;
            this.btnPrintReminder.Text = "طباعة تذكير";
            this.btnPrintReminder.UseVisualStyleBackColor = true;
            this.btnPrintReminder.Click += new System.EventHandler(this.btnPrintReminder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "كود الحيوان";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "اسم الحيوان";
            // 
            // ddlPetCode
            // 
            this.ddlPetCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetCode.FormattingEnabled = true;
            this.ddlPetCode.Location = new System.Drawing.Point(432, 46);
            this.ddlPetCode.Name = "ddlPetCode";
            this.ddlPetCode.Size = new System.Drawing.Size(211, 24);
            this.ddlPetCode.TabIndex = 7;
            this.ddlPetCode.SelectedIndexChanged += new System.EventHandler(this.ddlPetCode_SelectedIndexChanged);
            // 
            // VaccinationsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlPetCode);
            this.Controls.Add(this.dgvVaccinations);
            this.Controls.Add(this.btnAddVaccination);
            this.Controls.Add(this.btnPrintReminder);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.ddlPetFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "VaccinationsListForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "سجلات التطعيمات";
            this.Load += new System.EventHandler(this.VaccinationsListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlPetFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnAddVaccination;
        private System.Windows.Forms.DataGridView dgvVaccinations;
        private System.Windows.Forms.Button btnPrintReminder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlPetCode;
    }
}