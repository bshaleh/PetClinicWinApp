using PetClinicWinApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetClinicWinApp.Forms.Vaccination
{
   
    public partial class VaccinationsListForm : Form
    {
        private int? _petId;
        private List<dynamic> _allPets;
        private List<dynamic> _allRecords;
        public VaccinationsListForm() : this(null)
        {
        }
        public VaccinationsListForm(int? petId)
        {
            _petId = petId;
            InitializeComponent();
            dgvVaccinations.AutoGenerateColumns = false;
            LoadVaccinations();
            LoadPetsForFilter();
            dgvVaccinations.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "PetName", HeaderText = "اسم الحيوان", DataPropertyName = "PetName", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "PetCode", HeaderText = "كود الحيوان", DataPropertyName = "PetCode", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "VaccineName", HeaderText = "اللقاح", DataPropertyName = "VaccineName", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "VaccinationDate", HeaderText = "تاريخ اللقاح", DataPropertyName = "VaccinationDate", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "DonedBy", HeaderText = "تم بواسطة", DataPropertyName = "DonedBy", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "NextDueDate", HeaderText = "التالي", DataPropertyName = "NextDueDate", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Notes", HeaderText = "ملاحظات", DataPropertyName = "Notes", Width = 200 }
              
            );
        }

        private async void LoadVaccinations(int? petId = null)
        {
            try
            {
                _allPets = await ApiHelper.GetAsync<List<dynamic>>("pets");


                string endpoint = "vaccinations";
                if (petId.HasValue) endpoint += $"?petId={petId}";

                var vaccinations = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
                _allRecords = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
                dgvVaccinations.DataSource = vaccinations;
                // Apply initial filter
                if (petId.HasValue)
                {
                    // Select specific pet
                    var pet = _allPets.FirstOrDefault(p => (int)p.PetID == petId.Value);
                    if (pet != null)
                    {
                        ddlPetFilter.SelectedValue = pet.PetID;
                        ddlPetCode.SelectedValue = pet.PetID;
                    }
                }
                var petList = new List<dynamic>();
                petList.Add(new { PetID = 0, PetName = "-- جميع الحيوانات --", PetCode = "-- الكل --" });
                foreach (dynamic pet in _allPets)
                {
                    petList.Add(new
                    {
                        PetID = (int)pet.PetID,
                        PetName = (string)pet.PetName,
                        PetCode = (string)pet.PetCode
                    });
                }
                // Setup Pet Name dropdown
                ddlPetFilter.DataSource = null;
                ddlPetFilter.Items.Clear();
                ddlPetFilter.DataSource = petList;
                ddlPetFilter.DisplayMember = "PetName";
                ddlPetFilter.ValueMember = "PetID";

                // Setup Pet Code dropdown
                ddlPetCode.DataSource = null;
                ddlPetCode.Items.Clear();
                ddlPetCode.DataSource = petList;
                ddlPetCode.DisplayMember = "PetCode";
                ddlPetCode.ValueMember = "PetID";

                // Select "All Pets" by default
                ddlPetFilter.SelectedIndex = 0;
                ddlPetCode.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل التطعيمات: " + ex.Message);
            }
        }
        private async void LoadPetsForFilter()
        {
            try
            {
                var pets = await ApiHelper.GetAsync<List<dynamic>>("pets");
                ddlPetFilter.Items.Add(new { PetName = "جميع الحيوانات", PetID = 0 });
                foreach (var pet in pets)
                {
                    ddlPetFilter.Items.Add(pet);
                }
                ddlPetFilter.DisplayMember = "PetName";
                ddlPetFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الحيوانات: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int? petId = null;
            if (ddlPetFilter.SelectedIndex > 0)
            {
                dynamic selected = ddlPetFilter.SelectedItem;
                petId = (int)selected.PetID;
            }
            LoadVaccinations(petId);
        }

        private void btnAddVaccination_Click(object sender, EventArgs e)
        {
            int? selectedPetId = null;
            // Get pet from grid selection (if any)
            if (dgvVaccinations.SelectedRows.Count > 0)
            {
                dynamic selectedRecord = dgvVaccinations.SelectedRows[0].DataBoundItem;
                selectedPetId = (int)selectedRecord.PetID;
            }
            // Or get pet from constructor parameter (if form was opened for specific pet)
            else if (_petId.HasValue)
            {
                selectedPetId = _petId.Value;
            }

            using (var form = new AddVaccinationForm(selectedPetId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadVaccinations(_petId);
                }
            }
        }

        private void btnPrintReminder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("طباعة تذكير غير مطبقة بعد!");
        }

        private void VaccinationsListForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ddlPetFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPetFilter.SelectedValue == null) return;
            try
            {
                // 👇 EXTRACT PetID FROM SELECTED ITEM (JObject)
                dynamic selectedItem = ddlPetFilter.SelectedItem;
                int selectedPetId = (int)selectedItem.PetID;

                // Synchronize Pet Code dropdown
                ddlPetCode.SelectedIndexChanged -= ddlPetCode_SelectedIndexChanged;
                ddlPetCode.SelectedItem = selectedItem;
                ddlPetCode.SelectedIndexChanged += ddlPetCode_SelectedIndexChanged;

                // Filter records
                FilterRecords(selectedPetId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تصفية السجلات: " + ex.Message);
            }
        }

        private void ddlPetCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPetCode.SelectedValue == null) return;

            try
            {
                // 👇 EXTRACT PetID FROM SELECTED ITEM (JObject)
                dynamic selectedItem = ddlPetCode.SelectedItem;
                int selectedPetId = (int)selectedItem.PetID;

                // Synchronize Pet Name dropdown
                ddlPetFilter.SelectedIndexChanged -= ddlPetFilter_SelectedIndexChanged;
                ddlPetFilter.SelectedItem = selectedItem;
                ddlPetFilter.SelectedIndexChanged += ddlPetFilter_SelectedIndexChanged;

                // Filter records
                FilterRecords(selectedPetId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تصفية السجلات: " + ex.Message);
            }
        }

        private void FilterRecords(int petId)
        {
            if (petId == 0)
            {
                // Show all records
                dgvVaccinations.DataSource = _allRecords;
            }
            else
            {

                // Filter by pet ID
                var filteredRecords = _allRecords
                    .Where(r => (int)r.PetID == petId)
                    .ToList();
                dgvVaccinations.DataSource = filteredRecords;
            }
        }
    }
}
