using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Categories
{
    public class IndexModel : PageModel
    {
    [BindProperty]
    public List<Category> Categories { get; set; }

    private readonly ICategory categoryService;

    public IndexModel(ICategory service)
    {
      categoryService = service;
    }
        [AllowAnonymous]
        public async Task OnGet(string name)
        {
           Categories = await categoryService.GetCategories();
        }
    }
}
