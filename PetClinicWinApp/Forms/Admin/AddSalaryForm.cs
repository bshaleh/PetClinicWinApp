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
    public partial class AddSalaryForm : Form
    {
        public AddSalaryForm()
        {
            InitializeComponent();
        }

        private async void AddSalaryForm_Load(object sender, EventArgs e)
        {
            await LoadStaff();
            dtpPaymentDate.Value = DateTime.Now; // Default to today
        }
        private async Task LoadStaff()
        {
            try
            {
                var staff = await ApiHelper.GetAsync<List<dynamic>>("staff");
                ddlStaff.DataSource = staff;
                ddlStaff.DisplayMember = "FullName";
                ddlStaff.ValueMember = "StaffID";
                if (ddlStaff.Items.Count > 0) ddlStaff.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ في تحميل الموظفين: " + ex.Message;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (ddlStaff.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار موظف!");
                return;
            }
            int staffId;
            if (!int.TryParse(ddlStaff.SelectedValue.ToString(), out staffId))
            {
                MessageBox.Show("خطأ في بيانات الموظف المحدد!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("يرجى إدخال المبلغ!");
                return;
            }

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("يرجى إدخال مبلغ صحيح!");
                return;
            }

            try
            {
                var salary = new SalaryModel
                {
                    StaffID = staffId, 
                    Amount = amount,
                    PaymentDate = dtpPaymentDate.Value.Date,
                    Notes = txtNotes.Text.Trim()
                };

                dynamic result = await ApiHelper.PostAsync<dynamic>("salaries", salary);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم إضافة الراتب بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ: " + ex.Message;
                // Log full error for debugging
                System.Diagnostics.Debug.WriteLine($"AddSalary Error: {ex.Message}\nStack: {ex.StackTrace}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
