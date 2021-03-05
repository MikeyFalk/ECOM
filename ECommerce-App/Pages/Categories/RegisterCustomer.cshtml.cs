using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Auth.Models.DTO;
using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages
{
    public class RegisterCustomerModel : PageModel
    {
    public IUserService UserService { get; }
    public ICart CartService { get; set; }
    [BindProperty]
    public CustomerModel Input { get; set; }
    [BindProperty]
    public CreateCart CreateCart { get; set; }
    public RegisterCustomerModel(IUserService service, ICart newCartService)
    {
      UserService = service;
      CartService = newCartService;
    }
     public void OnGet()
     {
     }
    /// <summary>
    /// Ensures that upon getting to the register page, the correct fields are attached and then saved to the database to be later called on to login.
    /// </summary>
    /// <returns>A new user that gets posted to the db </returns>
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
      
      var newUsers = await UserService.Register(registerDTO);
      CreateCart cart = new CreateCart
      {
                UserId = newUsers.Id
      };
      CookieOptions cookieoption = new CookieOptions();
      cookieoption.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
      HttpContext.Response.Cookies.Append("UserId", newUsers.Id, cookieoption);

     await CartService.Create(cart);
     return RedirectToPage("/Categories/Index");
    }
    public class CustomerModel
    {
      public string Username { get; set; }
      public string Password { get; set; }
      public string Email { get; set; }
      public string Phonenumber { get; set; }
      public string UserId { get; set; }
      
      public IList<string> Roles { get; set; } 
      public CreateCart CreateCart { get; set; }
    }

   
    }
}
   