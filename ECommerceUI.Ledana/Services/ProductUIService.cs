namespace ECommerceUI.Ledana.Services
{
    internal class ProductUIService
    {

        internal static string GetProductName()
        {
            Console.WriteLine("Please put the name of the new product");
            string? name = Console.ReadLine();
            while(name is null)
            {
                Console.WriteLine("Please put a valid name or type 'x' to go back");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static decimal GetProductPrice()
        {
            Console.WriteLine("Please put the price of new product");
            string? input = Console.ReadLine();
            decimal price;

            while(!decimal.TryParse(input, out price) || input is null)
            {
                Console.WriteLine("Invalid input, try again or type 'x' to go back");
                input = Console.ReadLine();
            }
            return price;
        }

        internal static int GetStock()
        {
            return Helper.GetIntInput("Please put the stock of new product");
        }
    }
}
