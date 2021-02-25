using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeSalary : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public PayGrades payGrades { get; set; }
        public int PayGradeId { get; set; }
        public PayFrequency PayFrequeqncy { get; set; }
        public int PayFrequencyId { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
       
    }
}
