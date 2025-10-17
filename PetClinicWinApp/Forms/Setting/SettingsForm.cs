using PetClinicWinApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetClinicWinApp.Forms.Setting
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            
            Settings.Default.ApiBaseUrl = $"http://{Settings.Default.ApiServerIp}:{Settings.Default.ApiPort}/api/";
            txtApiUrl.Text = Settings.Default.ApiBaseUrl;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtServerIp.Text))
                {
                    MessageBox.Show("يرجى إدخال عنوان الخادم!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPort.Text))
                {
                    MessageBox.Show("يرجى إدخال المنفذ!");
                    return;
                }

                // 👇 SAVE ONLY IP AND PORT
                Settings.Default.ApiServerIp = txtServerIp.Text.Trim();
                Settings.Default.ApiPort = txtPort.Text.Trim();
                Settings.Default.Save();

                MessageBox.Show("تم حفظ الإعدادات بنجاح!\nيرجى إعادة تشغيل التطبيق لتفعيل التغييرات.",
                    "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ: " + ex.Message;
            }

        }
    }
}
