using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalDatabaseFirst.Models;

namespace FinalDatabaseFirst.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLoginsController : ControllerBase
    {
        private readonly finalAssigContext _context;

        public CustomerLoginsController(finalAssigContext context)
        {
            _context = context;
        }

        // GET: api/CustomerLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerLogin>>> GetCustomerLogin()
        {
            return await _context.CustomerLogin.ToListAsync();
        }

        // GET: api/CustomerLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerLogin>> GetCustomerLogin(decimal? id)
        {
            var customerLogin = await _context.CustomerLogin.FindAsync(id);

            if (customerLogin == null)
            {
                return NotFound();
            }

            return customerLogin;
        }

        // PUT: api/CustomerLogins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerLogin(decimal? id, CustomerLogin customerLogin)
        {
            if (id != customerLogin.CusId)
            {
                return BadRequest();
            }

            _context.Entry(customerLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerLoginExists(id))
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

        // POST: api/CustomerLogins
        [HttpPost]
        public async Task<ActionResult<CustomerLogin>> PostCustomerLogin(CustomerLogin customerLogin)
        {
            _context.CustomerLogin.Add(customerLogin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerLoginExists(customerLogin.CusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerLogin", new { id = customerLogin.CusId }, customerLogin);
        }

        // DELETE: api/CustomerLogins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerLogin>> DeleteCustomerLogin(decimal? id)
        {
            var customerLogin = await _context.CustomerLogin.FindAsync(id);
            if (customerLogin == null)
            {
                return NotFound();
            }

            _context.CustomerLogin.Remove(customerLogin);
            await _context.SaveChangesAsync();

            return customerLogin;
        }

        private bool CustomerLoginExists(decimal? id)
        {
            return _context.CustomerLogin.Any(e => e.CusId == id);
        }
    }
}
