﻿
using ECommerce_App.Auth.Models;
using ECommerce_App.Auth.Models.DTO;
using ECommerce_App.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce_App.Auth.Services
{
  public class IdentityUserService : IUserService
  {
    private UserManager<AuthUser> userManager;
    private SignInManager<AuthUser> signInManager;
    public IdentityUserService(UserManager<AuthUser> manager, SignInManager<AuthUser> sim)
    {
      userManager = manager;
      signInManager = sim;
    } 

    public async Task<UserDTO> Register(RegisterDTO data)
    {
      var user = new AuthUser
      {
        UserName = data.Username,
        Email = data.Email,
        PhoneNumber = data.Phonenumber
      };
      var result = await userManager.CreateAsync(user, data.Password);
      if (result.Succeeded)
      {
        await userManager.AddToRolesAsync(user, data.Roles);
                List<Claim> claims = new List<Claim>
                {
                    new Claim("userId", user.Id)

                };
                userManager.AddClaimsAsync(user, claims).Wait();
       
       await signInManager.PasswordSignInAsync(data.Username, data.Password, true, false);


        return new UserDTO
        {
          Id = user.Id,
          Username = user.UserName,
          Roles = await userManager.GetRolesAsync(user),
          
        };

      }
      return null;
    }
    private TimeSpan TimeSpan(object P)
    {
      throw new NotImplementedException();
    }

    public async Task<UserDTO> Authenticate(string username, string password)
    {
      var result = await signInManager.PasswordSignInAsync(username, password, true, false);
      if (result.Succeeded)
      {
        var user = await userManager.FindByNameAsync(username);
        return new UserDTO
        {
          Id = user.Id,
          Username = user.UserName,
          Roles = await userManager.GetRolesAsync(user)
        };
      }
      return null;
    }

    public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
    {
      var user = await userManager.GetUserAsync(principal);
      return new UserDTO
      {
        Id = user.Id,
        Username = user.UserName,
        Roles = await userManager.GetRolesAsync(user)
      };
    }
  }
}
