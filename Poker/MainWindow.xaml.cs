using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Poker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        Button btn_join = new Button();
        Button btn_host = new Button();
        Button btn_offline = new Button();
        Button btn_exit = new Button();
        public MenuWindow()
        {
            this.DataContext = this;
            InitializeComponent();

            btn_join.Content = "join game";
            btn_host.Content = "host game";
            btn_offline.Content = "play offline";
            btn_exit.Content = "exit";

            btn_join.Click += JoinGame;
            btn_host.Click += HostGame;
            btn_offline.Click += PlayOffline;
            btn_exit.Click += Exit;

            grd_main.ColumnDefinitions.Add(new ColumnDefinition());

            grd_main.RowDefinitions.Add(new RowDefinition());
            grd_main.RowDefinitions.Add(new RowDefinition());
            grd_main.RowDefinitions.Add(new RowDefinition());
            grd_main.RowDefinitions.Add(new RowDefinition());

            grd_main.Children.Add(btn_offline);
            grd_main.Children.Add(btn_exit);
            grd_main.Children.Add(btn_host);
            grd_main.Children.Add(btn_join);
            
            Grid.SetRow(btn_join, 0);
            Grid.SetRow(btn_offline, 1);
            Grid.SetRow(btn_host, 2);
            Grid.SetRow(btn_exit, 3);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PlayOffline(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HostGame(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void JoinGame(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}