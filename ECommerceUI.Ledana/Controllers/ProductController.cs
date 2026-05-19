using EcommerceAPI.Ledana.DTOs;
using ECommerceUI.Ledana.Clients;
using ECommerceUI.Ledana.Services;
using ECommerceUI.Ledana.UI;

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

        internal static async Task DeleteProduct()
        {
            var products = await productApiClient.GetProducts();
            if (products is null || products.Count == 0)
            {
                Console.WriteLine("Couldn't get products");
                return;
            }
            TableVisualisation.ShowProducts(products);
            int id = Helper.GetIntInput("Please put the id of the product you want to delete");
            if (Helper.IsProductIdCorrect(id, products))
                Console.WriteLine(await productApiClient.DeleteProduct(id));
            else
                Console.WriteLine("Id is incorrect");
        }

        internal static async Task UpdateProduct()
        {
            var products = await productApiClient.GetProducts();
            if (products is null || products.Count == 0)
            {
                Console.WriteLine("Couldn't get products");
                return;
            }
            TableVisualisation.ShowProducts(products);
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
