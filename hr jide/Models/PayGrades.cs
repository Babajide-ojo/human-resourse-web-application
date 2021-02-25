using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class PayGrades : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal MinimumSalary { get; set; }
        public decimal MaximumSalary { get; set; }
        
    }
}
