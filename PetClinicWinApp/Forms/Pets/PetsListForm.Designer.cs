namespace PetClinicWinApp.Forms.Pets
{
    partial class PetsListForm
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
            this.ddlOwnerFilter = new System.Windows.Forms.ComboBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnAddPet = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvPets = new System.Windows.Forms.DataGridView();
            this.btnViewMedical = new System.Windows.Forms.Button();
            this.btnViewProfile = new System.Windows.Forms.Button();
            this.btnPetCard = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPets)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlOwnerFilter
            // 
            this.ddlOwnerFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOwnerFilter.FormattingEnabled = true;
            this.ddlOwnerFilter.Location = new System.Drawing.Point(567, 29);
            this.ddlOwnerFilter.Name = "ddlOwnerFilter";
            this.ddlOwnerFilter.Size = new System.Drawing.Size(239, 24);
            this.ddlOwnerFilter.TabIndex = 0;
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(428, 14);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(119, 39);
            this.btnApplyFilter.TabIndex = 1;
            this.btnApplyFilter.Text = "تطبيق";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // btnAddPet
            // 
            this.btnAddPet.Location = new System.Drawing.Point(24, 79);
            this.btnAddPet.Name = "btnAddPet";
            this.btnAddPet.Size = new System.Drawing.Size(119, 39);
            this.btnAddPet.TabIndex = 1;
            this.btnAddPet.Text = "إضافة حيوان";
            this.btnAddPet.UseVisualStyleBackColor = true;
            this.btnAddPet.Click += new System.EventHandler(this.btnAddPet_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(245, 80);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 39);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvPets
            // 
            this.dgvPets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPets.Location = new System.Drawing.Point(24, 141);
            this.dgvPets.Name = "dgvPets";
            this.dgvPets.ReadOnly = true;
            this.dgvPets.RowTemplate.Height = 26;
            this.dgvPets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPets.Size = new System.Drawing.Size(908, 284);
            this.dgvPets.TabIndex = 2;
            // 
            // btnViewMedical
            // 
            this.btnViewMedical.Location = new System.Drawing.Point(24, 446);
            this.btnViewMedical.Name = "btnViewMedical";
            this.btnViewMedical.Size = new System.Drawing.Size(152, 39);
            this.btnViewMedical.TabIndex = 1;
            this.btnViewMedical.Text = "عرض السجلات الطبية";
            this.btnViewMedical.UseVisualStyleBackColor = true;
            this.btnViewMedical.Click += new System.EventHandler(this.btnViewMedical_Click);
            // 
            // btnViewProfile
            // 
            this.btnViewProfile.Location = new System.Drawing.Point(395, 446);
            this.btnViewProfile.Name = "btnViewProfile";
            this.btnViewProfile.Size = new System.Drawing.Size(152, 39);
            this.btnViewProfile.TabIndex = 1;
            this.btnViewProfile.Text = "تقرير الحيوان";
            this.btnViewProfile.UseVisualStyleBackColor = true;
            this.btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);
            // 
            // btnPetCard
            // 
            this.btnPetCard.Location = new System.Drawing.Point(797, 446);
            this.btnPetCard.Name = "btnPetCard";
            this.btnPetCard.Size = new System.Drawing.Size(135, 39);
            this.btnPetCard.TabIndex = 3;
            this.btnPetCard.Text = "بطاقة الحيوان";
            this.btnPetCard.UseVisualStyleBackColor = true;
            this.btnPetCard.Click += new System.EventHandler(this.btnPetCard_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(567, 87);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(239, 24);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(458, 79);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 40);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(812, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "تصفية حسب المالك";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(900, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "بحث";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PetsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(959, 508);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnPetCard);
            this.Controls.Add(this.dgvPets);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnViewProfile);
            this.Controls.Add(this.btnViewMedical);
            this.Controls.Add(this.btnAddPet);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.ddlOwnerFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PetsListForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "قائمة الحيوانات";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlOwnerFilter;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnAddPet;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvPets;
        private System.Windows.Forms.Button btnViewMedical;
        private System.Windows.Forms.Button btnViewProfile;
        private System.Windows.Forms.Button btnPetCard;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}