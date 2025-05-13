using AutoService.Shared;

namespace AutoService.Api.Services
{
    public interface IWorkService
    {
        Task Add(Work work);

        Task Delete(int id);

        Task<List<Work>> GetAll();

        Task<List<Work>> GetWorksForCustomer(int customerID);

        Task<Work> Get(int id, bool needLog);

        Task Update( Work work);

    }
}
