using AutoService.Shared;

namespace AutoService.UI.Services
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetAllCustomersAsync(bool includeWorks = false);

        Task<Customer> GetCustomerAsync(string id, bool includeWorks = false);

        Task DeleteCustomerAsync(string id);

        Task AddCustomerAsync(Customer customer);

        Task UpdateCustomerAsync(Customer customer);
    }
}
