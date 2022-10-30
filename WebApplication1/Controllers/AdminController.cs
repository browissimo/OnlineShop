using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.ViewModels.Item;
using OnlineShop.Service.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class AdminController : Controller
    {

        private readonly IItemService _itemService;

        public AdminController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IActionResult EditUsers()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult EditItems(int page=1)
        {
            var response = _itemService.GetItems(page);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");

        }
    }
}
