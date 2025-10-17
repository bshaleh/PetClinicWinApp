using PetClinicWinApp.Helpers;
using PetClinicWinApp.Models;
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

namespace PetClinicWinApp.Forms.Pets
{
    public partial class PetCardForm : Form
    {
        //private dynamic _petCard;
        public PetCardForm(int petId)
        {
            InitializeComponent();
            //LoadPetCard(petId);

        }
        public PetCardForm(dynamic petObject)
        {
            InitializeComponent();
            DisplayPetCard(petObject);

        }
        public PetCardForm(int petId, string PetCode,string Species,string Breed,string BirthDate,string Gender,string OwnerName)
        {
            //InitializeComponent();
            //LoadPetCard(petId);

        }
        private void DisplayPetCard(dynamic pet)
        {
            // Handle potential missing fields with null checks
            string petCode = pet.PetCode?.ToString() ?? "غير متوفر";
            string birthDate = pet.BirthDate?.ToString("yyyy-MM-dd") ?? "غير معروف";

            lblPetCode.Text = $"رمز الحيوان: {petCode}";
            lblPetName.Text = $"الاسم: {pet.PetName}";
            lblBirthDate.Text = $"تاريخ الميلاد: {birthDate}";
            lblSpecies.Text = $"النوع: {pet.Species}";
            lblBreed.Text = $"السلالة: {pet.Breed}";
            lblGender.Text = $"الجنس: {pet.Gender}";
            lblOwner.Text = $"المالك: {pet.OwnerName}";
        }
        private async void LoadPetCard(int petId)
        {
            try
            {
                // 👇 CALL YOUR EXISTING API ENDPOINT
                // Note: Your current PetsController doesn't have /card endpoint
                // So we'll use the existing /pets/{id} pattern
                dynamic petCard = await ApiHelper.GetAsync<List<dynamic>>($"Pets?petId={petId}");

               
                // Now display the single pet
                lblPetCode.Text = $"رمز الحيوان: {petCard.PetCode ?? "غير متوفر"}";
                lblPetName.Text = $"الاسم: {petCard.PetName}";
                lblBirthDate.Text = $"تاريخ الميلاد: {petCard.BirthDate?.ToString("yyyy-MM-dd") ?? "غير معروف"}";
                lblSpecies.Text = $"النوع: {petCard.Species}";
                lblBreed.Text = $"السلالة: {petCard.Breed}";
                lblGender.Text = $"الجنس: {petCard.Gender}";
                lblOwner.Text = $"المالك: {petCard.OwnerName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل بطاقة الحيوان: " + ex.Message);
            }
        }
        //private void DisplayPetCard()
        //{
        //    lblPetCode.Text = $"رمز الحيوان: {_petCard.PetCode}";
        //    lblPetName.Text = $"الاسم: {_petCard.PetName}";
        //    lblBirthDate.Text = $"تاريخ الميلاد: {_petCard.BirthDate?.ToString("yyyy-MM-dd") ?? "غير معروف"}";
        //    lblSpecies.Text = $"النوع: {_petCard.Species}";
        //    lblBreed.Text = $"السلالة: {_petCard.Breed}";
        //    lblGender.Text = $"الجنس: {_petCard.Gender}";
        //    lblOwner.Text = $"المالك: {_petCard.OwnerName}";
        //}


        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintPageHandler;
                PrintDialog printDialog = new PrintDialog { Document = printDoc };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في الطباعة: " + ex.Message);
            }
        }
        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Font headerFont = new Font("Arial", 14, FontStyle.Bold);
            Font normalFont = new Font("Arial", 12, FontStyle.Regular);
            float yPos = 50;
            float xPos = 50;

            // Header
            e.Graphics.DrawString("بطاقة الحيوان", headerFont, Brushes.Black, xPos, yPos);
            yPos += 50;

            // Pet details
            e.Graphics.DrawString(lblPetCode.Text, normalFont, Brushes.Black, xPos, yPos); yPos += 35;
            e.Graphics.DrawString(lblPetName.Text, normalFont, Brushes.Black, xPos, yPos); yPos += 35;
            e.Graphics.DrawString(lblBirthDate.Text, normalFont, Brushes.Black, xPos, yPos); yPos += 35;
            e.Graphics.DrawString(lblSpecies.Text, normalFont, Brushes.Black, xPos, yPos); yPos += 35;
            e.Graphics.DrawString(lblBreed.Text, normalFont, Brushes.Black, xPos, yPos); yPos += 35;
            e.Graphics.DrawString(lblGender.Text, normalFont, Brushes.Black, xPos, yPos); yPos += 35;
            e.Graphics.DrawString(lblOwner.Text, normalFont, Brushes.Black, xPos, yPos);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
