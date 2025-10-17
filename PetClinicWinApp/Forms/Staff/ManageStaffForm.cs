using PetClinicWinApp.Forms.Admin;
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
    public partial class ManageStaffForm : Form
    {
        public ManageStaffForm()
        {
            InitializeComponent();
            dgvStaff.AutoGenerateColumns = false;
            // Configure columns (if not done in designer)
            SetupGridColumns();
            LoadStaffPositions();
            LoadStaff();    
        }
        private async void LoadStaffPositions()
        {
            // Add "جميع الموظفين" option
            ddlPositionFilter.Items.Add("جميع الموظفين");

            // Add actual positions (you can hardcode or fetch from API)
            ddlPositionFilter.Items.AddRange(new[] { "Doctor", "Receptionist", "Nurse", "Admin" });
            ddlPositionFilter.SelectedIndex = 0; // Select "جميع الموظفين"
        }
        private async void LoadStaff(string position = null)
        {
            try
            {
                string endpoint = "staff";
                if (!string.IsNullOrEmpty(position) && position != "جميع الموظفين")
                {
                    endpoint += $"?position={position}";
                }

                // Disable auto-generation and set columns
                dgvStaff.AutoGenerateColumns = false;

                var staff = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
                dgvStaff.DataSource = staff;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الموظفين: " + ex.Message);
            }
        }

        private void SetupGridColumns()
        {
            dgvStaff.Columns.Clear(); // Clear any auto-generated columns

            dgvStaff.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "FullName",
                    HeaderText = "الاسم الكامل",
                    DataPropertyName = "FullName",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Position",
                    HeaderText = "الوظيفة",
                    DataPropertyName = "Position",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "BranchName",
                    HeaderText = "الفرع",
                    DataPropertyName = "BranchName",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Phone",
                    HeaderText = "رقم الجوال",
                    DataPropertyName = "Phone",
                    Width = 150
                },
                
                new DataGridViewTextBoxColumn
                {
                    Name = "Salary",
                    HeaderText = "الراتب",
                    DataPropertyName = "Salary",
                    Width = 250
                }
            );
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string position = ddlPositionFilter.SelectedItem?.ToString();
            LoadStaff(position);
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            using (var form = new AddStaffForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadStaff();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار صف من القائمة!");
                return;
            } 

            dynamic selectedStaff = dgvStaff.SelectedRows[0].DataBoundItem;
            int staffId = (int)selectedStaff.StaffID;

            using (var form = new EditStaffForm(staffId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadStaff();
                }
            }
        }

        private void btnSetSalary_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار موظف من القائمة!");
                return;
            }

            dynamic selectedStaff = dgvStaff.SelectedRows[0].DataBoundItem;
            int staffId = (int)selectedStaff.StaffID;
            string staffName = selectedStaff.FullName;

            using (var form = new SetSalaryForm(staffId, staffName))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Optionally refresh staff list or salary list
                     LoadStaff();
                }
            }
        }

        private async void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            // Check if a staff member is selected
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار موظف من القائمة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected staff
            dynamic selectedStaff = dgvStaff.SelectedRows[0].DataBoundItem;
            int staffId = Convert.ToInt32(selectedStaff.StaffID);
            string staffName = selectedStaff.FullName?.ToString() ?? "غير معروف";

            //// Prevent deleting yourself (if logged in user is this staff)
            //if (Program.CurrentUser != null && Program.CurrentUser.UserId == staffId)
            //{
            //    MessageBox.Show("لا يمكنك حذف نفسك!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // Confirm deletion
            var result = MessageBox.Show(
                $"هل أنت متأكد من حذف الموظف '{staffName}'؟\n\n" +
                "سيتم حذف الموظف نهائياً من النظام.",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2 // Make "No" default for safety
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Call DELETE /api/staff/{id}
                    dynamic deleteResult = await ApiHelper.DeleteAsync<dynamic>($"staff/{staffId}");

                    if ((bool)deleteResult.success)
                    {
                        MessageBox.Show("تم حذف الموظف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStaff(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("فشل في حذف الموظف: " + deleteResult.message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في حذف الموظف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
