using Microsoft.AspNetCore.Mvc;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Service.Interfaces;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public async  Task<IActionResult> GetAllItems()
        {
            var items = await itemService.GetAllItems();
            return View(items.Data);
        }

    }
}
