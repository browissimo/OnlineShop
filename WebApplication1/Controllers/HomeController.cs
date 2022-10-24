using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Models;
using OnlineShop.Domain.Entity;
using OnlineShop.Service.Interfaces;
using OnlineShop.Domain.ViewModels.Item;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService _itemService;

        public HomeController(IItemService itemService)
        {
            _itemService = itemService;
        }


        public IActionResult Index()
        {
            var response = _itemService.GetItems();
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

    }
}
