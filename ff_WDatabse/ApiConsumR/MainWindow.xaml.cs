using Models;
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

namespace ApiConsumR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetWitcherNames();
        }

        public async Task GetWitcherNames()
        {
            RestService restservice = new RestService("https://localhost:44360", "/Witcher");
            IEnumerable<Witcher> witchernames =
                await restservice.Get<Witcher>();
            
            cbox.ItemsSource = witchernames;
            cbox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Monster newmonster = new Monster()
            {
                Name = tb_title.Text,
                MonsterID = tb_monster.Text,
                Bounty = int.Parse(tb_bounty.Text),
                WitcherID = (cbox.SelectedItem as Witcher).WitcherID
            };

            RestService restservice = new RestService("https://localhost:44360", "/Monster");
            restservice.Post<Monster>(newmonster);
            GetWitcherNames();
        }
    }
}
