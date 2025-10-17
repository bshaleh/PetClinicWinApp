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

namespace PetClinicWinApp.Forms.Admin
{
    public partial class EditUserForm : Form
    {

        private int _userId;
        public EditUserForm(int userId, string username, string role, bool isActive)
        {
            _userId = userId;
            InitializeComponent();
            txtUsername.Text = username;
            ddlRole.SelectedItem = role;
            chkIsActive.Checked = isActive;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("اسم المستخدم مطلوب!");
                return;
            }

            var userData = new
            {
                userId = _userId,
                username = txtUsername.Text.Trim(),
                role = ddlRole.SelectedItem.ToString(),
                isActive = chkIsActive.Checked
            };

            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("users/update", userData);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم تعديل المستخدم بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
