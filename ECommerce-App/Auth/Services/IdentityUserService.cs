
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Auth.Services
{
  public class IdentityUserService : IUserService
  {
    private UserManager<authUser> userManager;
    private SignInManager<authUser> signInManager;
    public IdentityUserService(UserManager<authUser> manager, SignInManager<authUser> sim)
    {
      userManager = manager;
      signInManager = sim;
    } 

    public async Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState)
    {
      var user = new AuthUser
      {
        UserName = data.UserName,
        Email = data.Email,
        PhoneNumber = data.PhoneNumber
      };
      var result = await userManager.CreateAsync(user, data.Password);
      if (result.Succeeded)
      {
        await userManager.AddToRolesAsync(user, data.Roles);
        return new UserDTO;

        new UserDTO
        {
          Id = user.Id,
          UserName = user.UserName,
          Roles = await userManager.GetRolesAsync(user)
        };
      }
    }
  }
}
