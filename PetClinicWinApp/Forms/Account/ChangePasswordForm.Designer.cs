namespace PetClinicWinApp.Forms
{
    partial class ChangePasswordForm
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
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxShowOldPassword = new System.Windows.Forms.CheckBox();
            this.checkBoxShow1 = new System.Windows.Forms.CheckBox();
            this.checkBoxShow2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Location = new System.Drawing.Point(30, 84);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(121, 17);
            this.lblCurrentPassword.TabIndex = 1;
            this.lblCurrentPassword.Text = "كلمة المرور الحالية:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(171, 76);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(212, 24);
            this.txtCurrentPassword.TabIndex = 0;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(24, 121);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(127, 17);
            this.lblNewPassword.TabIndex = 1;
            this.lblNewPassword.Text = "كلمة المرور الجديدة:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(171, 114);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(212, 24);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(24, 154);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(111, 17);
            this.lblConfirmPassword.TabIndex = 1;
            this.lblConfirmPassword.Text = "تأكيد كلمة المرور:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(171, 151);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(212, 24);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(86, 214);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(147, 41);
            this.btnChangePassword.TabIndex = 3;
            this.btnChangePassword.Text = "تغيير كلمة المرور";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(276, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 41);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBoxShowOldPassword
            // 
            this.checkBoxShowOldPassword.AutoSize = true;
            this.checkBoxShowOldPassword.Location = new System.Drawing.Point(389, 76);
            this.checkBoxShowOldPassword.Name = "checkBoxShowOldPassword";
            this.checkBoxShowOldPassword.Size = new System.Drawing.Size(171, 21);
            this.checkBoxShowOldPassword.TabIndex = 5;
            this.checkBoxShowOldPassword.Text = "اظهار كلمة السر القديمة";
            this.checkBoxShowOldPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowOldPassword.CheckedChanged += new System.EventHandler(this.checkBoxShowOldPassword_CheckedChanged);
            // 
            // checkBoxShow1
            // 
            this.checkBoxShow1.AutoSize = true;
            this.checkBoxShow1.Location = new System.Drawing.Point(389, 116);
            this.checkBoxShow1.Name = "checkBoxShow1";
            this.checkBoxShow1.Size = new System.Drawing.Size(124, 21);
            this.checkBoxShow1.TabIndex = 5;
            this.checkBoxShow1.Text = "اظهار كلمة السر";
            this.checkBoxShow1.UseVisualStyleBackColor = true;
            this.checkBoxShow1.CheckedChanged += new System.EventHandler(this.checkBoxShow1_CheckedChanged);
            // 
            // checkBoxShow2
            // 
            this.checkBoxShow2.AutoSize = true;
            this.checkBoxShow2.Location = new System.Drawing.Point(389, 154);
            this.checkBoxShow2.Name = "checkBoxShow2";
            this.checkBoxShow2.Size = new System.Drawing.Size(124, 21);
            this.checkBoxShow2.TabIndex = 5;
            this.checkBoxShow2.Text = "اظهار كلمة السر";
            this.checkBoxShow2.UseVisualStyleBackColor = true;
            this.checkBoxShow2.CheckedChanged += new System.EventHandler(this.checkBoxShow2_CheckedChanged);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 344);
            this.Controls.Add(this.checkBoxShow2);
            this.Controls.Add(this.checkBoxShow1);
            this.Controls.Add(this.checkBoxShowOldPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblCurrentPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ChangePasswordForm";
            this.Text = "تغيير كلمة السر";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBoxShowOldPassword;
        private System.Windows.Forms.CheckBox checkBoxShow1;
        private System.Windows.Forms.CheckBox checkBoxShow2;
    }
}