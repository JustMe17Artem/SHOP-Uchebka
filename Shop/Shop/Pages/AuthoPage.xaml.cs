using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Shop.DataBase;
using System.Collections.ObjectModel;
using Shop.my_ado;

namespace Shop.Pages
{
    /// <summary>
    /// Interaction logic for AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        private int IncorrectTry = 0;
        private ObservableCollection<BanSession> sessions = new ObservableCollection<BanSession>(DB_Connection.connection.BanSession);
        
        public AuthoPage()
        {
            InitializeComponent();
            TBLogin.Text = Properties.Settings.Default.Login;
        }

        private void BtnRegistrate_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new RegPage());
        }

        private void BtnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            var lastBanSession = sessions.Last();
            if (DataAccess.IsCorrectUser(TBLogin.Text, TBPassword.Password))
            {
                if (RememberUser.IsChecked.GetValueOrDefault())
                    Properties.Settings.Default.Login = TBLogin.Text;
                else
                    Properties.Settings.Default.Login = null;
                Properties.Settings.Default.Save();
                MessageBox.Show("WELCUM");
                NavigationService.Navigate(new ProductsListPage(DataAccess.GetUser(TBLogin.Text, TBPassword.Password)));
            }
            else if(DateTime.Now < lastBanSession.DateEnd)
            {
                MessageBox.Show($"Бан закончится {lastBanSession.DateEnd}");
            }
            else
            {
                MessageBox.Show("who da fuck r' u? identify yo'self, nigga");
                IncorrectTry++;
                if(IncorrectTry == 3)
                {
                    BanSession session = new BanSession();
                    session.DateStart = DateTime.Now;
                    session.DateEnd = DateTime.Now.AddMinutes(1);
                    DataAccess.StartBan(session);
                    MessageBox.Show("Бан на 1 минуту");
                }
            }
        }
    }
}
