using PetClinicWinApp.Forms.Medical;
using PetClinicWinApp.Forms.Reports;
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

namespace PetClinicWinApp.Forms.Pets
{
    public partial class PetsListForm : Form
    {
        private List<PetModel> _allPets;

        public PetsListForm()
        {
            InitializeComponent();
            dgvPets.AutoGenerateColumns = false;
            SetupGridColumns();
            LoadPets();
            LoadOwnersForFilter();
        }
        private void SetupGridColumns()
        {
            dgvPets.Columns.Clear();

            dgvPets.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "PetCode", HeaderText = "كود الحيوان", DataPropertyName = "PetCode", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "PetName", HeaderText = "اسم الحيوان", DataPropertyName = "PetName", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "Species", HeaderText = "النوع", DataPropertyName = "Species", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Breed", HeaderText = "السلالة", DataPropertyName = "Breed", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "BirthDate", HeaderText = "تاريخ الميلاد", DataPropertyName = "BirthDate", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "Gender", HeaderText = "الجنس", DataPropertyName = "Gender", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "OwnerName", HeaderText = "المالك", DataPropertyName = "OwnerName", Width = 150 }
            );
        }
        private async void LoadPets(int? ownerId = null)
        {
            try
            {
                string endpoint = "pets";
                if (ownerId.HasValue) endpoint += $"?ownerId={ownerId}";

                var pets = await ApiHelper.GetAsync<List<PetModel>>(endpoint);

                _allPets = pets;
                dgvPets.DataSource = pets;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الحيوانات: " + ex.Message);
            }
        }

        private async void LoadOwnersForFilter()
        {
            try
            {
                var owners = await ApiHelper.GetAsync<List<dynamic>>("owners");
                ddlOwnerFilter.Items.Add(new { FullName = "جميع المالكين", OwnerID = 0 });
                foreach (var owner in owners)
                {
                    ddlOwnerFilter.Items.Add(owner);
                }
                ddlOwnerFilter.DisplayMember = "FullName";
                ddlOwnerFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل المالكين: " + ex.Message);
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            int? ownerId = null;
            if (ddlOwnerFilter.SelectedIndex > 0)
            {
                dynamic selected = ddlOwnerFilter.SelectedItem;
                ownerId = (int)selected.OwnerID;
            }
            LoadPets(ownerId);
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            using (var form = new AddPetForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPets();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPets();
        }

        private void btnViewMedical_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0) return;

            dynamic selectedPet = dgvPets.SelectedRows[0].DataBoundItem;
            int petId = (int)selectedPet.PetID;

            using (var form = new MedicalRecordsListForm(petId))
            {
                form.ShowDialog();
            }
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            if (dgvPets.SelectedRows.Count == 0) return;

            var selectedPet = dgvPets.SelectedRows[0].DataBoundItem as PetModel;
            int petId = selectedPet.PetID;

            using (var form = new PetProfileReportForm(petId))
            {
                form.ShowDialog();
            }
        }

        private void btnPetCard_Click(object sender, EventArgs e)
        {
            
            if (dgvPets.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار حيوان من القائمة!");
                return;
            }
            dynamic selectedPet = dgvPets.SelectedRows[0].DataBoundItem;
            using (var form = new PetCardForm(selectedPet))
            {
                form.ShowDialog();
            }
            //if (dgvPets.SelectedRows.Count == 0)
            //{
            //    MessageBox.Show("يرجى اختيار حيوان من القائمة!");
            //    return;
            //}
            ////if (dgvPets.SelectedRows.Count == 0) return;

            //dynamic selectedPet = dgvPets.SelectedRows[0].DataBoundItem;
            //int petId = (int)selectedPet.PetID;

            //using (var form = new PetCardForm(petId))
            //{
            //    form.ShowDialog();
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPets(txtSearch.Text.Trim());
        }

        private void SearchPets(string searchTerm)
        {
            if (_allPets == null) return;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Show all pets if search is empty
                dgvPets.DataSource = _allPets; // Store original data
                return;
            }

            // Filter by PetCode or PetName (case-insensitive)
            var filteredPets = _allPets
                .Where(p =>
                    (p.PetCode?.ToString().Contains(searchTerm) == true) ||
                    (p.PetName?.ToString().Contains(searchTerm) == true)
                )
                .ToList();

            dgvPets.DataSource = filteredPets;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPets(txtSearch.Text.Trim());
                e.SuppressKeyPress = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchPets(txtSearch.Text.Trim());
        }
    }
}
