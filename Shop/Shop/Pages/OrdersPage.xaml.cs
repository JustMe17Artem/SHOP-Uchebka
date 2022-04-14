using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Shop.my_ado;
using Shop.DataBase;


namespace Shop.Pages
{
    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private User currentUser;
        public OrdersPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            DGOrders.ItemsSource = DataAccess.GetOrders();
            DataContext = this;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage(currentUser));
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            var order = DGOrders.SelectedItem as Order;
            if (order != null)
            {
                order.WorkerId = currentUser.Worker.Where(w => w.UserId == currentUser.Id).FirstOrDefault().Id;
                NavigationService.Navigate(new OrderPage(order));
            }
            else
                MessageBox.Show("Заказ не выбран");
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
