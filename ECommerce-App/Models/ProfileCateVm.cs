using ECommerce_App.Auth.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class ProfileCateVm
    {
        public UserDTO Username { get; set;}
        public Category name {get; set;}
        public Category type { get; set; }
    }
}
