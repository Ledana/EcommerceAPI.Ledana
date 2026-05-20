using EcommerceAPI.Ledana.DTOs;
using EcommerceAPI.Ledana.Models;
using Spectre.Console;

namespace ECommerceUI.Ledana.UI
{
    internal class TableVisualisation
    {
        internal static void ShowAllProducts(List<Product> products)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Category name");
            table.AddColumn("Product name");
            table.AddColumn("Stock");
            table.AddColumn("Price");

            foreach (var item in products)
            {
                table.AddRow(item.Id.ToString(), item.Category.Name, item.Name, item.Stock.ToString(), item.Price.ToString());
            }
            AnsiConsole.Write(table);
        }

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

        internal static void ShowCategory(Category category)
        {
            var panel = new Panel($@"Category Id: {category.Id}
Category Name: {category.Name}
")
            {
                Header = new PanelHeader("Category's info"),
                Padding = new Padding(2, 2, 2, 2)
            };
            var table = new Table();
            table.AddColumn("Product name");
            table.AddColumn("Product stock");
            table.AddColumn("Product price");

            foreach (var item in category.Products)
            {
                table.AddRow(item.Name, item.Stock.ToString(), item.Price.ToString());
            }
            AnsiConsole.Write(panel);
            AnsiConsole.Write(table);
        }

        internal static void ShowProduct(Product product)
        {
            var panel = new Panel($@"Product Id: {product.Id}
Product Name: {product.Name}
Category Id: {product.CategoryId}
Category Name: {product.Category.Name}
Stock: {product.Stock}
Price: {product.Price}")
            {
                Header = new PanelHeader("Product's info"),
                Padding = new Padding(2, 2, 2, 2)
            };
            AnsiConsole.Write(panel);
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
