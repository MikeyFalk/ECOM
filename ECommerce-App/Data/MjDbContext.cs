using ECommerce_App.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ECommerce_App.Data
{
  public class MjDbContext : IdentityDbContext<AuthUser>
  {
    public MjDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      SeedRole(modelBuilder, "Administrator", "read", "create", "udpate", "delete");
      SeedRole(modelBuilder, "Editor", "read", "create", "udpate");
      SeedRole(modelBuilder, "Guest", "read");
    }
    private int nextId = 1;
    private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
    {
      var role = new IdentityRole
      {
        Id = roleName.ToLower(),
        Name = roleName,
        NormalizedName = roleName.ToUpper(),
        ConcurrencyStamp = Guid.Empty.ToString()

      };

      modelBuilder.Entity<IdentityRole>().HasData(role);
      var roleClaims = permissions.Select(permission => new IdentityRoleClaim<string>
      {
        Id = nextId++,
        RoleId = role.Id,
        ClaimType = "permissions",
        ClaimValue = permission
      }).ToArray();
      modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
    }
  }
 
}
