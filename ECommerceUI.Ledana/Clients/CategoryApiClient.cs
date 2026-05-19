using EcommerceAPI.Ledana.DTOs;
using EcommerceAPI.Ledana.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ECommerceUI.Ledana.Clients
{
    internal class CategoryApiClient
    {
        internal async Task<List<Category>?> GetCategories()
        {
            try
            {
                using HttpClient client = new();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetFromJsonAsync<ApiResponseDto<List<Category>>>("https://localhost:7077/api/category");

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
