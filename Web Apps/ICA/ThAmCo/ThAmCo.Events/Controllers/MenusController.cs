using Microsoft.AspNetCore.Mvc;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Controllers
{
    public class MenusController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var returnList = await API.MenuController.Get();

            return View(returnList);    
        }

        public async Task<IActionResult> Create()
        {
            return View("Edit", null);
        }

        public async Task<IActionResult> Edit(int menuId)
        {
            Menu items = await API.MenuController.Get(menuId);

            return View("Edit", items);
        }

        public async Task<IActionResult> Submit(Menu menu)
        {
            //TODO : DO

            return RedirectToAction("Index");
        }
    }
}
