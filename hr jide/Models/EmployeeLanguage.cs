using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeLanguage : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Language { get; set; }

        public string Fluency { get; set; }

        public string Competency { get; set; }
        public string Comments { get; set; }
       
    }
}
