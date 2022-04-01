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
    /// Interaction logic for AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        public int IncorrectTry = 0;
        public AuthoPage()
        {
            InitializeComponent();
            ObservableCollection<BanSession> sessions = new ObservableCollection<BanSession>(DB_Connection.connection.BanSession);
            var lastBanSession = sessions.Where(u => true).Last();
            if(DateTime.Now < lastBanSession.DateEnd)
            {
                BlockComponents();
            }
            TBLogin.Text = Properties.Settings.Default.Login;
            
        }
        private void BlockComponents()
        {
            BtnAuthorize.IsEnabled = false;
        }

        private void BtnRegistrate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            string login = TBLogin.Text;
            string password = TBPassword.Text;
            if(DataAccess.IsCorrectUser(login, password) &&  RememberUser.IsChecked.GetValueOrDefault())
            {
                MessageBox.Show("Добро пожаловать");
                Properties.Settings.Default.Login = TBLogin.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Нет такого пользователя");
                IncorrectTry++;
                if(IncorrectTry == 3)
                {
                    BtnAuthorize.IsEnabled = false;
                    BanSession session = new BanSession();
                    session.DateStart = DateTime.Now;
                    session.DateEnd = DateTime.Now.AddMinutes(1);
                    DataAccess.StartBan(session);
                    MessageBox.Show("Блокировка на 1 минуту");
                }
            }
        }
    }
}
