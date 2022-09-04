using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Domain.ViewModels.Item;
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

        public async Task<IActionResult> GetItems()
        {
            var response = await _itemService.GetItems();
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> GetItem(int id)
        {
            var response = await _itemService.GetItem(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItemAsync(int id)
        {
            var response = await _itemService.DeleteItem(id);
            {
                if (response.StatusCode == Domain.Enum.StatusCode.Ok)
                {
                    return RedirectToAction("GetItems");
                }
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _itemService.GetItem(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                   await _itemService.CreateItem(model);
                }
                else
                {
                    await _itemService.Edit(model.Id, model);
                }
            }

            return RedirectToAction("GetItems");
        }
    }
}
