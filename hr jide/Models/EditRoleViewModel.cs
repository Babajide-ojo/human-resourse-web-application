using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace hr_jide.Models
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id  { get; set; }

        [Required(ErrorMessage ="The Role name is required")]
        public string RoleName  { get; set; }


        public List<string> Users { get; set; }
    }
}
