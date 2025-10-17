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

namespace PetClinicWinApp.Forms.Medical
{
    public partial class AddMedicalRecordForm : Form
    {
        private int? _preselectedPetId;

        public AddMedicalRecordForm() : this(null)
        {
        }
        public AddMedicalRecordForm(int? selectedPetId)
        {
            _preselectedPetId = selectedPetId;
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlPet.SelectedValue == null || ddlDoctor.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار حيوان وطبيب!");
                return;
            }

            var record = new MedicalRecordModel
            {
                PetID = Convert.ToInt32(ddlPet.SelectedValue),
                StaffID = Convert.ToInt32(ddlDoctor.SelectedValue),
                VisitDate = dtpVisitDate.Value,
                Diagnosis = txtDiagnosis.Text.Trim(),
                Treatment = txtTreatment.Text.Trim(),
                Prescription = txtPrescription.Text.Trim(),
                Notes = txtNotes.Text.Trim()
            };

            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("medicalrecords", record);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم حفظ السجل الطبي بنجاح!");
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

        private async void AddMedicalRecordForm_Load(object sender, EventArgs e)
        {
            await LoadPets();
            await LoadDoctors();
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
            else
    {
        //        // No pet selected - show "All Pets" and "All Owners"
        //ddlPet.Items.Insert(0, new { PetID = 0, PetName = "-- جميع الحيوانات --" });
        //ddlPet.DisplayMember = "PetName";
        //ddlPet.ValueMember = "PetID";
        //ddlPet.SelectedIndex = 0;
        //// No pets available - show empty owner
        //ddlPetOwner.Items.Clear();
        //ddlPetOwner.Items.Add(new { OwnerID = 0, FullName = "-- سيتم تحديد المالك تلقائيًا --" });
        //ddlPetOwner.DisplayMember = "FullName";
        //ddlPetOwner.ValueMember = "OwnerID";
        //ddlPetOwner.SelectedIndex = 0;
        //ddlPetOwner.Enabled = false;
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

                ddlPetCode.DataSource = pets;
                ddlPetCode.DisplayMember = "PetCode";
                ddlPetCode.ValueMember = "PetID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الحيوانات: " + ex.Message);
            }
        }

        private async Task LoadDoctors()
        {
            try
            {
                var doctors = await ApiHelper.GetAsync<List<dynamic>>("staff?position=Doctor");
                ddlDoctor.DataSource = doctors;
                ddlDoctor.DisplayMember = "FullName";
                ddlDoctor.ValueMember = "StaffID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الأطباء: " + ex.Message);
            }
        }

        private void ddlPet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPet.SelectedValue == null) return;

            try
            {
                // Get selected pet
                dynamic selectedPet = ddlPet.SelectedItem;

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
                MessageBox.Show("خطأ في تحميل بيانات المالك: " + ex.Message);
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
                MessageBox.Show("خطأ في تحميل بيانات المالك: " + ex.Message);
            }
        }
    }
}
