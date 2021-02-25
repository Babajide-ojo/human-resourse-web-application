using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeDependant :BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }

        
        public string Relationship { get; set; }

        public DateTime DateOfBirth { get; set; }
        
    }
}
