using AutoService.Shared;

namespace AutoService.Api.Services
{
    public interface IWorkService
    {
        Task Add(Work work);

        Task Delete(string id);

        Task<List<Work>> GetAll();

        Task<List<Work>> GetWorksForCustomer(string customerID);

        Task<Work> Get(string id, bool needLog);

        Task Update( Work work);

    }
}
