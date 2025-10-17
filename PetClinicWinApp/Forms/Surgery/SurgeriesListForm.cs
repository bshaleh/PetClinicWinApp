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

namespace PetClinicWinApp.Forms.Surgery
{
    public partial class SurgeriesListForm : Form
    {
        private int? _petId;
        private List<dynamic> _allPets;
        private List<dynamic> _allRecords;
        public SurgeriesListForm() : this(null)
        {
        }
        public SurgeriesListForm(int? petId)
        {
            _petId = petId;
            InitializeComponent();
            dgvSurgeries.AutoGenerateColumns = false;
            LoadSurgeries();
            LoadPetsForFilter();
            dgvSurgeries.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "PetName", HeaderText = "اسم الحيوان", DataPropertyName = "PetName", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "PetCode", HeaderText = "كود الحيوان", DataPropertyName = "PetCode", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "SurgeryName", HeaderText = "اسم العملية", DataPropertyName = "SurgeryName", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "SurgeryDate", HeaderText = "تاريخ العملية", DataPropertyName = "SurgeryDate", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "SurgeonName", HeaderText = "الجراح", DataPropertyName = "SurgeonName", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Outcome", HeaderText = "النتيجة", DataPropertyName = "Outcome", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Notes", HeaderText = "ملاحظات", DataPropertyName = "Notes", Width = 200 }
            );
        }

        private async void LoadSurgeries(int? petId = null)
        {
            try
            {
                // Load all pets for dropdowns
                _allPets = await ApiHelper.GetAsync<List<dynamic>>("pets");

                string endpoint = "surgeries";
                if (petId.HasValue) endpoint += $"?petId={petId}";

                var surgeries = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
                _allRecords = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
                dgvSurgeries.DataSource = surgeries;
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
                MessageBox.Show("خطأ في تحميل العمليات: " + ex.Message);
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
            LoadSurgeries(petId);
        }

        private void btnAddSurgery_Click(object sender, EventArgs e)
        {
            int? selectedPetId = null;
            // Get pet from grid selection (if any)
            if (dgvSurgeries.SelectedRows.Count > 0)
            {
                dynamic selectedRecord = dgvSurgeries.SelectedRows[0].DataBoundItem;
                selectedPetId = (int)selectedRecord.PetID;
            }
            // Or get pet from constructor parameter (if form was opened for specific pet)
            else if (_petId.HasValue)
            {
                selectedPetId = _petId.Value;
            }
            using (var form = new AddSurgeryForm(selectedPetId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSurgeries(_petId);
                }
            }
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
                dgvSurgeries.DataSource = _allRecords;
            }
            else
            {

                // Filter by pet ID
                var filteredRecords = _allRecords
                    .Where(r => (int)r.PetID == petId)
                    .ToList();
                dgvSurgeries.DataSource = filteredRecords;
            }
        }
    }
}
