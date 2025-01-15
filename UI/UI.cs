//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using bal;


//namespace UI
//{
    

//    public class UIShopping
//    {
//        static void Main(string[] args)
//        {
//            ShoppingBal bal = new ShoppingBal();

//            Console.WriteLine("Welcome to Shopping");
//            Console.WriteLine("1. Register");
//            Console.WriteLine("2. Login");
//            Console.WriteLine("3. View Cart");
//            Console.WriteLine("4. Add to Cart");
//            Console.WriteLine("5. Place Order");
//            Console.WriteLine("Enter your choice (1-5):");

//            try
//            {
//                int select = Convert.ToInt32(Console.ReadLine());

//                if (select == 1)
//                {
//                    // Register User
//                    Console.WriteLine("Enter new user details:");
//                    DataTable dt = bal.GetUsers();
//                    DataRow dr = dt.NewRow();

//                    Console.Write("Enter Name: ");
//                    dr["Name"] = Console.ReadLine();

//                    Console.Write("Enter Username: ");
//                    dr["Username"] = Console.ReadLine();

//                    Console.Write("Enter Password: ");
//                    dr["Password"] = Console.ReadLine();

//                    Console.Write("Enter Mobile Number: ");
//                    dr["MobileNumber"] = Console.ReadLine();

//                    dt.Rows.Add(dr);
//                    bal.UpdateUsers(dt);
//                    Console.WriteLine("User registered successfully!");
//                }
//                else if (select == 2)
//                {
//                    // Placeholder for Login User
//                    Console.WriteLine("Login functionality is not yet implemented.");
//                }
//                else if (select == 3)
//                {
//                    // View Cart
//                    Console.WriteLine("Your cart items:");
//                    DataTable cart = bal.GetCart();
//                    foreach (DataRow row in cart.Rows)
//                    {
//                        Console.WriteLine($"Cart ID: {row["cartid"]}, Product Name: {row["productname"]}, Quantity: {row["Quantity"]}, Price: {row["price"]}");
//                    }
//                }
//                else if (select == 4)
//                {
//                    // Add to Cart
//                    Console.WriteLine("Enter product details to add to cart:");
//                    DataTable cart = bal.GetCart();
//                    DataRow dr = cart.NewRow();

//                    Console.Write("Enter Cart ID: ");
//                    dr["cartid"] = Console.ReadLine();

//                    Console.Write("Enter Product ID: ");
//                    dr["productid"] = Console.ReadLine();

//                    Console.Write("Enter Product Name: ");
//                    dr["productname"] = Console.ReadLine();

//                    Console.Write("Enter Quantity: ");
//                    dr["Quantity"] = Console.ReadLine();

//                    Console.Write("Enter Price: ");
//                    dr["price"] = Console.ReadLine();

//                    cart.Rows.Add(dr);
//                    bal.UpdateCart(cart);
//                    Console.WriteLine("Product added to cart successfully!");
//                }
//                else if (select == 5)
//                {
//                    // Place Order
//                    Console.WriteLine("Enter order details:");
//                    DataTable orders = bal.GetOrders();
//                    DataRow dr = orders.NewRow();

//                    Console.Write("Enter Order ID: ");
//                    dr["orderid"] = Console.ReadLine();

//                    Console.Write("Enter Username: ");
//                    dr["username"] = Console.ReadLine();

//                    Console.Write("Enter Total Cost: ");
//                    dr["TotalCost"] = Console.ReadLine();

//                    Console.Write("Enter Order Date: ");
//                    dr["Orderdate"] = Console.ReadLine();

//                    orders.Rows.Add(dr);
//                    orders.AcceptChanges(); // Ensure changes are committed
//                    Console.WriteLine("Order placed successfully!");
//                }
//                else
//                {
//                    Console.WriteLine("Invalid selection. Please enter a number between 1 and 5.");
//                }
//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("Invalid input. Please enter a valid number.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred: {ex.Message}");
//            }

//            Console.WriteLine("Thank you for using the shopping system. Press any key to exit.");
//            Console.ReadKey();
//        }
//    }

//}