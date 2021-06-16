using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApiConsumR
{
    /// <summary>
    /// Interaction logic for AddWitcherWindow.xaml
    /// </summary>
    public partial class AddWitcherWindow : Window
    {
        string token;
        string userId;
        public AddWitcherWindow()
        {
            InitializeComponent();
        }

        public AddWitcherWindow(string userid, string token)
        {
            this.token = token;
            this.userId = userid;
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Witcher w = new Witcher() { Name = nameInp.Text.ToString(), Age = int.Parse(ageInp.Text), School = schoolInp.Text, AvaragePay = int.Parse(wageInp.Text),  WitcherID = userId.ToString()};

            RestService restservice = new RestService("https://witcherendpoint.azurewebsites.net", "/Witcher");
            restservice.Post<Witcher>(w);

            MainWindow mw = new MainWindow(userId, token);
            mw.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(userId, token);
            mw.Show();
            this.Close();
        }
    }
}
