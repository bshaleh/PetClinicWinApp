using PetClinicWinApp.Forms.Owners;
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
    public partial class AddPetForm : Form
    {
        public AddPetForm()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlOwner.SelectedValue == null || Convert.ToInt32(ddlOwner.SelectedValue) == 0)
            {
                MessageBox.Show("يرجى اختيار مالك أو إضافة مالك جديد!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPetName.Text))
            {
                MessageBox.Show("اسم الحيوان مطلوب!");
                return;
            }

            var pet = new
            {
                PetName = txtPetName.Text.Trim(),
                Species = ddlSpecies.SelectedItem?.ToString() ?? "",
                Breed = txtBreed.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                Gender = ddlGender.SelectedItem?.ToString() ?? "",
                OwnerID = Convert.ToInt32(ddlOwner.SelectedValue)
            };

            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("pets", pet);
                if ((bool)result.success)
                {
                    MessageBox.Show($"تم إضافة الحيوان بنجاح! رمز الحيوان: {result.petCode}");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("خطأ: " + result.message);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ: " + ex.Message;
            }
            //if (ddlOwner.SelectedValue == null || Convert.ToInt32(ddlOwner.SelectedValue) == 0)
            //{
            //    MessageBox.Show("يرجى اختيار مالك أو إضافة مالك جديد!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(txtPetName.Text))
            //{
            //    MessageBox.Show("اسم الحيوان مطلوب!");
            //    return;
            //}

            ////if (ddlOwner.SelectedValue == null)
            ////{
            ////    MessageBox.Show("يرجى اختيار مالك!");
            ////    return;
            ////}
            ////int ownerId;
            ////try
            ////{
            ////    ownerId = Convert.ToInt32(ddlOwner.SelectedValue);
            ////}
            ////catch
            ////{
            ////    MessageBox.Show("خطأ في اختيار المالك!");
            ////    return;
            ////}
            ////if (string.IsNullOrWhiteSpace(txtPetName.Text))
            ////{
            ////    MessageBox.Show("اسم الحيوان مطلوب!");
            ////    return;
            ////}
            //var pet = new 
            //{
            //    PetName = txtPetName.Text.Trim(),
            //    Species = ddlSpecies.SelectedItem?.ToString() ?? "",
            //    Breed = txtBreed.Text.Trim(),
            //    BirthDate = dtpBirthDate.Value,
            //    Gender = ddlGender.SelectedItem?.ToString() ?? "",
            //    OwnerID = Convert.ToInt32(ddlOwner.SelectedValue)
            //};

            //try
            //{
            //    dynamic result = await ApiHelper.PostAsync<dynamic>("pets", pet);
            //    if ((bool)result.success)
            //    {
            //        MessageBox.Show("تم إضافة الحيوان بنجاح!");
            //        DialogResult = DialogResult.OK;
            //        await LoadOwners();
            //        Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = "خطأ: " + ex.Message;
            //}

        }

        private async void AddPetForm_Load(object sender, EventArgs e)
        {
            ddlSpecies.Items.AddRange(new[] { "Dog", "Cat", "Bird", "Rabbit", "Other" });
            ddlGender.Items.AddRange(new[] { "Male", "Female" });
            await LoadOwners();
        }
        private async Task LoadOwners()
        {
            
            try
            {
                var owners = await ApiHelper.GetAsync<List<PetOwnerModel>>("owners");
                //ddlOwner.DataSource = null;
                //ddlOwner.Items.Clear();
                var pets = await ApiHelper.GetAsync<List<PetModel>>("Pets");

                var ownerList = new List<PetOwnerModel>();
                var petList = new List<PetModel>();

                ownerList.Add(new PetOwnerModel { OwnerID = 0, FullName = "-- اختر مالكًا --" });
                petList.Add(new PetModel { PetID = -1, Breed = "-- اختر سلالة --" });

                foreach (dynamic owner in owners)
                {
                    ownerList.Add(new PetOwnerModel
                    {
                        OwnerID = (int)owner.OwnerID,
                        FullName = (string)owner.FullName
                    });
                }
                foreach (PetModel pet in pets)
                {
                    petList.Add(new PetModel
                    {
                        PetID = (int)pet.PetID,
                        Breed = (string)pet.Breed
                    });
                }

                txtBreed.DataSource = null;
                txtBreed.Items.Clear();
                txtBreed.DataSource = petList;
                txtBreed.DisplayMember = "Breed";
                txtBreed.ValueMember = "PetID";

                //ddlOwner.DataSource = owners;
                ddlOwner.DataSource = null;
                ddlOwner.Items.Clear();
                ddlOwner.DataSource = ownerList;
                ddlOwner.DisplayMember = "FullName";
                ddlOwner.ValueMember = "OwnerID";
                ddlOwner.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("خطأ في تحميل المالكين: " + ex.Message);
                var fallbackList = new List<PetOwnerModel>
                 {
                   new PetOwnerModel { OwnerID = 0, FullName = "-- اختر مالكًا --" }
                 };
                ddlOwner.DataSource = null;
                ddlOwner.Items.Clear();
                ddlOwner.DataSource = fallbackList;
                ddlOwner.DisplayMember = "FullName";
                ddlOwner.ValueMember = "OwnerID";
                ddlOwner.SelectedIndex = 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAddOwner_Click(object sender, EventArgs e)
        {
            using (var form = new AddOwnerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Refresh owner list and select the new owner
                    await LoadOwners();

                    // Select the newly added owner (last item in list)
                    if (ddlOwner.Items.Count > 0)
                    {
                        ddlOwner.SelectedIndex = ddlOwner.Items.Count - 1;
                    }
                }
            }
        }
    }
}
