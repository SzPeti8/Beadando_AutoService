using AutoService.Api.Services;
using AutoService.Shared;

namespace AutoService.Api.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _customers = new List<Customer>();
            _logger = logger;
        }
        public void Add(Customer customer)
        {
            _customers.Add(customer);
            _logger.LogInformation("Customer added: {@Customer}", customer);
        }
        public void Delete(string id)
        {
            _customers.RemoveAll(x => x.Id == id);
            _logger.LogInformation("Customer deleted");
        }
        public List<Customer> Get()
        {
            return _customers;
        }
        public Customer Get(string id)
        {
            return _customers.Find(c => c.Id == id);
        }
        public void Update( Customer customer)
        {
            var existingCustomer = Get(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Adress = customer.Adress;
                existingCustomer.Email = customer.Email;
                _logger.LogInformation("Customer updated: {@Customer}", customer);
            }
            else
            {
                _logger.LogWarning("Customer not found for update: {@Customer}", customer);
            }
        }
    }
}
