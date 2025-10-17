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
    
    public partial class SetSalaryForm : Form
    {
        private int _staffId;
        private string _staffName;
        public SetSalaryForm(int staffId, string staffNam)
        {
            _staffId = staffId;
            _staffName = staffNam;
            InitializeComponent();
        }

        private async void SetSalaryForm_Load(object sender, EventArgs e)
        {
            // Set staff name
            lblStaffName.Text = $"تعيين راتب لـ: {_staffName}";

            // Set default payment date to today
            dtpPaymentDate.Value = DateTime.Now;

            // Load current salary (optional - if you have API endpoint)
            await LoadCurrentSalary();
        }
        private async Task LoadCurrentSalary()
        {
            try
            {

                // GET /api/staff?staffId={id} returns List<dynamic> with one item
                var staffList = await ApiHelper.GetAsync<List<dynamic>>($"staff?staffId={_staffId}");

                if (staffList.Count > 0)
                {
                    dynamic staff = staffList[0]; // 👈 GET FIRST (AND ONLY) ITEM

                    // 👇 SAFE SALARY EXTRACTION
                    if (staff.Salary != null)
                    {
                        try
                        {
                            decimal salary = Convert.ToDecimal(staff.Salary.ToString());
                            lblCurrentSalary.Text = $"الراتب الحالي: {salary:F2} ر.س";
                            lblCurrentSalary.ForeColor = System.Drawing.Color.Blue;
                        }
                        catch
                        {
                            lblCurrentSalary.Text = "الراتب الحالي: غير صالح";
                            lblCurrentSalary.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblCurrentSalary.Text = "الراتب الحالي: غير محدد";
                        lblCurrentSalary.ForeColor = System.Drawing.Color.Orange;
                    }
                }
                else
                {
                    lblCurrentSalary.Text = "الراتب الحالي: غير متوفر";
                    lblCurrentSalary.ForeColor = System.Drawing.Color.Gray;
                }
            }
            catch (Exception ex)
            {
                lblCurrentSalary.Text = "خطأ في تحميل الراتب الحالي";
                lblCurrentSalary.ForeColor = System.Drawing.Color.Red;
                // Log error for debugging
                System.Diagnostics.Debug.WriteLine($"LoadCurrentSalary Error: {ex.Message}");
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtNewAmount.Text))
            {
                MessageBox.Show("يرجى إدخال الراتب الجديد!");
                return;
            }

            decimal newAmount;
            if (!decimal.TryParse(txtNewAmount.Text, out newAmount) || newAmount <= 0)
            {
                MessageBox.Show("يرجى إدخال مبلغ صحيح للراتب!");
                return;
            }

            var salary = new SalaryModel
            {
                StaffID = _staffId,
                Amount = newAmount,
                PaymentDate = dtpPaymentDate.Value.Date,
                Notes = $"تعيين راتب جديد - {txtNotes.Text.Trim()}"
            };

            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("salaries", salary);
                if ((bool)result.success)
                {
                    MessageBox.Show("تم تعيين الراتب بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
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
