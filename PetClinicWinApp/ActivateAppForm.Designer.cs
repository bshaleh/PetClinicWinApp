namespace PetClinicWinApp
{
    partial class ActivateAppForm
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
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtMachineId = new System.Windows.Forms.TextBox();
            this.txtActivationCode = new System.Windows.Forms.TextBox();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(54, 45);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(259, 24);
            this.txtClientName.TabIndex = 0;
            // 
            // txtMachineId
            // 
            this.txtMachineId.Location = new System.Drawing.Point(54, 90);
            this.txtMachineId.Name = "txtMachineId";
            this.txtMachineId.Size = new System.Drawing.Size(259, 24);
            this.txtMachineId.TabIndex = 0;
            // 
            // txtActivationCode
            // 
            this.txtActivationCode.Location = new System.Drawing.Point(58, 138);
            this.txtActivationCode.Name = "txtActivationCode";
            this.txtActivationCode.Size = new System.Drawing.Size(255, 24);
            this.txtActivationCode.TabIndex = 0;
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(103, 193);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(99, 38);
            this.btnActivate.TabIndex = 1;
            this.btnActivate.Text = "تفعيل";
            this.btnActivate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(258, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(34, 266);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(42, 17);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "اسم العميل";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "معرف الجهاز:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "رمز التفعيل:";
            // 
            // ActivateAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 307);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.txtActivationCode);
            this.Controls.Add(this.txtMachineId);
            this.Controls.Add(this.txtClientName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActivateAppForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تفعيل التطبيق";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtMachineId;
        private System.Windows.Forms.TextBox txtActivationCode;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}