using Products.Business;
using Products.Data.Model;
using Products.Presentation.Constants;

namespace Products.Presentation
{
    public class Display
    {
        private readonly ProductsBusiness productsBusiness;

        public Display()
        {
            productsBusiness = new ProductsBusiness();
        }

        public void InterractWithUser()
        {
            ShowMenu();

            int input = GetCommand();

            bool continueProgram = ManageCommand(input);
            if (continueProgram)
            {
                InterractWithUser();
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 14));

            Console.Write(new string(' ', 5));
            Console.Write("Menu");
            Console.WriteLine(new string(' ', 5));

            Console.WriteLine(new string('-', 14));

            Console.WriteLine($"{CommandConstants.ListAllProducts}. List all entries");
            Console.WriteLine($"{CommandConstants.AddProduct}. Add product");
            Console.WriteLine($"{CommandConstants.UpdateProduct}. Update product by Id");
            Console.WriteLine($"{CommandConstants.FetchProductById}. Fetch product by Id");
            Console.WriteLine($"{CommandConstants.DeleteProduct}. Delete product by Id");
            Console.WriteLine($"{CommandConstants.Exit}. Exit");
        }

        private int GetCommand()
        {
            Console.WriteLine("Please enter the number of the wanted command...");

            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input! You could only enter a number!");

                return GetCommand();
            }
        }

        /// <summary>
        /// Manages the command that user chose
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>
        /// True if the program should continue, otherwise - false
        /// </returns>
        private bool ManageCommand(int userInput)
        {
            switch (userInput)
            {
                case CommandConstants.ListAllProducts:
                    HandleListAllProductsCommand();
                    break;

                case CommandConstants.AddProduct:
                    HandleAddProductCommand();
                    break;

                case CommandConstants.FetchProductById:
                    HandleFetchProductByIdCommand();
                    break;

                case CommandConstants.UpdateProduct:
                    HandleUpdateProductCommand();
                    break;

                case CommandConstants.DeleteProduct:
                    HandleDeleteProductCommand();
                    break;

                case CommandConstants.Exit:
                    return false;

                default:
                    HandleIncorrectCommand();
                    break;
            }

            return true;
        }

        private void HandleDeleteProductCommand()
        {
            var product = GetProduct();
            if (product is null)
            {
                Console.WriteLine($"There is no such product!");
                return;
            }

            productsBusiness.Delete(product);
        }

        private void HandleUpdateProductCommand()
        {
            // ToDo: add validations to the input data

            var product = GetProduct();
            if (product is null)
            {
                Console.WriteLine($"There is no such product!");
                return;
            }

            (product.Name, product.Price, product.Stock) = GetProductData();

            productsBusiness.Update(product);

        }

        private void HandleFetchProductByIdCommand()
        {
            // ToDo: add validations to the input data

            var product = GetProduct();
            if (product is null)
            {
                Console.WriteLine($"There is no such product!");
                return;
            }

            Console.WriteLine(product);
        }

        private void HandleIncorrectCommand()
        {
            Console.WriteLine("Incorrect command!");
        }

        private void HandleListAllProductsCommand()
        {
            var products = productsBusiness.GetAll();

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        private void HandleAddProductCommand()
        {
            // ToDo: add validations to the input data

            var (name, price, stock) = GetProductData();

            var product = new Product(name, price, stock);

            productsBusiness.Add(product);

            Console.WriteLine("Successfully created:");
            Console.WriteLine(product);
        }

        private (string name, double price, int stock) GetProductData()
        {

            Console.WriteLine("Please enter name of the product..");

            string name = Console.ReadLine();

            Console.WriteLine("Please enter the price of the product..");

            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the stock quantity of the product..");

            int stock = int.Parse(Console.ReadLine());

            return (name, price, stock);
        }

        private Product GetProduct()
        {
            Console.WriteLine("Please enter Id of the product..");

            int id = int.Parse(Console.ReadLine());

            return productsBusiness.Get(id);
        }
    }
}
