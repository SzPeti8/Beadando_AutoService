using AutoService.Api.Services;
using AutoService.Shared;
using Castle.Core.Resource;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Api.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Customer added: {@Customer}", customer);
        }
        public async Task Delete(int id)
        {
            var customer = await Get(id, false);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Customer id: {customer.Id}, Name: {customer.Name} deleted.");
        }
        public async Task<List<Customer>> GetAll()
        {
            var result = await _context.Customers.ToListAsync();
            _logger.LogInformation($"All {result.Count} customers retrieved");
            return result;
        }
        public async Task<Customer> Get(int id,bool needLog = true)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (needLog)
            {
                _logger.LogInformation("Customer retrieved: {@customer}", customer);
            }
            
            return customer;
        }
        public async Task Update( Customer customer)
        {
            var existingCustomer = await Get(customer.Id,false);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Adress = customer.Adress;
                existingCustomer.Email = customer.Email;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Customer updated: {@Customer}", customer);
            }
            else
            {
                _logger.LogWarning("Customer not found for update: {@Customer}", customer);
            }
        }

        public async Task<List<Work>> GetWorksForCustomer(int customerID)
        {
            var results = await _context.Works
                .Where(w => w.CustomerId == customerID)
                .ToListAsync();
            _logger.LogInformation($"Works retrieved for customer: {customerID}+\n+ {results}");
            return results;
        }

    }
}
