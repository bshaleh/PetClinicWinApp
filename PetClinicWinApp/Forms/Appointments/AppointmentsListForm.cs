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

namespace PetClinicWinApp.Forms.Appointments
{
    public partial class AppointmentsListForm : Form
    {
        public AppointmentsListForm()
        {
            InitializeComponent();
            dtpTo.Value = DateTime.Now;
            dtpDateFilter.Value = DateTime.Now.AddDays(-30);
            dgvAppointments.AutoGenerateColumns = false;
            //ddlStatusFilter.Items.AddRange(new[] { "الكل", "Scheduled", "Completed", "Cancelled" });
            SetupGridColumns();
            //LoadAppointments();
        }

        private void SetupGridColumns()
        {
            dgvAppointments.Columns.Clear(); // Clear any auto-generated columns

            dgvAppointments.Columns.AddRange(
        new DataGridViewTextBoxColumn { HeaderText = "تاريخ الموعد", DataPropertyName = "AppointmentDate", Width = 150 },
        new DataGridViewTextBoxColumn { HeaderText = "اسم الحيوان", DataPropertyName = "PetName", Width = 150 },
        new DataGridViewTextBoxColumn { HeaderText = "المالك", DataPropertyName = "OwnerName", Width = 100 },
        new DataGridViewTextBoxColumn { HeaderText = "الطبيب", DataPropertyName = "StaffName", Width = 100 },
        new DataGridViewTextBoxColumn { HeaderText = "فرع العيادة", DataPropertyName = "BranchName", Width = 100 },
        new DataGridViewTextBoxColumn { HeaderText = "السبب", DataPropertyName = "Reason", Width = 200 },
        new DataGridViewTextBoxColumn { HeaderText = "الحالة", DataPropertyName = "Status", Width = 100 }
    );
        }

        //private async void LoadAppointments(DateTime? date = null, string status = null)
        //{
        //    try
        //    {
        //        string endpoint = "appointments";
        //        if (date.HasValue || !string.IsNullOrEmpty(status))
        //        {
        //            var queryParams = new List<string>();
        //            if (date.HasValue) queryParams.Add($"appointmentDate={date.Value:yyyy-MM-dd}");
        //            if (!string.IsNullOrEmpty(status)) queryParams.Add($"status={status}");
        //            endpoint += "?" + string.Join("&", queryParams);
        //        }

        //        var appointments = await ApiHelper.GetAsync<List<dynamic>>(endpoint);
        //        dgvAppointments.DataSource = appointments;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("خطأ في تحميل المواعيد: " + ex.Message);
        //    }
        //}

        private async Task LoadAppointments()
        {
            try
            {
                // Build query parameters
                var queryParams = new List<string>();
                queryParams.Add($"fromDate={dtpDateFilter.Value:yyyy-MM-dd}");
                queryParams.Add($"toDate={dtpTo.Value:yyyy-MM-dd}");

                string status = ddlStatusFilter.SelectedItem?.ToString();
                if (status != "الكل")
                {
                    queryParams.Add($"status={status}");
                }

                string endpoint = "appointments?" + string.Join("&", queryParams);
                var appointments = await ApiHelper.GetAsync<List<dynamic>>(endpoint);

                // Sort by date (newest first)
                var sortedAppointments = appointments
                    .OrderByDescending(x => DateTime.Parse(x.AppointmentDate.ToString()))
                    .ToList();

                dgvAppointments.DataSource = sortedAppointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل المواعيد: " + ex.Message);
            }
        }


