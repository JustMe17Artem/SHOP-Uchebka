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
        public static bool IsCorrectUser(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DB_Connection.connection.User);
            var currentUser = users.Where(u => u.Login == login && u.Password == password).ToList();
            return currentUser.Count == 1;
        }
        public static bool IsIncorrectUser(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DB_Connection.connection.User);
            var currentUser = users.Where(u => u.Login == login && u.Password == password).ToList();
            return currentUser.Count == 0;
        }
        public static bool StartBan(BanSession session)
        {
            try
            {
                DB_Connection.connection.BanSession.Add(session);
                DB_Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static User GetUser(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DB_Connection.connection.User);
            var currentUser = users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            return currentUser;
        }
        public static User GetUser(int idUser)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(DB_Connection.connection.User);
            var currentUser = users.Where(u => u.Id == idUser).FirstOrDefault();
            return currentUser;
        }
    }
}
