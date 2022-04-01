﻿using System;
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

namespace Shop.Pages
{
    /// <summary>
    /// Interaction logic for AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        public AuthoPage()
        {
            InitializeComponent();
        }

        private void BtnRegistrate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAuthorize_Click(object sender, RoutedEventArgs e)
        {
            string login = TBLogin.Text;
            string password = TBPassword.Text;
            if(DataAccess.IsCorrectUser(login, password))
            {
                MessageBox.Show("Добро пожаловать");
            }
            else
            {
                MessageBox.Show("Нет такогопользователя");
            }
        }
    }
}
