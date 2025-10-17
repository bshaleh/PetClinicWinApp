namespace PetClinicWinApp.Forms.Medical
{
    partial class AddMedicalRecordForm
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
            this.ddlDoctor = new System.Windows.Forms.ComboBox();
            this.dtpVisitDate = new System.Windows.Forms.DateTimePicker();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.lblTreatment = new System.Windows.Forms.Label();
            this.txtTreatment = new System.Windows.Forms.TextBox();
            this.lblPrescription = new System.Windows.Forms.Label();
            this.txtPrescription = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ddlPetOwner = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlPetCode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ddlPet
            // 
            this.ddlPet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPet.FormattingEnabled = true;
            this.ddlPet.Location = new System.Drawing.Point(41, 52);
            this.ddlPet.Name = "ddlPet";
            this.ddlPet.Size = new System.Drawing.Size(208, 24);
            this.ddlPet.TabIndex = 0;
            this.ddlPet.SelectedIndexChanged += new System.EventHandler(this.ddlPet_SelectedIndexChanged);
            // 
            // ddlDoctor
            // 
            this.ddlDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDoctor.FormattingEnabled = true;
            this.ddlDoctor.Location = new System.Drawing.Point(453, 16);
            this.ddlDoctor.Name = "ddlDoctor";
            this.ddlDoctor.Size = new System.Drawing.Size(208, 24);
            this.ddlDoctor.TabIndex = 0;
            // 
            // dtpVisitDate
            // 
            this.dtpVisitDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpVisitDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVisitDate.Location = new System.Drawing.Point(453, 55);
            this.dtpVisitDate.Name = "dtpVisitDate";
            this.dtpVisitDate.Size = new System.Drawing.Size(208, 24);
            this.dtpVisitDate.TabIndex = 1;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Location = new System.Drawing.Point(691, 133);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(71, 17);
            this.lblDiagnosis.TabIndex = 2;
            this.lblDiagnosis.Text = "التشخيص:";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(202, 130);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosis.Size = new System.Drawing.Size(459, 76);
            this.txtDiagnosis.TabIndex = 3;
            this.txtDiagnosis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTreatment
            // 
            this.lblTreatment.AutoSize = true;
            this.lblTreatment.Location = new System.Drawing.Point(717, 232);
            this.lblTreatment.Name = "lblTreatment";
            this.lblTreatment.Size = new System.Drawing.Size(46, 17);
            this.lblTreatment.TabIndex = 2;
            this.lblTreatment.Text = "العلاج:";
            // 
            // txtTreatment
            // 
            this.txtTreatment.Location = new System.Drawing.Point(202, 222);
            this.txtTreatment.Multiline = true;
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTreatment.Size = new System.Drawing.Size(459, 76);
            this.txtTreatment.TabIndex = 3;
            this.txtTreatment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrescription
            // 
            this.lblPrescription.AutoSize = true;
            this.lblPrescription.Location = new System.Drawing.Point(710, 321);
            this.lblPrescription.Name = "lblPrescription";
            this.lblPrescription.Size = new System.Drawing.Size(52, 17);
            this.lblPrescription.TabIndex = 2;
            this.lblPrescription.Text = "الوصفة:";
            // 
            // txtPrescription
            // 
            this.txtPrescription.Location = new System.Drawing.Point(202, 311);
            this.txtPrescription.Multiline = true;
            this.txtPrescription.Name = "txtPrescription";
            this.txtPrescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrescription.Size = new System.Drawing.Size(459, 76);
            this.txtPrescription.TabIndex = 3;
            this.txtPrescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(699, 406);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(64, 17);
            this.lblNotes.TabIndex = 2;
            this.lblNotes.Text = "ملاحظات:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(202, 403);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(459, 76);
            this.txtNotes.TabIndex = 3;
            this.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(41, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(41, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ddlPetOwner
            // 
            this.ddlPetOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetOwner.Enabled = false;
            this.ddlPetOwner.FormattingEnabled = true;
            this.ddlPetOwner.Location = new System.Drawing.Point(41, 89);
            this.ddlPetOwner.Name = "ddlPetOwner";
            this.ddlPetOwner.Size = new System.Drawing.Size(208, 24);
            this.ddlPetOwner.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "الحيوان";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "المالك";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(670, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "الطبيب المعالج";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(679, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "تاريخ المعاينة";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "كود الحيوان";
            // 
            // ddlPetCode
            // 
            this.ddlPetCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetCode.FormattingEnabled = true;
            this.ddlPetCode.Location = new System.Drawing.Point(41, 16);
            this.ddlPetCode.Name = "ddlPetCode";
            this.ddlPetCode.Size = new System.Drawing.Size(208, 24);
            this.ddlPetCode.TabIndex = 0;
            this.ddlPetCode.SelectedIndexChanged += new System.EventHandler(this.ddlPetCode_SelectedIndexChanged);
            // 
            // AddMedicalRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 492);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtPrescription);
            this.Controls.Add(this.txtTreatment);
            this.Controls.Add(this.txtDiagnosis);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblPrescription);
            this.Controls.Add(this.lblTreatment);
            this.Controls.Add(this.lblDiagnosis);
            this.Controls.Add(this.dtpVisitDate);
            this.Controls.Add(this.ddlDoctor);
            this.Controls.Add(this.ddlPetOwner);
            this.Controls.Add(this.ddlPetCode);
            this.Controls.Add(this.ddlPet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "AddMedicalRecordForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "إضافة سجل طبي";
            this.Load += new System.EventHandler(this.AddMedicalRecordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlPet;
        private System.Windows.Forms.ComboBox ddlDoctor;
        private System.Windows.Forms.DateTimePicker dtpVisitDate;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label lblTreatment;
        private System.Windows.Forms.TextBox txtTreatment;
        private System.Windows.Forms.Label lblPrescription;
        private System.Windows.Forms.TextBox txtPrescription;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox ddlPetOwner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlPetCode;
    }
}