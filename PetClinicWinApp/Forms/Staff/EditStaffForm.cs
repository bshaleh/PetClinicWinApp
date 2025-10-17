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

namespace PetClinicWinApp.Forms.Staff
{
    public partial class EditStaffForm : Form
    {
        private int _staffId;
        public EditStaffForm(int staffId)
        {
            _staffId = staffId;
            InitializeComponent();
        }

        private async void EditStaffForm_Load(object sender, EventArgs e)
        {
            // Populate dropdowns
            ddlPosition.Items.AddRange(new[] { "Doctor", "Receptionist", "Nurse", "Admin", "Technician" });
            await LoadBranches();
            await LoadUsers();
            await LoadStaffDetails();
        }
        private async Task LoadStaffDetails()
        {
            try
            {
                // 👇 GET LIST WITH ONE ITEM
                var staffList = await ApiHelper.GetAsync<List<dynamic>>($"staff?staffId={_staffId}");

                if (staffList.Count > 0)
                {
                    dynamic staff = staffList[0]; // 👈 TAKE FIRST ITEM

                    txtFullName.Text = staff.FullName?.ToString() ?? "";
                    ddlPosition.SelectedItem = staff.Position?.ToString();
                    txtPhone.Text = staff.Phone?.ToString() ?? "";
                    txtEmail.Text = staff.Email?.ToString() ?? "";
                    txtSalary.Text = staff.Salary?.ToString() ?? "";

                    if (staff.HireDate != null)
                    {
                        dtpHireDate.Value = Convert.ToDateTime(staff.HireDate.ToString());
                    }

                    if (staff.BranchID != null)
                    {
                        ddlBranch.SelectedValue = Convert.ToInt32(staff.BranchID.ToString());
                    }

                    if (staff.UserID != null)
                    {
                        ddlUserAccount.SelectedValue = Convert.ToInt32(staff.UserID.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على بيانات الموظف!");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل بيانات الموظف: " + ex.Message);
            }
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

            var staffData = new
            {
                StaffID = _staffId,
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
                // PUT /api/staff/{id} to update staff
                dynamic result = await ApiHelper.PutAsync<dynamic>($"staff/{_staffId}", staffData);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم تحديث بيانات الموظف بنجاح!");
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
    }
}
