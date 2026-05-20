using EcommerceAPI.Ledana.DTOs;
using ECommerceUI.Ledana.Clients;
using ECommerceUI.Ledana.UI;
using Spectre.Console;

namespace ECommerceUI.Ledana.Services
{
    internal class SaleUIService
    {
        static ProductApiClient productApiClient = new();
        internal static async Task<List<SaleProductDto>?> GetProducts()
        {
            bool isRunning = AnsiConsole.Confirm("Do you want to add a product");
            List<SaleProductDto> saleProducts = [];
            int quantity = 0;
            decimal discount = 0m;
            decimal price = 0m;
            var products = await productApiClient.GetProducts();
            if(products is null)
            {
                Console.WriteLine("Validating products went wrong please close the app and try again");
                return null;
            }

            while (isRunning)
            {
                TableVisualisation.ShowAllProducts(products);
                int productId = Helper.GetIntInput("Please put the product id");
                var product = await productApiClient.GetProductById(productId);
                if(product is null)
                {
                    Console.WriteLine("Your chosen product is not found");
                    return null;
                }

                if (Helper.IsProductIdCorrect(productId, products))
                {
                    quantity = Helper.GetIntInput("Please put the quantity");
                    discount = Helper.GetDecimalInput("Please put the discount");
                    price = product.Price;
                }
                else
                {
                    Console.WriteLine("Input was not valid");
                    return null;
                }

                    SaleProductDto productDto = new()
                {
                    ProductsId = productId,
                    Quantity = quantity,
                    Discount = discount,
                    UnitPriceAtSale = price
                };
                saleProducts.Add(productDto);
                isRunning = AnsiConsole.Confirm("Do you want to add a product");
            }

            return saleProducts;
        }
    }
}
