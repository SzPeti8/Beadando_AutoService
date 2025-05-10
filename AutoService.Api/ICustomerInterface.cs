using AutoService.Shared;

namespace AutoService.Api
{
    public interface ICustomerInterface
    {
        void Add(Customer customer);

        void Delete(string id);

        List<Customer> Get();

        Customer Get(string id);

        void Update(string id, Customer customer);
    }
}
