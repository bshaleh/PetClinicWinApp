namespace PetClinicWinApp.Forms.Admin
{
    partial class AddUserForm
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.ddlRole = new System.Windows.Forms.ComboBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxshowConf = new System.Windows.Forms.CheckBox();
            this.ddlStaff = new System.Windows.Forms.ComboBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(454, 85);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(106, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "اسم المستخدم:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(226, 85);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsername.Size = new System.Drawing.Size(201, 24);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(454, 132);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(79, 17);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "كلمة المرور:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(226, 125);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(201, 24);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(454, 170);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(111, 17);
            this.lblConfirmPassword.TabIndex = 0;
            this.lblConfirmPassword.Text = "تأكيد كلمة المرور:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(226, 167);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtConfirmPassword.Size = new System.Drawing.Size(201, 24);
            this.txtConfirmPassword.TabIndex = 1;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(454, 214);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(39, 17);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "الدور:";
            // 
            // ddlRole
            // 
            this.ddlRole.FormattingEnabled = true;
            this.ddlRole.Location = new System.Drawing.Point(226, 214);
            this.ddlRole.Name = "ddlRole";
            this.ddlRole.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlRole.Size = new System.Drawing.Size(207, 24);
            this.ddlRole.TabIndex = 2;
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(454, 258);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(46, 17);
            this.lblIsActive.TabIndex = 0;
            this.lblIsActive.Text = "الحالة:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(286, 254);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(59, 21);
            this.chkIsActive.TabIndex = 3;
            this.chkIsActive.Text = "نشط";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(360, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(206, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(34, 344);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 0;
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(74, 125);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(129, 21);
            this.checkBoxShowPassword.TabIndex = 6;
            this.checkBoxShowPassword.Text = "اظهار كلمة المرور";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowPassword_CheckedChanged);
            // 
            // checkBoxshowConf
            // 
            this.checkBoxshowConf.AutoSize = true;
            this.checkBoxshowConf.Location = new System.Drawing.Point(74, 163);
            this.checkBoxshowConf.Name = "checkBoxshowConf";
            this.checkBoxshowConf.Size = new System.Drawing.Size(129, 21);
            this.checkBoxshowConf.TabIndex = 6;
            this.checkBoxshowConf.Text = "اظهار كلمة المرور";
            this.checkBoxshowConf.UseVisualStyleBackColor = true;
            this.checkBoxshowConf.CheckedChanged += new System.EventHandler(this.checkBoxshowConf_CheckedChanged);
            // 
            // ddlStaff
            // 
            this.ddlStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStaff.FormattingEnabled = true;
            this.ddlStaff.Location = new System.Drawing.Point(226, 40);
            this.ddlStaff.Name = "ddlStaff";
            this.ddlStaff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddlStaff.Size = new System.Drawing.Size(201, 24);
            this.ddlStaff.TabIndex = 7;
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(454, 43);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(52, 17);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "الموظف";
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 405);
            this.Controls.Add(this.ddlStaff);
            this.Controls.Add(this.checkBoxshowConf);
            this.Controls.Add(this.checkBoxShowPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.ddlRole);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblIsActive);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.lblUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إضافة مستخدم جديد";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox ddlRole;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.CheckBox checkBoxshowConf;
        private System.Windows.Forms.ComboBox ddlStaff;
        private System.Windows.Forms.Label lblStaff;
    }
}