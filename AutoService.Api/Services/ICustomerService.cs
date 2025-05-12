using AutoService.Shared;

namespace AutoService.Api.Services
{
    public interface ICustomerService
    {
        Task Add(Customer customer);

        Task Delete(string id);

        Task<List<Customer>> GetAll();

        Task<Customer> Get(string id, bool needLog = true);

        Task Update( Customer customer);

        Task<List<Work>> GetWorksForCustomer(string customerID);
    }
}
