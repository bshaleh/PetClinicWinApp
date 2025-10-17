namespace PetClinicWinApp.Forms.Appointments
{
    partial class BookAppointmentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ddlPet = new System.Windows.Forms.ComboBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.ddlStaff = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAppointment = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPet = new System.Windows.Forms.Button();
            this.ddlBranch = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlBranchID = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "الحيوان:";
            // 
            // ddlPet
            // 
            this.ddlPet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPet.FormattingEnabled = true;
            this.ddlPet.Location = new System.Drawing.Point(158, 46);
            this.ddlPet.Name = "ddlPet";
            this.ddlPet.Size = new System.Drawing.Size(245, 24);
            this.ddlPet.TabIndex = 1;
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(487, 92);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(53, 17);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "الطبيب:";
            // 
            // ddlStaff
            // 
            this.ddlStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStaff.FormattingEnabled = true;
            this.ddlStaff.Location = new System.Drawing.Point(158, 90);
            this.ddlStaff.Name = "ddlStaff";
            this.ddlStaff.Size = new System.Drawing.Size(245, 24);
            this.ddlStaff.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "تاريخ ووقت الموعد:";
            // 
            // dtpAppointment
            // 
            this.dtpAppointment.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointment.Location = new System.Drawing.Point(158, 132);
            this.dtpAppointment.Name = "dtpAppointment";
            this.dtpAppointment.ShowUpDown = true;
            this.dtpAppointment.Size = new System.Drawing.Size(245, 24);
            this.dtpAppointment.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "سبب الزيارة:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(158, 213);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(245, 61);
            this.txtReason.TabIndex = 3;
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(123, 298);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(123, 47);
            this.btnBook.TabIndex = 4;
            this.btnBook.Text = "حجز الموعد";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(295, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 47);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddPet
            // 
            this.btnAddPet.Location = new System.Drawing.Point(12, 46);
            this.btnAddPet.Name = "btnAddPet";
            this.btnAddPet.Size = new System.Drawing.Size(114, 23);
            this.btnAddPet.TabIndex = 5;
            this.btnAddPet.Text = "إضافة حيوان";
            this.btnAddPet.UseVisualStyleBackColor = true;
            this.btnAddPet.Click += new System.EventHandler(this.btnAddPet_Click);
            // 
            // ddlBranch
            // 
            this.ddlBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBranch.FormattingEnabled = true;
            this.ddlBranch.Location = new System.Drawing.Point(158, 174);
            this.ddlBranch.Name = "ddlBranch";
            this.ddlBranch.Size = new System.Drawing.Size(200, 24);
            this.ddlBranch.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(495, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "الفرع :";
            // 
            // ddlBranchID
            // 
            this.ddlBranchID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBranchID.Enabled = false;
            this.ddlBranchID.FormattingEnabled = true;
            this.ddlBranchID.Location = new System.Drawing.Point(364, 174);
            this.ddlBranchID.Name = "ddlBranchID";
            this.ddlBranchID.Size = new System.Drawing.Size(39, 24);
            this.ddlBranchID.TabIndex = 1;
            // 
            // BookAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 388);
            this.Controls.Add(this.btnAddPet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.dtpAppointment);
            this.Controls.Add(this.ddlBranchID);
            this.Controls.Add(this.ddlBranch);
            this.Controls.Add(this.ddlStaff);
            this.Controls.Add(this.ddlPet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BookAppointmentForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "حجز موعد جديد";
            this.Load += new System.EventHandler(this.BookAppointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlPet;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.ComboBox ddlStaff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpAppointment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddPet;
        private System.Windows.Forms.ComboBox ddlBranch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlBranchID;
    }
}