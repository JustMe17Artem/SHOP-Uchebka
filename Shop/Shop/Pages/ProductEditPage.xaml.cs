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
using System.IO;
using Microsoft.Win32;

namespace Shop.Pages
{
    /// <summary>
    /// Interaction logic for ProductEditPage.xaml
    /// </summary>
    public partial class ProductEditPage : Page
    {
        Product changedProduct;
        public ProductEditPage(Product product)
        {
            InitializeComponent();
            changedProduct = product;
            TBId.Text = product.Id.ToString();
            TBName.Text = product.Name;
            TBDescription.Text = product.Description;
            TBPrice.Text = product.Price.ToString();
            UnitCb.ItemsSource = DataAccess.GetUnits();
            CountryCb.ItemsSource = DataAccess.GetCountries();
            CountryCb.DisplayMemberPath = "Name";
            DataContext = changedProduct;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsListPage(ProductsListPage.currentUser));
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        { 
            DataAccess.DeleteProduct(changedProduct);
            MessageBox.Show($"Продукт {changedProduct.Name} удалён");
            NavigationService.Navigate(new ProductsListPage(ProductsListPage.currentUser));
        }

        private void BtnSaveProduct_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                changedProduct.AddDate = DateTime.Now;
                changedProduct.Name = TBName.Text;
                changedProduct.Description = TBDescription.Text;
                var unit = UnitCb.SelectedItem as Unit;
                changedProduct.UnitId = unit.Id;
                changedProduct.Price = Int32.Parse(TBPrice.Text); 
                DataAccess.Changeroduct();
                NavigationService.Navigate(new ProductsListPage(ProductsListPage.currentUser));
            }
            catch (FormatException)
            {
                MessageBox.Show("Цена в цифрах!");
            }
            
        }

        private void BtnEditPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                changedProduct.Photo = File.ReadAllBytes(openFile.FileName);
                ProductImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

    }
}
