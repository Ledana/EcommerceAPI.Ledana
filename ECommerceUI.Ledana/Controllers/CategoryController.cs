using ECommerceUI.Ledana.Clients;
using ECommerceUI.Ledana.UI;

namespace ECommerceUI.Ledana.Controllers
{
    internal class CategoryController
    {
        static CategoryApiClient categoryApiClient = new();
        internal static async Task AddNewCategory()
        {
            throw new NotImplementedException();
        }

        internal static async Task DeleteCategory()
        {
            throw new NotImplementedException();
        }

        internal static async Task UpdateCategory()
        {
            throw new NotImplementedException();
        }

        internal static async Task ViewCategories()
        {
            var categories = await categoryApiClient.GetCategories();
            if (categories is null || categories.Count == 0) Console.WriteLine("No categories found!");
            else
                TableVisualisation.ShowCategories(categories);
        }

        internal static async Task ViewCategoryById()
        {
            throw new NotImplementedException();
        }
    }
}
