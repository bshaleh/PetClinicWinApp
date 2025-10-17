namespace PetClinicWinApp.Forms.Staff
{
    partial class AddStaffForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlPosition = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.ddlBranch = new System.Windows.Forms.ComboBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.lblMessage = new System.Windows.Forms.Label();
            this.ddlUserAccount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(108, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlPosition
            // 
            this.ddlPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPosition.FormattingEnabled = true;
            this.ddlPosition.Items.AddRange(new object[] {
            "Doctor",
            "Receptionist",
            "Nurse",
            "Admin"});
            this.ddlPosition.Location = new System.Drawing.Point(73, 65);
            this.ddlPosition.Name = "ddlPosition";
            this.ddlPosition.Size = new System.Drawing.Size(221, 24);
            this.ddlPosition.TabIndex = 13;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(73, 149);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(221, 24);
            this.txtEmail.TabIndex = 10;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(73, 112);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(221, 24);
            this.txtPhone.TabIndex = 11;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(73, 24);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(221, 24);
            this.txtFullName.TabIndex = 12;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(390, 204);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 17);
            this.lblBranch.TabIndex = 4;
            this.lblBranch.Text = "الفرع:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(388, 159);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(43, 17);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "البريد:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(382, 115);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(49, 17);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "الهاتف:";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(376, 68);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(55, 17);
            this.lblPosition.TabIndex = 7;
            this.lblPosition.Text = "الوظيفة:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(343, 27);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(88, 17);
            this.lblFullName.TabIndex = 8;
            this.lblFullName.Text = "الاسم الكامل:";
            // 
            // ddlBranch
            // 
            this.ddlBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBranch.FormattingEnabled = true;
            this.ddlBranch.Location = new System.Drawing.Point(73, 201);
            this.ddlBranch.Name = "ddlBranch";
            this.ddlBranch.Size = new System.Drawing.Size(221, 24);
            this.ddlBranch.TabIndex = 16;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(385, 247);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(46, 17);
            this.lblSalary.TabIndex = 4;
            this.lblSalary.Text = "الراتب:";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(73, 244);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(221, 24);
            this.txtSalary.TabIndex = 10;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new System.Drawing.Point(347, 289);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(84, 17);
            this.lblHireDate.TabIndex = 4;
            this.lblHireDate.Text = "تاريخ التعيين:";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.CustomFormat = "yyyy-MM-dd";
            this.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHireDate.Location = new System.Drawing.Point(94, 286);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(200, 24);
            this.dtpHireDate.TabIndex = 17;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(38, 422);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 4;
            // 
            // ddlUserAccount
            // 
            this.ddlUserAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUserAccount.FormattingEnabled = true;
            this.ddlUserAccount.Location = new System.Drawing.Point(73, 326);
            this.ddlUserAccount.Name = "ddlUserAccount";
            this.ddlUserAccount.Size = new System.Drawing.Size(221, 24);
            this.ddlUserAccount.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "حساب المستخدم:";
            // 
            // AddStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 448);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.ddlUserAccount);
            this.Controls.Add(this.ddlBranch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ddlPosition);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblFullName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddStaffForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "إضافة موظف";
            this.Load += new System.EventHandler(this.AddStaffForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlPosition;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.ComboBox ddlBranch;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ComboBox ddlUserAccount;
        private System.Windows.Forms.Label label1;
    }
}