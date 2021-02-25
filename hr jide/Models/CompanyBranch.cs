using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class CompanyBranch : BaseEntity
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
