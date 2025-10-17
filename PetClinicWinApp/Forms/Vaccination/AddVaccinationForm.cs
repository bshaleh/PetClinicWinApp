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

namespace PetClinicWinApp.Forms.Vaccination
{
    public partial class AddVaccinationForm : Form
    {
        private int? _preselectedPetId;
        public AddVaccinationForm() : this(null)
        {
        }
        public AddVaccinationForm(int? selectedPetId)
        {
            _preselectedPetId = selectedPetId;
            InitializeComponent();
            dtpVaccinationDate.Value = DateTime.Now; // Default to today
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlPet.SelectedValue == null || string.IsNullOrWhiteSpace(txtVaccineName.Text))
            {
                MessageBox.Show("يرجى اختيار حيوان وإدخال اسم اللقاح!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtVaccineName.Text))
            {
                MessageBox.Show("اسم اللقاح مطلوب!");
                return;
            }

            var vaccination = new 
            {
                PetID = Convert.ToInt32(ddlPet.SelectedValue),
                VaccineName = txtVaccineName.Text.Trim(),
                VaccinationDate = dtpVaccinationDate.Value,
                NextDueDate = dtpNextDueDate.Value,
                AdministeredBy = Convert.ToInt32(ddlAdministeredBy.SelectedValue),
                Notes = txtNotes.Text.Trim()
            };

            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("vaccinations", vaccination);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم تسجيل التطعيم بنجاح!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void AddVaccinationForm_Load(object sender, EventArgs e)
        {
            await LoadPets();
            await LoadStaff();
            // If a specific pet was pre-selected, select it and its owner
            if (_preselectedPetId.HasValue)
            {
                // Find and select the pet
                for (int i = 0; i < ddlPet.Items.Count; i++)
                {
                    dynamic pet = ddlPet.Items[i];
                    if ((int)pet.PetID == _preselectedPetId.Value)
                    {
                        ddlPet.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        private async Task LoadPets()
        {
            try
            {
                var pets = await ApiHelper.GetAsync<List<dynamic>>("pets");
                ddlPet.DataSource = pets;
                ddlPet.DisplayMember = "PetName";
                ddlPet.ValueMember = "PetID";
                // Setup Pet Code dropdown

                ddlPetCode.DataSource = pets;
                ddlPetCode.DisplayMember = "PetCode";
                ddlPetCode.ValueMember = "PetID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الحيوانات: " + ex.Message);
            }
        }

        private async Task LoadStaff()
        {
            try
            {
                var staff = await ApiHelper.GetAsync<List<dynamic>>("staff");
                ddlAdministeredBy.DataSource = staff;
                ddlAdministeredBy.DisplayMember = "FullName";
                ddlAdministeredBy.ValueMember = "StaffID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الموظفين: " + ex.Message);
            }
        }

        private void ddlPet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPet.SelectedValue == null) return;

            try
            {
                dynamic selectedPet = ddlPet.SelectedItem;

                // Update Pet Owner dropdown
                ddlPetOwner.Items.Clear();
                ddlPetOwner.Items.Add(new
                {
                    OwnerID = (int)selectedPet.OwnerID,
                    FullName = (string)selectedPet.OwnerName
                });
                ddlPetOwner.DisplayMember = "FullName";
                ddlPetOwner.ValueMember = "OwnerID";
                ddlPetOwner.SelectedIndex = 0;
                ddlPetOwner.Enabled = true;

                // Synchronize Pet Code dropdown
                ddlPetCode.SelectedIndexChanged -= ddlPetCode_SelectedIndexChanged; // Prevent recursion
                ddlPetCode.SelectedValue = selectedPet.PetID;
                ddlPetCode.SelectedIndexChanged += ddlPetCode_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحديث بيانات المالك أو رمز الحيوان: " + ex.Message);
            }
        }

        private void ddlPetCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPetCode.SelectedValue == null) return;

            try
            {
                // Get selected pet
                dynamic selectedPet = ddlPetCode.SelectedItem;

                // Clear and set owner
                ddlPetOwner.Items.Clear();
                ddlPetOwner.Items.Add(new
                {
                    OwnerID = (int)selectedPet.OwnerID,
                    FullName = (string)selectedPet.OwnerName
                });
                ddlPetOwner.DisplayMember = "FullName";
                ddlPetOwner.ValueMember = "OwnerID";
                ddlPetOwner.SelectedIndex = 0;
                ddlPetOwner.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في مزامنة اسم الحيوان: " + ex.Message);
            }
        }
    }
}
