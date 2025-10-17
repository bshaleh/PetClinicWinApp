using PetClinicWinApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetClinicWinApp.Forms.Reports
{
    public partial class SalesInvoiceReportForm : Form
    {
        private int _saleId;
        private dynamic _saleData;
        private List<dynamic> _saleItems;

        public SalesInvoiceReportForm()
        {
        }

        public SalesInvoiceReportForm(int saleId)
        {
            _saleId = saleId;
            InitializeComponent();
            dgvItems.AutoGenerateColumns = false;
            dgvItems.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] {
                    new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "اسم المنتج", DataPropertyName = "ProductName", Width = 200 },
                    new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "الكمية", DataPropertyName = "Quantity", Width = 80 },
                    new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "UnitPrice", HeaderText = "السعر", DataPropertyName = "UnitPrice", Width = 100 },
                    new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Total", HeaderText = "الإجمالي", DataPropertyName = "Total", Width = 100 }
                }
            );
        }

        private async void SalesInvoiceReportForm_Load(object sender, EventArgs e)
        {
            await LoadInvoiceData();
        }
        private async Task LoadInvoiceData()
        {
            try
            {
                // Load sale header
                _saleData = await ApiHelper.GetAsync<dynamic>($"sales/{_saleId}");

                // Load sale items
                _saleItems = await ApiHelper.GetAsync<List<dynamic>>($"sales/{_saleId}/items");

                DisplayInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل الفاتورة: " + ex.Message);
                Close();
            }
        }

        private void DisplayInvoice()
        {
            if (_saleData == null) return;

            // Header
            lblTitle.Text = "فاتورة بيع";
            lblInvoiceInfo.Text = $"رقم الفاتورة: {_saleData.SaleID}\n" +
                                 $"{((DateTime)_saleData.SaleDate).ToString("yyyy-MM-dd HH:mm")} التاريخ: \n" +
                                 $"الفرع: {_saleData.BranchName}";

            // Customer Info
            string customerName = _saleData.CustomerName?.ToString() ?? "عميل عام";
            lblCustomerInfo.Text = $"العميل: {customerName}\n" +
                                  $"البائع: {_saleData.SoldByName}\n" +
                                  $"طريقة الدفع: {_saleData.PaymentMethod}";

            // Items
            dgvItems.DataSource = _saleItems;

            // Totals
            decimal subtotal = _saleItems.Sum(item => (decimal)item.Total);
            decimal tax = 0; // No tax in your system
            decimal total = subtotal + tax;

            lblSubtotal.Text = $"الإجمالي الفرعي: {subtotal:F2} ر.س";
            lblTax.Text = $"الضريبة (0%): {tax:F2} ر.س";
            lblTotal.Text = $"الإجمالي: {total:F2} ر.س";

            // Footer
            lblFooter.Text = "شكراً لاختياركم عيادتنا";
            lblTimestamp.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} تاريخ الطباعة:";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintPageHandler;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    MessageBox.Show("تمت طباعة الفاتورة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في الطباعة: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            try
            {
                // 👇 FONT DEFINITIONS
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font smallFont = new Font("Arial", 8);
                Brush brush = Brushes.Black;
                Pen pen = Pens.Black;

                // 👇 LAYOUT SETTINGS
                float leftMargin = e.MarginBounds.Left;
                float rightMargin = e.MarginBounds.Right;
                float topMargin = e.MarginBounds.Top;
                float pageWidth = e.MarginBounds.Width;
                float yPos = topMargin;
                float lineHeight = normalFont.GetHeight(e.Graphics) + 5;

                // COLUMN WIDTHS FOR VERTICAL LINES
                float col1Width = 200; // ProductName
                float col2Width = 80;  // Quantity
                float col3Width = 100; // UnitPrice
                float col4Width = 100; // Total
                float totalWidth = col1Width + col2Width + col3Width + col4Width;

                // 👇 1. PRINT TITLE
                string title = "فاتورة بيع";
                SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
                e.Graphics.DrawString(title, titleFont, brush,
                    (pageWidth - titleSize.Width) / 2 + leftMargin, yPos);
                yPos += titleSize.Height + 10;

                // 👇 2. PRINT HORIZONTAL LINE AFTER TITLE
                e.Graphics.DrawLine(pen, leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                // 👇 3. PRINT INVOICE INFO
                string invoiceInfo = $"رقم الفاتورة: {_saleData.SaleID}\n" +
                                   $"التاريخ: {((DateTime)_saleData.SaleDate).ToString("yyyy-MM-dd HH:mm")}\n" +
                                   $"الفرع: {_saleData.BranchName}";
                e.Graphics.DrawString(invoiceInfo, normalFont, brush, leftMargin, yPos);
                yPos += 60;

                // 👇 4. PRINT CUSTOMER INFO
                string customerName = _saleData.CustomerName?.ToString() ?? "عميل عام";
                string customerInfo = $"العميل: {customerName}\n" +
                                    $"البائع: {_saleData.SoldByName}\n" +
                                    $"طريقة الدفع: {_saleData.PaymentMethod}";
                e.Graphics.DrawString(customerInfo, normalFont, brush, leftMargin, yPos);
                yPos += 60;

                // 👇 5. PRINT HORIZONTAL LINE BEFORE ITEMS
                e.Graphics.DrawLine(pen, leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                // 👇 6. PRINT ITEMS HEADER WITH VERTICAL LINES
                float headerY = yPos;
                e.Graphics.DrawString("اسم المنتج", headerFont, brush, leftMargin, yPos);
                e.Graphics.DrawString("الكمية", headerFont, brush, leftMargin + col1Width, yPos);
                e.Graphics.DrawString("السعر", headerFont, brush, leftMargin + col1Width + col2Width, yPos);
                e.Graphics.DrawString("الإجمالي", headerFont, brush, leftMargin + col1Width + col2Width + col3Width, yPos);

                // VERTICAL LINES FOR HEADER
                e.Graphics.DrawLine(pen, leftMargin, headerY, leftMargin, headerY + lineHeight);
                e.Graphics.DrawLine(pen, leftMargin + col1Width, headerY, leftMargin + col1Width, headerY + lineHeight);
                e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width, headerY, leftMargin + col1Width + col2Width, headerY + lineHeight);
                e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width + col3Width, headerY, leftMargin + col1Width + col2Width + col3Width, headerY + lineHeight);
                e.Graphics.DrawLine(pen, leftMargin + totalWidth, headerY, leftMargin + totalWidth, headerY + lineHeight);

                yPos += lineHeight;

                // 👇 7. PRINT HORIZONTAL LINE AFTER HEADER
                e.Graphics.DrawLine(pen, leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                // 👇 8. PRINT ITEMS WITH VERTICAL LINES
                foreach (dynamic item in _saleItems)
                {
                    float itemY = yPos;

                    // ITEM DETAILS
                    e.Graphics.DrawString(item.ProductName?.ToString() ?? "", normalFont, brush, leftMargin, yPos);
                    e.Graphics.DrawString(item.Quantity?.ToString() ?? "0", normalFont, brush, leftMargin + col1Width, yPos);
                    e.Graphics.DrawString(((decimal)item.UnitPrice).ToString("F2"), normalFont, brush, leftMargin + col1Width + col2Width, yPos);
                    e.Graphics.DrawString(((decimal)item.Total).ToString("F2"), normalFont, brush, leftMargin + col1Width + col2Width + col3Width, yPos);

                    // VERTICAL LINES FOR ITEM
                    e.Graphics.DrawLine(pen, leftMargin, itemY, leftMargin, itemY + lineHeight);
                    e.Graphics.DrawLine(pen, leftMargin + col1Width, itemY, leftMargin + col1Width, itemY + lineHeight);
                    e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width, itemY, leftMargin + col1Width + col2Width, itemY + lineHeight);
                    e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width + col3Width, itemY, leftMargin + col1Width + col2Width + col3Width, itemY + lineHeight);
                    e.Graphics.DrawLine(pen, leftMargin + totalWidth, itemY, leftMargin + totalWidth, itemY + lineHeight);

                    yPos += lineHeight;

                    // CHECK PAGE LIMIT
                    if (yPos > e.MarginBounds.Bottom - 150)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }

                // 👇 9. PRINT HORIZONTAL LINE AFTER ITEMS
                e.Graphics.DrawLine(pen, leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                // 👇 10. PRINT TOTALS
                decimal subtotal = _saleItems.Sum(item => (decimal)item.Total);
                decimal tax = 0;
                decimal total = subtotal + tax;

                e.Graphics.DrawString($"الإجمالي الفرعي: {subtotal:F2} ر.س", normalFont, brush,
                    rightMargin - 200, yPos);
                yPos += lineHeight;

                e.Graphics.DrawString($"الضريبة (0%): {tax:F2} ر.س", normalFont, brush,
                    rightMargin - 200, yPos);
                yPos += lineHeight;

                e.Graphics.DrawString($"الإجمالي: {total:F2} ر.س", headerFont, brush,
                    rightMargin - 200, yPos);
                yPos += lineHeight * 2;

                // 👇 11. PRINT HORIZONTAL LINE BEFORE FOOTER
                e.Graphics.DrawLine(pen, leftMargin, yPos, rightMargin, yPos);
                yPos += 10;

                // 👇 12. PRINT FOOTER
                string footer = "شكراً لاختياركم عيادتنا\n" +
                              $"تاريخ الطباعة: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                SizeF footerSize = e.Graphics.MeasureString(footer, smallFont);
                e.Graphics.DrawString(footer, smallFont, Brushes.Gray,
                    (pageWidth - footerSize.Width) / 2 + leftMargin, yPos);

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في إعداد الطباعة: " + ex.Message);
            }
        }

    }
}
