using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Auth.Models.DTO
{
  public class RegisterDTO
  {
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    public string Phonenumber { get; set; }
    public IList<string> Roles { get; set; } = new string[3];
    }
}
