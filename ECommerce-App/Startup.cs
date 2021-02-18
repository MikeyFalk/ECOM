using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerce_App.Data;
using ECommerce_App.Auth.Models;
using ECommerce_App.Auth.Services;
using ECommerce_App.Auth.Services.Interfaces;


namespace ECommerce_App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public IConfiguration Configuration { get; set; }
        
        public Startup(IConfiguration configuration)
        {
      Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

        services.AddDbContext<MjDbContext>(options =>
        {
          string connectionString = Configuration.GetConnectionString("DefaultConnection");
          options.UseSqlServer(connectionString);
        });

        services.AddIdentity<AuthUser, IdentityRole>(options =>
        {
          options.User.RequireUniqueEmail = true;

        }).AddEntityFrameworkStores<MjDbContext>();

        services.AddAuthentication();
        services.AddAuthorization(options => 
        {
          options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
          options.AddPolicy("read", policy => policy.RequireClaim("permissions", "read"));
          options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
          options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
        });

        services.AddTransient<IUserService, IdentityUserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
