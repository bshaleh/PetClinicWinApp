using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Models
{
    class VaccinationModel
    {
        public int VaccinationID { get; set; }
        public int PetID { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string Notes { get; set; }
        public int AdministeredBy { get; set; }
        public string PetCode { get; set; }
        public string PetName { get; set; }
        public string DonedBy { get; set; }
    }
}
