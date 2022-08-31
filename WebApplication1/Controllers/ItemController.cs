using Microsoft.AspNetCore.Mvc;
using OnlineShop.DAL.Interfaces;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ItemController : Controller
    {

        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemRepository.GetAllItems();
            return View(items);
        }
    }
}
