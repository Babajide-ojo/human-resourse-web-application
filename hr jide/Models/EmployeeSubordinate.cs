using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeSubordinate : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string ReportingMethod { get; set; }
        
    }
}
