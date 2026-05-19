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
    }
}
