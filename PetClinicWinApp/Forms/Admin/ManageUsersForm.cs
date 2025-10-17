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
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = false;
            SetupGridColumns();
            LoadUsers();
        }
        private void SetupGridColumns()
        {
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "Username",
                    HeaderText = "اسم المستخدم",
                    DataPropertyName = "Username",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Role",
                    HeaderText = "الدور",
                    DataPropertyName = "Role",
                    Width = 100
                },
                new DataGridViewCheckBoxColumn
                {
                    Name = "IsActive",
                    HeaderText = "نشط",
                    DataPropertyName = "IsActive",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "StaffName",
                    HeaderText = "الموظف المرتبط",
                    DataPropertyName = "StaffName",
                    Width = 200
                }
            );
        }
        private async void LoadUsers()
        {
            try
            {
                var users = await ApiHelper.GetAsync<List<dynamic>>("users");

                dgvUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ: " + ex.Message + "\n\nتأكد أنك مسجل كـ Admin");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddUserForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار مستخدم من القائمة!");
                return;
            }

            var selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as dynamic;
            int userId = selectedUser.UserID != null ? Convert.ToInt32(selectedUser.UserID) : 0;
            string username = selectedUser.Username;
            string role = selectedUser.Role;
            bool isActive = selectedUser.IsActive != null ? Convert.ToBoolean(selectedUser.IsActive) : false;

            using (var form = new EditUserForm(userId, username, role, isActive))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers(); // Refresh grid
                }
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // Check if a user is selected
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار مستخدم من القائمة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Get selected user
            dynamic selectedUser = dgvUsers.SelectedRows[0].DataBoundItem;
            int userId = Convert.ToInt32(selectedUser.UserID);
            string username = selectedUser.Username?.ToString() ?? "غير معروف";

            // Prevent deleting yourself
            //if (userId == Program.CurrentUser?.UserId)
            //{
            //    MessageBox.Show("لا يمكنك حذف نفسك!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            // Confirm deletion
            var result = MessageBox.Show(
                $"هل أنت متأكد من حذف المستخدم '{username}'؟\n\n" +
                "سيتم حذف المستخدم من جدول المستخدمين والموظفين.",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2 // Make "No" default for safety
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Call API to delete user
                    dynamic deleteResult = await ApiHelper.DeleteAsync<dynamic>($"users/{userId}");

                    if ((bool)deleteResult.success)
                    {
                        MessageBox.Show("تم حذف المستخدم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("فشل في حذف المستخدم: " + deleteResult.message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في حذف المستخدم: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
