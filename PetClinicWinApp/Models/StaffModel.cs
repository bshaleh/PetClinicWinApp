using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Models
{
    class StaffModel
    {
        public int StaffID { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public int BranchID { get; set; }
        public int? UserID { get; set; }
        public string UserName { get; set; }
    }
}
