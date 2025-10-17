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

namespace PetClinicWinApp.Forms.Staff
{
    public partial class AddStaffForm : Form
    {
       

        

        public AddStaffForm()
        {
            
            InitializeComponent();

        }
  

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("الاسم الكامل مطلوب!");
                return;
            }
            if (ddlPosition.SelectedItem == null)
            {
                MessageBox.Show("يرجى اختيار وظيفة!");
                return;
            }
            if (ddlBranch.SelectedValue == null || Convert.ToInt32(ddlBranch.SelectedValue) == 0)
            {
                MessageBox.Show("يرجى اختيار فرع!");
                return;
            }

            decimal salary = 0;
            if (!string.IsNullOrWhiteSpace(txtSalary.Text))
            {
                if (!decimal.TryParse(txtSalary.Text, out salary))
                {
                    MessageBox.Show("يرجى إدخال راتب صحيح!");
                    return;
                }
            }

            // Prepare staff data
            var staff = new
            {
                FullName = txtFullName.Text.Trim(),
                Position = ddlPosition.SelectedItem.ToString(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Salary = salary > 0 ? (decimal?)salary : null,
                HireDate = dtpHireDate.Value.Date,
                BranchID = Convert.ToInt32(ddlBranch.SelectedValue),
                UserID = ddlUserAccount.SelectedValue != null && Convert.ToInt32(ddlUserAccount.SelectedValue) != 0
                         ? (int?)Convert.ToInt32(ddlUserAccount.SelectedValue)
                         : null
            };

            try
            {
                // POST to /api/staff
                dynamic result = await ApiHelper.PostAsync<dynamic>("staff", staff);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم إضافة الموظف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                lblMessage.Text = "خطأ: " + ex.Message;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void AddStaffForm_Load(object sender, EventArgs e)
        {
            // Populate dropdowns
            ddlPosition.Items.AddRange(new[] { "Doctor", "Receptionist", "Nurse", "Admin", "Technician" });
            ddlPosition.SelectedIndex = 0;

            await LoadBranches();
            await LoadUsers();
        }
        private async Task LoadBranches()
        {
            try
            {
                var branches = await ApiHelper.GetAsync<List<dynamic>>("branches");

                // Add "Select Branch" option
                var branchList = new List<dynamic>();
                branchList.Add(new { BranchID = 0, BranchName = "-- اختر فرعًا --" });
                foreach (dynamic branch in branches)
                {
                    branchList.Add(new
                    {
                        BranchID = (int)branch.BranchID,
                        BranchName = (string)branch.BranchName
                    });
                }

                ddlBranch.DataSource = null;
                ddlBranch.Items.Clear();
                ddlBranch.DataSource = branchList;
                ddlBranch.DisplayMember = "BranchName";
                ddlBranch.ValueMember = "BranchID";
                ddlBranch.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ في تحميل الفروع: " + ex.Message;
            }
        }
        private async Task LoadUsers()
        {
            try
            {
                var users = await ApiHelper.GetAsync<List<dynamic>>("users");

                // Add "No User Account" option
                var userList = new List<dynamic>();
                userList.Add(new { UserID = 0, Username = "-- بدون حساب مستخدم --" });
                foreach (dynamic user in users)
                {
                    userList.Add(new
                    {
                        UserID = (int)user.UserID,
                        Username = (string)user.Username
                    });
                }

                ddlUserAccount.DataSource = null;
                ddlUserAccount.Items.Clear();
                ddlUserAccount.DataSource = userList;
                ddlUserAccount.DisplayMember = "Username";
                ddlUserAccount.ValueMember = "UserID";
                ddlUserAccount.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ في تحميل المستخدمين: " + ex.Message;
            }
        }

        private async Task LoadStaff(int staffId)
        {
            try
            {
                dynamic staff = await ApiHelper.GetAsync<dynamic>($"staff/{staffId}");
                txtFullName.Text = staff.FullName;
                ddlPosition.Text = staff.Position;
                txtPhone.Text = staff.Phone;
                txtEmail.Text = staff.Email;
                ddlBranch.SelectedValue = staff.BranchID;
                txtSalary.Text = staff.Salary?.ToString() ?? "";
                dtpHireDate.Value = staff.HireDate ?? DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل بيانات الموظف: " + ex.Message);
            }
        }
    }
}
