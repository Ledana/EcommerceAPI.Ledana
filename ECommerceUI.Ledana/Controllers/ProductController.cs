using EcommerceAPI.Ledana.DTOs;
using EcommerceAPI.Ledana.Models;
using ECommerceUI.Ledana.Clients;
using ECommerceUI.Ledana.Services;
using ECommerceUI.Ledana.UI;
using Spectre.Console;

namespace ECommerceUI.Ledana.Controllers
{
    internal class ProductController
    {
        static ProductApiClient productApiClient = new();
        static CategoryApiClient categoryApiClient = new();
        internal static async Task AddNewProduct()
        {
            var categories = await categoryApiClient.GetCategories();
            if (categories is null || categories.Count == 0)
            {
                Console.WriteLine("No categories found!");
                return;
            }
            else
                TableVisualisation.ShowCategories(categories);

            int id = await CategoryUIService.GetCategoryId("Please choose the id of the category for new product");
            if (id == 0) return;

            string name = ProductUIService.GetProductName("Please put the name of the new product");
            if (name.ToLower() == "x") return;

            int stock = ProductUIService.GetStock("Please put the stock of new product");
            if (stock == 0) return;

            decimal price = ProductUIService.GetProductPrice();
            if (price == 0m) return;

            ProductDto product = new()
            {
                Name = name,
                Stock = stock,
                Price = price,
                CategoryId = id
            };
            Console.WriteLine(await productApiClient.CreateProduct(product));
        }

        private static void ViewAllProducts(ref ApiResponseDto<List<Product>>? response, ref int pageNumber, ref int pageSize, ref bool keepRunning)
        {
            if (response is null) { Console.WriteLine("No products found!"); return; }

            Console.Clear();

            TableVisualisation.ShowProducts(response.Data);
            Console.WriteLine($"Total count: {response.TotalCount}");
            Console.WriteLine($"Current page: {response.CurrentPage}");
            Console.WriteLine($"Page size: {response.PageSize}");
            Console.WriteLine($"Has next: {response.HasNext}");
            Console.WriteLine($"Has previous: {response.HasPrevious}");

            var choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .AddChoices("Next", "Previous", "First", "Last", "Go Back"));

            switch (choice)
            {
                case "Next":
                    if (!response.HasNext) return;
                    pageNumber++;
                    break;
                case "Previous":
                    if (!response.HasPrevious) return;
                    if (pageNumber > 1) pageNumber--;
                    break;
                case "First":
                    pageNumber = 1;
                    break;
                case "Last":
                    pageNumber = response.TotalCount % pageSize == 0 ? response.TotalCount / pageSize : response.TotalCount / pageSize + 1;
                    break;
                case "Go Back":
                    keepRunning = false;
                    break;
            }

        }

        internal static async Task DeleteProduct()
        {
            int pageNumber = 1;
            int pageSize = 5;
            bool keepRunning = true;

            while (keepRunning)
            {
                var response = await productApiClient.GetProducts(pageNumber, pageSize);
                
                ViewAllProducts(ref response, ref pageNumber, ref pageSize, ref keepRunning);
            }

            int id = Helper.GetIntInput("Please put the id of the product you want to delete");
            var products = await productApiClient.GetProducts();
            if (products is null || products.Count == 0)
            {
                Console.WriteLine("No products found"); return;
            }
            if (Helper.IsProductIdCorrect(id, products))
                Console.WriteLine(await productApiClient.DeleteProduct(id));
            else
                Console.WriteLine("Id is incorrect");
        }

        internal static async Task UpdateProduct()
        {
            int pageNumber = 1;
            int pageSize = 5;
            bool keepRunning = true;

            while (keepRunning)
            {
                var response = await productApiClient.GetProducts(pageNumber, pageSize);

                ViewAllProducts(ref response, ref pageNumber, ref pageSize, ref keepRunning);
            }
            var products = await productApiClient.GetProducts();
            if (products is null || products.Count == 0)
            {
                Console.WriteLine("No products found");
                return;
            }
            
            int id = Helper.GetIntInput("Please put the id of the product you want to update");
            if (Helper.IsProductIdCorrect(id, products))
            {
                int categoryId = await CategoryUIService.GetCategoryId("Please choose the new id of the category for the product");
                if (id == 0) return;

                string name = ProductUIService.GetProductName("Please put the new name of the product");
                if (name.ToLower() == "x") return;

                int stock = ProductUIService.GetStock("Please put the new stock of the product");
                if (stock == 0) return;

                decimal price = ProductUIService.GetProductPrice();
                if (price == 0m) return;

                ProductDto product = new()
                {
                    Name = name,
                    Stock = stock,
                    Price = price,
                    CategoryId = id
                };

                Console.WriteLine(await productApiClient.UpdateProduct(product));
            }
            else
                Console.WriteLine("Id is incorrect");
        }

        internal static async Task ViewAllProductsOrderedById()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewAllProductsOrderedByName()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewAllProductsOrderedByPrice()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewAllProductsOrderedByStock()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewProductById()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewProductsByName()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewProductsByPrice()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewProductsByStock()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewProductsCheaperThenPrice()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewProductsLowerThenStock()
        {
            throw new NotImplementedException();
        }
    }
}
