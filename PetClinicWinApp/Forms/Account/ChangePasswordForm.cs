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

namespace PetClinicWinApp.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private int _userId;
        public ChangePasswordForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                MessageBox.Show("يرجى إدخال كلمة المرور الحالية!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("يرجى إدخال كلمة المرور الجديدة!");
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("كلمة المرور الجديدة وتأكيدها غير متطابقين!");
                return;
            }

            var passwordData = new
            {
                userId = _userId,
                currentPassword = txtCurrentPassword.Text,
                newPassword = txtNewPassword.Text
            };

            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("auth/changepassword", passwordData);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم تغيير كلمة المرور بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("خطأ في تغيير كلمة المرور: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxShowOldPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowOldPassword.Checked)
            {
                txtCurrentPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtCurrentPassword.UseSystemPasswordChar = true;
            }
        }

        private void checkBoxShow1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShow1.Checked)
            {
                txtNewPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = true;
            }
        }

        private void checkBoxShow2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShow2.Checked)
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
