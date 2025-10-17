using PetClinicWinApp.Helpers;
using PetClinicWinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetClinicWinApp.Forms.Owners
{
    public partial class OwnersListForm : Form
    {
        public OwnersListForm()
        {
            InitializeComponent();
            dgvOwners.AutoGenerateColumns = false;
            // Configure columns (if not done in designer)
            SetupGridColumns();

            LoadOwners();
        }
        private void SetupGridColumns()
        {
            dgvOwners.Columns.Clear(); // Clear any auto-generated columns

            dgvOwners.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "FullName",
                    HeaderText = "الاسم الكامل",
                    DataPropertyName = "FullName",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Phone",
                    HeaderText = "رقم الجوال",
                    DataPropertyName = "Phone",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Email",
                    HeaderText = "البريد الإلكتروني",
                    DataPropertyName = "Email",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Address",
                    HeaderText = "العنوان",
                    DataPropertyName = "Address",
                    Width = 250
                }
            );
        }

        private async void LoadOwners()
        {
            try
            {
                var owners = await ApiHelper.GetAsync<List<PetOwnerModel>>("owners");
               
                dgvOwners.DataSource = owners;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddOwnerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOwners(); // Refresh
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOwners();
        }

        private void OwnersListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
