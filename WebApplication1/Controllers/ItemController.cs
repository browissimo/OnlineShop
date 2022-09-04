using Microsoft.AspNetCore.Mvc;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Service.Interfaces;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<IActionResult> GetAllItemsAsync()
        {
            var response = await _itemService.GetAllItemsAsync();
            return View(response.Data);
        }

    }
}
