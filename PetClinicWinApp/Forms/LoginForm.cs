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
using PetClinicWinApp.Properties;
using PetClinicWinApp.Forms.Setting;

namespace PetClinicWinApp.Forms
{

    public partial class LoginForm : Form
    {
        public UserModel AuthenticatedUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // --- CHECK FOR FIXED SUPER ADMIN CREDENTIALS ---
            // Super Admin Credentials: sa_admin / sa_password123
            // These are hardcoded and not stored in the database.
            if (txtUsername.Text.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase) && txtPassword.Text.Trim() == "admin123")
            {
                // Grant full admin access
                AuthenticatedUser = new UserModel
                {
                    UserId = -1, // Use a special ID for super admin
                    Username = "admin",
                    Role = "Admin", // <-- Crucial: Assign Admin role
                    IsActive = true
                };
                ApiHelper.SetUserRole("Admin"); // Set role for API calls
                DialogResult = DialogResult.OK;
                Close();
                return; // Exit early, no need to call API
            }


            var loginData = new { username = txtUsername.Text.Trim(), password = txtPassword.Text.Trim() };
            
            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("auth/login", loginData);

               
                if (result.success == true)
                {
                    AuthenticatedUser = new UserModel
                    {
                        UserId = (int)result.userId,
                        Username = (string)result.username,
                        Role = (string)result.role,
                        BranchId = result.branchId == null ? (int?)null : (int)result.branchId,
                        BranchName = result.branchName == null ? null : (string)result.branchName
                    };

                    ApiHelper.SetUserRole((string)result.role); // Set for future API calls

                    DialogResult = DialogResult.OK;
                    Close();
                }
                 
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        private async void btnTestApi_Click(object sender, EventArgs e)
        {
            try
            {
                var test = await ApiHelper.GetAsync<dynamic>("owners");
                MessageBox.Show("API is reachable! Response: " + test.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Error: " + ex.Message + "\n\nInner: " + ex.InnerException?.Message);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            //e.DrawBackground();
            //e.DrawBorder();
            //e.DrawText();
        }

        private void txtUsername_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.Show(": اسم المستخدم",txtUsername);
            //toolTip1.OwnerDraw = true;
            //toolTip1.ForeColor = Color.Red;
            //toolTip1.BackColor = Color.Yellow;
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.Show(": كلمة السر", txtUsername);
            //toolTip1.OwnerDraw = true;
            //toolTip1.ForeColor = Color.Red;
            //toolTip1.BackColor = Color.Yellow;

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new SettingsForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("تم حفظ الإعدادات بنجاح!\nيرجى إعادة تشغيل التطبيق لتفعيل التغييرات.",
                        "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            await CheckConnectionStatus(); // 👈 CHECK CONNECTION ON LOAD
        }
        private async Task CheckConnectionStatus()
        {
            try
            {
                lblConnectionStatus.Text = "جارٍ التحقق من الاتصال...";
                lblConnectionStatus.ForeColor = System.Drawing.Color.Orange;

                // Test API connection
                var test = await ApiHelper.GetAsync<dynamic>("owners");
                lblConnectionStatus.Text = "✅ متصل بالخادم";
                lblConnectionStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblConnectionStatus.Text = "❌ غير متصل بالخادم";
                lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

}
