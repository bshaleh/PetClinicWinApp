using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Models
{
    public class PetModel
    {
        public int PetID { get; set; }
        public string PetCode { get; set; }
        public string PetName { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public int OwnerID { get; set; }
        public string Notes { get; set; }
        public string OwnerName { get; set; }
    }
}
