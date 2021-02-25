using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeMembership : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }

        public Membership Membership { get; set; }
        public int MembershipId { get; set; }


        public ReportingMethod ReportingMethod { get; set; }
        public int ReportMethodId { get; set; }

     
    }
}
