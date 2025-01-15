using System;
using System.Collections.Generic;
using System.Data;
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
                // No need to pass 'bal' as argument now
                ShoppingBal bal = new ShoppingBal(); // Create an instance of ShoppingBal here

                Console.WriteLine("Welcome to Shopping");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("Enter your choice (1-2):");

                try
                {
                    int select = Convert.ToInt32(Console.ReadLine());

                    if (select == 1)
                    {
                        RegisteringUser(); 
                    }
                    else if (select == 2)
                    {
                        LoginUser(); 
                    }
                    else
                    {
                        Console.WriteLine("Choose either 1 or 2.");
                        return; 
                    }

                    ShowProducts(); 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            // Register a new user
            static void RegisteringUser()
            {
                ShoppingBal bal = new ShoppingBal(); 
                Console.WriteLine("Enter new user details:");
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();
                Console.WriteLine("Mobile number:");
                int mobilenumber = Convert.ToInt32(Console.ReadLine());

                bal.RegisteringUser(name, username, password, mobilenumber); // Call method to register the user
                Console.WriteLine("Successful registration!");
            }

            // Login user
            static void LoginUser()
            {
                ShoppingBal bal = new ShoppingBal(); // Instantiate bal inside the method
                Console.WriteLine("Enter your login details:");
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();

                bool loginSuccess = bal.LoginUser(username, password); // Use bal to check login

                if (loginSuccess)
                {
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("Invalid credentials. Please try again.");
                    return; // Exits if login fails
                }
            }

        static void ShowProductsAndCart()
        {
           
            ShoppingBal bal = new ShoppingBal();

            
            DataTable products = bal.GetProducts();
            Console.WriteLine("\nAvailable Products:");
            foreach (DataRow row in products.Rows)
            {
                Console.WriteLine($"Product ID: {row["productid"]}, Name: {row["productname"]}, Quantity: {row["quantity"]}, Price: {row["price"]}");
            }

           
            Console.Write("\nDo you want to add a product to your cart? (yes/no): ");
            string addToCart = Console.ReadLine().ToLower();

            if (addToCart == "yes")
            {
                
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();

                Console.Write("Enter the product ID to add to the cart: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

               
                bal.AddToCart(productId, quantity);
            }

            // Optionally, call a method to view the cart or place an order
           // ViewCartAndPlaceOrder(bal);
        }
        static void PlaceOrder(ShoppingBal bal)
        {
            Console.WriteLine("\nEnter Order details:");

            Console.Write("Order ID: ");
            string orderId = Console.ReadLine();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Total Cost: ");
            string totalCost = Console.ReadLine();

            Console.Write("Enter Order Date: ");
            string orderDate = Console.ReadLine();

            // Place order and show success message
            bal.PlaceOrder(orderId, username, totalCost, orderDate);
            Console.WriteLine("Order placed successfully!");
        }
    }





























































































































































































//            ShoppingBal obj2 = new ShoppingBal();
//            Console.WriteLine("Welcome to Shopping");
//            Console.WriteLine("1.Register");
//            Console.WriteLine("2.login");
//            Console.WriteLine("3.ViewCart");
//            Console.WriteLine("4.AddtoCart");
//            Console.WriteLine("5.Placeorder");
//            int select = Convert.
//                ToInt32(Console.ReadLine());
//            //if(select < 1 && select > 5)
//            //{
//            //    Console.WriteLine("Please enter numbers between 1 and 5");
//            //}
//            //switch(select)
//            //{
//            //    case 1:
//            //        Console.WriteLine("Enter name");
//            //        string name = Console.ReadLine();
//            //        Console.WriteLine("Enter username");
//            //        string username = Console.ReadLine();
//            //        Console.WriteLine("Enter password");
//            //        string password = Console.ReadLine();
//            //        Console.WriteLine("Enter mobilenumber");
//            //        int mobilenumber = Convert.ToInt32(Console.ReadLine());




//            //       string result = obj2.registering( name, username,password,mobilenumber);
//            //        Console.WriteLine(result);

//            //        break;


//            ShoppingBal bal = new ShoppingBal();
//            DataTable dt = bal.getusers();
//            DataTable pt = bal.getproducts();

//            DataTable addtocart = bal.addingcart();
//            DataTable placing = bal.placingorder1();

//            Console.Read();
//            DataRow dr = dt.NewRow();
//            Console.WriteLine("Enter new user details:");
//            Console.Write("Enter Name: ");
//            dr["Name"] = Console.ReadLine();
//            Console.Write("Enter Username: ");
//            dr["Username"] = Console.ReadLine();
//            Console.Write("Enter Password: ");
//            dr["Password"] = Console.ReadLine();
//            dr["MobileNumber"] = Console.ReadLine();
//            dt.Rows.Add(dr);
//            bal.changeduser(dt);



//            DataRow dr1 = addtocart.NewRow();
//            Console.WriteLine("Enter product u want to enter:");
//            Console.WriteLine("ENTER cartid");
//            dr1["cartid"] = Console.ReadLine();
//            Console.WriteLine("Enter productid");
//            dr1["productid"] = Console.ReadLine();
//            Console.WriteLine("Enter Product name");
//            dr1["productname"] = Console.ReadLine();
//            Console.WriteLine("Quantity to be enterd");
//            dr1["Qunatity"] = Console.ReadLine();
//            Console.WriteLine("Price");
//            dr1["price"] = Console.ReadLine();
//            addtocart.Rows.Add(dr1);
//            bal.afteraddingtocart(addtocart);

//            //DataRow dr2 = placing.NewRow();
//            //Console.WriteLine("orders palced");
//            //Console.WriteLine("ENTER OrderID ");
//            //dr1["orderid"] = Console.ReadLine();
//            //Console.WriteLine("Enter Username ");
//            //dr1["username"] = Console.ReadLine();
//            //Console.WriteLine("Enter TotalCost");
//            //dr1["TotalCost"] = Console.ReadLine();
//            //Console.WriteLine("Order date");
//            //dr1["Orderdate"] = Console.ReadLine();
//            ////Console.WriteLine("Price");
//            ////dr1["price"] = Console.ReadLine();
//            //placing.Rows.Add(dr2);

//            DataRow dr2 = placing.NewRow();
//            Console.WriteLine("Orders placed");
//            Console.WriteLine("ENTER OrderID ");
//            dr2["orderid"] = Console.ReadLine(); // Use dr2
//            Console.WriteLine("Enter Username ");
//            dr2["username"] = Console.ReadLine(); // Use dr2
//            Console.WriteLine("Enter TotalCost");
//            dr2["TotalCost"] = Console.ReadLine(); // Use dr2
//            Console.WriteLine("Order date");
//            dr2["Orderdate"] = Console.ReadLine(); // Use dr2
//            placing.Rows.Add(dr2);
//            placing.AcceptChanges(); // Accept changes




//        }
//    }
//    }

