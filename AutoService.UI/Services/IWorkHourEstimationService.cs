using AutoService.Shared;

namespace AutoService.UI.Services
{
    public interface IWorkHourEstimationService
    {
        double GetWorkHourEstimation(Work work);
    }
}
