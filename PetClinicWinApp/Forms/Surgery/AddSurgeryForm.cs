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

namespace PetClinicWinApp.Forms.Surgery
{
    public partial class AddSurgeryForm : Form
    {
        private int? _preselectedPetId;
       // private List<dynamic> _allPets; // Store all pets for linking

        public AddSurgeryForm() : this(null)
        {
        }
        public AddSurgeryForm(int? selectedPetId)
        {
            _preselectedPetId = selectedPetId;
            InitializeComponent();
            dtpSurgeryDate.Value = DateTime.Now; // Default to today
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlPet.SelectedValue == null || Convert.ToInt32(ddlPet.SelectedValue) == 0)
            {
                MessageBox.Show("يرجى اختيار حيوان!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSurgeryName.Text))
            {
                MessageBox.Show("اسم العملية مطلوب!");
                return;
            }
            if (ddlSurgeon.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار جراح!");
                return;
            }


            var surgery = new 
            {
                PetID = Convert.ToInt32(ddlPet.SelectedValue),
                SurgeryName = txtSurgeryName.Text.Trim(),
                SurgeryDate = dtpSurgeryDate.Value.Date,
                SurgeonID = Convert.ToInt32(ddlSurgeon.SelectedValue),
                Outcome = ddlOutcome.SelectedItem?.ToString() ?? "",
                Notes = txtNotes.Text.Trim()
            };

            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("surgeries", surgery);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم تسجيل العملية بنجاح!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    lblMessage.Text = "خطأ: " + result.message;
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

        private async void AddSurgeryForm_Load(object sender, EventArgs e)
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


                // No pet selected - show "All Pets" and "All Owners"

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
                //if (ddlPet.Items.Count > 0) ddlPet.SelectedIndex = 0;

                // Setup Pet Code dropdown
               
                ddlPetCode.DataSource = pets;
                ddlPetCode.DisplayMember = "PetCode";
                ddlPetCode.ValueMember = "PetID";
                //if (ddlPetCode.Items.Count > 0) ddlPetCode.SelectedIndex = 0;

                // Initialize Pet Owner dropdown
                //ddlPetOwner.Items.Clear();
                //ddlPetOwner.Items.Add(new { OwnerID = 0, FullName = "-- سيتم تحديد المالك تلقائيًا --" });
                //ddlPetOwner.DisplayMember = "FullName";
                //ddlPetOwner.ValueMember = "OwnerID";
                //ddlPetOwner.SelectedIndex = 0;
                //ddlPetOwner.Enabled = false;
                //var pets = await ApiHelper.GetAsync<List<dynamic>>("pets");
                //ddlPet.DataSource = pets;
                //ddlPet.DisplayMember = "PetName";
                //ddlPet.ValueMember = "PetID";
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

                ddlSurgeon.DataSource = doctors;
                ddlSurgeon.DisplayMember = "FullName";
                ddlSurgeon.ValueMember = "StaffID";

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
