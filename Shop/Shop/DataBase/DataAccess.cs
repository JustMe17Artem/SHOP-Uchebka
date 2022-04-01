using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Shop.my_ado;

namespace Shop.DataBase
{
    public static class DataAccess
    {
        public static ObservableCollection<Product> GetProducts()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>(DB_Connection.connection.Product);
            return products;
        }

    }
}
