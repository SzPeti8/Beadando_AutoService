using AutoService.Shared;
using System;
using System.Net.Http.Json;
using System.Text;

namespace AutoService.UI.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _httpClient.PostAsJsonAsync("/customers/add/", customer);
        
        }

        public async Task DeleteCustomerAsync(string id)
        {
            await _httpClient.DeleteAsync($"/customers/{id}");
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        { 
            return await _httpClient.GetFromJsonAsync<IList<Customer>>("/customers/?");
        }

        public async Task<Customer> GetCustomerAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"/customers/{id}/?");
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _httpClient.PutAsJsonAsync($"/customers/{customer.Id}", customer);
        }
    }
}
