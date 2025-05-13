using AutoService.Shared;

namespace AutoService.Api.Services
{
    public interface ICustomerService
    {
        Task Add(Customer customer);

        Task Delete(int id);

        Task<List<Customer>> GetAll();

        Task<Customer> Get(int id, bool needLog = true);

        Task Update( Customer customer);

        Task<List<Work>> GetWorksForCustomer(int customerID);
    }
}
