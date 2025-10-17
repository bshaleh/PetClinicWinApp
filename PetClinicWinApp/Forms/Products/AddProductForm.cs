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

namespace PetClinicWinApp.Forms.Products
{
    public partial class AddProductForm : Form
    {
        private int? _productId;
        public AddProductForm() : this(null)
        {
        }
        public AddProductForm(int? productId)
        {
            _productId = productId;
            InitializeComponent();

            if (productId.HasValue)
            {
                Text = "تعديل منتج";
                btnSave.Text = "تحديث";
            }
        }
        //public AddProductForm()
        //{
        //    InitializeComponent();
        //}

        private async void btnSave_Click(object sender, EventArgs e)
        {// Validate inputs
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
            if (!decimal.TryParse(txtPrice.Text, out price) || price <= 0)
            {
                MessageBox.Show("يرجى إدخال سعر صحيح!");
                return;
            }

            var product = new
            {
                ProductName = txtProductName.Text.Trim(),
                Category = ddlCategory.SelectedItem.ToString(),
                Price = price,
                StockQuantity = (int)nudStockQuantity.Value,
                Description = txtDescription.Text.Trim()
            };

            try
            {
                // 👇 USE TYPED MODEL INSTEAD OF dynamic
                var result = await ApiHelper.PostAsync<ApiResponseModel>("products", product);
                if (result.Success)
                {
                    MessageBox.Show("تم إضافة المنتج بنجاح!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    lblMessage.Text = "خطأ: " + result.Message;
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

        private async void AddProductForm_Load(object sender, EventArgs e)
        {
            if (_productId.HasValue)
            {
                await LoadProduct(_productId.Value);
            }
        }
        private async Task LoadProduct(int productId)
        {
            try
            {
                dynamic product = await ApiHelper.GetAsync<dynamic>($"products/{productId}");
                txtProductName.Text = product.ProductName;
                ddlCategory.Text = product.Category;
                txtPrice.Text = product.Price.ToString();
                nudStockQuantity.Text = product.StockQuantity.ToString();
                txtDescription.Text = product.Description;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل بيانات المنتج: " + ex.Message);
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(txtPrice.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("الرجاء ادخال أرقام فقط ..");
            //    txtPrice.Text = txtPrice.Text.Remove(txtPrice.Text.Length - 1);
            //}
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
