using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoService.Api;
using AutoService.Shared;

namespace AutoService.Api.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        // GET: Customers
        [HttpGet]
        public async Task<ActionResult<List<Work>>> GetAll()
        {
            var people = await _context.Customers.ToListAsync();
            return Ok(people);
        }

        // GET: Customers/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> Get(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        [HttpPost("add/")]
        public async Task<IActionResult> Add([FromBody] Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.Id);

            if (existingCustomer is not null)
            {
                return Conflict();
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [Bind("Id,Name,Adress,Email")] Customer customer)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var oldCustomer = await _context.Customers.FindAsync(id);

            if (oldCustomer is null)
            {
                return NotFound();
            }

            oldCustomer.Name = customer.Name;
            oldCustomer.Adress = customer.Adress;
            oldCustomer.Email = customer.Email;

            _context.Customers.Update(oldCustomer);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (CustomerExists(id))
            {
                _context.Customers.Remove(customer);
            }
            else
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return Ok($"Id:{id}, Name: {customer.Name}. Deleted");
        }

        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        [HttpGet("{id}/works")]
        public async Task<ActionResult<List<Work>>> GetWorks(string id)
        {
            if (id == null || !CustomerExists(id))
            {
                return NotFound();
            }
            var works = await _context.Works
                .Where(w => w.CustomerId == id)
                .ToListAsync();
            if (works == null)
            {
                return NotFound();
            }
            return Ok(works);
        }
    }
}
