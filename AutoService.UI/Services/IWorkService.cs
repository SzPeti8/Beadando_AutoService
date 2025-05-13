using AutoService.Shared;

namespace AutoService.UI.Services
{
    public interface IWorkService
    {
        Task<IList<Work>> GetAllWorksAsync();

        Task<Work> GetWorkAsync(string id);

        Task DeleteWorkAsync(string id);

        Task AddWorkAsync(Work work);

        Task UpdateWorkAsync(Work work);
        Task<List<Work>> GetWorksForCustomerAsync(string id);
    }
}
