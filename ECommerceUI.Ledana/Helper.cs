using EcommerceAPI.Ledana.Models;

namespace ECommerceUI.Ledana
{
    internal class Helper
    {
        internal static int GetIntInput(string message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            int id;
            while (!int.TryParse(input, out id) || input is null)
            {
                Console.WriteLine("Invalid input, try again! Or type '0' to go back");
                input = Console.ReadLine();
            }
            return id;
        }

        internal static bool IsProductIdCorrect(int id, List<Product> products)
        {
            return products.Any(p => p.Id == id);
        }
    }
}
