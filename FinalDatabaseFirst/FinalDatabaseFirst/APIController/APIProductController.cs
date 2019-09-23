using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalDatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalDatabaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIProductController : ControllerBase
    {
        private readonly finalAssigContext _context;

        public APIProductController(finalAssigContext context)
        {
            _context = context;
        }

        // GET: api/APIProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/APIProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var products = await _context.Product.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/APIProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProdId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/APIProduct
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = product.ProdId}, product);
        }

        // DELETE: api/APIProduct/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var products = await _context.Product.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Product.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProdId == id);
        }
    }
}

    