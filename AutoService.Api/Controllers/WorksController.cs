using AutoService.Api.Services;
using AutoService.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoService.Api.Controllers
{
    [Route("works")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly IWorkService _workService;
        

        public WorksController(IWorkService workService)
        {
            _workService = workService;
             
        }

        [HttpPost("add/")]
        public async Task<IActionResult> Add([FromBody] Work work)
        {
            var existingPerson = await _workService.Get(work.Id, false);

            if (existingPerson is not null)
            {
                return Conflict("There is already a Work with this Id");
            }

            await _workService.Add(work);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingWork = await _workService.Get(id, false);

            if (existingWork is null)
            {
                return NotFound();
            }

            await _workService.Delete(id);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Work>>> GetAll()
        {
            var works = await _workService.GetAll();
            return Ok(works);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> Get(string id)
        {
            var work = await _workService.Get(id,   true);

            if (work is null)
            {
                return NotFound();
            }

            return Ok(work);
        }

        [HttpGet("{id}/works")]
        public async Task<ActionResult<List<Work>>> GetWorksForCustomer(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var works = await _workService.GetWorksForCustomer(id);
            if (works == null)
            {
                return NotFound();
            }
            return Ok(works);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Work work)
        {
            if (id != work.Id|| work == null)
            {
                return BadRequest();
            }

            var existingWork = await _workService.Get(id, false);

            if (existingWork is null)
            {
                return NotFound();
            }

            if(existingWork.WorkStatus == work.WorkStatus)
            {
                await _workService.Update(work);
                return Ok();
            }
            else if (work.WorkStatus == WorkStatusEnum.ElvegzesAlatt &&  existingWork.WorkStatus == WorkStatusEnum.FelvettMunka)
            {
                await _workService.Update(work);
                return Ok();
            }
            else if(work.WorkStatus == WorkStatusEnum.Befejezett && existingWork.WorkStatus == WorkStatusEnum.ElvegzesAlatt)
            {
                await _workService.Update(work);
                return Ok();
            }
            else
            {
                ModelState.AddModelError<Work>((x) => x.WorkStatus, $"New WorkStatus cannot be lower than current. You tried: {existingWork.WorkStatus} => {work.WorkStatus}");
                return ValidationProblem(ModelState);
            }
               
            
           

            
        }
    }
}
