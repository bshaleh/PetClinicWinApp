using PetClinicWinApp.Forms.Admin;
using PetClinicWinApp.Forms.Appointments;
using PetClinicWinApp.Forms.Medical;
using PetClinicWinApp.Forms.Owners;
using PetClinicWinApp.Forms.Pets;
using PetClinicWinApp.Forms.Products;
using PetClinicWinApp.Forms.Sales;
using PetClinicWinApp.Forms.Staff;
using PetClinicWinApp.Forms.Surgery;
using PetClinicWinApp.Forms.Vaccination;
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

namespace PetClinicWinApp.Forms
{
    
    public partial class MainForm : Form
    {
        private UserModel _currentUser;
        

        public MainForm(UserModel user)
        {
            InitializeComponent();
            _currentUser = user;
            Text = $"Pet Clinic - Welcome {_currentUser.Username} ({_currentUser.Role})";
            SetupMenu();
        }
        private void SetupMenu()
        {
            menuStrip1.Items.Clear();

            if (_currentUser.Role == "Admin")
            {
                AddMenuItem("أدارة", "ادارة المستخدمين", typeof(ManageUsersForm));
                AddMenuItem("أدارة", "الرواتب", typeof(SalariesForm));
                AddMenuItem("أدارة", "ادارة الموظفين", typeof(ManageStaffForm));
                AddMenuItem("أدارة", "اضافة موظف", typeof(AddStaffForm));
                


            }

            AddMenuItem("الحيوانات", "لائحة الحيوانات", typeof(PetsListForm));
            AddMenuItem("الحيوانات", "اضافة حيوان", typeof(AddPetForm));
            AddMenuItem("المالكين", "لائحة المالكين", typeof(OwnersListForm));
            AddMenuItem("المالكين", "اضافة مالك", typeof(AddOwnerForm));
            AddMenuItem("المواعيد", "لائحة المواعيد", typeof(AppointmentsListForm));
            AddMenuItem("المواعيد", "تعيين موعد", typeof(BookAppointmentForm));
            AddMenuItem("المعاينات", "لائحة المعاينات ", typeof(MedicalRecordsListForm));
            AddMenuItem("المعاينات", "اضافة معاينة", typeof(AddMedicalRecordForm));
            AddMenuItem("الجراحات", "لائحة الجراحات", typeof(SurgeriesListForm));
            AddMenuItem("الجراحات", "اضافة جراحة", typeof(AddSurgeryForm));
            AddMenuItem("اللقاحات", "لائحة اللقاحات", typeof(VaccinationsListForm));
            AddMenuItem("اللقاحات", "اضافة لقاح", typeof(AddVaccinationForm));

            //if (_currentUser.Role != "Receptionist") // Example permission
            //{
            //    AddMenuItem("Appointments", "Book Appointment", typeof(BookAppointmentForm));
            //}
            AddMenuItem("المبيعات", "لائحة المبيعات", typeof(SalesListForm));
            AddMenuItem("المبيعات", "بيع جديد", typeof(NewSaleForm));
            AddMenuItem("المنتجات", "ادارة المنتجات", typeof(ManageProductsForm));
            AddMenuItem("المنتجات", "اضافة منتج", typeof(AddProductForm));
            

            
            var accountMenu = new ToolStripMenuItem("ادارة الحسابات");
            accountMenu.DropDownItems.Add("تغيير كلمة السر", null, (s, e) => {
                using (var form = new ChangePasswordForm(_currentUser.UserId))
                {
                    form.ShowDialog();
                }
            });
            menuStrip1.Items.Add(accountMenu);
            accountMenu.DropDownItems.Add("تسجيل الخروج", null, (s, e) => Logout());
        }

        private void AddMenuItem(string category, string text, Type formType)
        {
            var menu = GetOrCreateMenuItem(category);
            menu.DropDownItems.Add(text, null, (s, e) => OpenForm(formType));
        }

        private ToolStripMenuItem GetOrCreateMenuItem(string text)
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item.Text == text) return item;
            }
            var newItem = new ToolStripMenuItem(text);
            menuStrip1.Items.Add(newItem);
            return newItem;
        }

        private void OpenForm(Type formType)
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm.GetType() == formType)
                {
                    frm.Activate();
                    return;
                }
            }

            Form newForm = (Form)Activator.CreateInstance(formType);
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void OpenChangePasswordForm()
        {
            using (var form = new ChangePasswordForm(_currentUser.UserId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("يرجى تسجيل الدخول مرة أخرى بكلمة المرور الجديدة.", "تم التحديث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Closes MainForm → returns to login
                }
            }
        }

        private void Logout()
        {
            DialogResult result = MessageBox.Show("هل تريد تسجيل الخروج؟", "تسجيل الخروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Returns to login
            }
        }
    }
}
