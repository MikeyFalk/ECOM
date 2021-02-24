using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Components
{
    [ViewComponent]
    public class LoggedInUserViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAysnc()
        {
            string username = HttpContext.Request.Cookies["Username"];

            ViewModel user = new ViewModel()
            {
                username = username
            };
            return View(user);
        }

        public class ViewModel
        {
            public string username { get; set; }
        }

    }
}
