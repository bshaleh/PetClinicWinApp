namespace PetClinicWinApp.Forms.Medical
{
    partial class MedicalRecordsListForm
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
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlPetCode = new System.Windows.Forms.ComboBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlPetFilter
            // 
            this.ddlPetFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetFilter.FormattingEnabled = true;
            this.ddlPetFilter.Location = new System.Drawing.Point(686, 18);
            this.ddlPetFilter.Name = "ddlPetFilter";
            this.ddlPetFilter.Size = new System.Drawing.Size(167, 24);
            this.ddlPetFilter.TabIndex = 0;
            this.ddlPetFilter.SelectedIndexChanged += new System.EventHandler(this.ddlPetFilter_SelectedIndexChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(563, 27);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(102, 33);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "تصفية";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(772, 405);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(184, 33);
            this.btnAddRecord.TabIndex = 1;
            this.btnAddRecord.Text = "إضافة سجل طبي";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // dgvRecords
            // 
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Location = new System.Drawing.Point(21, 80);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.RowTemplate.Height = 26;
            this.dgvRecords.Size = new System.Drawing.Size(935, 310);
            this.dgvRecords.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(873, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "اسم الحيوان";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(880, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "كود الحيوان";
            // 
            // ddlPetCode
            // 
            this.ddlPetCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetCode.FormattingEnabled = true;
            this.ddlPetCode.Location = new System.Drawing.Point(686, 50);
            this.ddlPetCode.Name = "ddlPetCode";
            this.ddlPetCode.Size = new System.Drawing.Size(167, 24);
            this.ddlPetCode.TabIndex = 0;
            this.ddlPetCode.SelectedIndexChanged += new System.EventHandler(this.ddlPetCode_SelectedIndexChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // MedicalRecordsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.ddlPetCode);
            this.Controls.Add(this.ddlPetFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MedicalRecordsListForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سجلات طبية";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlPetFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlPetCode;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}