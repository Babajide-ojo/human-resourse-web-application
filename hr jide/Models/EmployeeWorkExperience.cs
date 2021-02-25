using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeWorkExperience : BaseEntity
    {
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Comment { get; set; }
        
    }
}
