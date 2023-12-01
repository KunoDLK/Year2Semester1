using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Data;
using ThAmCo.Catering.DatabaseContexts;

namespace ThAmCo.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuFoodItemsController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public MenuFoodItemsController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuFoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuFoodItems>>> GetMenusFoodItems()
        {
            return await _context.MenusFoodItems.ToListAsync();
        }

        // GET: api/MenuFoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuFoodItems>> GetMenuFoodItems(int id)
        {
            var menuFoodItems = await _context.MenusFoodItems.FirstOrDefaultAsync(x => x.MenuId == id);

            if (menuFoodItems == null)
            {
                return NotFound();
            }

            return menuFoodItems;
        }

        // PUT: api/MenuFoodItems/5
        [HttpPost]
        public async Task<IActionResult> PostMenuFoodItems(MenuFoodItems menuFoodItem)
        {
            if (_context.MenusFoodItems.FirstOrDefault(x => x.MenuId == menuFoodItem.MenuId && x.FoodItemId == menuFoodItem.FoodItemId) != null
                || _context.FoodItems.Find(menuFoodItem.FoodItemId) == null
                || _context.Menus.Find(menuFoodItem.MenuId) == null)
            {
                return BadRequest();
            }

            _context.MenusFoodItems.Add(menuFoodItem);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/MenuFoodItems/5
        [HttpDelete]
        public async Task<IActionResult> DeleteMenuFoodItems(MenuFoodItems menuFoodItem)
        {
            var menuFoodItems = await _context.MenusFoodItems.FirstOrDefaultAsync(x => x.MenuId == menuFoodItem.MenuId && x.FoodItemId == menuFoodItem.FoodItemId);
            if (menuFoodItems == null)
            {
                return NotFound();
            }

            _context.MenusFoodItems.Remove(menuFoodItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
