using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; }
        public bool IsActive { get; set; }
        public string StaffName { get; set; }

    }
}
