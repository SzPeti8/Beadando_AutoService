using AutoService.Shared;

namespace AutoService.Api
{
    public interface IWorkService
    {
        void Add(Work work);

        void Delete(string id);

        List<Work> Get();

        List<Work> GetWorksForCustomer(string customerID);

        Task<List<Work>> GetWorksForCustomerAsync(string customerID);
        
        Work Get(string id);

        void Update( Work work);

        double CalculateWorkDuration(string id);
    }
}
