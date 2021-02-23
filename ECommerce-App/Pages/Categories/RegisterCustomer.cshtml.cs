using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Auth.Models.DTO;
using ECommerce_App.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages
{
    public class RegisterCustomerModel : PageModel
    {
    public IUserService userService { get; }

    [BindProperty]
    public CustomerModel Input { get; set; }
    public RegisterCustomerModel(IUserService service)
    {
      userService = service;
    }
     public void OnGet()
     {
     }

    public async Task<IActionResult> OnPostAsync()
    {
      if(!ModelState.IsValid)
      {
        return Page();
      }

      RegisterDTO registerDTO = new RegisterDTO()
      {
        Username = Input.Username,
        Password = Input.Password,
        Email = Input.Email, 
        Phonenumber = Input.Phonenumber,
        Roles = new List<string>() { "guest" }
    };
      
      await userService.Register(registerDTO);
      return RedirectToPage("/Categories/Index");
    }
    public class CustomerModel
    {
      public string Username { get; set; }
      public string Password { get; set; }
      public string Email { get; set; }
      public string Phonenumber { get; set; }
      public IList<string> Roles { get; set; } 
    }

   
    }
}
    //foreach (var error in result.Errors)
    //{
    //  var errorKey =
    //    error.Code.Contains("Password") ? nameof(data.Password) :
    //    error.Code.Contains("Email") ? nameof(data.Email) :
    //    error.Code.Contains("Username") ? nameof(data.Username) :
    //    "";
    //  modelState.AddModelError(errorKey, error.Description);
    //}





//Customer customer = new User()
//{
//  Name = Input.Username,
//  Email = Input.Email,
//  Password = Input.Password,
//  Phonenumber = Input.Phonenumber

//};
//User record = await userService.Create(user);