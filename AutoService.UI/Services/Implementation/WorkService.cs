using AutoService.Shared;
using System;
using System.Net.Http.Json;

namespace AutoService.UI.Services.Implementation
{
    public class WorkService : IWorkService
    {

        private readonly HttpClient _httpClient;

        public WorkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddWorkAsync(Work work)
        {
            await _httpClient.PostAsJsonAsync("/works", work);
        }

        public async Task DeleteWorkAsync(string id)
        {
            await _httpClient.DeleteAsync($"/works/{id}");
        }

        public async Task<IList<Work>> GetAllWorksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IList<Work>>("/works");
        }

        public async Task<Work> GetWorkAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Work>($"/Works/{id}");
        }

        public async Task UpdateWorkAsync(Work work)
        {
            await _httpClient.PutAsJsonAsync($"/works/{work.Id}", work);
        }
    }
}
