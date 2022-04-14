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
            DGProducts.SelectionMode = DataGridSelectionMode.Extended;
            DataContext = this;
        }
        public OrderPage(Order order)
        {
            InitializeComponent();
            Order = order;
            Products = DataAccess.GetProducts().ToList();
            DPDate.SelectedDate = DateTime.Now;
            StatusOrders = DataAccess.GetStatusOrder().ToList();
            CBStatus.SelectedItem = Order.StatusOrder;
            DGProducts.SelectionMode = DataGridSelectionMode.Extended;
            DataContext = this;
            SetEnable();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var productOrder in ProductOrders)
            {
                Order.ProductOrder.Add(productOrder);
            }
            DataAccess.AddOrder(Order, currentUser);
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
    }
}
