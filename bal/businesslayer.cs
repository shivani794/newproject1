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
        public (DataTable registrationtable, DataTable Producttable, DataTable orderstable) BALGetAllData()
        {
            return dal1.GetAllData();
        }
        public void updateUsers(DataTable userstable)
        {
            dal1.UpdateUsers(userstable);
        }
        public void updateorders(DataTable orderstable)
        {
            dal1.updateorders(orderstable);
        }


        //public void updateProducts(DataTable prod)
        //{
        //    dal1.UpdateProducts(prod);
        //}
        //public void updateOrders(DataTable orde)
        //{
        //    dal1.UpdateOrders(orde);
        //}
    }
}
    

