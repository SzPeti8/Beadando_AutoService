using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoService.Api;
using AutoService.Shared;
using AutoService.Api.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace AutoService.Api.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customers
        [HttpGet]
        public async Task<ActionResult<List<Work>>> GetAll()
        {
            var people = await _customerService.GetAll();
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

            var customer = await _customerService.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        [HttpPost("add/")]
        public async Task<IActionResult> Add([FromBody] Customer customer)
        {
            var existingCustomer = await _customerService.Get(customer.Id,false);

            if (existingCustomer is not null)
            {
                return Conflict();
            }

            await _customerService.Add(customer);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [Bind("Id,Name,Adress,Email")] Customer customer)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var oldCustomer = await _customerService.Get(id,false);

            if (oldCustomer is null)
            {
                return NotFound();
            }

            await _customerService.Update(customer);

            return Ok();
        }


        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.Get(id, false);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                await _customerService.Delete(id);
            }

            return Ok($"Id:{id}, Name: {customer.Name}. Deleted");
        }

        [HttpGet("{id}/works")]
        public async Task<ActionResult<List<Work>>> GetWorks(string id)
        {
            var customer = await _customerService.Get(id, false);
            if (id == null || customer == null)
            {
                return NotFound();
            }
            var works = await _customerService.GetWorksForCustomer(id);
            if (works == null)
            {
                return NotFound();
            }
            return Ok(works);
        }
    }
}
