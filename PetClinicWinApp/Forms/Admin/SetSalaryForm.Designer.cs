namespace PetClinicWinApp.Forms.Admin
{
    partial class SetSalaryForm
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
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblCurrentSalary = new System.Windows.Forms.Label();
            this.lblNewAmount = new System.Windows.Forms.Label();
            this.txtNewAmount = new System.Windows.Forms.TextBox();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblStaffName.Location = new System.Drawing.Point(330, 20);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStaffName.Size = new System.Drawing.Size(195, 17);
            this.lblStaffName.TabIndex = 0;
            this.lblStaffName.Text = "تعيين راتب لـ: [اسم الموظف]";
            // 
            // lblCurrentSalary
            // 
            this.lblCurrentSalary.AutoSize = true;
            this.lblCurrentSalary.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblCurrentSalary.Location = new System.Drawing.Point(344, 56);
            this.lblCurrentSalary.Name = "lblCurrentSalary";
            this.lblCurrentSalary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentSalary.Size = new System.Drawing.Size(171, 17);
            this.lblCurrentSalary.TabIndex = 0;
            this.lblCurrentSalary.Text = "الراتب الحالي: 0.00 ر.س";
            // 
            // lblNewAmount
            // 
            this.lblNewAmount.AutoSize = true;
            this.lblNewAmount.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblNewAmount.Location = new System.Drawing.Point(330, 130);
            this.lblNewAmount.Name = "lblNewAmount";
            this.lblNewAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNewAmount.Size = new System.Drawing.Size(127, 17);
            this.lblNewAmount.TabIndex = 0;
            this.lblNewAmount.Text = "الراتب الجديد (ر.س):";
            // 
            // txtNewAmount
            // 
            this.txtNewAmount.Location = new System.Drawing.Point(76, 127);
            this.txtNewAmount.Name = "txtNewAmount";
            this.txtNewAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewAmount.Size = new System.Drawing.Size(236, 24);
            this.txtNewAmount.TabIndex = 1;
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblPaymentDate.Location = new System.Drawing.Point(384, 178);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPaymentDate.Size = new System.Drawing.Size(73, 17);
            this.lblPaymentDate.TabIndex = 0;
            this.lblPaymentDate.Text = "تاريخ الدفع:";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "yyyy-MM-dd";
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(76, 171);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpPaymentDate.Size = new System.Drawing.Size(236, 24);
            this.dtpPaymentDate.TabIndex = 2;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblNotes.Location = new System.Drawing.Point(393, 231);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNotes.Size = new System.Drawing.Size(64, 17);
            this.lblNotes.TabIndex = 0;
            this.lblNotes.Text = "ملاحظات:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(76, 228);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(236, 60);
            this.txtNotes.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 44);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(278, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 44);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(36, 403);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 0;
            // 
            // SetSalaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 440);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtNewAmount);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblPaymentDate);
            this.Controls.Add(this.lblNewAmount);
            this.Controls.Add(this.lblCurrentSalary);
            this.Controls.Add(this.lblStaffName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SetSalaryForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تعيين راتب للموظف";
            this.Load += new System.EventHandler(this.SetSalaryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblCurrentSalary;
        private System.Windows.Forms.Label lblNewAmount;
        private System.Windows.Forms.TextBox txtNewAmount;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
    }
}