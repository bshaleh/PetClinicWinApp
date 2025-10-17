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

namespace PetClinicWinApp.Forms.Reports
{
    
    public partial class PetProfileReportForm : Form
    {
        private int _petId;

        private dynamic _petForPrinting;
        private List<dynamic> _medicalRecordsForPrinting;
        private List<dynamic> _vaccinationsForPrinting;
        private List<dynamic> _surgeriesForPrinting;
        //private List<dynamic> _appointmentsForPrinting;

        public PetProfileReportForm(int petId)
        {
            _petId = petId;
            InitializeComponent();
            LoadPetProfile();
        }
        private async void LoadPetProfile()
        {
            try
            {
                // Load pet info
                dynamic pets = await ApiHelper.GetAsync<dynamic>($"pets?petId={_petId}");

                _petForPrinting = pets;
                string petName = pets.PetName?.ToString() ?? "غير معروف";
                string petCode = pets.PetCode?.ToString() ?? "غير معروف";
                string species = pets.Species?.ToString() ?? "";
                string breed = pets.Breed?.ToString() ?? "";
                string ownerName = pets.OwnerName?.ToString() ?? "";
                string gender = pets.Gender?.ToString() ?? "";
                DateTime? birthDate = pets.BirthDate != null ? (DateTime?)pets.BirthDate : null;

                lblPetName.Text = petName;
                lblOwnerInfo.Text = ownerName;
                lblPetCode.Text = petCode;




                // Load medical records
                var medicalRecords = await ApiHelper.GetAsync<List<dynamic>>($"medicalrecords?petId={_petId}");
                dgvMedical.DataSource = medicalRecords;
                _medicalRecordsForPrinting = medicalRecords;

                // Load vaccinations
                var vaccinations = await ApiHelper.GetAsync<List<dynamic>>($"vaccinations?petId={_petId}");
                dgvVaccinations.DataSource = vaccinations;
                _vaccinationsForPrinting = vaccinations;

                // Load surgeries
                var surgeries = await ApiHelper.GetAsync<List<dynamic>>($"surgeries?petId={_petId}");
                dgvSurgeries.DataSource = surgeries;
                _surgeriesForPrinting = surgeries;

                // Load appointments
                //var appointments = await ApiHelper.GetAsync<List<dynamic>>($"appointments?petId={_petId}");
                //dgvAppointments.DataSource = appointments;
                //_appointmentsForPrinting = appointments;


            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل تقرير الحيوان: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_petForPrinting == null)
            {
                MessageBox.Show("لا توجد بيانات للطباعة!");
                return;
            }

            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument1;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font smallFont = new Font("Arial", 8);
                Pen pen = Pens.Black;

                float yPos = 50;
                float leftMargin = 50;
                float rightMargin = e.MarginBounds.Right;
                float pageWidth = e.MarginBounds.Width;

                // Print Title
                string title = "تقرير الحيوان";
                SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
                e.Graphics.DrawString(title, titleFont, Brushes.Black,
                    (pageWidth - titleSize.Width) / 2 + leftMargin, yPos);
                yPos += 40;

                // Print Pet Info
                string petInfo = $"{_petForPrinting.PetName} - {_petForPrinting.Species} ({_petForPrinting.Breed})\n" +
                                $"المالك: {_petForPrinting.OwnerName}\n" +
                                $"تاريخ الميلاد: {(_petForPrinting.BirthDate != null ? ((DateTime)_petForPrinting.BirthDate).ToString("yyyy-MM-dd") : "غير معروف")} | " +
                                $"الجنس: {_petForPrinting.Gender}";

                e.Graphics.DrawString(petInfo, normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 80;
                // Define column widths (adjust as needed)
                const int col1Width = 100; // e.g., التاريخ
                const int col2Width = 100;  // e.g.,الطبيب 
                const int col3Width = 180; // e.g., التشخيص
                const int col4Width = 200; // e.g., العلاج (wider)
                const int col5Width = 200;

                // Print Medical Records Section
                if (_medicalRecordsForPrinting != null && _medicalRecordsForPrinting.Count > 0)
                {
                    e.Graphics.DrawString("السجلات الطبية:", headerFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;

                    // 👇 PRINT COLUMN HEADERS WITH VERTICAL LINES
                    float headerY = yPos;
                    e.Graphics.DrawString("التاريخ", normalFont, Brushes.Black, leftMargin, yPos);
                    e.Graphics.DrawString("الطبيب", normalFont, Brushes.Black, leftMargin + col1Width, yPos);
                    e.Graphics.DrawString("التشخيص", normalFont, Brushes.Black, leftMargin + col1Width + col2Width, yPos); 
                    e.Graphics.DrawString("العلاج", normalFont, Brushes.Black, leftMargin + col1Width + col2Width + col3Width, yPos);
                    e.Graphics.DrawString("الوصفة", normalFont, Brushes.Black, leftMargin + col1Width + col2Width + col3Width + col4Width, yPos);

                    //// 👇 PRINT COLUMN HEADERS
                    //string headerLine = string.Format(
                    //    "{0,-" + col1Width + "} {1,-" + col2Width + "} {2,-" + col3Width + "} {3,-" + col4Width + "} {4,-" + col5Width + "}",
                    //    "الوصفة", "العلاج", "الطبيب", "التشخيص", "التاريخ" 
                    //);
                    //e.Graphics.DrawString(headerLine, normalFont, Brushes.Black, leftMargin, yPos);
                    //yPos += 20;

                    // Draw underline under headers
                    //e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin - 30, yPos);
                    //yPos += 10;

                    // 👇 DRAW VERTICAL LINES FOR HEADER
                    float totalWidth = col1Width + col2Width + col3Width + col4Width + col5Width;
                    e.Graphics.DrawLine(pen, leftMargin, headerY, leftMargin, headerY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + col1Width, headerY, leftMargin + col1Width, headerY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width, headerY, leftMargin + col1Width + col2Width, headerY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width + col3Width, headerY, leftMargin + col1Width + col2Width + col3Width, headerY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width + col3Width + col4Width, headerY, leftMargin + col1Width + col2Width + col3Width + col4Width, headerY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + totalWidth, headerY, leftMargin + totalWidth, headerY + 20);
                    yPos += 20;
                    // Draw underline under headers
                    e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin - 30, yPos);
                    yPos += 10;

                    foreach (dynamic record in _medicalRecordsForPrinting.Take(10)) // Limit to 5 records
                    {
                        try
                        {
                            float itemY = yPos; // 👈 STORE Y POSITION FOR VERTICAL LINES
                            // Format each field with padding to align columns
                            string dateStr = ((DateTime)record.VisitDate).ToString("yyyy-MM-dd");
                            string diagnosisStr = record.Diagnosis?.ToString() ?? "";
                            string doctorStr = record.DoctorName?.ToString() ?? "";
                            string treatmentStr = record.Treatment?.ToString() ?? "";
                            string prescription = record.Prescription?.ToString() ?? "";
                            // 👇 PRINT DATA ROWS WITH VERTICAL LINES
                            e.Graphics.DrawString(dateStr, smallFont, Brushes.Black, leftMargin, yPos);
                            e.Graphics.DrawString(doctorStr, smallFont, Brushes.Black, leftMargin + col1Width, yPos);
                            e.Graphics.DrawString(diagnosisStr, smallFont, Brushes.Black, leftMargin + col1Width + col2Width, yPos);  
                            e.Graphics.DrawString(treatmentStr, smallFont, Brushes.Black, leftMargin + col1Width + col2Width + col3Width, yPos);
                            e.Graphics.DrawString(prescription, smallFont, Brushes.Black, leftMargin + col1Width + col2Width + col3Width + col4Width, yPos);

                            // 👇 DRAW VERTICAL LINES FOR DATA ROW
                            e.Graphics.DrawLine(pen, leftMargin, itemY, leftMargin, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + col1Width, itemY, leftMargin + col1Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width, itemY, leftMargin + col1Width + col2Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width + col3Width, itemY, leftMargin + col1Width + col2Width + col3Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width + col3Width + col4Width, itemY, leftMargin + col1Width + col2Width + col3Width + col4Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + col1Width + col2Width + col3Width + col4Width + col5Width, itemY, leftMargin + col1Width + col2Width + col3Width + col4Width + col5Width, itemY + 20);

                            yPos += 20;
                            //// Use String.Format with fixed widths for alignment
                            //string line = string.Format(
                            //    "{0,-" + col1Width + "} {1,-" + col2Width + "} {2,-" + col3Width + "} {3,-" + col4Width + "} {4,-" + col5Width + "}",
                            //    Truncate(dateStr, col1Width - 5),
                            //    Truncate(diagnosisStr, col2Width - 5),
                            //    Truncate(doctorStr, col3Width - 5),
                            //    Truncate(treatmentStr, col4Width - 5),
                            //    Truncate(prescription, col5Width - 5)
                            //);

                            //e.Graphics.DrawString(line, smallFont, Brushes.Black, leftMargin, yPos);
                            //yPos += 20;

                            // Check if we need a new page
                            if (yPos > e.MarginBounds.Bottom - 100)
                            {
                                e.HasMorePages = true;
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle individual record errors gracefully
                            e.Graphics.DrawString($"خطأ في عرض السجل: {ex.Message}", smallFont, Brushes.Red, leftMargin, yPos);
                            yPos += 20;
                        }
                    }
                    //yPos += 20;
                }

                // 👇 PRINT VACCINATIONS SECTION ON SAME PAGE
                if (_vaccinationsForPrinting != null && _vaccinationsForPrinting.Count > 0)
                {
                    e.Graphics.DrawString("التطعيمات:", headerFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;

                    // Define column widths for vaccinations
                    const int vacCol1Width = 150; // اللقاح
                    const int vacCol2Width = 120; // تاريخ التطعيم
                    const int vacCol3Width = 120; // التالي
                    const int vacCol4Width = 150; // تم بواسطة
                    float vacTotalWidth = vacCol1Width + vacCol2Width + vacCol3Width + vacCol4Width;

                    // Print vaccination headers
                    float vacHeaderY = yPos;
                    e.Graphics.DrawString("اللقاح", normalFont, Brushes.Black, leftMargin, yPos);
                    e.Graphics.DrawString("تاريخ التطعيم", normalFont, Brushes.Black, leftMargin + vacCol1Width, yPos);
                    e.Graphics.DrawString("التالي", normalFont, Brushes.Black, leftMargin + vacCol1Width + vacCol2Width, yPos);
                    e.Graphics.DrawString("تم بواسطة", normalFont, Brushes.Black, leftMargin + vacCol1Width + vacCol2Width + vacCol3Width, yPos);

                    // Vertical lines for vaccination headers
                    e.Graphics.DrawLine(pen, leftMargin, vacHeaderY, leftMargin, vacHeaderY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + vacCol1Width, vacHeaderY, leftMargin + vacCol1Width, vacHeaderY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + vacCol1Width + vacCol2Width, vacHeaderY, leftMargin + vacCol1Width + vacCol2Width, vacHeaderY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + vacCol1Width + vacCol2Width + vacCol3Width, vacHeaderY, leftMargin + vacCol1Width + vacCol2Width + vacCol3Width, vacHeaderY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + vacTotalWidth, vacHeaderY, leftMargin + vacTotalWidth, vacHeaderY + 20);

                    yPos += 20;
                    e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin - 30, yPos);
                    yPos += 10;

                    foreach (dynamic vaccine in _vaccinationsForPrinting.Take(10))
                    {
                        try
                        {
                            float itemY = yPos;
                            string vaccineName = vaccine.VaccineName?.ToString() ?? "";
                            string vaccDate = ((DateTime)vaccine.VaccinationDate).ToString("yyyy-MM-dd");
                            string nextDate = vaccine.NextDueDate != null ? ((DateTime)vaccine.NextDueDate).ToString("yyyy-MM-dd") : "غير محدد";
                            string administeredBy = vaccine.AdministeredBy?.ToString() ?? "";

                            e.Graphics.DrawString(vaccineName, smallFont, Brushes.Black, leftMargin, yPos);
                            e.Graphics.DrawString(vaccDate, smallFont, Brushes.Black, leftMargin + vacCol1Width, yPos);
                            e.Graphics.DrawString(nextDate, smallFont, Brushes.Black, leftMargin + vacCol1Width + vacCol2Width, yPos);
                            e.Graphics.DrawString(administeredBy, smallFont, Brushes.Black, leftMargin + vacCol1Width + vacCol2Width + vacCol3Width, yPos);

                            // Vertical lines for vaccination data rows
                            e.Graphics.DrawLine(pen, leftMargin, itemY, leftMargin, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + vacCol1Width, itemY, leftMargin + vacCol1Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + vacCol1Width + vacCol2Width, itemY, leftMargin + vacCol1Width + vacCol2Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + vacCol1Width + vacCol2Width + vacCol3Width, itemY, leftMargin + vacCol1Width + vacCol2Width + vacCol3Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + vacTotalWidth, itemY, leftMargin + vacTotalWidth, itemY + 20);

                            yPos += 20;

                            if (yPos > e.MarginBounds.Bottom - 150)
                            {
                                e.HasMorePages = true;
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            e.Graphics.DrawString($"خطأ في عرض التطعيم: {ex.Message}", smallFont, Brushes.Red, leftMargin, yPos);
                            yPos += 20;
                        }
                    }
                    yPos += 20;
                }

                // 👇 PRINT SURGERIES SECTION ON SAME PAGE
                if (_surgeriesForPrinting != null && _surgeriesForPrinting.Count > 0)
                {
                    e.Graphics.DrawString("العمليات:", headerFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;

                    // Define column widths for surgeries
                    const int surgCol1Width = 200; // العملية
                    const int surgCol2Width = 120; // التاريخ
                    const int surgCol3Width = 150; // الجراح
                    const int surgCol4Width = 100; // النتيجة
                    float surgTotalWidth = surgCol1Width + surgCol2Width + surgCol3Width + surgCol4Width;

                    // Print surgery headers
                    float surgHeaderY = yPos;
                    e.Graphics.DrawString("العملية", normalFont, Brushes.Black, leftMargin, yPos);
                    e.Graphics.DrawString("التاريخ", normalFont, Brushes.Black, leftMargin + surgCol1Width, yPos);
                    e.Graphics.DrawString("الجراح", normalFont, Brushes.Black, leftMargin + surgCol1Width + surgCol2Width, yPos);
                    e.Graphics.DrawString("النتيجة", normalFont, Brushes.Black, leftMargin + surgCol1Width + surgCol2Width + surgCol3Width, yPos);

                    // Vertical lines for surgery headers
                    e.Graphics.DrawLine(pen, leftMargin, surgHeaderY, leftMargin, surgHeaderY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + surgCol1Width, surgHeaderY, leftMargin + surgCol1Width, surgHeaderY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + surgCol1Width + surgCol2Width, surgHeaderY, leftMargin + surgCol1Width + surgCol2Width, surgHeaderY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + surgCol1Width + surgCol2Width + surgCol3Width, surgHeaderY, leftMargin + surgCol1Width + surgCol2Width + surgCol3Width, surgHeaderY + 20);
                    e.Graphics.DrawLine(pen, leftMargin + surgTotalWidth, surgHeaderY, leftMargin + surgTotalWidth, surgHeaderY + 20);

                    yPos += 20;
                    e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, rightMargin - 30, yPos);
                    yPos += 10;

                    foreach (dynamic surgery in _surgeriesForPrinting.Take(10))
                    {
                        try
                        {
                            float itemY = yPos;
                            string surgeryName = surgery.SurgeryName?.ToString() ?? "";
                            string surgDate = ((DateTime)surgery.SurgeryDate).ToString("yyyy-MM-dd");
                            string surgeonName = surgery.SurgeonName?.ToString() ?? "";
                            string outcome = surgery.Outcome?.ToString() ?? "";

                            e.Graphics.DrawString(surgeryName, smallFont, Brushes.Black, leftMargin, yPos);
                            e.Graphics.DrawString(surgDate, smallFont, Brushes.Black, leftMargin + surgCol1Width, yPos);
                            e.Graphics.DrawString(surgeonName, smallFont, Brushes.Black, leftMargin + surgCol1Width + surgCol2Width, yPos);
                            e.Graphics.DrawString(outcome, smallFont, Brushes.Black, leftMargin + surgCol1Width + surgCol2Width + surgCol3Width, yPos);

                            // Vertical lines for surgery data rows
                            e.Graphics.DrawLine(pen, leftMargin, itemY, leftMargin, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + surgCol1Width, itemY, leftMargin + surgCol1Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + surgCol1Width + surgCol2Width, itemY, leftMargin + surgCol1Width + surgCol2Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + surgCol1Width + surgCol2Width + surgCol3Width, itemY, leftMargin + surgCol1Width + surgCol2Width + surgCol3Width, itemY + 20);
                            e.Graphics.DrawLine(pen, leftMargin + surgTotalWidth, itemY, leftMargin + surgTotalWidth, itemY + 20);

                            yPos += 20;

                            if (yPos > e.MarginBounds.Bottom - 150)
                            {
                                e.HasMorePages = true;
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            e.Graphics.DrawString($"خطأ في عرض العملية: {ex.Message}", smallFont, Brushes.Red, leftMargin, yPos);
                            yPos += 20;
                        }
                    }
                    yPos += 20;
                }

                //// Print Vaccinations Section
                //if (_vaccinationsForPrinting != null && _vaccinationsForPrinting.Count > 0)
                //{
                //    e.Graphics.DrawString("التطعيمات:", headerFont, Brushes.Black, leftMargin, yPos);
                //    yPos += 30;

                //    foreach (dynamic vaccine in _vaccinationsForPrinting.Take(5)) // Limit to 5 vaccines
                //    {
                //        string line = $"{vaccine.VaccineName} - {((DateTime)vaccine.VaccinationDate).ToString("yyyy-MM-dd")} - التالي: {((DateTime)vaccine.NextDueDate).ToString("yyyy-MM-dd")}";
                //        e.Graphics.DrawString(line, smallFont, Brushes.Black, leftMargin, yPos);
                //        yPos += 20;

                //        if (yPos > e.MarginBounds.Bottom - 100)
                //        {
                //            e.HasMorePages = true;
                //            return;
                //        }
                //    }
                //    yPos += 20;
                //}

                // Print Footer
                yPos = e.MarginBounds.Bottom - 50;
                string footer = $"تاريخ الطباعة: {DateTime.Now.ToString("yyyy-MM-dd HH:mm")}";
                e.Graphics.DrawString(footer, smallFont, Brushes.Gray, leftMargin, yPos);

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في إعداد الطباعة: " + ex.Message);
            }
        }
        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return "";
            if (value.Length <= maxLength) return value;
            return value.Substring(0, Math.Max(0, maxLength - 3)) + "...";
        }
    }
}
