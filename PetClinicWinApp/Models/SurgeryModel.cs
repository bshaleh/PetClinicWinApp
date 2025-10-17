using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Models
{
    class SurgeryModel
    {
        public int SurgeryID { get; set; }
        public int PetID { get; set; }
        public string SurgeryName { get; set; }
        public DateTime SurgeryDate { get; set; }
        public int SurgeonID { get; set; }
        public string Notes { get; set; }
        public string Outcome { get; set; }
        public string PetCode { get; set; }
        public string PetName { get; set; }
        public string SurgeonName { get; set; }
    }
}
