using ECommerceUI.Ledana.Clients;

namespace ECommerceUI.Ledana.Services
{
    internal class CategoryUIService
    {
        static CategoryApiClient categoryApiClient = new();
        internal static async Task<int> GetCategoryId(string message)
        {
            int id = Helper.GetIntInput(message);
            var categories = await categoryApiClient.GetCategories();
            if (categories is null) return 0;

            if (categories.Any(c => c.Id == id))
                return id;

            return 0;
        }
    }
}
