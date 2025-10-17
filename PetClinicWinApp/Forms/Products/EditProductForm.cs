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
    public partial class EditProductForm : Form
    {
        private int _productId;
        private dynamic _originalProduct; // Store original data for comparison/population
        public EditProductForm(int productId)
        {
            _productId = productId;
            InitializeComponent();
            ddlCategory.Items.AddRange(new[] { "Food", "Medicine", "Toy", "Accessory", "Other" });
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("اسم المنتج مطلوب!");
                return;
            }

            if (ddlCategory.SelectedItem == null)
            {
                MessageBox.Show("يرجى اختيار فئة المنتج!");
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                MessageBox.Show("يرجى إدخال سعر صحيح (غير سالب)!");
                return;
            }

            // Prepare updated product data
            var updatedProduct = new
            {
                ProductID = _productId, // Important for API to know which record to update
                ProductName = txtProductName.Text.Trim(),
                Category = ddlCategory.SelectedItem.ToString(),
                Price = price,
                StockQuantity = (int)nudStockQuantity.Value,
                Description = txtDescription.Text.Trim()
            };
            var confirmResult = MessageBox.Show("هل أنت متأكد من أنك تريد حذف المنتج", "تأكيد التعديل", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // POST to update product (assuming your API has POST endpoint for updates)
                    // If you have PUT endpoint, use ApiHelper.PutAsync instead
                    dynamic result = await ApiHelper.PutAsync<dynamic>($"products/{_productId}", updatedProduct);

                    if ((bool)result.success)
                    {
                        MessageBox.Show("تم تحديث المنتج بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        lblMessage.Text = "خطأ: " + result.message?.ToString() ?? "فشل في تحديث المنتج";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "خطأ: " + ex.Message;
                }
            }


            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void EditProductForm_Load(object sender, EventArgs e)
        {
            await LoadProductDetails();
        }

        private async System.Threading.Tasks.Task LoadProductDetails()
        {
            try
            {
                // GET /api/products?productId={id} returns List<dynamic> with one item
                var products = await ApiHelper.GetAsync<dynamic>($"products?productId={_productId}");

                if (products.Count > 0)
                {
                    _originalProduct = products[0];

                    // Populate form fields
                    txtProductName.Text = _originalProduct.ProductName?.ToString() ?? "";

                    // Handle category
                    string category = _originalProduct.Category?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(category))
                    {
                        if (!ddlCategory.Items.Contains(category))
                        {
                            ddlCategory.Items.Add(category);
                        }
                        ddlCategory.SelectedItem = category;
                    }

                    txtPrice.Text = _originalProduct.Price?.ToString() ?? "0";
                    nudStockQuantity.Value = _originalProduct.StockQuantity ?? 0;
                    txtDescription.Text = _originalProduct.Description?.ToString() ?? "";
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على المنتج.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطأ في تحميل تفاصيل المنتج: " + ex.Message;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
