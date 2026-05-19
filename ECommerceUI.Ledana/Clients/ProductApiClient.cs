using EcommerceAPI.Ledana.DTOs;
using EcommerceAPI.Ledana.Models;
using System.Net.Http.Json;

namespace ECommerceUI.Ledana.Clients
{
    internal class ProductApiClient
    {
        private static readonly HttpClient _client = new();
        internal async Task<string> CreateProduct(ProductDto product)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("https://localhost:7077/api/product", product);
                if (response.IsSuccessStatusCode)
                    return "Product added successfully!";

                return "Creating product didn't work";
            }
            catch (Exception e)
            {
                return "Creating product didn't work " + e.Message;
            }
        }

        internal async Task<string> DeleteProduct(int id)
        {
            try
            {
                var response = await _client.DeleteFromJsonAsync<ApiResponseDto<string>>($"https://localhost:7077/api/product/{id}");

                if (response is null) return "Deleting product didn't work";

                if (!response.RequestFailed)
                    return "Product deleted successfully!";

                return response.ErrorMessage;
            }
            catch (Exception e)
            {
                return "Deleting product didn't work " + e.Message;
            }
        }

        internal async Task<List<Product>?> GetProducts()
        {
            try
            {
                var response = await _client.GetFromJsonAsync<ApiResponseDto<List<Product>>>($"https://localhost:7077/api/product");
                if (response is null) return null;

                return response.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Getting products went wrong " + e.Message);
                return null;
            }
        }

        internal async Task<string> UpdateProduct(ProductDto product)
        {
            try
            {
                var response = await _client.PutAsJsonAsync<ProductDto>($"https://localhost:7077/api/product", product);

                if (response.IsSuccessStatusCode)
                    return "Product updated successfully!";

                return "Updating product didn't work";
            }
            catch (Exception e)
            {
                return "Updating product didn't work " + e.Message;
            }
        }
    }
}
