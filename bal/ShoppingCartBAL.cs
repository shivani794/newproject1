//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using dal;
//using dal.DAL;


//namespace bal
//{
//    public class ShoppingCartBAL
//    {
//        public bool IsLoginSuccessful(string username, string password)
//        {
//            ShoppingCartDal dal1 = new ShoppingCartDal();
//            DataSet loginResult = dal1.CheckLogin(username, password);

//            // If login result contains rows, login is successful
//            return loginResult.Tables["LoginResult"].Rows.Count > 0;
//        }

//        // Method for user registration
//        public bool RegisterUser(string name, string username, string password, int mobilenumber)
//        {
//            ShoppingCartDal dal1 = new ShoppingCartDal();
//            DataSet registrationResult = dal1.RegisterUser(name, username, password, mobilenumber);

//            return registrationResult.Tables["RegistrationResult"].Rows.Count > 0;
//        }

//        // Method to get all products
//        public DataSet GetProducts()
//        {
//            ShoppingCartDal dal1 = new ShoppingCartDal();
//            return dal1.GetAllProducts();
//        }

//        // Method to view the cart
//        public DataSet ViewCart(int userId)
//        {
//            ShoppingCartDal dal1 = new ShoppingCartDal();
//            return dal1.GetCart(userId);
//        }

//        // Method to add product to the cart
//        public void AddToCart(int userId, int productId)
//        {
//            ShoppingCartDal dal1 = new ShoppingCartDal();
//            dal1.AddToCart(userId, productId);
//        }

//        // Method to place an order
//        public void PlaceOrder(int userId)
//        {
//            ShoppingCartDal dal1 = new ShoppingCartDal();
//            dal1.PlaceOrder(userId);
//        }
//    }
//}
    
