using EcommerceAPI.Ledana.DTOs;
using EcommerceAPI.Ledana.Models;
using System.Net.Http.Json;

namespace ECommerceUI.Ledana.Clients
{
    internal class SaleApiClient
    {
        HttpClient httpClient = new();

        internal async Task<string> CreateSale(SaleDto saleDto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("https://localhost:7077/api/sale", saleDto);

                var content =  await response.Content.ReadFromJsonAsync<ApiResponseDto<Sale>>();
                if (content is null) return "Couldn't add the sale";

                return content.ErrorMessage;
            }
            catch (Exception e)
            {
                return "Creating sale went wrong!" + e.Message;
            }
        }

        internal async Task<SaleProductViewDto?> GetSaleById(int categoryId)
        {
            try
            {
                var response =  await httpClient.GetFromJsonAsync<ApiResponseDto<SaleProductViewDto>>($"https://localhost:7077/api/sale/{categoryId}");
                if (response is null) return null;

                return response.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Getting sales went wrong " + e.Message);
                return null;
            }
        }

        internal async Task<ApiResponseDto<List<SaleProductViewDto>>?> GetSalesSortedByDate(int pageNumber, int pageSize)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<ApiResponseDto<List<SaleProductViewDto>>>($"https://localhost:7077/api/sale?page_size={pageSize}&page_number={pageNumber}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Getting sales went wrong " + e.Message);
                return null;
            }
        }
    }
}
