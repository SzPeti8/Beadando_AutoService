using AutoService.Shared;

namespace AutoService.UI.Services.Implementation
{
    public class WorkHourEstimationService : IWorkHourEstimationService
    {
        public double GetWorkHourEstimation(Work work)
        {
            
            int categoryScore = work.WorkType switch
            {
                WorkTypeEnum.Karosszeria => 3,
                WorkTypeEnum.Motor => 8,
                WorkTypeEnum.Futomu => 6,
                WorkTypeEnum.Fekberendezes => 4,
                _ => 1
            };

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
