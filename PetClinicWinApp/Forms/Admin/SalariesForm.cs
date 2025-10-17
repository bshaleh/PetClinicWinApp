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
    public partial class SalariesForm : Form
    {
        public SalariesForm()
        {
            InitializeComponent();
            dgvSalaries.AutoGenerateColumns = false;
            //InitializeDataGridView();
            SetupGridColumns();
            LoadSalaries();
            LoadStaffForFilter();
        }
        //private void InitializeDataGridView()
        //{
        //    dgvSalaries.AutoGenerateColumns = false;
        //    dgvSalaries.Columns.Clear();

        //    // Define your Arabic columns here
        //    dgvSalaries.Columns.AddRange(
        //    // your columns
        //    );
        //}

        private void SetupGridColumns()
        {
            dgvSalaries.Columns.Clear(); // Clear any auto-generated columns

            dgvSalaries.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "StaffName",
                    HeaderText = "اسم الموظف",
                    DataPropertyName = "StaffName",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Amount",
                    HeaderText = "القيمة",
                    DataPropertyName = "Amount",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PaymentDate",
                    HeaderText = "تاريخ الدفع",
                    DataPropertyName = "PaymentDate",
                    Width = 250
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Notes",
                    HeaderText = "ملاحظات",
                    DataPropertyName = "Notes",
                    Width = 250
                }
            );
        }
        private async void LoadSalaries()
        {
            try
            {
                string endpoint = "salaries";

                // 👇 ADD STAFF FILTER
                if (ddlStaffFilter.SelectedIndex > 0) // Skip "جميع الموظفين"
                {
                    dynamic selectedStaff = ddlStaffFilter.SelectedItem;
                    int staffId = (int)selectedStaff.StaffID;
                    endpoint += $"?staffId={staffId}";
                }

                var salaries = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
                dgvSalaries.DataSource = salaries;

                // 👇 CALCULATE TOTAL BASED ON FILTERED LIST
                decimal total = 0;
                foreach (dynamic salary in salaries)
                {
                    total += (decimal)salary.Amount;
                }
                lblTotal.Text = $"إجمالي الرواتب: {total:F2} ر.س";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الرواتب: " + ex.Message);
            }
            //try
            //{
            //    string endpoint = "salaries";
            //    if (staffId.HasValue) endpoint += $"?staffId={staffId}";


            //    var salaries = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
            //    dgvSalaries.DataSource = salaries;

            //    // Calculate total
            //    decimal total = 0;
            //    foreach (dynamic salary in salaries)
            //    {
            //        total += (decimal)salary.Amount;
            //    }
            //    lblTotal.Text = $"إجمالي الرواتب: {total:F2} ر.س";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("خطأ في تحميل الرواتب: " + ex.Message);
            //}
        }

        private async void LoadStaffForFilter()
        {
            try
            {
                var staff = await ApiHelper.GetAsync<List<dynamic>>("staff");
                ddlStaffFilter.Items.Add(new { FullName = "جميع الموظفين", StaffID = 0 });
                foreach (var s in staff)
                {
                    ddlStaffFilter.Items.Add(s);
                }
                ddlStaffFilter.DisplayMember = "FullName";
                ddlStaffFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الموظفين: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int? staffId = null;
            if (ddlStaffFilter.SelectedIndex > 0)
            {
                dynamic selected = ddlStaffFilter.SelectedItem;
                staffId = (int)selected.StaffID;
            }
            LoadSalaries();
        }

        private void btnAddSalary_Click(object sender, EventArgs e)
        {
            using (var form = new AddSalaryForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSalaries();
                }
            }
        }

        private void ddlStaffFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSalaries();
        }
    }
}
