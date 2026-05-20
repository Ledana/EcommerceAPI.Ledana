using EcommerceAPI.Ledana.DTOs;
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

                if (response.IsSuccessStatusCode)
                    return "Sale added successfully";

                return "Couldn't create sale";
            }
            catch (Exception e)
            {
                return "Creating sale went wrong!" + e.Message;
            }
        }
    }
}
