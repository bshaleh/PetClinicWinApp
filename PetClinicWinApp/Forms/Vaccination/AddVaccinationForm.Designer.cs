namespace PetClinicWinApp.Forms.Vaccination
{
    partial class AddVaccinationForm
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
            this.lblVaccine = new System.Windows.Forms.Label();
            this.txtVaccineName = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpVaccinationDate = new System.Windows.Forms.DateTimePicker();
            this.lblAdministered = new System.Windows.Forms.Label();
            this.ddlAdministeredBy = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ddlPetCode = new System.Windows.Forms.ComboBox();
            this.ddlPetOwner = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNextDueDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ddlPet
            // 
            this.ddlPet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPet.FormattingEnabled = true;
            this.ddlPet.Location = new System.Drawing.Point(116, 12);
            this.ddlPet.Name = "ddlPet";
            this.ddlPet.Size = new System.Drawing.Size(214, 24);
            this.ddlPet.TabIndex = 0;
            this.ddlPet.SelectedIndexChanged += new System.EventHandler(this.ddlPet_SelectedIndexChanged);
            // 
            // lblVaccine
            // 
            this.lblVaccine.AutoSize = true;
            this.lblVaccine.Location = new System.Drawing.Point(389, 127);
            this.lblVaccine.Name = "lblVaccine";
            this.lblVaccine.Size = new System.Drawing.Size(76, 17);
            this.lblVaccine.TabIndex = 1;
            this.lblVaccine.Text = "اسم اللقاح:";
            // 
            // txtVaccineName
            // 
            this.txtVaccineName.Location = new System.Drawing.Point(97, 120);
            this.txtVaccineName.Name = "txtVaccineName";
            this.txtVaccineName.Size = new System.Drawing.Size(233, 24);
            this.txtVaccineName.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(377, 173);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(88, 17);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "تاريخ التطعيم:";
            // 
            // dtpVaccinationDate
            // 
            this.dtpVaccinationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVaccinationDate.Location = new System.Drawing.Point(97, 161);
            this.dtpVaccinationDate.Name = "dtpVaccinationDate";
            this.dtpVaccinationDate.Size = new System.Drawing.Size(233, 24);
            this.dtpVaccinationDate.TabIndex = 3;
            // 
            // lblAdministered
            // 
            this.lblAdministered.AutoSize = true;
            this.lblAdministered.Location = new System.Drawing.Point(389, 207);
            this.lblAdministered.Name = "lblAdministered";
            this.lblAdministered.Size = new System.Drawing.Size(76, 17);
            this.lblAdministered.TabIndex = 1;
            this.lblAdministered.Text = "تم بواسطة:";
            // 
            // ddlAdministeredBy
            // 
            this.ddlAdministeredBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAdministeredBy.FormattingEnabled = true;
            this.ddlAdministeredBy.Location = new System.Drawing.Point(97, 203);
            this.ddlAdministeredBy.Name = "ddlAdministeredBy";
            this.ddlAdministeredBy.Size = new System.Drawing.Size(233, 24);
            this.ddlAdministeredBy.TabIndex = 0;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(401, 297);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(64, 17);
            this.lblNotes.TabIndex = 1;
            this.lblNotes.Text = "ملاحظات:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(97, 293);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(233, 46);
            this.txtNotes.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(97, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "تسجيل";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 37);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ddlPetCode
            // 
            this.ddlPetCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetCode.FormattingEnabled = true;
            this.ddlPetCode.Location = new System.Drawing.Point(116, 42);
            this.ddlPetCode.Name = "ddlPetCode";
            this.ddlPetCode.Size = new System.Drawing.Size(214, 24);
            this.ddlPetCode.TabIndex = 5;
            this.ddlPetCode.SelectedIndexChanged += new System.EventHandler(this.ddlPetCode_SelectedIndexChanged);
            // 
            // ddlPetOwner
            // 
            this.ddlPetOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetOwner.FormattingEnabled = true;
            this.ddlPetOwner.Location = new System.Drawing.Point(116, 72);
            this.ddlPetOwner.Name = "ddlPetOwner";
            this.ddlPetOwner.Size = new System.Drawing.Size(214, 24);
            this.ddlPetOwner.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "المالك:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "كود الحيوان";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "الحيوان";
            // 
            // dtpNextDueDate
            // 
            this.dtpNextDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNextDueDate.Location = new System.Drawing.Point(97, 246);
            this.dtpNextDueDate.Name = "dtpNextDueDate";
            this.dtpNextDueDate.Size = new System.Drawing.Size(233, 24);
            this.dtpNextDueDate.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "تاريخ التطعيم: التالي";
            // 
            // AddVaccinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 430);
            this.Controls.Add(this.dtpNextDueDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlPetCode);
            this.Controls.Add(this.ddlPetOwner);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpVaccinationDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtVaccineName);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblAdministered);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblVaccine);
            this.Controls.Add(this.ddlAdministeredBy);
            this.Controls.Add(this.ddlPet);
            this.MaximizeBox = false;
            this.Name = "AddVaccinationForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تسجيل تطعيم";
            this.Load += new System.EventHandler(this.AddVaccinationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlPet;
        private System.Windows.Forms.Label lblVaccine;
        private System.Windows.Forms.TextBox txtVaccineName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpVaccinationDate;
        private System.Windows.Forms.Label lblAdministered;
        private System.Windows.Forms.ComboBox ddlAdministeredBy;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox ddlPetCode;
        private System.Windows.Forms.ComboBox ddlPetOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNextDueDate;
        private System.Windows.Forms.Label label4;
    }
}