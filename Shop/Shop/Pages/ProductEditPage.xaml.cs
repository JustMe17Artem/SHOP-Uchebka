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
    /// Interaction logic for ProductEditPage.xaml
    /// </summary>
    public partial class ProductEditPage : Page
    {
        public ProductEditPage(Product product)
        {
            InitializeComponent();
            TBId.Text = product.Id.ToString();
            TBName.Text = product.Name;
            TBDescription.Text = product.Description;
            if (product.UnitId == 1)
            {
                RBKg.IsChecked = true;
            }
            else if (product.UnitId == 2)
            {
                RBSt.IsChecked = true;  
            }
            else if (product.UnitId == 3)
            {
                RBLit.IsChecked = true;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsListPage());
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditPhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
