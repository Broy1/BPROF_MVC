using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MonsterWindow.xaml
    /// </summary>
    public partial class MonsterWindow : Window
    {
        Witcher w;
        string token;
        public MonsterWindow()
        {
            InitializeComponent();
        }
        public MonsterWindow(Witcher w, string token)
        {
            this.token = token;
            this.w = w;
            InitializeComponent();
            GetMonsterNames();
        }

        public async Task GetMonsterNames()
        {
            monsterGrid.ItemsSource = null;
            RestService restservice = new RestService("https://witcherendpoint.azurewebsites.net", "/Monster");
            List<Monster> playlistnames = await restservice.Get<Monster>();

            List<Monster> a = new List<Monster>();
            foreach (var item in playlistnames)
            {
                if (item.WitcherID == w.WitcherID)
                {
                    a.Add(item);
                }
            }

            monsterGrid.ItemsSource = a;
            monsterGrid.SelectedIndex = 0;
        }

        private void AddMonster_Click(object sender, RoutedEventArgs e)
        {
            AddNewMonster mw = new AddNewMonster(w, token);
            mw.Show();
            this.Close();
        }

        private void DeleteMonster_Click(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://witcherendpoint.azurewebsites.net", "/Monster");
            restservice.Delete<string>((monsterGrid.SelectedItem as Monster).MonsterID);
            GetMonsterNames();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(w.WitcherID, token);
            mw.Show();
            this.Close();
        }
    }
}
