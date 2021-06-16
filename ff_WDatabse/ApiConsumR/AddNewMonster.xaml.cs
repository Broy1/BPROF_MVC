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
    /// Interaction logic for AddNewMonster.xaml
    /// </summary>
    public partial class AddNewMonster : Window
    {
        string gameId;
        Witcher w;
        string token;
        public AddNewMonster()
        {
            InitializeComponent();
        }

        public AddNewMonster(Witcher w, string token)
        {
            this.token = token;
            this.gameId = w.WitcherID;
            this.w = w;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Monster m = new Monster() { Name=mName.Text, Bounty=int.Parse(mBounty.Text), Threat=int.Parse(mThreat.Text), WitcherID=w.WitcherID };

            RestService restservice = new RestService("https://androidfelevesendpoints.azurewebsites.net/", "/Achi");
            restservice.Post<Monster>(m);

            MonsterWindow mw = new MonsterWindow(w,token);
            mw.Show();
            mw.Close();
            this.Close();

            mw = new MonsterWindow(w, token);
            mw.Show();
        }
    }
}
