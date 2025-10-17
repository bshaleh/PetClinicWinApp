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

namespace PetClinicWinApp.Forms.Products
{
    public partial class ManageProductsForm : Form
    {
        private List<dynamic> _allProductsCache; // Cache all products for client-side filtering
        public ManageProductsForm()
        {
            InitializeComponent();
            dgvProducts.AutoGenerateColumns = false; // Ensure it's off, even if set in designer
            dgvProducts.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "ProductCode", HeaderText = "كود المنتج", DataPropertyName = "ProductCode", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "اسم المنتج", DataPropertyName = "ProductName", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "الوصف", DataPropertyName = "Category", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Price", HeaderText = " السعر", DataPropertyName = "Price", Width = 50 },
                new DataGridViewTextBoxColumn { Name = "StockQuantity", HeaderText = "الكمية ", DataPropertyName = "StockQuantity", Width = 50 },
                new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "الوصف", DataPropertyName = "Description", Width = 200 }

            );
           
        }
       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // If search is empty, show all cached products
                dgvProducts.DataSource = _allProductsCache;
                return;
            }

            if (_allProductsCache == null) return;

            var filteredList = new List<dynamic>();
            foreach (dynamic product in _allProductsCache)
            {
                // Check if any relevant field contains the search term
                if (((string)product.ProductName).ToLowerInvariant().Contains(searchTerm) ||
                    ((string)product.Category).ToLowerInvariant().Contains(searchTerm) ||
                    ((string)product.Description ?? "").ToLowerInvariant().Contains(searchTerm))
                {
                    filteredList.Add(product);
                }
            }
            dgvProducts.DataSource = filteredList;
            //LoadProducts(txtSearch.Text.Trim());
        }

        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (var form = new AddProductForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadProducts();
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار منتج لتعديله!");
                return;
            }

            try
            {
                // 👇 GET SELECTED PRODUCT
                dynamic selectedProduct = dgvProducts.SelectedRows[0].DataBoundItem;

                // 👇 SAFELY EXTRACT PRODUCT ID
                int productId = Convert.ToInt32(selectedProduct.ProductID);
                string productName = selectedProduct.ProductName?.ToString() ?? "غير معروف";

                // Open Edit Product Form
                using (var form = new EditProductForm(productId))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                       await LoadProducts(); // Refresh list
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في فتح نموذج التعديل: " + ex.Message);
            }
            
        }

       

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadProducts();
            txtSearch.Text = "";
        }

        private async void ManageProductsForm_Load(object sender, EventArgs e)
        {
            await LoadProducts();
        }
        private async Task LoadProducts()
        {
            try
            {
                lblMessage.Text = "";
                var products = await ApiHelper.GetAsync<List<dynamic>>("products");
                _allProductsCache = products; // Store for search
                dgvProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ في تحميل المنتجات: " + ex.Message;
            }
        }

        private void SearchProduct(string searchTerm)
        {
            if (_allProductsCache == null) return;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Show all pets if search is empty
                dgvProducts.DataSource = _allProductsCache; // Store original data
                return;
            }

            // Filter by PetCode or PetName (case-insensitive)
            var filteredPets = _allProductsCache
                .Where(p =>
                    (p.ProductName?.ToString().Contains(searchTerm) == true) ||
                    (p.ProductCode?.ToString().Contains(searchTerm) == true)
                )
                .ToList();

            dgvProducts.DataSource = filteredPets;
        }

        private async void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // 👇 GET SELECTED PRODUCT FROM DATAGRIDVIEW
                    dynamic selectedProduct = dgvProducts.Rows[e.RowIndex].DataBoundItem;

                    // 👇 SAFELY EXTRACT PRODUCT ID
                    int productId = Convert.ToInt32(selectedProduct.ProductID);
                    string productName = selectedProduct.ProductName?.ToString() ?? "غير معروف";

                    // Open Edit Product Form
                    using (var form = new EditProductForm(productId))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                           await LoadProducts(); // Refresh list
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في فتح نموذج التعديل: " + ex.Message);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Check if a row is selected
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار منتج لحذفه.", "لا يوجد اختيار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Get the selected product
            DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];
            dynamic selectedProduct = selectedRow.DataBoundItem;
            int productId = (int)selectedProduct.ProductID;
            string productName = selectedProduct.ProductName?.ToString() ?? "المنتج المحدد";

            // 3. Confirm deletion
            var confirmResult = MessageBox.Show(
                $"هل أنت متأكد من أنك تريد حذف المنتج '{productName}'؟\nلا يمكن التراجع عن هذا الإجراء.",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2 // Make "No" the default for safety
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // 4. Call the new DeleteAsync method in ApiHelper
                    dynamic result = await ApiHelper.DeleteAsync<dynamic>($"products/{productId}");

                    // 5. Check the result from the API
                    // Assuming your API returns { success: true/false, message?: ... }
                    if ((bool)result.success)
                    {
                        MessageBox.Show("تم حذف المنتج بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // 6. Refresh the product list
                        btnRefresh_Click(sender, e); // Re-use the refresh logic
                    }
                    else
                    {
                        // Handle API-level errors (e.g., product not found, foreign key constraints)
                        lblMessage.Text = "فشل في حذف المنتج: " + (result.message?.ToString() ?? "حدث خطأ غير معروف.");
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    // Handle network errors, timeouts, unexpected API responses
                    lblMessage.Text = "خطأ أثناء محاولة حذف المنتج: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProduct(txtSearch.Text.Trim());
        }
    }
}
