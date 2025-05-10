using AutoService.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoService.Api.Controllers
{
    [Route("works")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly WorkService _workService; 

        public WorksController(DataContext dataContext, WorkService workService)
        {
            _dataContext = dataContext;
            _workService = workService; 
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Work work)
        {
            var existingPerson = await _dataContext.Works.FindAsync(work.Id);

            if (existingPerson is not null)
            {
                return Conflict();
            }

            _dataContext.Works.Add(work);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingWork = await _dataContext.Works.FindAsync(id);

            if (existingWork is null)
            {
                return NotFound();
            }

            _dataContext.Works.Remove(existingWork);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Work>>> GetAll()
        {
            var works = await _dataContext.Works.ToListAsync();
            return Ok(works);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> Get(string id)
        {
            var work = await _dataContext.Works.FindAsync(id);

            if (work is null)
            {
                return NotFound();
            }

            return Ok(work);
        }

        [HttpGet("{id}/works")]
        public async Task<ActionResult<List<Customer>>> GetWorksForCustomer(string id)
        {
            
            var works = await _workService.GetWorksForCustomerAsync(id);

            if (works is null || works.Count == 0)
            {
                return NotFound();
            }

            return Ok(works);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Work work)
        {
            if (id != work.Id)
            {
                return BadRequest();
            }

            var existingWork = await _dataContext.Works.FindAsync(id);

            if (existingWork is null)
            {
                return NotFound();
            }

            existingWork.CustomerId = work.CustomerId;
            existingWork.RegPlate = work.RegPlate;
            existingWork.DateOfMake = work.DateOfMake;
            existingWork.WorkType = work.WorkType;
            existingWork.FaultDescription = work.FaultDescription;
            existingWork.FaultSeverity = work.FaultSeverity;
            existingWork.WorkStatus = work.WorkStatus;

            _dataContext.Works.Update(existingWork);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
