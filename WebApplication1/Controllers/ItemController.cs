using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DAL.Interfaces;
using OnlineShop.Domain.ViewModels.Item;
using OnlineShop.Service.Interfaces;
using System.IO;
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


        [HttpGet]
        public IActionResult GetItems()
        {
            ViewBag.Type = "All";

            var response = _itemService.GetItems();

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> GetItem(int id)
        {
            var response = await _itemService.GetItem(id);
            return PartialView("GetItem", response.Data);
        }

        public async Task<IActionResult> ChangeColor(int id, int colorId)
        {
            var response = await _itemService.ChangeColor(id, colorId);
            return PartialView("GetItem", response.Data);
        }

        //[HttpPost]
        public async Task<IActionResult> GetItemsByType(string type)//, int page = 1, int pageSize = 5)
        {
            var response = await _itemService.GetItemsByType(type);
            return View("GetItems", response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchStirng)
        {
            var response = await _itemService.Search(searchStirng);

            if (response.Description == "Найдено 0 элементов")
            {
                ViewBag.Type = "Products not found, but check out what we have";
            }

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View("GetItems", response.Data);
            }
            return View("Error", $"{response.Description}");           
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _itemService.Delete(id);
            {
                if (response.StatusCode == Domain.Enum.StatusCode.Ok)
                {
                    return RedirectToAction("GetItems");
                }
                return RedirectToAction("Error");
            }
        }

        public IActionResult Compare() => PartialView();

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return PartialView();
            }

            var response = await _itemService.GetItem(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(ItemViewModel model)
        {
            ModelState.Remove("DateCreate");
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    await _itemService.Create(model);
                }
                else
                {
                    await _itemService.Edit(model.Id, model);
                }
                return RedirectToAction("GetItems");
            }
            return View();
        }

        [HttpPost]
        public JsonResult GetTypes()
        {
            var types = _itemService.GetTypes();
            return Json(types.Data);
        }
    }
}
