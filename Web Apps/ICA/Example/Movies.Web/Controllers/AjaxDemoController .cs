using Microsoft.AspNetCore.Mvc;

namespace Movies.Web.Controllers
{
    public class AjaxDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
