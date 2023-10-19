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
            var menuFoodItems = await _context.MenusFoodItems.FindAsync(id);

            if (menuFoodItems == null)
            {
                return NotFound();
            }

            return menuFoodItems;
        }

        // PUT: api/MenuFoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuFoodItems(int id, MenuFoodItems menuFoodItems)
        {
            if (id != menuFoodItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(menuFoodItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuFoodItemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MenuFoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuFoodItems>> PostMenuFoodItems(MenuFoodItems menuFoodItems)
        {
            _context.MenusFoodItems.Add(menuFoodItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuFoodItems", new { id = menuFoodItems.Id }, menuFoodItems);
        }

        // DELETE: api/MenuFoodItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuFoodItems(int id)
        {
            var menuFoodItems = await _context.MenusFoodItems.FindAsync(id);
            if (menuFoodItems == null)
            {
                return NotFound();
            }

            _context.MenusFoodItems.Remove(menuFoodItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuFoodItemsExists(int id)
        {
            return _context.MenusFoodItems.Any(e => e.Id == id);
        }
    }
}
