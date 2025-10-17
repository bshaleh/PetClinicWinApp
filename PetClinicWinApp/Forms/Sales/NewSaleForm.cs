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

namespace PetClinicWinApp.Forms.Sales
{
    public partial class NewSaleForm : Form
    {
        private List<CartItemModel> _cart = new List<CartItemModel>();
        private List<dynamic> _allProducts = new List<dynamic>();
        public NewSaleForm()
        {
            InitializeComponent();
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] {
                    new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "اسم المنتج", DataPropertyName = "ProductName", Width = 200 },
                    new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "الكمية", DataPropertyName = "Quantity", Width = 100 },
                    new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "UnitPrice", HeaderText = "السعر", DataPropertyName = "UnitPrice", Width = 100 },
                    new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "Total", HeaderText = "الإجمالي", DataPropertyName = "Total", Width = 100 },
                    new System.Windows.Forms.DataGridViewButtonColumn { Name = "Remove", HeaderText = "إزالة", Text = "إزالة", UseColumnTextForButtonValue = true, Width = 80 }
                }
                    );
            
            //dgvCart.CellContentClick += dgvCart_CellContentClick;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار منتج!");
                return;
            }

            int productId = Convert.ToInt32(ddlProduct.SelectedValue);
            int quantity = (int)numQuantity.Value;

            // 👇 CHECK PRODUCT AVAILABILITY
            dynamic selectedProduct = ddlProduct.SelectedItem;
            int availableStock = (int)selectedProduct.StockQuantity;
            decimal unitPrice = (decimal)selectedProduct.Price;

            if (quantity > availableStock)
            {
                MessageBox.Show($"الكمية المطلوبة ({quantity}) أكبر من الكمية المتاحة ({availableStock})!");
                return;
            }

            // Check if product already in cart
            var existingItem = _cart.FirstOrDefault(item => item.ProductID == productId);
            if (existingItem != null)
            {
                int newQuantity = existingItem.Quantity + quantity;
                if (newQuantity > availableStock)
                {
                    MessageBox.Show($"الكمية المطلوبة ({newQuantity}) أكبر من الكمية المتاحة ({availableStock})!");
                    return;
                }
                existingItem.Quantity = newQuantity; // ✅ NOW WORKS - CartItemModel has writable properties
                existingItem.Total = newQuantity * existingItem.UnitPrice; // ✅ UPDATE TOTAL TOO
            }
            else
            {
                var cartItem = new CartItemModel // 👈 USE CartItemModel INSTEAD OF ANONYMOUS OBJECT
                {
                    ProductID = productId,
                    ProductName = (string)selectedProduct.ProductName,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    Total = quantity * unitPrice
                };
                _cart.Add(cartItem);
            }

            RefreshCart();
            ClearProductSelection();
        }

        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart; // ✅ NOW WORKS WITH CartItemModel
            CalculateTotal();
        }
        private void CalculateTotal()
        {
            decimal total = _cart.Sum(item => item.Total); // ✅ NOW WORKS
            lblTotal.Text = $"الإجمالي: {total:F2} ر.س";
        }

        private void ClearProductSelection()
        {
            ddlProduct.SelectedIndex = 0;
            numQuantity.Value = 1;
        }
        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                _cart.RemoveAt(e.RowIndex);
                RefreshCart();
            }
        }


        private async void btnCompleteSale_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("السلة فارغة!");
                return;
            }

            if (ddlCustomer.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار عميل!");
                return;
            }

            int customerId = Convert.ToInt32(ddlCustomer.SelectedValue);

            // 👇 USE CartItemModel INSTEAD OF dynamic
            var sale = new
            {
                SaleDate = DateTime.Now,
                PetOwnerID = customerId == 0 ? (int?)null : customerId,
                TotalAmount = _cart.Sum(item => item.Total), // ✅ NOW WORKS
                PaymentMethod = "Cash",
                SoldBy = 1, // Get from session later
                BranchID = 1, // Get from session later
                Notes = txtNotes.Text.Trim(),
                SaleDetails = _cart.Select(item => new // ✅ NOW WORKS
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            };

            try
            {
                dynamic result = await ApiHelper.PostAsync<dynamic>("sales", sale);
                if ((bool)result.success)
                {
                    MessageBox.Show($"تم إتمام البيع بنجاح! رقم الفاتورة: {result.saleId}", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Update product stock quantities
                    await UpdateProductStock();

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
        private async Task UpdateProductStock()
        {
            try
            {
                foreach (var item in _cart)
                {
                    int productId = (int)item.ProductID;
                    int quantitySold = (int)item.Quantity;

                    // Call API to update stock
                    var updateData = new
                    {
                        productId = productId,
                        quantitySold = quantitySold
                    };

                    await ApiHelper.PostAsync<dynamic>("products/updatestock", updateData);
                }
            }
            catch (Exception ex)
            {
                // Log error but don't stop sale completion
                System.Diagnostics.Debug.WriteLine("Error updating stock: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void NewSaleForm_Load(object sender, EventArgs e)
        {
            await LoadCustomers();
            await LoadProducts();
        }
        private async Task LoadCustomers()
        {
            try
            {
                var customers = await ApiHelper.GetAsync<List<dynamic>>("owners");

                // Add general customer option
                var customerList = new List<dynamic>();
                customerList.Add(new { OwnerID = 0, FullName = "عميل عام" });

                foreach (var customer in customers)
                {
                    customerList.Add(new
                    {
                        OwnerID = (int)customer.OwnerID,
                        FullName = (string)customer.FullName
                    });
                }

                ddlCustomer.DataSource = customerList;
                ddlCustomer.DisplayMember = "FullName";
                ddlCustomer.ValueMember = "OwnerID";
                ddlCustomer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل العملاء: " + ex.Message);
            }
        }

        private async Task LoadProducts()
        {
            try
            {
                _allProducts = await ApiHelper.GetAsync<List<dynamic>>("products");

                ddlProduct.DataSource = _allProducts;
                ddlProduct.DisplayMember = "ProductName";
                ddlProduct.ValueMember = "ProductID";
                ddlProduct.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل المنتجات: " + ex.Message);
            }
        }
    }
}
