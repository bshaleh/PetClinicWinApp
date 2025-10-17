namespace PetClinicWinApp.Forms.Surgery
{
    partial class SurgeriesListForm
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
            this.ddlPetFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnAddSurgery = new System.Windows.Forms.Button();
            this.dgvSurgeries = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlPetCode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurgeries)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlPetFilter
            // 
            this.ddlPetFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetFilter.FormattingEnabled = true;
            this.ddlPetFilter.Location = new System.Drawing.Point(494, 18);
            this.ddlPetFilter.Name = "ddlPetFilter";
            this.ddlPetFilter.Size = new System.Drawing.Size(176, 24);
            this.ddlPetFilter.TabIndex = 0;
            this.ddlPetFilter.SelectedIndexChanged += new System.EventHandler(this.ddlPetFilter_SelectedIndexChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(340, 29);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(115, 35);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "تصفية";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnAddSurgery
            // 
            this.btnAddSurgery.Location = new System.Drawing.Point(645, 391);
            this.btnAddSurgery.Name = "btnAddSurgery";
            this.btnAddSurgery.Size = new System.Drawing.Size(115, 35);
            this.btnAddSurgery.TabIndex = 1;
            this.btnAddSurgery.Text = "تسجيل عملية";
            this.btnAddSurgery.UseVisualStyleBackColor = true;
            this.btnAddSurgery.Click += new System.EventHandler(this.btnAddSurgery_Click);
            // 
            // dgvSurgeries
            // 
            this.dgvSurgeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurgeries.Location = new System.Drawing.Point(30, 85);
            this.dgvSurgeries.Name = "dgvSurgeries";
            this.dgvSurgeries.ReadOnly = true;
            this.dgvSurgeries.RowTemplate.Height = 26;
            this.dgvSurgeries.Size = new System.Drawing.Size(735, 275);
            this.dgvSurgeries.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(691, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "كود الحيوان";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "اسم الحيوان";
            // 
            // ddlPetCode
            // 
            this.ddlPetCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPetCode.FormattingEnabled = true;
            this.ddlPetCode.Location = new System.Drawing.Point(494, 52);
            this.ddlPetCode.Name = "ddlPetCode";
            this.ddlPetCode.Size = new System.Drawing.Size(176, 24);
            this.ddlPetCode.TabIndex = 4;
            this.ddlPetCode.SelectedIndexChanged += new System.EventHandler(this.ddlPetCode_SelectedIndexChanged);
            // 
            // SurgeriesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlPetCode);
            this.Controls.Add(this.dgvSurgeries);
            this.Controls.Add(this.btnAddSurgery);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.ddlPetFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SurgeriesListForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "سجل العمليات الجراحية";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurgeries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlPetFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnAddSurgery;
        private System.Windows.Forms.DataGridView dgvSurgeries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlPetCode;
    }
}