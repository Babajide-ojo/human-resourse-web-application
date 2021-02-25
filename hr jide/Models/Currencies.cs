using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class Currencies : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength (3)]
        public char CurrencyCode { get; set; }
        
    }
}
