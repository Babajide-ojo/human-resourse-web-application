﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class Currency : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public string CurrencyCode { get; set; }

    }
}
