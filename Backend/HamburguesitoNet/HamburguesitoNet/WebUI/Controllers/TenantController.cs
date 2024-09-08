using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class TenantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
