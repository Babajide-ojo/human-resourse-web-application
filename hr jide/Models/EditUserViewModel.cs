using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();

            Roles = new List<string>();
        }
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<string> Claims { get; set; }

        public List<string> Roles { get; set; }

    }
}
