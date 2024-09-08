using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class SellsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
