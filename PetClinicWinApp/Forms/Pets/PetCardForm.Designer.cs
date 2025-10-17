namespace PetClinicWinApp.Forms.Pets
{
    partial class PetCardForm
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
            this.lblPetCode = new System.Windows.Forms.Label();
            this.lblPetName = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblSpecies = new System.Windows.Forms.Label();
            this.lblBreed = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPetCode
            // 
            this.lblPetCode.AutoSize = true;
            this.lblPetCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblPetCode.Location = new System.Drawing.Point(437, 9);
            this.lblPetCode.Name = "lblPetCode";
            this.lblPetCode.Size = new System.Drawing.Size(116, 24);
            this.lblPetCode.TabIndex = 0;
            this.lblPetCode.Text = "رمز الحيوان";
            // 
            // lblPetName
            // 
            this.lblPetName.Location = new System.Drawing.Point(122, 49);
            this.lblPetName.Name = "lblPetName";
            this.lblPetName.Size = new System.Drawing.Size(115, 27);
            this.lblPetName.TabIndex = 0;
            this.lblPetName.Text = "الاسم";
            this.lblPetName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Location = new System.Drawing.Point(45, 78);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(192, 32);
            this.lblBirthDate.TabIndex = 0;
            this.lblBirthDate.Text = "تاريخ الميلاد:";
            this.lblBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpecies
            // 
            this.lblSpecies.Location = new System.Drawing.Point(418, 49);
            this.lblSpecies.Name = "lblSpecies";
            this.lblSpecies.Size = new System.Drawing.Size(134, 27);
            this.lblSpecies.TabIndex = 0;
            this.lblSpecies.Text = "النوع";
            this.lblSpecies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBreed
            // 
            this.lblBreed.Location = new System.Drawing.Point(406, 86);
            this.lblBreed.Name = "lblBreed";
            this.lblBreed.Size = new System.Drawing.Size(146, 24);
            this.lblBreed.TabIndex = 0;
            this.lblBreed.Text = "السلالة";
            this.lblBreed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGender
            // 
            this.lblGender.Location = new System.Drawing.Point(418, 129);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(134, 31);
            this.lblGender.TabIndex = 0;
            this.lblGender.Text = "الجنس";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwner
            // 
            this.lblOwner.Location = new System.Drawing.Point(71, 124);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(166, 36);
            this.lblOwner.TabIndex = 0;
            this.lblOwner.Text = "المالك";
            this.lblOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(165, 198);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(137, 44);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(354, 198);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 44);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PetCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 282);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblBreed);
            this.Controls.Add(this.lblSpecies);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblPetName);
            this.Controls.Add(this.lblPetCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PetCardForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "بطاقة الحيوان";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPetCode;
        private System.Windows.Forms.Label lblPetName;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}