using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;

namespace bal
{
    public class bal
    {
        GetUsers obj = new GetUsers();
        register obj2 = new register();
        DataTable dt = new DataTable();
        public DataTable getusers()
        {
            dt = obj.getusers();
            return dt;
        }
        public DataTable registering()
        {
            dt = obj.registeringnew();
            return dt;
        }
        product obj1 = new product();
        DataTable d11 = new DataTable();
        public DataTable product()
        {
            
            d11 = obj1.productinfo();
            return dt;
        }
    }
}
