using AutoService.Shared;

namespace AutoService.UI.Services
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerAsync(string id);

        Task DeleteCustomerAsync(string id);

        Task AddCustomerAsync(Customer customer);

        Task UpdateCustomerAsync(Customer customer);
    }
}
