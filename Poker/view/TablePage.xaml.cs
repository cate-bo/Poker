using Poker.view;
using Poker.viewmodel;
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

namespace Poker
{
    public struct CanvasPosition
    {
        public CanvasPosition(bool left, bool top, double x, double y)
        {
            Left = left;
            Top = top;
            X = x;
            Y = y;
        }
        public bool Left { get; set; }
        public bool Top { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public struct PlayerPosition
    {
        public PlayerPosition(CanvasPosition gridposition, CanvasPosition betposition, CanvasPosition dealerbuttonposition)
        {
            Gridposition = gridposition;
            Betposition = betposition;
            Dealerbuttonposition = dealerbuttonposition;
        }
        public CanvasPosition Gridposition { get; set; }
        public CanvasPosition Betposition { get; set; }
        public CanvasPosition Dealerbuttonposition { get; set; }
    }
    /// <summary>
    /// Interaction logic for TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        //player positions
        public static PlayerPosition myPosition = new PlayerPosition();
        public static List<PlayerPosition> playerPositions = new List<PlayerPosition>();

        //table UI
        BitmapImage bmi_background = new BitmapImage();
        ImageBrush imb_background = new ImageBrush();
        BitmapImage bmi_table = new BitmapImage();
        Image img_table = new Image();
        Button btn_menu = new Button();
        Canvas can_main = new Canvas();
        Viewbox vbx_main = new Viewbox();
        GameController _game;
        //Setupbox
        Canvas can_setup = new Canvas();
        Grid grd_setup = new Grid();
        TextBlock tbl_name = new TextBlock();
        TextBox tbx_name = new TextBox();
        TextBlock tbl_startingChips = new TextBlock();
        TextBox tbx_startingChips = new TextBox();
        TextBlock tbl_BB = new TextBlock();
        TextBox tbx_BB = new TextBox();
        Button btn_finnishSetup = new Button();
        public TablePage(GameController game)
        {
            
            _game = game;
            //this.DataContext = _game;
            InitializeComponent();
            this.Content = vbx_main;
            vbx_main.Child = can_main;
            new TableWindow(this);

            //viewbox stuff
            vbx_main.Stretch = Stretch.Uniform;
            vbx_main.HorizontalAlignment = HorizontalAlignment.Left;
            vbx_main.VerticalAlignment = VerticalAlignment.Top;

            //vbx_main.Height = 490;
            //vbx_main.Width = 960;

            //canvas
            can_main.Height = 490;
            can_main.Width = 960;

            //table
            bmi_table.BeginInit();
            bmi_table.UriSource = new Uri(@"C:\Users\cate\source\repos\Poker\Poker\view\assets\table.png");
            bmi_table.EndInit();
            img_table.Source = bmi_table;
            can_main.Children.Add(img_table);
            img_table.Height = 360;
            img_table.Width = 640;
            Canvas.SetLeft(img_table, 0);
            Canvas.SetTop(img_table, 0);

            //background
            this.Background = imb_background;
            bmi_background.BeginInit();
            bmi_background.UriSource = new Uri(@"C:\Users\cate\source\repos\Poker\Poker\view\assets\background.png");
            bmi_background.EndInit();
            imb_background.ImageSource = bmi_background;
            imb_background.Stretch = Stretch.Uniform;
            imb_background.TileMode = TileMode.Tile;
            imb_background.AlignmentX = AlignmentX.Left;
            imb_background.AlignmentY = AlignmentY.Top;
            imb_background.Viewport = new Rect(0, 0, 32, 32);
            imb_background.ViewportUnits = BrushMappingMode.Absolute;

            //menu button
            btn_menu.Click += btn_menu_click;
            btn_menu.Width = 32;
            btn_menu.Height = 32;
            can_main.Children.Add(btn_menu);
            Canvas.SetLeft(btn_menu, 32);
            Canvas.SetTop(btn_menu, 32);

            //setup thing
            can_setup.Height = can_main.Height * 2;
            can_setup.Width = can_main.Width * 2;
            can_setup.Background = new SolidColorBrush(Color.FromArgb(160, 0, 0, 0));

            can_setup.Children.Add(grd_setup);
            grd_setup.Width = 300;
            grd_setup.Height = 300;

            grd_setup.ColumnDefinitions.Add(new ColumnDefinition());
            grd_setup.ColumnDefinitions.Add(new ColumnDefinition());

            grd_setup.RowDefinitions.Add(new RowDefinition());
            grd_setup.RowDefinitions.Add(new RowDefinition());


            grd_setup.Children.Add(tbl_name);
            grd_setup.Children.Add(tbx_name);

            tbx_name.Height = 20;


            tbl_name.Text = "name";

            tbl_name.VerticalAlignment = VerticalAlignment.Center;

            tbl_name.Foreground = new SolidColorBrush(Colors.White);

            Grid.SetColumn(tbl_name, 0);
            Grid.SetColumn(tbx_name, 1);

            Grid.SetRow(tbl_name, 0);
            Grid.SetRow(tbx_name, 0);

            if (_game.Hosting)
            {
                grd_setup.RowDefinitions.Add(new RowDefinition());
                grd_setup.RowDefinitions.Add(new RowDefinition());

                grd_setup.Children.Add(tbl_startingChips);
                grd_setup.Children.Add(tbx_startingChips);
                grd_setup.Children.Add(tbl_BB);
                grd_setup.Children.Add(tbx_BB);

                tbx_BB.Height = 20;
                tbx_startingChips.Height = 20;

                tbl_startingChips.Text = "starting chips";
                tbl_BB.Text = "big blind";

                tbl_BB.VerticalAlignment = VerticalAlignment.Center;
                tbl_startingChips.VerticalAlignment = VerticalAlignment.Center;

                tbl_startingChips.Foreground = new SolidColorBrush(Colors.White);
                tbl_BB.Foreground = new SolidColorBrush(Colors.White);

                Grid.SetColumn(tbl_BB, 0);
                Grid.SetColumn(tbx_BB, 1);
                Grid.SetColumn(tbl_startingChips, 0);
                Grid.SetColumn(tbx_startingChips, 1);

                
                Grid.SetRow(tbl_startingChips, 1);
                Grid.SetRow(tbx_startingChips, 1);
                Grid.SetRow(tbl_BB, 2);
                Grid.SetRow(tbx_BB, 2);
            }

            //finnishsetup button
            btn_finnishSetup.Click += Btn_finnishSetup_Click;
            grd_setup.Children.Add(btn_finnishSetup);
            btn_finnishSetup.Height = 20;
            Grid.SetColumnSpan(btn_finnishSetup, 2);
            Grid.SetColumn(btn_finnishSetup, 0);
            Grid.SetRow(btn_finnishSetup, grd_setup.RowDefinitions.Count - 1);

            Canvas.SetLeft(grd_setup, (can_main.Width / 2) - (grd_setup.Width / 2));
            Canvas.SetTop(grd_setup, (can_main.Height / 2) - (grd_setup.Height / 2));
        }

        public void AddPlayerToTable(Player player)
        {
            can_main.Children.Add(player.DisplayBox);
            ArrangePlayers();
        }

        private void btn_menu_click(object sender, RoutedEventArgs e)
        {
            App.MenuInstance.Show();
            App.MenuInstance.Focus();
        }

        public void Setup(bool host)
        {
            can_main.Children.Add(can_setup);
            
        }

        private void Btn_finnishSetup_Click(object sender, RoutedEventArgs e)
        {
            _game.SubmitSetup(tbx_name.Text, tbx_startingChips.Text, tbx_BB.Text);
        }

        public void CloseSetup()
        {
            can_main.Children.Remove(can_setup);
        }

        public void ArrangePlayers()
        {

        }
    }
}
