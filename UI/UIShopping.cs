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
            //ShoppingBal obj2 = new ShoppingBal();
            //Console.WriteLine("Welcome to Shopping");
            //Console.WriteLine("1.Register");
            //Console.WriteLine("2.login");
            //Console.WriteLine("3.ViewCart");
            //Console.WriteLine("4.AddtoCart");
            //Console.WriteLine("5.Placeorder");
            //int select =Convert.
            //    ToInt32(Console.ReadLine());
            //if(select < 1 && select > 5)
            //{
            //    Console.WriteLine("Please enter numbers between 1 and 5");
            //}
            //switch(select)
            //{
            //    case 1:
            //        Console.WriteLine("Enter name");
            //        string name = Console.ReadLine();
            //        Console.WriteLine("Enter username");
            //        string username = Console.ReadLine();
            //        Console.WriteLine("Enter password");
            //        string password = Console.ReadLine();
            //        Console.WriteLine("Enter mobilenumber");
            //        int mobilenumber = Convert.ToInt32(Console.ReadLine());
                    
                    

                
            //       string result = obj2.registering( name, username,password,mobilenumber);
            //        Console.WriteLine(result);
                                
            //        break;


            ShoppingBal bal = new ShoppingBal();
            DataTable dt = bal.getusers();
            DataTable pt = bal.getproducts();
       //     DataTable login = bal.login12();
            DataTable addtocart = bal.addingcart();
            DataTable placing = bal.placingorder1();

            Console.Read();
            DataRow dr = dt.NewRow();
            Console.WriteLine("Enter new user details:");
            Console.Write("Enter Name: ");
            dr["Name"] = Console.ReadLine();
            Console.Write("Enter Username: ");
            dr["Username"] = Console.ReadLine();
            Console.Write("Enter Password: ");
            dr["Password"] = Console.ReadLine();
            dr["MobileNumber"] = Console.ReadLine();
            dt.Rows.Add(dr);
            bal.changeduser(dt);



            DataRow dr1 = addtocart.NewRow();
            Console.WriteLine("Enter product u want to enter:");
            Console.WriteLine("ENTER cartid");
            dr1["cartid"] = Console.ReadLine();
            Console.WriteLine("Enter productid");
            dr1["productid"] = Console.ReadLine();
            Console.WriteLine("Enter Product name");
            dr1["productname"] = Console.ReadLine();
            Console.WriteLine("Quantity to be enterd");
            dr1["Qunatity"] = Console.ReadLine();
            Console.WriteLine("Price");
            dr1["price"] = Console.ReadLine();
            addtocart.Rows.Add(dr1);
            bal.afteraddingtocart(addtocart);

            DataRow dr2 = placing.NewRow();
            Console.WriteLine("orders palced");
            Console.WriteLine("ENTER OrderID ");
            dr1["orderid"] = Console.ReadLine();
            Console.WriteLine("Enter Username ");
            dr1["username"] = Console.ReadLine();
            Console.WriteLine("Enter TotalCost");
            dr1["TotalCost"] = Console.ReadLine();
            Console.WriteLine("Order date");
            dr1["Orderdate"] = Console.ReadLine();
            //Console.WriteLine("Price");
            //dr1["price"] = Console.ReadLine();
            placing.Rows.Add(dr2);

            

        }
    }
    }

