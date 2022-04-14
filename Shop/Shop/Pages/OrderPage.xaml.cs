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
using System.Collections.ObjectModel;
using Shop.DataBase;

namespace Shop.Pages
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public static User currentUser;
        public List<Product> Products { get; set; }
        public Order Order { get; set; }
        public List<StatusOrder> StatusOrders { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public OrderPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            DPDate.SelectedDate = DateTime.Now.Date;
            Products = DataAccess.GetProducts().ToList();
            StatusOrders = DataAccess.GetStatusOrder().ToList();
            Order = new Order
            {
                StatusOrder = StatusOrders[0]
            };
            ProductOrders = Order.ProductOrder.ToList();
            CBStatus.SelectedItem = Order.StatusOrder;
            BtnDecline.Visibility = Visibility.Hidden;
            BtnAccept.Visibility = Visibility.Hidden;
            DGProducts.SelectionMode = DataGridSelectionMode.Extended;
            DataContext = this;
        }
        public OrderPage(Order order)
        {
            InitializeComponent();
            Order = order;
            CBProduct.Visibility = Visibility.Hidden;
            DPDate.SelectedDate = Order.Date;
            ProductOrders = Order.ProductOrder.ToList();
            StatusOrders = DataAccess.GetStatusOrder().ToList();
            BtnDecline.Visibility = Visibility.Visible;
            BtnAccept.Visibility = Visibility.Visible;
            BtnAdd.Visibility = Visibility.Hidden;
            BtnRemove.Visibility = Visibility.Hidden;
            CBStatus.SelectedItem = Order.StatusOrder;
            DGProducts.ItemsSource = ProductOrders;
            Order.StatusOrderId = 3;
            DB_Connection.connection.SaveChanges();
            BtnCreate.Visibility = Visibility.Hidden;
            DataContext = this;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var productOrder in ProductOrders)
            {
                Order.ProductOrder.Add(productOrder);
            }
            if (DGProducts.Items.Count != 0)
            {
                DataAccess.AddOrder(Order, currentUser);
                MessageBox.Show("Заказ оформлен");
                NavigationService.Navigate(new ProductsListPage(currentUser));
            }
            else
                MessageBox.Show("Выберите продукты для заказа!");
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var product = CBProduct.SelectedItem as Product;
            ProductOrders.Add(new ProductOrder
            {
                Product = product,
                ProductId = product.Id,
            });

            DGProducts.Items.Refresh();
            Products.Remove(product);
        }

        private void DGProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = (sender as Product);
        }
        private void SetEnable()
        {
            if (Order.StatusOrder.Name != "Новый")
            {
                grid.IsEnabled = false;
            }
        }

        private void DGProducts_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (this.DGProducts.SelectedItem != null)
            {
                (sender as DataGrid).RowEditEnding -= DGProducts_RowEditEnding;
                (sender as DataGrid).CommitEdit();
                (sender as DataGrid).Items.Refresh();

                double sum = 0;
                foreach (Product product in DGProducts.ItemsSource)
                {
                    sum += Convert.ToInt32(product.Price);
                }
                TBSum.Text = sum.ToString();
                (sender as DataGrid).RowEditEnding += DGProducts_RowEditEnding;
            }
            return;
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            var index = DGProducts.SelectedIndex;
            ProductOrders.RemoveAt(index);
            DGProducts.Items.Refresh();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            Order.StatusOrderId = 2;
            DB_Connection.connection.SaveChanges();
            MessageBox.Show("Заказ принят");
            NavigationService.GoBack();
        }

        private void BtnDecline_Click(object sender, RoutedEventArgs e)
        {
            Order.StatusOrderId = 5;
            DB_Connection.connection.SaveChanges();
            MessageBox.Show("Заказ отклонён");
            NavigationService.GoBack();
        }

        private void Btnback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
