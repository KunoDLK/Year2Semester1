using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
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
            if (menu.MenuId == 0)
            {
            await API.MenuController.Post(menu);
            }
            else
            {
                await API.MenuController.Put(menu);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteWithConfimation(int menuId)
        {
            return View(menuId);
        }

        public async Task<IActionResult> Delete(int menuId)
        {
            await API.MenuController.Delete(menuId);

            return RedirectToAction("Index");
        }

    }
}
