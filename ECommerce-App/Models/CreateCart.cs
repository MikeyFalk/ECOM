﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
  public class CreateCart
  {
    [Required]
    public int id { get; set; }
    public string name { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }


  }
}