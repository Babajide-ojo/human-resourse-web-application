using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeSkills : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int SkillId { get; set; }
        public int YearsOfExperience { get; set; }
        public string Comment { get; set; }
        
    }
}
