using PetClinicWinApp.Forms.Pets;
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

namespace PetClinicWinApp.Forms.Appointments
{
    public partial class BookAppointmentForm : Form
    {
        public BookAppointmentForm()
        {
            InitializeComponent();
        }



        private async void btnBook_Click(object sender, EventArgs e)
        {
            if (ddlPet.Items.Count == 0)
            {
                MessageBox.Show("لا يمكن الحجز دون وجود حيوانات مسجلة. الرجاء إضافة حيوان أولاً.");
                return;
            }

            if (ddlPet.SelectedValue == null || ddlStaff.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار حيوان وطبيب!");
                return;
            }

            var appointment = new
            {
                PetID = Convert.ToInt32(ddlPet.SelectedValue),
                StaffID = Convert.ToInt32(ddlStaff.SelectedValue),
                BranchID = Convert.ToInt32(ddlBranchID.SelectedValue), // Get from session later
                AppointmentDate = dtpAppointment.Value,
                Reason = txtReason.Text.Trim(),
                Status = "Scheduled"
            };

            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("appointments", appointment);


                if ((bool)result.success)
                {
                    MessageBox.Show("تم حجز الموعد بنجاح!");
                    BookedAppointmentDate = dtpAppointment.Value;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message);
            }
        }
        public DateTime? BookedAppointmentDate { get; private set; }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void BookAppointmentForm_Load(object sender, EventArgs e)
        {
            await LoadPets();
            await LoadDoctors();
            await LoadBranches();
        }
        private async Task LoadPets()
        {
            try
            {
                var pets = await ApiHelper.GetAsync<List<dynamic>>("pets");
                ddlPet.DataSource = pets;
                ddlPet.DisplayMember = "PetName";
                ddlPet.ValueMember = "PetID";
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
                ddlStaff.DataSource = doctors;
                ddlStaff.DisplayMember = "FullName";
                ddlStaff.ValueMember = "StaffID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الأطباء: " + ex.Message);
            }
        }

        private async Task LoadBranches()
        {
            try
            {
                var branches = await ApiHelper.GetAsync<List<dynamic>>("Branches");
                ddlBranch.DataSource = branches;
                ddlBranch.DisplayMember = "BranchName";
                ddlBranch.ValueMember = "BranchID";

                ddlBranchID.DataSource = branches;
                ddlBranchID.DisplayMember = "BranchID";
                ddlBranchID.ValueMember = "BranchID";

            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الافرع: " + ex.Message);
            }
        }


        private async void btnAddPet_Click(object sender, EventArgs e)
        {
            using (var form = new AddPetForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Refresh pets list
                    await LoadPets();
                }
            }
        }
    }
}
