using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Controllers
{
      public class MenusController : Controller
      {
            private string DefaultNewName => "Untitled Menu";

            private API.APIController<Menu> APIController { get; set; }

            public MenusController()
            {
                  APIController = new API.APIController<Menu>("Menus");
            }

            public async Task<IActionResult> Index()
            {
                  var returnList = await APIController.Get();

                  returnList = returnList.OrderByDescending(x => x.MenuName.Equals(DefaultNewName)).OrderByDescending(x => x.MenuId).ToList();

                  return View(returnList);
            }

            public async Task<IActionResult> Create()
            {
                  await APIController.Post(new Menu() { MenuName = DefaultNewName });

                  return RedirectToAction("Index");
            }

            public async Task<IActionResult> Edit(int menuId)
            {
                  Menu items = await APIController.Get(menuId);

                  return View("Edit", items);
            }

            public async Task<IActionResult> Submit(Menu menu)
            {
                  await APIController.Put(menu);

                  return RedirectToAction("Index");
            }

            public async Task<IActionResult> DeleteWithConfimation(int menuId)
            {
                  return View(menuId);
            }

            public async Task<IActionResult> Delete(int menuId)
            {
                  await APIController.Delete(menuId);

                  return RedirectToAction("Index");
            }

      }
}
