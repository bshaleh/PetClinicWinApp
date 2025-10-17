namespace PetClinicWinApp.Forms.Admin
{
    partial class SalariesForm
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
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnAddSalary = new System.Windows.Forms.Button();
            this.lblStaffFilter = new System.Windows.Forms.Label();
            this.ddlStaffFilter = new System.Windows.Forms.ComboBox();
            this.dgvSalaries = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(363, 20);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(109, 43);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Text = "تصفية";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnAddSalary
            // 
            this.btnAddSalary.Location = new System.Drawing.Point(792, 23);
            this.btnAddSalary.Name = "btnAddSalary";
            this.btnAddSalary.Size = new System.Drawing.Size(109, 43);
            this.btnAddSalary.TabIndex = 0;
            this.btnAddSalary.Text = "إضافة راتب جديد";
            this.btnAddSalary.UseVisualStyleBackColor = true;
            this.btnAddSalary.Click += new System.EventHandler(this.btnAddSalary_Click);
            // 
            // lblStaffFilter
            // 
            this.lblStaffFilter.AutoSize = true;
            this.lblStaffFilter.Location = new System.Drawing.Point(27, 36);
            this.lblStaffFilter.Name = "lblStaffFilter";
            this.lblStaffFilter.Size = new System.Drawing.Size(124, 17);
            this.lblStaffFilter.TabIndex = 1;
            this.lblStaffFilter.Text = "فلتر حسب الموظف:";
            // 
            // ddlStaffFilter
            // 
            this.ddlStaffFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStaffFilter.FormattingEnabled = true;
            this.ddlStaffFilter.Location = new System.Drawing.Point(168, 33);
            this.ddlStaffFilter.Name = "ddlStaffFilter";
            this.ddlStaffFilter.Size = new System.Drawing.Size(167, 24);
            this.ddlStaffFilter.TabIndex = 2;
            this.ddlStaffFilter.SelectedIndexChanged += new System.EventHandler(this.ddlStaffFilter_SelectedIndexChanged);
            // 
            // dgvSalaries
            // 
            this.dgvSalaries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalaries.Location = new System.Drawing.Point(41, 82);
            this.dgvSalaries.Name = "dgvSalaries";
            this.dgvSalaries.ReadOnly = true;
            this.dgvSalaries.RowTemplate.Height = 26;
            this.dgvSalaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalaries.Size = new System.Drawing.Size(860, 325);
            this.dgvSalaries.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Lime;
            this.lblTotal.Location = new System.Drawing.Point(37, 428);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(262, 24);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "إجمالي الرواتب: 0.00 ر.س";
            // 
            // SalariesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 461);
            this.Controls.Add(this.dgvSalaries);
            this.Controls.Add(this.ddlStaffFilter);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblStaffFilter);
            this.Controls.Add(this.btnAddSalary);
            this.Controls.Add(this.btnFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SalariesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إدارة الرواتب";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnAddSalary;
        private System.Windows.Forms.Label lblStaffFilter;
        private System.Windows.Forms.ComboBox ddlStaffFilter;
        private System.Windows.Forms.DataGridView dgvSalaries;
        private System.Windows.Forms.Label lblTotal;
    }
}