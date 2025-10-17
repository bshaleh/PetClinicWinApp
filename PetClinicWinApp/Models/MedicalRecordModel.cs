using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Models
{
    class MedicalRecordModel
    {
        public int RecordID { get; set; }
        public int PetID { get; set; }
        public int StaffID { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public string PetName { get; set; }
        public string PetCode { get; set; }
        public string DoctorName { get; set; }
    }
}
