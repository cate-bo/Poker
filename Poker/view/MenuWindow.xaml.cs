using Poker.viewmodel;
using System.ComponentModel;
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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        //gets focused when menu button is presed in a table window if null new Menuwindow is created and MenuInstance is set to it(in constructor)
        
        Button btn_join = new Button();
        Button btn_new = new Button();
        Button btn_exit = new Button();
        public MenuWindow()
        {
            App.MenuInstance = this;
            this.DataContext = this;
            InitializeComponent();
            this.Closing += ClosingEvent;

            btn_join.Content = "join game";
            btn_new.Content = "new game";
            btn_exit.Content = "exit";

            btn_join.Click += JoinGame;
            btn_new.Click += StartGame;
            btn_exit.Click += Exit;

            grd_main.ColumnDefinitions.Add(new ColumnDefinition());

            grd_main.RowDefinitions.Add(new RowDefinition());
            grd_main.RowDefinitions.Add(new RowDefinition());
            grd_main.RowDefinitions.Add(new RowDefinition());

            grd_main.Children.Add(btn_exit);
            grd_main.Children.Add(btn_new);
            grd_main.Children.Add(btn_join);

            Grid.SetRow(btn_new, 0);
            Grid.SetRow(btn_join, 1);
            Grid.SetRow(btn_exit, 2);
        }

        private void ClosingEvent(object? sender, CancelEventArgs e)
        {
            if(App.TableWindows.Count > 0)
            {
                e.Cancel = true;
                this.Hide();
            }
            
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            new GameController(true);
        }

        private void JoinGame(object sender, RoutedEventArgs e)
        {
            new GameController(false);
        }
    }
}