        private async void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpDateFilter.Value > dtpTo.Value)
            {
                MessageBox.Show("تاريخ البداية يجب أن يكون قبل تاريخ النهاية!");
                return;
            }
            await LoadAppointments();
            //DateTime? date = dtpDateFilter.Value.Date;
            //string status = ddlStatusFilter.SelectedItem?.ToString();
            //LoadAppointments(date, status);
        }

        private async void btnBook_Click(object sender, EventArgs e)
        {
            using (var form = new BookAppointmentForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // 👇 ADJUST toDate TO INCLUDE NEW APPOINTMENT
                    if (form.BookedAppointmentDate.HasValue)
                    {
                        // If new appointment is after current toDate, extend toDate
                        if (form.BookedAppointmentDate.Value.Date > dtpTo.Value.Date)
                        {
                            dtpTo.Value = form.BookedAppointmentDate.Value.Date.AddDays(1);
                        }
                    }
                    await LoadAppointments();
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadAppointments();
        }

        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار موعد من القائمة!");
                return;
            }

            var selectedRow = dgvAppointments.SelectedRows[0];
            dynamic appointment = selectedRow.DataBoundItem;
            string currentStatus = appointment.Status.ToString();

            if (currentStatus == "Completed")
            {
                MessageBox.Show("هذا الموعد تم تسجيل حضوره مسبقاً!");
                return;
            }
            

            // Confirm status change
            var result = MessageBox.Show(
                "هل تريد تغيير حالة الموعد إلى 'تم الحضور'؟",
                "تأكيد التغيير",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var updateData = new
                    {
                        appointmentId = (int)appointment.AppointmentID,
                        status = "Completed"
                    };

                    dynamic apiResult = await ApiHelper.PostAsync<dynamic>("appointments/updatestatus", updateData);

                    if ((bool)apiResult.success)
                    {
                        MessageBox.Show("تم تحديث حالة الموعد بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       await LoadAppointments(); // Refresh
                    }
                    else
                    {
                        MessageBox.Show("فشل في تحديث الحالة: " + apiResult.message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحديث الحالة: " + ex.Message);
                }
            }

            //if (dgvAppointments.SelectedRows.Count == 0) return;

            //// Implement check-in logic here
            //MessageBox.Show("تسجيل الحضور غير مطبق بعد!");
        }

        private async void AppointmentsListForm_Load(object sender, EventArgs e)
        {
            // Set default From date (30 days ago)
            dtpDateFilter.Value = DateTime.Now.AddDays(-30);

            try
            {
                // 👇 GET LATEST APPOINTMENT DATE FROM API
                dynamic result = await ApiHelper.GetAsync<dynamic>("appointments/latestdate");
                DateTime latestDate = DateTime.Parse(result.latestDate.ToString());

                // Set To date to latest appointment date (or today if later)
                dtpTo.Value = latestDate < DateTime.Now.Date ? DateTime.Now.Date : latestDate;
            }
            catch (Exception ex)
            {
                // If API fails, default to today
                dtpTo.Value = DateTime.Now.Date;
                System.Diagnostics.Debug.WriteLine($"Failed to get latest date: {ex.Message}");
            }

            await LoadAppointments();

        }

        private async void ddlStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadAppointments();
        }

        private async void btnCancelAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار موعد من القائمة!");
                return;
            }

            var selectedRow = dgvAppointments.SelectedRows[0];
            dynamic appointment = selectedRow.DataBoundItem;
            string currentStatus = appointment.Status.ToString();

            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("هذا الموعد تم إلغاؤه مسبقاً!");
                return;
            }
            if (currentStatus == "Completed")
            {
                MessageBox.Show("لا يمكن إلغاء موعد تم تسجيل حضوره!");
                return;
            }

            // Confirm cancellation
            var result = MessageBox.Show(
                "هل تريد إلغاء هذا الموعد؟\nلا يمكن التراجع عن هذا الإجراء.",
                "تأكيد الإلغاء",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var updateData = new
                    {
                        appointmentId = (int)appointment.AppointmentID,
                        status = "Cancelled"
                    };

                    dynamic apiResult = await ApiHelper.PostAsync<dynamic>("appointments/updatestatus", updateData);

                    if ((bool)apiResult.success)
                    {
                        MessageBox.Show("تم إلغاء الموعد بنجاح!", "تم الإلغاء", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadAppointments(); // Refresh grid
                    }
                    else
                    {
                        MessageBox.Show("فشل في إلغاء الموعد: " + apiResult.message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في إلغاء الموعد: " + ex.Message);
                }
            }
        }
    }
}
