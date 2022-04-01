using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Shop.Pages
{
    /// <summary>
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public string neededSymbols = "!@#$%^";
        public RegPage()
        {
            InitializeComponent();
        }

        public void SetPassword()
        {
            
        }

        private void TBLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            var nyms = new Regex(@"[0-9]");
            var symbols = new Regex(@"[!@#$%^]");
            var letters = new Regex(@"[A-Я]");
            if ( TBLogin.Text == "")
                PasswordError.Text = "Придумайте пароль";
            else if (nyms.IsMatch(TBLogin.Text) && symbols.IsMatch(TBLogin.Text) && letters.IsMatch(TBLogin.Text) && TBLogin.Text.Length >=6)
            {
                PasswordError.Text = "Пароль соответствует требованиям";
            }
            else
            {
                PasswordError.Text = "Пароль не соответствует требованиям";
            }
        }
    }
}
