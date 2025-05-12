using AutoService.Api.Services;
using AutoService.Shared;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoService.Api.Services.Implementation
{
    public class WorkService : IWorkService
    {
        private readonly DataContext _context;
        private readonly ILogger<WorkService> _logger;

        public WorkService(ILogger<WorkService> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Add(Work newWork)
        {
            Work work = newWork;
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Work added {@id}: {@work}", work.Id, newWork);
        }

        public async Task Delete(string id)
        {
            Work? work = await _context.Works.FindAsync(id);
            _context.Works.Remove(work);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Work deleted with id: {@id}", id);
        }

        public async Task<List<Work>> GetAll()
        {
            var result = await _context.Works.ToListAsync();

            _logger.LogInformation($"All {result.Count} works retrieved");
            return result;
        }

        public async Task<List<Work>> GetWorksForCustomer(string customerID)
        {

            var results = await _context.Works
                .Where(w => w.CustomerId == customerID)
                .ToListAsync();
            _logger.LogInformation($"Works retrieved for customer: {customerID}+\n+ {results}");
            return results;
        }


        public async Task<Work> Get(string id, bool needLog = true)
        {
            var work = await _context.Works.FirstOrDefaultAsync(w => w.Id == id);
            if (needLog) 
            {
                _logger.LogInformation("Work retrieved: {@work}", work);
            }
            
            return work;
        }

        public async Task Update(Work work)
        {
            var existingWork = await _context.Works.FindAsync(work.Id);
            
            if (existingWork != null)
            {
                existingWork.CustomerId = work.CustomerId;
                existingWork.RegPlate = work.RegPlate;
                existingWork.DateOfMake = work.DateOfMake;
                existingWork.WorkType = work.WorkType;
                existingWork.FaultDescription = work.FaultDescription;
                existingWork.FaultSeverity = work.FaultSeverity;
                existingWork.WorkStatus = work.WorkStatus;
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Work updated: {existingWork}");
            }
        }

        public async Task<double> CalculateWorkDuration(string id)
        {
            var work = await _context.Works.FindAsync(id);
            if (work == null)
            {
                _logger.LogWarning("Work with ID {Id} not found", id);
                return 0; // Return a default value if the work is not found
            }

            int categoryScore = work.WorkType switch
            {
                WorkTypeEnum.Karosszeria => 3,
                WorkTypeEnum.Motor => 8,
                WorkTypeEnum.Futomu => 6,
                WorkTypeEnum.Fekberendezes => 4,
                _ => 1
            };

            if (!work.DateOfMake.HasValue)
            {
                _logger.LogWarning("DateOfMake is null for Work with ID {Id}", id);
                return 0;
            }

            int age = DateTime.Now.Year - work.DateOfMake.Value.Year;
            double oldness = age switch
            {
                < 5 => 0.5,
                >= 5 and < 10 => 1,
                >= 10 and < 20 => 1.5,
                >= 20 => 2
            };

            double severityScore = work.FaultSeverity switch
            {
                1 or 2 => 0.2,
                3 or 4 => 0.4,
                5 or 7 => 0.6,
                8 or 9 => 0.8,
                10 => 1,
                _ => 1
            };

            return categoryScore * oldness * severityScore;
        }
    }

}