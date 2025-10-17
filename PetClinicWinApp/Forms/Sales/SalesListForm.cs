using PetClinicWinApp.Forms.Reports;
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

namespace PetClinicWinApp.Forms.Sales
{
    public partial class SalesListForm : Form
    {
        public SalesListForm()
        {

            InitializeComponent();
            dgvSales.AutoGenerateColumns = false; // Ensure it's off, even if set in designer
            dgvSales.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "SaleID", HeaderText = "رقم الفاتورة", DataPropertyName = "SaleID", Width = 50 },
                new DataGridViewTextBoxColumn { Name = "SaleDate", HeaderText = "تاريخ الفاتورة", DataPropertyName = "SaleDate", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "CustomerName", HeaderText = "الزبون", DataPropertyName = "CustomerName", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "TotalAmount", HeaderText = " الاجمالي", DataPropertyName = "TotalAmount", Width = 50 },
                new DataGridViewTextBoxColumn { Name = "PaymentMethod", HeaderText = "طريقة الدفع ", DataPropertyName = "PaymentMethod", Width = 50 },
                new DataGridViewTextBoxColumn { Name = "SoldByName", HeaderText = "البائع", DataPropertyName = "SoldByName", Width = 200 }

            );
            // Set default date range (last 30 days)
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
           
        }
        private async Task LoadSales(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                lblMessage.Text = "";

                // Build query parameters
                var queryParams = new List<string>();

                if (startDate.HasValue)
                {
                    queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");
                }

                if (endDate.HasValue)
                {
                    queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");
                }

                string endpoint = "sales";
                if (queryParams.Count > 0)
                {
                    endpoint += "?" + string.Join("&", queryParams);
                }

                var sales = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
                dgvSales.DataSource = sales;

                // Calculate totals
                decimal totalSales = 0;
                int totalItems = 0;

                foreach (dynamic sale in sales)
                {
                    totalSales += (decimal)sale.TotalAmount;
                    totalItems += 1; // Each row is one sale
                }

                lblTotalSales.Text = $"إجمالي المبيعات: {totalSales:F2} ر.س";
                lblTotalItems.Text = $"إجمالي العناصر: {totalItems}";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ في تحميل المبيعات: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("تاريخ البداية يجب أن يكون قبل تاريخ النهاية!");
                return;
            }

            await LoadSales(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
        }

        private async void btnNewSale_Click(object sender, EventArgs e)
        {
            using (var form = new NewSaleForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadSales(); // Refresh
                }
            }
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            if (dgvSales.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار فاتورة من القائمة!");
                return;
            }

            var selectedRow = dgvSales.SelectedRows[0];
            dynamic selectedSale = selectedRow.DataBoundItem;

            int saleId = Convert.ToInt32(selectedSale.SaleID);

            // Open invoice form/report
            using (var form = new SalesInvoiceReportForm(saleId))
            {
                form.ShowDialog();
            }
        }

        private async void SalesListForm_Load(object sender, EventArgs e)
        {
           await LoadSales();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadSales();
        }

        private async void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvSales.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار فاتورة من القائمة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Get selected sale
            dynamic selectedSale = dgvSales.SelectedRows[0].DataBoundItem;
            int saleId = Convert.ToInt32(selectedSale.SaleID);
            string saleDate = ((DateTime)selectedSale.SaleDate).ToString("yyyy-MM-dd");
            // Confirm deletion
            var result = MessageBox.Show(
                $"هل أنت متأكد من حذف الفاتورة رقم {saleId} بتاريخ {saleDate}؟\n\n" +
                "سيتم استعادة كميات المنتجات إلى المخزون.",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2 // Make "No" default for safety
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Call API to delete sale and restore stock
                    dynamic deleteResult = await ApiHelper.DeleteAsync<dynamic>($"sales/{saleId}");

                    if ((bool)deleteResult.success)
                    {
                        MessageBox.Show("تم حذف الفاتورة واستعادة الكميات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadSales(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("فشل في حذف الفاتورة: " + deleteResult.message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في حذف الفاتورة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
