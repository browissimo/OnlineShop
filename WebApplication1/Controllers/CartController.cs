using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult GetCart()
        {
            return View();
        }
    }
}
