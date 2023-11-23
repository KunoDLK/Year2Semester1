using Microsoft.AspNetCore.Mvc;

namespace ThAmCo.Events.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
