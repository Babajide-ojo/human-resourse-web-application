using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeImmigration : BaseEntity
    {

        public int Id { get; set; }
        public string EmployeeId { get; set; }


        public DocumentType DocumentType { get; set; }
        public int DocumentTypeId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public int DocumentNumber { get; set; }
        public Country Country { get; set; }
        public int CountryId{ get; set; }
        public DateTime EligibleReviewDate { get; set; }
        
    }
}
