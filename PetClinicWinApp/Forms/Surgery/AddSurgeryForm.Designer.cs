namespace PetClinicWinApp.Forms.Surgery
{
    partial class AddSurgeryForm
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
            this.ddlPet = new System.Windows.Forms.ComboBox();
            this.lblSurgeryName = new System.Windows.Forms.Label();
            this.txtSurgeryName = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpSurgeryDate = new System.Windows.Forms.DateTimePicker();
            this.lblSurgeon = new System.Windows.Forms.Label();
            this.ddlSurgeon = new System.Windows.Forms.ComboBox();
            this.lblOutcome = new System.Windows.Forms.Label();
            this.ddlOutcome = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlPetOwner = new System.Windows.Forms.ComboBox();
            this.ddlPetCode = new System.Windows.Forms.ComboBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ddlPet
            // 
            this.ddlPet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPet.FormattingEnabled = true;
            this.ddlPet.Location = new System.Drawing.Point(120, 12);
            this.ddlPet.Name = "ddlPet";
            this.ddlPet.Size = new System.Drawing.Size(214, 24);
            this.ddlPet.TabIndex = 0;
            this.ddlPet.SelectedIndexChanged += new System.EventHandler(this.ddlPet_SelectedIndexChanged);
            // 
            // lblSurgeryName
            // 
            this.lblSurgeryName.AutoSize = true;
            this.lblSurgeryName.Location = new System.Drawing.Point(366, 121);
            this.lblSurgeryName.Name = "lblSurgeryName";
            this.lblSurgeryName.Size = new System.Drawing.Size(85, 17);
            this.lblSurgeryName.TabIndex = 1;
            this.lblSurgeryName.Text = "اسم العملية:";
            // 
            // txtSurgeryName
            // 
            this.txtSurgeryName.Location = new System.Drawing.Point(86, 117);
            this.txtSurgeryName.Name = "txtSurgeryName";
            this.txtSurgeryName.Size = new System.Drawing.Size(264, 24);
            this.txtSurgeryName.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(366, 166);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(85, 17);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "تاريخ العملية:";
            // 
            // dtpSurgeryDate
            // 
            this.dtpSurgeryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSurgeryDate.Location = new System.Drawing.Point(86, 163);
            this.dtpSurgeryDate.Name = "dtpSurgeryDate";
            this.dtpSurgeryDate.Size = new System.Drawing.Size(264, 24);
            this.dtpSurgeryDate.TabIndex = 3;
            // 
            // lblSurgeon
            // 
            this.lblSurgeon.AutoSize = true;
            this.lblSurgeon.Location = new System.Drawing.Point(403, 208);
            this.lblSurgeon.Name = "lblSurgeon";
            this.lblSurgeon.Size = new System.Drawing.Size(48, 17);
            this.lblSurgeon.TabIndex = 1;
            this.lblSurgeon.Text = "الجراح:";
            // 
            // ddlSurgeon
            // 
            this.ddlSurgeon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSurgeon.FormattingEnabled = true;
            this.ddlSurgeon.Location = new System.Drawing.Point(86, 205);
            this.ddlSurgeon.Name = "ddlSurgeon";
            this.ddlSurgeon.Size = new System.Drawing.Size(264, 24);
            this.ddlSurgeon.TabIndex = 0;
            // 
            // lblOutcome
            // 
            this.lblOutcome.AutoSize = true;
            this.lblOutcome.Location = new System.Drawing.Point(398, 249);
            this.lblOutcome.Name = "lblOutcome";
            this.lblOutcome.Size = new System.Drawing.Size(53, 17);
            this.lblOutcome.TabIndex = 1;
            this.lblOutcome.Text = "النتيجة:";
            // 
            // ddlOutcome
            // 
            this.ddlOutcome.FormattingEnabled = true;
            this.ddlOutcome.Items.AddRange(new object[] {
            "Successful",
            "Complicated",
            "Fatal"});
            this.ddlOutcome.Location = new System.Drawing.Point(86, 246);
            this.ddlOutcome.Name = "ddlOutcome";
            this.ddlOutcome.Size = new System.Drawing.Size(264, 24);
            this.ddlOutcome.TabIndex = 4;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(387, 307);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(64, 17);
            this.lblNotes.TabIndex = 1;
            this.lblNotes.Text = "ملاحظات:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(86, 292);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(264, 57);
            this.txtNotes.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(108, 371);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 48);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "تسجيل";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(288, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 48);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "الحيوان";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "كود الحيوان";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "المالك:";
            // 
            // ddlPetOwner
            // 
            this.ddlPetOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetOwner.FormattingEnabled = true;
            this.ddlPetOwner.Location = new System.Drawing.Point(120, 72);
            this.ddlPetOwner.Name = "ddlPetOwner";
            this.ddlPetOwner.Size = new System.Drawing.Size(214, 24);
            this.ddlPetOwner.TabIndex = 0;
            // 
            // ddlPetCode
            // 
            this.ddlPetCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetCode.FormattingEnabled = true;
            this.ddlPetCode.Location = new System.Drawing.Point(120, 42);
            this.ddlPetCode.Name = "ddlPetCode";
            this.ddlPetCode.Size = new System.Drawing.Size(214, 24);
            this.ddlPetCode.TabIndex = 0;
            this.ddlPetCode.SelectedIndexChanged += new System.EventHandler(this.ddlPetCode_SelectedIndexChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(27, 434);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 1;
            // 
            // AddSurgeryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 473);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ddlOutcome);
            this.Controls.Add(this.dtpSurgeryDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtSurgeryName);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblOutcome);
            this.Controls.Add(this.lblSurgeon);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSurgeryName);
            this.Controls.Add(this.ddlSurgeon);
            this.Controls.Add(this.ddlPetCode);
            this.Controls.Add(this.ddlPetOwner);
            this.Controls.Add(this.ddlPet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSurgeryForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل عملية جراحية";
            this.Load += new System.EventHandler(this.AddSurgeryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlPet;
        private System.Windows.Forms.Label lblSurgeryName;
        private System.Windows.Forms.TextBox txtSurgeryName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpSurgeryDate;
        private System.Windows.Forms.Label lblSurgeon;
        private System.Windows.Forms.ComboBox ddlSurgeon;
        private System.Windows.Forms.Label lblOutcome;
        private System.Windows.Forms.ComboBox ddlOutcome;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlPetOwner;
        private System.Windows.Forms.ComboBox ddlPetCode;
        private System.Windows.Forms.Label lblMessage;
    }
}