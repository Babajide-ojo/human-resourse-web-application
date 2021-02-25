using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeLicense: BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int LicenseId { get; set; }
        public int LicenseNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Comment { get; set; }
       
    }
}
