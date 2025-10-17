using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Models
{
    class ApiResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? ProductId { get; set; }
        public string ProductCode { get; set; }
    }
}
