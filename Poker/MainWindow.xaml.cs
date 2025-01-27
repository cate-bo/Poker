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
        Button btn_new = new Button();
        Button btn_exit = new Button();
        public MenuWindow()
        {
            this.DataContext = this;
            InitializeComponent();

            btn_join.Content = "join game";
            btn_new.Content = "new game";
            btn_exit.Content = "exit";

            btn_join.Click += JoinGame;
            btn_new.Click += HostGame;
            btn_exit.Click += Exit;

            grd_main.ColumnDefinitions.Add(new ColumnDefinition());

            grd_main.RowDefinitions.Add(new RowDefinition());
            grd_main.RowDefinitions.Add(new RowDefinition());
            grd_main.RowDefinitions.Add(new RowDefinition());

            grd_main.Children.Add(btn_exit);
            grd_main.Children.Add(btn_new);
            grd_main.Children.Add(btn_join);
            
            Grid.SetRow(btn_join, 0);
            Grid.SetRow(btn_new, 1);
            Grid.SetRow(btn_exit, 2);
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