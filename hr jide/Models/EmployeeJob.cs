using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EmployeeJob : BaseEntity
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }

        public JobTitles JobTitles { get; set; }
        public int JobTitlesId { get; set; }

        public EmployementStatus Employementstatus { get; set; }
        public int EmploymentStatusId { get; set; }


        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public JobCategories JobCategories { get; set; }
        public int JobCategoriesId { get; set; }

        public CompanyBranch CompanyBranch { get; set; }
        public int CompanyBranchId { get; set; }

        public DateTime JoinedDate { get; set; }

        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }

        
    }
}
