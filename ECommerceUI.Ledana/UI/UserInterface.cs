using ECommerceUI.Ledana.Controllers;
using Spectre.Console;
using static ECommerceUI.Ledana.Enums;

namespace ECommerceUI.Ledana.UI
{
    internal class UserInterface
    {
        internal async Task MainMenu()
        {
            Console.WriteLine("Welcome to our app!");

            bool isRunning = true;
            while(isRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MainMenuOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        MainMenuOptions.ProductsMenu,
                        MainMenuOptions.CategoriesMenu,
                        MainMenuOptions.SalesMenu,
                        MainMenuOptions.Quit
                        ));

                switch(option)
                {
                    case MainMenuOptions.ProductsMenu:
                        await ProductsMenu();
                        break;
                    case MainMenuOptions.CategoriesMenu:
                        await CategoriesMenu();
                        break;
                    case MainMenuOptions.SalesMenu:
                        await SalesMenu();
                        break;
                    case MainMenuOptions.Quit:
                        Console.WriteLine("Good bye");
                        isRunning = false;
                        break;
                }               
            }
        }

        private async Task SalesMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<SalesMenuOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        SalesMenuOptions.ViewSalesMenu,
                        SalesMenuOptions.AddNewSale,
                        SalesMenuOptions.GoBack
                    ));

                switch (option)
                {
                    case SalesMenuOptions.ViewSalesMenu:
                        await ViewSalesMenu();
                        break;
                    case SalesMenuOptions.AddNewSale:
                        await SaleController.AddNewSale();
                        break;;
                    case SalesMenuOptions.GoBack:
                        isRunning = false;
                        break;
                }
            }
        }

        private async Task ViewSalesMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<ViewSalesMenuOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        ViewSalesMenuOptions.ViewSalesOrderedByDate,
                        ViewSalesMenuOptions.ViewSalesOrderedByTotalPrice,
                        ViewSalesMenuOptions.ViewSaleWithId,
                        ViewSalesMenuOptions.ViewSalesWithProductName,
                        ViewSalesMenuOptions.ViewSalesWithCategoryName,
                        ViewSalesMenuOptions.ViewSalesWithDate,
                        ViewSalesMenuOptions.ViewSalesWithTotalPrice,
                        ViewSalesMenuOptions.ViewSalesCheaperThenPrice,
                        ViewSalesMenuOptions.ViewSalesNewerThenDate,
                        ViewSalesMenuOptions.GoBack
                    ));

                switch (option)
                {
                    case ViewSalesMenuOptions.ViewSalesOrderedByDate:
                        await SaleController.ViewSalesOrderedByDate();
                        break;
                    case ViewSalesMenuOptions.ViewSalesOrderedByTotalPrice:
                        await SaleController.ViewSalesOrderedByTotalPrice();
                        break;
                    case ViewSalesMenuOptions.ViewSaleWithId:
                        await SaleController.ViewSaleWithId();
                        break;
                    case ViewSalesMenuOptions.ViewSalesWithProductName:
                        await SaleController.ViewSalesWithProductName();
                        break;
                    case ViewSalesMenuOptions.ViewSalesWithCategoryName:
                        await SaleController.ViewSalesWithCategoryName();
                        break;
                    case ViewSalesMenuOptions.ViewSalesWithDate:
                        await SaleController.ViewSalesWithDate();
                        break;
                    case ViewSalesMenuOptions.ViewSalesWithTotalPrice:
                        await SaleController.ViewSalesWithTotalPrice();
                        break;
                    case ViewSalesMenuOptions.ViewSalesCheaperThenPrice:
                        await SaleController.ViewSalesCheaperThenPrice();
                        break;
                    case ViewSalesMenuOptions.ViewSalesNewerThenDate:
                        SaleController.ViewSalesNewerThenDate();
                        break;
                    case ViewSalesMenuOptions.GoBack:
                        isRunning = false;
                        break;
                }
            }
        }

        private async Task CategoriesMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<CategoriesMenuOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        CategoriesMenuOptions.ViewCategories,
                        CategoriesMenuOptions.ViewCategoryById,
                        CategoriesMenuOptions.AddNewCategory,
                        CategoriesMenuOptions.UpdateCategory,
                        CategoriesMenuOptions.DeleteCategory,
                        CategoriesMenuOptions.GoBack
                    ));

                switch (option)
                {
                    case CategoriesMenuOptions.ViewCategories:
                        await CategoryController.ViewCategories();
                        break;
                    case CategoriesMenuOptions.ViewCategoryById:
                        await CategoryController.ViewCategoryById();
                        break;
                    case CategoriesMenuOptions.AddNewCategory:
                        await CategoryController.AddNewCategory();
                        break;
                    case CategoriesMenuOptions.UpdateCategory:
                        await CategoryController.UpdateCategory();
                        break;
                    case CategoriesMenuOptions.DeleteCategory:
                        await CategoryController.DeleteCategory();
                        break;
                    case CategoriesMenuOptions.GoBack:
                        isRunning = false;
                        break;
                }
            }
        }

        private async Task ProductsMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<ProductsMenuOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        ProductsMenuOptions.ViewProductsMenu,
                        ProductsMenuOptions.AddNewProduct,
                        ProductsMenuOptions.UpdateProduct,
                        ProductsMenuOptions.DeleteProduct,
                        ProductsMenuOptions.GoBack
                    ));

                switch (option)
                {
                    case ProductsMenuOptions.ViewProductsMenu:
                        await ViewProductsMenu();
                        break;
                    case ProductsMenuOptions.AddNewProduct:
                        await ProductController.AddNewProduct();
                        break;
                    case ProductsMenuOptions.UpdateProduct:
                        await ProductController.UpdateProduct();
                        break;
                    case ProductsMenuOptions.DeleteProduct:
                        await ProductController.DeleteProduct();
                        break;
                    case ProductsMenuOptions.GoBack:
                        isRunning = false;
                        break;
                }
            }
        }

        private async Task ViewProductsMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<ViewProductsMenuOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        ViewProductsMenuOptions.ViewAllProductsOrderedById,
                        ViewProductsMenuOptions.ViewAllProductsOrderedByName,
                        ViewProductsMenuOptions.ViewAllProductsOrderedByPrice,
                        ViewProductsMenuOptions.ViewAllProductsOrderedByStock,
                        ViewProductsMenuOptions.ViewProductById,
                        ViewProductsMenuOptions.ViewProductsByName,
                        ViewProductsMenuOptions.ViewProductsByPrice,
                        ViewProductsMenuOptions.ViewProductsByStock,
                        ViewProductsMenuOptions.ViewProductsCheaperThenPrice,
                        ViewProductsMenuOptions.ViewProductsLowerThenStock,
                        ViewProductsMenuOptions.GoBack
                    ));

                switch (option)
                {
                    case ViewProductsMenuOptions.ViewAllProductsOrderedById:
                        await ProductController.ViewAllProductsOrderedById();
                        break;
                    case ViewProductsMenuOptions.ViewAllProductsOrderedByName:
                        await ProductController.ViewAllProductsOrderedByName();
                        break;
                    case ViewProductsMenuOptions.ViewAllProductsOrderedByPrice:
                        await ProductController.ViewAllProductsOrderedByPrice();
                        break;
                    case ViewProductsMenuOptions.ViewAllProductsOrderedByStock:
                        await ProductController.ViewAllProductsOrderedByStock();
                        break;
                    case ViewProductsMenuOptions.ViewProductById:
                        await ProductController.ViewProductById();
                        break;
                    case ViewProductsMenuOptions.ViewProductsByName:
                        await ProductController.ViewProductsByName();
                        break;
                    case ViewProductsMenuOptions.ViewProductsByPrice:
                        await ProductController.ViewProductsByPrice();
                        break;
                    case ViewProductsMenuOptions.ViewProductsByStock:
                        await ProductController.ViewProductsByStock();
                        break;
                    case ViewProductsMenuOptions.ViewProductsCheaperThenPrice:
                        await ProductController.ViewProductsCheaperThenPrice();
                        break;
                    case ViewProductsMenuOptions.ViewProductsLowerThenStock:
                        await ProductController.ViewProductsLowerThenStock();
                        break;
                    case ViewProductsMenuOptions.GoBack:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}
