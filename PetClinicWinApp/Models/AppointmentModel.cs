using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Models
{
    class AppointmentModel
    {
        public int AppointmentID { get; set; }
        public int PetID { get; set; }
        public int StaffID { get; set; }
        public int BranchID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
