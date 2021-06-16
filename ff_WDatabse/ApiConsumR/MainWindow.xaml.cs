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
        private string token;
        string userId;
        public MainWindow()
        {
            InitializeComponent();
            Login();
        }
        public MainWindow(string uid, string token)
        {
            this.token = token;
            InitializeComponent();
            this.userId = uid;
            Login();
        }

        public async Task Login()
        {
            PasswordWindow pw = new PasswordWindow();
            if (pw.ShowDialog() == true)
            {
                RestService restservice = new RestService("https://witcherendpoint.azurewebsites.net/", "/Auth");
                TokenViewModel tvm = await restservice.Put<TokenViewModel, LoginViewModel>(new LoginViewModel()
                {
                    Username = pw.UserName,
                    Password = pw.Password
                });
                token = tvm.Token;
                GetWitcherNames();
            }
            else
            {
                this.Close();
            }
        }

        public async Task GetWitcherNames()
        {
            RestService restservice = new RestService("https://witcherendpoint.azurewebsites.net/", "/Witcher", token);
            IEnumerable<Witcher> witchernames =
                await restservice.Get<Witcher>();
            
            cbox.ItemsSource = witchernames;
            cbox.SelectedIndex = 0;
        }
        public async Task GetWitcherNames(string userid)
        {
            cbox.ItemsSource = null;
            RestService restservice = new RestService("https://witcherendpoint.azurewebsites.net/", "/Witcher", token);
            Witcher witchernames = await restservice.Get<Witcher, string>(userid);

            cbox.ItemsSource = witchernames.Monsters_slain;

            restservice = new RestService("https://witcherendpoint.azurewebsites.net/", "/User", token);
            witchernames = await restservice.Get<Witcher, string>(userid);

            cbox.ItemsSource = witchernames.Monsters_slain;
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

            RestService restservice = new RestService("https://witcherendpoint.azurewebsites.net/", "/Monster", token);
            restservice.Post<Monster>(newmonster);
            GetWitcherNames();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditWitcher ew = new EditWitcher(token, cbox.SelectedItem as Witcher);
            ew.Show();
            this.Close();
        }

        private void List_monsters_Click(object sender, RoutedEventArgs e)
        {
            MonsterWindow mw = new MonsterWindow(cbox.SelectedItem as Witcher, token);
            mw.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://witcherendpoint.azurewebsites.net/", "/Witcher", token);
            restservice.Delete<string>((cbox.SelectedItem as Witcher).WitcherID);
            GetWitcherNames(userId);
        }

        private void AddWitcher_Click(object sender, RoutedEventArgs e)
        {
            AddWitcherWindow aw = new AddWitcherWindow(userId, token);
            aw.Show();
            this.Close();
        }
    }
}
