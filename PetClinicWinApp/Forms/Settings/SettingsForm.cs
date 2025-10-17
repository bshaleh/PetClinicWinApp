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

namespace PetClinicWinApp.Forms.Settings
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Validate Base URL
            //    if (string.IsNullOrWhiteSpace(txtBaseUrl.Text))
            //    {
            //        MessageBox.Show("يرجى إدخال عنوان خادم API!");
            //        return;
            //    }

            //    // 👇 ONLY SAVE BASE URL (localhost + port)
            //    Settings.Default.ApiBaseUrl = txtBaseUrl.Text.Trim();
            //    Settings.Default.Save();

            //    MessageBox.Show("تم حفظ الإعدادات بنجاح!\nيرجى إعادة تشغيل التطبيق لتفعيل التغييرات.",
            //        "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    DialogResult = DialogResult.OK;
            //    Close();
            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = "خطأ: " + ex.Message;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //// 👇 ONLY LOAD BASE URL (localhost + port)
            //txtBaseUrl.Text = Settings.Default.ApiBaseUrl ?? "http://localhost:9424/api/";
        }
    }
}
