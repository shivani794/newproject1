using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bal;

namespace UI
{
    public class UIShopping
    {
        static void Main(string[] args)
        {
            ShoppingBal bal = new ShoppingBal();
            UIShopping ui = new UIShopping();
            var (registrationtable, Producttable, orderstable) = bal.BALGetAllData();

            Console.WriteLine("Welcome to Shopping");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("Enter your choice (1-2):");

            try
            {
                int select = Convert.ToInt32(Console.ReadLine());
                if (select == 1)
                {
                    ui.loginUser(registrationtable);
                }
                else if (select == 2)
                {
                    ui.registration(registrationtable);
                }
                else
                {
                    Console.WriteLine("Choose either 1 or 2.");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.WriteLine("***********************************************");
            ui.DisplayProducts();
            Console.WriteLine("***********************************************");
            ui.ShoppingCart();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        public void loginUser(DataTable registrationtable)
        {
            Console.WriteLine("username");
            string username = Console.ReadLine();
            Console.WriteLine("password");
            string password = Console.ReadLine();
            foreach (DataRow row in registrationtable.Rows)
            {
                if (row["Username"].ToString() == username && row["Password"].ToString() == password)
                {
                    Console.Clear();
                    Console.WriteLine($"Login successful! Welcome, {username}.\n");
                }
            }
        }

        public void registration(DataTable usertable)
        {
            Console.WriteLine("enter name");
            string name = Console.ReadLine();
            Console.WriteLine("enter usename");
            string username = Console.ReadLine();
            Console.WriteLine("enter password");
            string password = Console.ReadLine();
            Console.WriteLine("enter mobile number");
            int mobilenumber = Convert.ToInt32(Console.ReadLine());

            DataRow newrow = usertable.NewRow();
            newrow["name"] = name;
            newrow["username"] = username;
            newrow["password"] = password;
            newrow["mobilenumber"] = mobilenumber;
            usertable.Rows.Add(newrow);
            Console.WriteLine("Registration successful");
            ShoppingBal bal = new ShoppingBal();
            //ass we are inserting new row here we are writing as bal.upadateusers here as that method is being upadted
            bal.updateUsers(usertable);
        }
        public void DisplayProducts()
        {

            ShoppingBal bal = new ShoppingBal();
            var allData = bal.BALGetAllData();


            DataTable productTable = allData.Producttable;


            Console.WriteLine("Available Products:");
            foreach (DataRow row in productTable.Rows)
            {
                Console.WriteLine($"Product ID: {row["ProductID"]}, Product Name: {row["ProductName"]}, Price: {row["Price"]}, Quantity: {row["Quantity"]}");
            }
        }
        //****************************************************//
        //display cart in list
        //orders placed
        // another method for calling while statements
        //*****************************************//




        public void ShoppingCart()
        {

            List<Product1> prol2 = new List<Product1>();
            List<cart> cartItems = new List<cart>();
            bool continueShopping = true;
            while (continueShopping)
            {
                DisplayMenu();
                string choice = GetUserChoice();

                switch (choice)
                {
                    case "1":
                        AddToCart();
                        break;

                    case "2":
                        ViewCart();
                        break;

                    case "3":
                        continueShopping = false;
                        Console.WriteLine("Thank you for shopping!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("\nChoose an option: ");
            Console.WriteLine("1. Add to Cart");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. Exit");
        }

        public string GetUserChoice()
        {
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        public void AddToCart()
        {
            DisplayAvailableProducts();
            int productId = GetProductId();
            if (productId == -1) return;

            int quantity = GetQuantity();
            if (quantity == -1) return;

            UpdateCart(productId, quantity);
        }

        public void DisplayAvailableProducts()
        {
            List<Product1> prol2 = new List<Product1>();
            List<cart> cartItems = new List<cart>();
            Console.WriteLine("\nAvailable Products:");
            foreach (var product in prol2)
            {
                Console.WriteLine($"{product.ProductId}. {product.ProductName} - {product.Quantity} in stock - ${product.Price}");
            }
        }

        public int GetProductId()
        {

            List<Product1> prol2 = new List<Product1>();
            List<cart> cartItems = new List<cart>();
            Console.Write("Enter Product ID to add to cart: ");
            if (int.TryParse(Console.ReadLine(), out int productId) && prol2.Exists(p => p.ProductId == productId))
            {
                return productId;
            }
            else
            {
                Console.WriteLine("Invalid Product ID.");
                return -1;
            }
        }

        public int GetQuantity()
        {
            Console.Write("Enter Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
            {
                return quantity;
            }
            else
            {
                Console.WriteLine("Invalid quantity.");
                return -1;
            }
        }

        public void UpdateCart(int productId, int quantity)
        {

            List<Product1> prol2 = new List<Product1>();
            List<cart> cartItems = new List<cart>();
            var existingItem = cartItems.Find(item => item.ProductID == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var product = prol2.Find(p => p.ProductId == productId);
                cartItems.Add(new cart
                {
                    ProductID = productId,
                    ProductName = product.ProductName,
                    Quantity = quantity,
                    FinalPrice = product.Price * quantity
                });
            }
            Console.WriteLine("Item added to cart successfully!");
        }

        public void ViewCart()
        {
            List<Product1> prol2 = new List<Product1>();
            List<cart> cartItems = new List<cart>();
            if (cartItems.Count > 0)
            {
                Console.WriteLine("\nCart Items:");
                foreach (var item in cartItems)
                {
                    var product = prol2.Find(p => p.ProductId == item.ProductID);
                    Console.WriteLine($"{product.ProductName} (ID: {product.ProductId}) - Quantity: {item.Quantity} - Price: ${product.Price} each - Final Price: ${item.FinalPrice}");
                }
            }
            else
            {
                Console.WriteLine("Your cart is empty.");
            }
        }
    }



}


