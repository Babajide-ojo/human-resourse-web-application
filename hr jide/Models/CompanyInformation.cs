using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class CompanyInformation : BaseEntity
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public int TaxId { get; set; }
        public int NumberOfEmployees { get; set; }
        public string RegistrationNumber { get; set; }
        public long PhoneNumber { get; set; }
        public int Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
       
    }
}
