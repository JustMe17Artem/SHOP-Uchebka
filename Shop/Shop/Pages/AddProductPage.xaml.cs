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
using Microsoft.Win32;
using System.IO;

namespace Shop.Pages
{
    /// <summary>
    /// Interaction logic for AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        Product productToAdd = new Product();
        public AddProductPage()
        {
            InitializeComponent();
            UnitCb.ItemsSource = DataAccess.GetUnits();
            DataContext = productToAdd;
        }

        private void btn_newphoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Description = TBDescription.Text;
            product.IsDeleted = false;
            var unit = UnitCb.SelectedItem as Unit;
            product.Name = TBName.Text;
            product.UnitId = unit.Id;
            product.Photo = productToAdd.Photo;
            product.AddDate = DateTime.Now.Date;
            DataAccess.AddProduct(product);
        }

        private void TBName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TBDescription_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                productToAdd.Photo = File.ReadAllBytes(openFile.FileName);
                ProductPhoto.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }
    }
}
