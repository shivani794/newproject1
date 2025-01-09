//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using bal;
//using dal;
//using dal.DAL;

//namespace bal
//{
//    public class businesslayer
//    {
        //    {
        //        GetUsers obj = new GetUsers();
        //        register obj2 = new register();
        //        DataTable dt = new DataTable();
        //        public DataTable getusers()
        //        {
        //            dt = obj.getusers();
        //            return dt;
        //        }
        //        public DataTable registering()
        //        {
        //            dt = obj.registeringnew();
        //            return dt;
        //        }
        //        product obj1 = new product();
        //        DataTable d11 = new DataTable();
        //        public DataTable product()
        //        {

        //            d11 = obj1.productinfo();
        //            return dt;
        //        }
        //    }
        //}
//        public DataSet RegisteringNew()
//        {
//            Register dal = new Register(); // Instantiate the DAL class inside the method
//            return dal.RegisteringNew();
//        }


//        public DataSet GetUsers()
//        {
//            Register dal = new Register(); // Instantiate the DAL class inside the method
//            return dal.GetUsers();
//        }


//        public DataSet ProductInfo()
//        {
//            Register dal = new Register(); // Instantiate the DAL class inside the method
//            return dal.ProductInfo();
//        }


//        public bool IsLoginSuccessful(string username, string password)
//        {
//            // Create instance of DAL and call CheckLogin method
//            login loginDal = new login();
//            DataSet loginResult = loginDal.CheckLogin(username, password);

//            // Check if the DataSet contains the "LoginResult" table and has rows
//            if (loginResult.Tables["LoginResult"].Rows.Count > 0)
//            {
//                // If there's at least one row, login is successful
//                return true;
//            }
//            else
//            {
//                // If no row, login failed
//                return false;
//            }
//        }
//    }
//}




