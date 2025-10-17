using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicWinApp.Models
{
    class SaleModel
    {
        public int SaleID { get; set; }
        public DateTime SaleDate { get; set; }
        public int? PetOwnerID { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public int SoldBy { get; set; }
        public string SoldByName { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public List<SaleDetailModel> SaleDetails { get; set; }
    }
    public class SaleDetailModel
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
