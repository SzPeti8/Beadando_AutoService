using AutoService.Shared;
using System;

namespace AutoService.Api
{
    public class WorkService : IWorkService
    {
        private readonly List<Work> _works;
        private readonly ILogger<WorkService> _logger;

        public WorkService(ILogger<WorkService> logger)
        {
            _works = new List<Work>();
            _logger = logger;
        }

        public void Add(Work work)
        {
            _works.Add(work);
            _logger.LogInformation("Work added: {@Work}", work);
        }

        public void Delete(string id)
        {
            _works.RemoveAll(x => x.Id == id);
            _logger.LogInformation("Work deleted");
        }

        public List<Work> Get()
        {
            return _works;
        }

        public List<Work> GetWorksForCustomer(string customerID)
        {
            return _works.Where(w => w.CustomerId == customerID).ToList();
        }


        public Work Get(string id)
        {
            return _works.Find(w => w.Id == id);
        }

        public void Update(Work work)
        {
            var existingWork = Get(work.Id);
            if (existingWork != null)
            {
                existingWork.CustomerId = work.CustomerId;
                existingWork.RegPlate = work.RegPlate;
                existingWork.DateOfMake = work.DateOfMake;
                existingWork.WorkType = work.WorkType;
                existingWork.FaultDescription = work.FaultDescription;
                existingWork.FaultSeverity = work.FaultSeverity;
                existingWork.WorkStatus = work.WorkStatus;
                _logger.LogInformation("Work updated");
            }
        }

        public double CalculateWorkDuration(string id)
        {
            var work = Get(id);
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