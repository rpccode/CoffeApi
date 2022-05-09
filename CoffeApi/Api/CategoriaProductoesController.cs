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
    public class CategoriaProductoesController : ControllerBase
    {
        private readonly CoffeAppContext _context;

        public CategoriaProductoesController(CoffeAppContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaProducto>>> GetCategoriaProductos()
        {
            return await _context.CategoriaProductos.ToListAsync();
        }

        // GET: api/CategoriaProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaProducto>> GetCategoriaProducto(string id)
        {
            var categoriaProducto = await _context.CategoriaProductos.FindAsync(id);

            if (categoriaProducto == null)
            {
                return NotFound();
            }

            return categoriaProducto;
        }

        // PUT: api/CategoriaProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaProducto(string id, CategoriaProducto categoriaProducto)
        {
            if (id != categoriaProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaProductoExists(id))
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

        // POST: api/CategoriaProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaProducto>> PostCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            _context.CategoriaProductos.Add(categoriaProducto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoriaProductoExists(categoriaProducto.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategoriaProducto", new { id = categoriaProducto.Id }, categoriaProducto);
        }

        // DELETE: api/CategoriaProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaProducto(string id)
        {
            var categoriaProducto = await _context.CategoriaProductos.FindAsync(id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }

            _context.CategoriaProductos.Remove(categoriaProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaProductoExists(string id)
        {
            return _context.CategoriaProductos.Any(e => e.Id == id);
        }
    }
}
