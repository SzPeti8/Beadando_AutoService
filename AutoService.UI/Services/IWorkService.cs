using AutoService.Shared;

namespace AutoService.UI.Services
{
    public interface IWorkService
    {
        Task<IList<Work>> GetAllWorksAsync();

        Task<Work> GetWorkAsync(int id);

        Task DeleteWorkAsync(int id);

        Task AddWorkAsync(Work work);

        Task UpdateWorkAsync(Work work);
        Task<List<Work>> GetWorksForCustomerAsync(int id);
    }
}
