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

        //public string registering(string name, string username, string password, int mobilenumber)
        //{
        //    //ShoppingDal obj = new ShoppingDal();
        //    return obj.Register(name, username, password, mobilenumber);
        //  //  return register1.Tables["Registration"].Rows.Count > 0;
        //}

        //crete objexts and call here







        ShoppingDal dal = new ShoppingDal();
        DataTable usertable = new DataTable();
        DataTable ptable = new DataTable();
        DataTable logintable = new DataTable();
        DataTable addcart = new DataTable();
        DataTable placingorder = new DataTable();
        public DataTable getusers()
        {
            usertable = dal.getusers();
            return usertable;
        }
        public DataTable getproducts()
        {
            ptable = dal.getproducts();
            return ptable;
        }
        public void changeduser(DataTable dt)
        {
            dal.updateusers(dt);
        }
        //public DataTable login12()
        //{
        //    logintable = dal.loginuser();
        //    return logintable;
        //}
        public DataTable addingcart()
        {

            addcart = dal.addtocart1();
            return addcart;
        }
        public void afteraddingtocart(DataTable addcart)
        {
            dal.afteraddingtocart1(addcart);
        }
        public DataTable placingorder1()
        {
            placingorder = dal.placeorder1();
            return placingorder;
        }


    }
}
       






