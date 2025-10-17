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

namespace PetClinicWinApp.Forms.Medical
{
    public partial class MedicalRecordsListForm : Form
    {
        private int? _petId;

        private List<dynamic> _allPets;
        private List<dynamic> _allRecords;
 
        public MedicalRecordsListForm() : this(null)
        {
        }
        public MedicalRecordsListForm(int? petId)
        {
            _petId = petId;
            InitializeComponent();
            dgvRecords.AutoGenerateColumns = false;
            LoadRecords(petId);
            if (petId.HasValue) LoadPetsForFilter(petId.Value);
            dgvRecords.Columns.AddRange(
    new DataGridViewTextBoxColumn { HeaderText = "تاريخ الزيارة", DataPropertyName = "VisitDate", Width = 150 },
    new DataGridViewTextBoxColumn { HeaderText = "رمز الحيوان", DataPropertyName = "PetCode", Width = 120 },
    new DataGridViewTextBoxColumn { HeaderText = "اسم الحيوان", DataPropertyName = "PetName", Width = 150 },
    new DataGridViewTextBoxColumn { HeaderText = "الطبيب", DataPropertyName = "DoctorName", Width = 150 },
    new DataGridViewTextBoxColumn { HeaderText = "التشخيص", DataPropertyName = "Diagnosis", Width = 200 },
    new DataGridViewTextBoxColumn { HeaderText = "العلاج", DataPropertyName = "Treatment", Width = 200 },
    new DataGridViewTextBoxColumn { HeaderText = "الوصفة", DataPropertyName = "Prescription", Width = 100 }
);
        }
        private async void LoadRecords(int? petId = null)
        {
            try
            {
               
                // Load all pets for dropdowns
                _allPets = await ApiHelper.GetAsync<List<dynamic>>("pets");
               

                // Load all records
                string endpoint = "medicalrecords";
                if (petId.HasValue) endpoint += $"?petId={petId.Value}";

                _allRecords = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
                

               
                // Setup dropdowns
                SetupPetDropdowns();

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
                else
                {
                    // Show all records initially
                    dgvRecords.DataSource = _allRecords;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message);
            }
            
        }

        private void SetupPetDropdowns()
        {
            // Add "All Pets" option
            var petList = new List<dynamic>();
            petList.Add(new { PetID = 0, PetName = "-- جميع الحيوانات --", PetCode = "-- الكل --" });
             // Convert each pet from API (JObject) into a consistent anonymous-like object
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
        private async void LoadPetsForFilter(int selectedPetId)
        {
            try
            {
                var pets = await ApiHelper.GetAsync<List<dynamic>>("pets");
                

                // Add "All Pets" option
                var petList = new List<dynamic>();
                petList.Add(new { PetID = 0, PetName = "-- جميع الحيوانات --", PetCode = "-- الكل --" });
                petList.AddRange(pets);

                // Setup Pet Name dropdown
                ddlPetFilter.DataSource = petList;
                ddlPetFilter.DisplayMember = "PetName";
                ddlPetFilter.ValueMember = "PetID";

                // Setup Pet Code dropdown  
                ddlPetCode.DataSource = petList;
                ddlPetCode.DisplayMember = "PetCode";
                ddlPetCode.ValueMember = "PetID";

                // Select "All Pets"
                ddlPetFilter.SelectedIndex = 0;
                ddlPetCode.SelectedIndex = 0;
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
            LoadRecords(petId);
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            int? selectedPetId = null;
            // Get pet from grid selection (if any)
            if (dgvRecords.SelectedRows.Count > 0)
            {
                dynamic selectedRecord = dgvRecords.SelectedRows[0].DataBoundItem;
                selectedPetId = (int)selectedRecord.PetID;
            }
            // Or get pet from constructor parameter (if form was opened for specific pet)
            else if (_petId.HasValue)
            {
                selectedPetId = _petId.Value;
            }

            using (var form = new AddMedicalRecordForm(selectedPetId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadRecords(_petId); // Refresh
                }
            }
          
        }

        private async void btnPrint_Click(object sender, EventArgs e)
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
                dgvRecords.DataSource = _allRecords;
            }
            else
            {

                // Filter by pet ID
                var filteredRecords = _allRecords
                    .Where(r => (int)r.PetID == petId)
                    .ToList();
                dgvRecords.DataSource = filteredRecords;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

    
    }
}
