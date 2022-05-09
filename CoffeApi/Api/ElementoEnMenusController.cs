using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoffeApi.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ElementoEnMenusController : ControllerBase
    {
        private readonly CoffeAppContext _context;

        public ElementoEnMenusController(CoffeAppContext context)
        {
            _context = context;
        }

        // GET: api/ElementoEnMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElementoEnMenu>>> GetElementoEnMenus()
        {
            return await _context.ElementoEnMenus.ToListAsync();
        }

        // GET: api/ElementoEnMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElementoEnMenu>> GetElementoEnMenu(string id)
        {
            var elementoEnMenu = await _context.ElementoEnMenus.FindAsync(id);

            if (elementoEnMenu == null)
            {
                return NotFound();
            }

            return elementoEnMenu;
        }

        // PUT: api/ElementoEnMenus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElementoEnMenu(string id, ElementoEnMenu elementoEnMenu)
        {
            if (id != elementoEnMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(elementoEnMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementoEnMenuExists(id))
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

        // POST: api/ElementoEnMenus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ElementoEnMenu>> PostElementoEnMenu(ElementoEnMenu elementoEnMenu)
        {
            _context.ElementoEnMenus.Add(elementoEnMenu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ElementoEnMenuExists(elementoEnMenu.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetElementoEnMenu", new { id = elementoEnMenu.Id }, elementoEnMenu);
        }

        // DELETE: api/ElementoEnMenus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementoEnMenu(string id)
        {
            var elementoEnMenu = await _context.ElementoEnMenus.FindAsync(id);
            if (elementoEnMenu == null)
            {
                return NotFound();
            }

            _context.ElementoEnMenus.Remove(elementoEnMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElementoEnMenuExists(string id)
        {
            return _context.ElementoEnMenus.Any(e => e.Id == id);
        }
    }
}
