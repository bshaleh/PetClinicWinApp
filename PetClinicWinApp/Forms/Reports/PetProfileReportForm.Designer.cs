namespace PetClinicWinApp.Forms.Reports
{
    partial class PetProfileReportForm
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
            this.lblPetName = new System.Windows.Forms.Label();
            this.lblOwnerInfo = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMedical = new System.Windows.Forms.TabPage();
            this.dgvMedical = new System.Windows.Forms.DataGridView();
            this.tabVaccinations = new System.Windows.Forms.TabPage();
            this.dgvVaccinations = new System.Windows.Forms.DataGridView();
            this.tabSurgeries = new System.Windows.Forms.TabPage();
            this.dgvSurgeries = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPetCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tabControl1.SuspendLayout();
            this.tabMedical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedical)).BeginInit();
            this.tabVaccinations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinations)).BeginInit();
            this.tabSurgeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurgeries)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPetName
            // 
            this.lblPetName.AutoSize = true;
            this.lblPetName.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblPetName.Location = new System.Drawing.Point(733, 9);
            this.lblPetName.Name = "lblPetName";
            this.lblPetName.Size = new System.Drawing.Size(97, 33);
            this.lblPetName.TabIndex = 0;
            this.lblPetName.Text = "label1";
            // 
            // lblOwnerInfo
            // 
            this.lblOwnerInfo.AutoSize = true;
            this.lblOwnerInfo.Location = new System.Drawing.Point(905, 61);
            this.lblOwnerInfo.Name = "lblOwnerInfo";
            this.lblOwnerInfo.Size = new System.Drawing.Size(42, 17);
            this.lblOwnerInfo.TabIndex = 1;
            this.lblOwnerInfo.Text = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMedical);
            this.tabControl1.Controls.Add(this.tabVaccinations);
            this.tabControl1.Controls.Add(this.tabSurgeries);
            this.tabControl1.Location = new System.Drawing.Point(40, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1018, 343);
            this.tabControl1.TabIndex = 2;
            // 
            // tabMedical
            // 
            this.tabMedical.Controls.Add(this.dgvMedical);
            this.tabMedical.Location = new System.Drawing.Point(4, 25);
            this.tabMedical.Name = "tabMedical";
            this.tabMedical.Padding = new System.Windows.Forms.Padding(3);
            this.tabMedical.Size = new System.Drawing.Size(1010, 314);
            this.tabMedical.TabIndex = 0;
            this.tabMedical.Text = "السجلات الطبية";
            this.tabMedical.UseVisualStyleBackColor = true;
            // 
            // dgvMedical
            // 
            this.dgvMedical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedical.Location = new System.Drawing.Point(0, 3);
            this.dgvMedical.Name = "dgvMedical";
            this.dgvMedical.ReadOnly = true;
            this.dgvMedical.RowTemplate.Height = 26;
            this.dgvMedical.Size = new System.Drawing.Size(1032, 305);
            this.dgvMedical.TabIndex = 0;
            // 
            // tabVaccinations
            // 
            this.tabVaccinations.Controls.Add(this.dgvVaccinations);
            this.tabVaccinations.Location = new System.Drawing.Point(4, 25);
            this.tabVaccinations.Name = "tabVaccinations";
            this.tabVaccinations.Padding = new System.Windows.Forms.Padding(3);
            this.tabVaccinations.Size = new System.Drawing.Size(1010, 314);
            this.tabVaccinations.TabIndex = 1;
            this.tabVaccinations.Text = "التطعيمات";
            this.tabVaccinations.UseVisualStyleBackColor = true;
            // 
            // dgvVaccinations
            // 
            this.dgvVaccinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccinations.Location = new System.Drawing.Point(6, 6);
            this.dgvVaccinations.Name = "dgvVaccinations";
            this.dgvVaccinations.ReadOnly = true;
            this.dgvVaccinations.RowTemplate.Height = 26;
            this.dgvVaccinations.Size = new System.Drawing.Size(998, 302);
            this.dgvVaccinations.TabIndex = 0;
            // 
            // tabSurgeries
            // 
            this.tabSurgeries.Controls.Add(this.dgvSurgeries);
            this.tabSurgeries.Location = new System.Drawing.Point(4, 25);
            this.tabSurgeries.Name = "tabSurgeries";
            this.tabSurgeries.Padding = new System.Windows.Forms.Padding(3);
            this.tabSurgeries.Size = new System.Drawing.Size(1010, 314);
            this.tabSurgeries.TabIndex = 2;
            this.tabSurgeries.Text = "العمليات";
            this.tabSurgeries.UseVisualStyleBackColor = true;
            // 
            // dgvSurgeries
            // 
            this.dgvSurgeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurgeries.Location = new System.Drawing.Point(6, 6);
            this.dgvSurgeries.Name = "dgvSurgeries";
            this.dgvSurgeries.RowTemplate.Height = 26;
            this.dgvSurgeries.Size = new System.Drawing.Size(998, 302);
            this.dgvSurgeries.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(935, 448);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(123, 36);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "طباعة التقرير";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(776, 448);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(974, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "اسم المالك :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(862, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "اسم الحيوان : ";
            // 
            // lblPetCode
            // 
            this.lblPetCode.AutoSize = true;
            this.lblPetCode.Location = new System.Drawing.Point(447, 26);
            this.lblPetCode.Name = "lblPetCode";
            this.lblPetCode.Size = new System.Drawing.Size(42, 17);
            this.lblPetCode.TabIndex = 1;
            this.lblPetCode.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "كود الحيوان :";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // PetProfileReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 513);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPetCode);
            this.Controls.Add(this.lblOwnerInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPetName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PetProfileReportForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تقرير الحيوان";
            this.tabControl1.ResumeLayout(false);
            this.tabMedical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedical)).EndInit();
            this.tabVaccinations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinations)).EndInit();
            this.tabSurgeries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurgeries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPetName;
        private System.Windows.Forms.Label lblOwnerInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMedical;
        private System.Windows.Forms.DataGridView dgvMedical;
        private System.Windows.Forms.TabPage tabVaccinations;
        private System.Windows.Forms.DataGridView dgvVaccinations;
        private System.Windows.Forms.TabPage tabSurgeries;
        private System.Windows.Forms.DataGridView dgvSurgeries;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPetCode;
        private System.Windows.Forms.Label label4;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}