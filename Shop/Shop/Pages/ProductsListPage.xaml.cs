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
using Shop.DataBase;
using System.Collections.ObjectModel;
using Shop.my_ado;

namespace Shop.Pages
{
    /// <summary>
    /// Interaction logic for ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Page
    {
        private static ObservableCollection<Product> products { get; set; }
        public static User currentUser;
        public ProductsListPage(User user)
        {
            InitializeComponent();
            products = DataAccess.GetProducts();
            LVProducts.ItemsSource = products;
            DataContext = this;
            currentUser = user;

        }

        private void TBSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
            if (TBSearch.Text != "")
            {
                LVProducts.ItemsSource = DataAccess.GetProductsByNameOrDescription(TBSearch.Text);
            }
            else
            {
                DataContext = this;
            }
        }

        private void LVProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = (sender as ListView).SelectedItem as Product;
            NavigationService.Navigate(new ProductEditPage(selectedProduct));
        }
    }
}
