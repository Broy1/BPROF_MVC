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
    /// Interaction logic for EditWitcher.xaml
    /// </summary>
    public partial class EditWitcher : Window
    {
        string token;
        Witcher witcher;
        public EditWitcher(string token, Witcher witcher)
        {
            InitializeComponent();
            this.token = token;
            this.witcher = witcher;
            witcherName.Text = witcher.Name;
            witcherWage.Text = witcher.AvaragePay.ToString();
        }

        private void Edit_ok_click(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://witcherendpoint.azurewebsites.net", "/Witcher", token);

            Witcher w = new Witcher() {Name = witcherName.Text, AvaragePay = int.Parse(witcherWage.Text)};
            w.Name = witcher.Name;
            w.AvaragePay = witcher.AvaragePay;

            restservice.Put<string, Witcher>(w.WitcherID, w);

            MainWindow mw = new MainWindow(witcher.WitcherID, token);
            mw.Show();
            this.Close();
        }
    }
}
