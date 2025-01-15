using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using dal;

namespace bal
{

    public class ShoppingBal
    {
        private ShoppingDal dal1 = new ShoppingDal();

        public void RegisteringUser(string name, string username, string password,int mobilenumber)
        {
            
            dal1.RegisterUserToDb(name, username,password, mobilenumber);
        }
        public bool LoginUser(string username, string password)
        {
            return dal1.ValidateLogin(username, password);
        }

        public void AddToCart(int productId, int quantity)
        {
           
            dal1.AddToCart( productId, quantity);

            Console.WriteLine("Product added to the cart successfully!");
        }

        public void PlaceOrder(string orderId, string username, string totalCost, string orderDate)
        {
            // Convert totalCost to decimal or float if needed
            decimal cost = Convert.ToDecimal(totalCost);

            // Call the DAL method to insert the order into the database
            dal.InsertOrder(orderId, username, cost, orderDate);
        }


        // Get all users
        //public DataTable GetUsers()
        //{
        //    return dal1.GetUsers();
        //}

        //// Get all products
        //public DataTable GetProducts()
        //{
        //    return dal1.GetProducts();
        //}

        //// Update user data
        //public void UpdateUsers(DataTable userTable)
        //{
        //    dal1.UpdateUsers(userTable);
        //}

        //// Get cart items
        //public DataTable GetCart()
        //{
        //    return dal1.GetCart();
        //}

        //// Update cart
        //public void UpdateCart(DataTable cartTable)
        //{
        //    dal1.UpdateCart(cartTable);
        //}

        //// Get all orders
        //public DataTable GetOrders()
        //{
        //    return dal1.GetOrders();
        //}
    }
}
