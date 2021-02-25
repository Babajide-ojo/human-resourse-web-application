using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeContactDetails : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public long PhoneNumber { get; set; }
        public long Mobile { get; set; }
        public long WorkTelephone { get; set; }
        public long Fax { get; set; }
        public string WorkEmail { get; set; }
        public string OtherEmail { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public string Address { get; set; }
        public string City_or_state_or_province { get; set; }
        public int PostalCode { get; set; }
    
        
    }
}
