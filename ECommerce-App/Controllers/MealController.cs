﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Controllers
{
    public class MealController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
