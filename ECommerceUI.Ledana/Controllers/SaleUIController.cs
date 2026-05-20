using EcommerceAPI.Ledana.DTOs;
using ECommerceUI.Ledana.Clients;
using ECommerceUI.Ledana.Services;

namespace ECommerceUI.Ledana.Controllers
{
    //TODO add validatin in api if stock is zero and remove items from stock when added in a sale
    //TODO show the price of  aproduct the user has choosen to add
    //TODO show final price and products the user has chosen to put in the sale
    internal class SaleUIController
    {
        static SaleApiClient saleApiClient = new();
        internal static async Task AddNewSale()
        {
            DateTime date = DateTime.UtcNow;

            var products = await SaleUIService.GetProducts();
            if (products is null)
                return;

            SaleDto saleDto = new()
            {
                Date = date,
                SaleProducts = products
            };
            Console.WriteLine(await saleApiClient.CreateSale(saleDto));
        }

        internal static async Task ViewSalesCheaperThenPrice()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewSalesNewerThenDate()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewSalesOrderedByDate()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewSalesOrderedByTotalPrice()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewSalesWithCategoryName()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewSalesWithDate()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewSalesWithProductName()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewSalesWithTotalPrice()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewSaleWithId()
        {
            throw new NotImplementedException();
        }
    }
}
