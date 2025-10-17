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

namespace PetClinicWinApp.Forms.Admin
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("اسم المستخدم مطلوب!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("كلمة المرور مطلوبة!");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("كلمة المرور وتأكيدها غير متطابقين!");
                return;
            }

            if (ddlRole.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى اختيار دور للمستخدم!");
                return;
            }
            if (ddlStaff.SelectedValue == null) // 👈 NEW VALIDATION
            {
                MessageBox.Show("يرجى اختيار موظف!");
                return;
            }
            // 👇 SAFE StaffID HANDLING
            int? _staffId = null;
            if (ddlStaff.SelectedValue != null)
            {
                try
                {
                    // Convert JValue to int safely
                    _staffId = Convert.ToInt32(ddlStaff.SelectedValue);
                    if (_staffId == 0) _staffId = null; // "No Staff" option
                }
                catch
                {
                    _staffId = null; // Fallback
                }
            }

            var user = new 
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                // Password will be hashed on server side
                Role = ddlRole.SelectedItem.ToString(),
                IsActive = chkIsActive.Checked,
                 StaffID = _staffId
            };

            try
            {
                // Send to API
                dynamic result = await ApiHelper.PostAsync<dynamic>("users", user);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم إنشاء المستخدم بنجاح!: ", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    // 👇 THIS WILL SHOW "اسم المستخدم موجود بالفعل!"
                    MessageBox.Show("خطأ: " + result.message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ: " + ex.Message;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void AddUserForm_Load(object sender, EventArgs e)
        {
            // Populate roles
            ddlRole.Items.AddRange(new[] { "Admin", "Doctor", "Receptionist" });
            ddlRole.SelectedIndex = 0; // Default to Admin

            // 👇 LOAD STAFF LIST
            await LoadStaff();
        }
        private async Task LoadStaff()
        {
            try
            {
                // 👇 GET ALL STAFF (even those without users)
                var staffList = await ApiHelper.GetAsync<List<dynamic>>("staff");

                // Add to dropdown
                ddlStaff.DataSource = staffList;
                ddlStaff.DisplayMember = "FullName";
                ddlStaff.ValueMember = "StaffID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الموظفين: " + ex.Message);
            }
        }


        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void checkBoxshowConf_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxshowConf.Checked)
            {
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
