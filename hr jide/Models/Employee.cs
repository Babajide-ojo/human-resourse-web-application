using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class Employee : BaseEntity
    {

        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Photograph { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
