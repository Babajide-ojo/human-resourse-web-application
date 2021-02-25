using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeEmergencyContact : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
       
        public string Relationship { get; set; }
        public long HomeTelephone { get; set; }
        public long Mobile{ get; set; }
        public long WorkTelephone { get; set; }
       


    }
}
