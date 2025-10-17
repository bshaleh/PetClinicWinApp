namespace PetClinicWinApp.Forms.Staff
{
    partial class EditStaffForm
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
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.ddlPosition = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.lblBranch = new System.Windows.Forms.Label();
            this.ddlBranch = new System.Windows.Forms.ComboBox();
            this.lblUserAccount = new System.Windows.Forms.Label();
            this.ddlUserAccount = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(321, 48);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(88, 17);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "الاسم الكامل:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(32, 48);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(244, 24);
            this.txtFullName.TabIndex = 1;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(354, 103);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(55, 17);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "الوظيفة:";
            // 
            // ddlPosition
            // 
            this.ddlPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPosition.FormattingEnabled = true;
            this.ddlPosition.Location = new System.Drawing.Point(32, 96);
            this.ddlPosition.Name = "ddlPosition";
            this.ddlPosition.Size = new System.Drawing.Size(244, 24);
            this.ddlPosition.TabIndex = 2;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(336, 144);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(73, 17);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "رقم الجوال:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(32, 144);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(244, 24);
            this.txtPhone.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(304, 192);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(105, 17);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "البريد الإلكتروني:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(32, 192);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(244, 24);
            this.txtEmail.TabIndex = 1;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(311, 241);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(98, 17);
            this.lblSalary.TabIndex = 0;
            this.lblSalary.Text = "الراتب الشهري:";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(32, 241);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(244, 24);
            this.txtSalary.TabIndex = 1;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new System.Drawing.Point(320, 291);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(89, 17);
            this.lblHireDate.TabIndex = 0;
            this.lblHireDate.Text = "تاريخ التوظيف:";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.CustomFormat = "yyyy-MM-dd";
            this.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHireDate.Location = new System.Drawing.Point(32, 283);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(244, 24);
            this.dtpHireDate.TabIndex = 3;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(368, 337);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 17);
            this.lblBranch.TabIndex = 0;
            this.lblBranch.Text = "الفرع:";
            // 
            // ddlBranch
            // 
            this.ddlBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBranch.FormattingEnabled = true;
            this.ddlBranch.Location = new System.Drawing.Point(32, 330);
            this.ddlBranch.Name = "ddlBranch";
            this.ddlBranch.Size = new System.Drawing.Size(244, 24);
            this.ddlBranch.TabIndex = 2;
            // 
            // lblUserAccount
            // 
            this.lblUserAccount.AutoSize = true;
            this.lblUserAccount.Location = new System.Drawing.Point(291, 378);
            this.lblUserAccount.Name = "lblUserAccount";
            this.lblUserAccount.Size = new System.Drawing.Size(118, 17);
            this.lblUserAccount.TabIndex = 0;
            this.lblUserAccount.Text = "حساب المستخدم:";
            // 
            // ddlUserAccount
            // 
            this.ddlUserAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUserAccount.FormattingEnabled = true;
            this.ddlUserAccount.Location = new System.Drawing.Point(32, 375);
            this.ddlUserAccount.Name = "ddlUserAccount";
            this.ddlUserAccount.Size = new System.Drawing.Size(244, 24);
            this.ddlUserAccount.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(490, 163);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(490, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 37);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(32, 420);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 0;
            // 
            // EditStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 445);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.ddlUserAccount);
            this.Controls.Add(this.ddlBranch);
            this.Controls.Add(this.ddlPosition);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblUserAccount);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblFullName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditStaffForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تعديل موظف";
            this.Load += new System.EventHandler(this.EditStaffForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox ddlPosition;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.ComboBox ddlBranch;
        private System.Windows.Forms.Label lblUserAccount;
        private System.Windows.Forms.ComboBox ddlUserAccount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
    }
}