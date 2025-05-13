using AutoService.Shared;

namespace AutoService.UI.Services
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerAsync(int id);

        Task DeleteCustomerAsync(int id);

        Task AddCustomerAsync(Customer customer);

        Task UpdateCustomerAsync(Customer customer);
    }
}
