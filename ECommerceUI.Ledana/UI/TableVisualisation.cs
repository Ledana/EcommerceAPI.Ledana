using EcommerceAPI.Ledana.Models;
using Spectre.Console;

namespace ECommerceUI.Ledana.UI
{
    internal class TableVisualisation
    {
        internal static void ShowCategories(List<Category> categories)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");

            foreach(var item in categories)
            {
                table.AddRow(item.Id.ToString(), item.Name);
            }
            AnsiConsole.Write(table);
        }

        internal static void ShowProducts(List<Product> products)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Category Name");
            table.AddColumn("Stock");
            table.AddColumn("Price");

            foreach (var item in products)
            {
                table.AddRow(item.Id.ToString(), item.Name, item.Category.Name, item.Stock.ToString(), item.Price.ToString());
            }
            AnsiConsole.Write(table);
        }
    }
}
