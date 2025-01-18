using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using bal;

namespace UI
{
    public class UIShopping
    {
        static string userName;
        static void Main(string[] args)
        {
            
            ShoppingBal bal = new ShoppingBal();
            UIShopping ui = new UIShopping();
            var (registrationtable, Producttable, orderstable) = bal.BALGetAllData();

            List<cart> cart = new List<cart>();
            bool isAuthenticated = false;
            bool exitProgram = false;

            while (!isAuthenticated && !exitProgram)
            {
                Console.WriteLine("Welcome to Shopping");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("Enter your choice (1-2):");

                try
                {
                    int select = Convert.ToInt32(Console.ReadLine());

                    if (select == 1)
                    {
                        isAuthenticated = ui.loginUser(registrationtable);
                        if (!isAuthenticated)
                        {
                            Console.WriteLine("Login failed. Please try again.\n");
                        }
                    }
                    else if (select == 2)
                    {
                        ui.registration(registrationtable);
                        Console.WriteLine("Registration successful. Please login to continue.\n");
                    }
                    else
                    {
                        Console.WriteLine("Choose either 1 or 2.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine("Do you want to exit? (Y/N):");
                string exitChoice = Console.ReadLine()?.ToUpper();
                if (exitChoice == "Y")
                {
                    exitProgram = true;
                    Console.WriteLine("Thank you for visiting. Goodbye!");
                }
            }


            if (isAuthenticated)
            {
                Console.WriteLine("***********************************************");
                ui.DisplayProducts();
                ui.shop(Producttable, cart);
                //bal.updateProducts(Producttable);
                //ui.ViewCart(cart, Producttable);
                Console.WriteLine("Would you like to place your order? (Y/N):");
                string placeOrderChoice = Console.ReadLine()?.ToUpper();

                if (placeOrderChoice == "Y")
                {
                    // Call PlaceOrder if the user confirms
                    ui.PlaceOrder(cart, orderstable, Producttable, bal);
                }
                else
                {
                    Console.WriteLine("You have chosen not to place an order.");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


        public bool loginUser(DataTable registrationtable)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            foreach (DataRow row in registrationtable.Rows)
            {
                if (row["Username"].ToString() == username && row["Password"].ToString() == password)
                {
                    Console.Clear();
                    Console.WriteLine($"Login successful! Welcome, {username}.\n");
                    userName = username;
                    return true;
                }
            }
            Console.WriteLine("Invalid username or password. Please try again.\n");
            return false;
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
            userName = username;
            ShoppingBal bal = new ShoppingBal();
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

        public void shop(DataTable Producttable, List<cart> cart)
        {
            bool continueShopping = true;

            while (continueShopping)
            {
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Add to Cart");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        bool addMoreItems = true;
                        while (addMoreItems)
                        {
                            Console.Write("Enter Product ID to add to cart: ");
                            int productId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Quantity: ");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            AddToCart(cart, productId, quantity, Producttable);
                            Console.WriteLine("Item added to cart successfully!");

                            Console.Write("Do you want to add more items? (yes/no): ");
                            string response = Console.ReadLine();
                            addMoreItems = response?.ToLower() == "yes";
                        }
                        break;

                    case "2":
                        ViewCart(cart, Producttable);
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

        static void AddToCart(List<cart> cart, int productId, int quantity, DataTable Producttable)
        {
            while (true)
            {
                DataRow prow = Producttable.Select($"productid={productId}").FirstOrDefault();

                if (prow == null)
                {
                    Console.WriteLine($"Product with ID {productId} does not exist. Please enter a valid product ID.");
                    Console.Write("Enter product ID: ");
                    productId = Convert.ToInt32(Console.ReadLine());
                    continue;
                }

                int availableQuantity = Convert.ToInt32(prow["Quantity"]);
                int price = Convert.ToInt32(prow["Price"]);
                string productName = prow["ProductName"].ToString();

                if (availableQuantity < 0)
                {
                    Console.WriteLine($"Cannot add product '{productName}' (ID: {productId}) to the cart as it has a negative stock.");
                    Console.Write("Enter a valid product ID: ");
                    productId = Convert.ToInt32(Console.ReadLine());
                    continue;
                }

                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be greater than zero. Cannot add to cart.");
                    Console.Write("Enter quantity: ");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    continue;
                }

                if (quantity > availableQuantity)
                {
                    Console.WriteLine($"Requested quantity exceeds available stock. Available quantity: {availableQuantity}");
                    Console.WriteLine("Please re-enter the quantity or choose another product.");
                    Console.Write("Enter productid: ");
                    productId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Quantity: ");
                    quantity = Convert.ToInt32(Console.ReadLine());
                    continue;
                }

                var existingItem = cart.Find(item => item.ProductID == productId);

                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                    existingItem.FinalPrice = existingItem.Quantity * price;
                }
                else
                {
                    cart.Add(new cart
                    {
                        ProductID = productId,
                        ProductName = productName,
                        Username = userName,
                        Quantity = quantity,
                        FinalPrice = price * quantity
                    });
                }

                prow["Quantity"] = availableQuantity - quantity;

                Console.WriteLine($"Product added to cart successfully. Product ID: {productId}, Quantity: {quantity}, Total Price: {price * quantity}");
                break;
            }
        }

        public void ViewCart(List<cart> cart, DataTable Producttable)
        {
            if (cart.Count > 0)
            {
                Console.WriteLine("\nCart Items:");
                foreach (var item in cart)
                {
                    Console.WriteLine($"Product Name: {item.ProductName}, Product ID: {item.ProductID}, Quantity: {item.Quantity}, Final Price: {item.FinalPrice}");
                }

                Console.WriteLine("\nUpdated Product Table:");
                Console.WriteLine("ProductID | ProductName        | Price      | AvailableQuantity");
                foreach (DataRow row in Producttable.Rows)
                {
                    Console.WriteLine($"{row["ProductID"],-10} | {row["ProductName"],-20} | {row["Price"],-10} | {row["Quantity"],-5}");
                }
            }
            else
            {
                Console.WriteLine("No items in the cart.");
            }
        }

        public void PlaceOrder(List<cart> cart, DataTable orderstable, DataTable Producttable, ShoppingBal bal)
        {
            if (cart.Count > 0)
            {
                
                decimal totalCost = 0;
                foreach (var item in cart)
                {
                    totalCost += item.FinalPrice;  
                }

               

              
                int orderId = orderstable.Rows.Count + 1;
                string username = cart[0].Username;

                
                DataRow newOrder = orderstable.NewRow();
                newOrder["Username"] = username;
                newOrder["OrderID"] = orderId;
                newOrder["TotalCost"] = totalCost; 
                newOrder["OrderDate"] = DateTime.Now;

                
                orderstable.Rows.Add(newOrder);
                bal.updateProducts(Producttable);
                bal.updateorders(orderstable);

              

                
                cart.Clear();

                Console.WriteLine("Order placed successfully!");
                Console.WriteLine($"Order ID: {orderId}, Total Cost: {totalCost:C}, Order Date: {DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Your cart is empty. Add items to the cart before placing an order.");
            }
        }

    }
}