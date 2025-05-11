using AutoService.Shared;

namespace AutoService.Api
{
    public interface ICustomerService
    {
        void Add(Customer customer);

        void Delete(string id);

        List<Customer> Get();

        Customer Get(string id);

        void Update( Customer customer);
    }
}
