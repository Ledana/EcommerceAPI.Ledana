using EcommerceAPI.Ledana.DTOs;
using EcommerceAPI.Ledana.Models;
using System.Net.Http.Json;

namespace ECommerceUI.Ledana.Clients
{
    internal class CategoryApiClient
    {
        private static readonly HttpClient _client = new();
        internal async Task<List<Category>?> GetCategories()
        {
            try
            {
                var response = await _client.GetFromJsonAsync<ApiResponseDto<List<Category>>>("https://localhost:7077/api/category");
                if (response is null) return null;

                return response.Data;

            }
            catch (Exception e)
            {
                Console.WriteLine("Getting categories didn't work " + e.Message);
                return null;
            }
        }
    }
}
