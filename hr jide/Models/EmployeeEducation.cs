using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeEducation: BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Level { get; set; }
        public string Institute { get; set; }
        public string Major { get; set; }
        public int Year { get; set; }
        public decimal GPA { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        
    }
}
