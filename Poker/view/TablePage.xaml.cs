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
    /// <summary>
    /// Interaction logic for TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        BitmapImage bmi_background = new BitmapImage();
        ImageBrush imb_background = new ImageBrush();
        Button btn_menu = new Button();
        Canvas can_main = new Canvas();
        public TablePage()
        {
            InitializeComponent();
            this.Content = can_main;

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
            //Canvas.SetLeft
        }

        public void AddPlayer(Player player)
        {
            new PlayerGrid(player);
        }

        private void btn_menu_click(object sender, RoutedEventArgs e)
        {
            App.MenuInstance.Show();
            App.MenuInstance.Focus();
        }
    }
}
