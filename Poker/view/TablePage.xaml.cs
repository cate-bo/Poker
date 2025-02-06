﻿using Poker.view;
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
        Viewbox vbx_main = new Viewbox();
        GameController _game;
        List<PlayerGrid> _playerGrids = new List<PlayerGrid>();
        PlayerGrid _me;
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
            vbx_main.Stretch = Stretch.UniformToFill;

            //vbx_main.Height = 490;
            //vbx_main.Width = 960;

            //canvas
            can_main.Height = 490;
            can_main.Width = 960;


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
            Canvas.SetLeft(btn_menu, 50);
            Canvas.SetTop(btn_menu, 50);
        }

        public void AddPlayer(Player player, bool me)
        {
            can_main.Children.Add(player.DisplayBox);
            if (me)
            {
                _me = player.DisplayBox;
            }
        }

        private void btn_menu_click(object sender, RoutedEventArgs e)
        {
            App.MenuInstance.Show();
            App.MenuInstance.Focus();
        }

        public void Setup(bool host)
        {
            can_main.Children.Add(can_setup);
            can_setup.Height = 490;
            can_setup.Width = 960;
            can_setup.Background = new SolidColorBrush(Color.FromArgb(160, 0,0,0));

            can_setup.Children.Add(grd_setup);
            grd_setup.Width = 128;
            grd_setup.Height = 128;

            grd_setup.ColumnDefinitions.Add(new ColumnDefinition());
            grd_setup.ColumnDefinitions.Add(new ColumnDefinition());

            grd_setup.RowDefinitions.Add(new RowDefinition());
            grd_setup.RowDefinitions.Add(new RowDefinition());


            grd_setup.Children.Add(tbl_name);
            grd_setup.Children.Add(tbx_name);

            tbx_name.Height = 20;

            tbl_name.Text = "name:";

            Grid.SetColumn(tbl_name, 0);
            Grid.SetColumn(tbx_name, 1);

            Grid.SetRow(tbl_name, 0);
            Grid.SetRow(tbx_name, 0);

            if (host)
            {
                grd_setup.RowDefinitions.Add(new RowDefinition());
                grd_setup.RowDefinitions.Add(new RowDefinition());

                grd_setup.Children.Add(tbl_startingChips);
                grd_setup.Children.Add(tbx_startingChips);
                grd_setup.Children.Add(tbl_BB);
                grd_setup.Children.Add(tbx_BB);

                tbx_BB.Height = 20;
                tbx_startingChips.Height = 20;

                tbl_BB.Text = "big blind";

                Grid.SetColumn(tbl_BB, 0);
                Grid.SetColumn(tbx_BB, 1);
                Grid.SetColumn(tbl_startingChips, 0);
                Grid.SetColumn(tbx_startingChips, 1);

                Grid.SetRow(tbl_BB, 1);
                Grid.SetRow(tbx_BB, 1);
                Grid.SetRow(tbl_startingChips, 2);
                Grid.SetRow(tbx_startingChips, 2);
            }

            //finnishsetup button
            btn_finnishSetup.Click += Btn_finnishSetup_Click;
            grd_setup.Children.Add(btn_finnishSetup);
            btn_finnishSetup.Height = 20;
            Grid.SetColumnSpan(btn_finnishSetup, 2);
            Grid.SetColumn(btn_finnishSetup, 0);
            Grid.SetRow(btn_finnishSetup, grd_setup.RowDefinitions.Count - 1);

            Canvas.SetLeft(grd_setup, (can_main.Width / 2) - (grd_setup.Width / 2));
            
        }

        private void Btn_finnishSetup_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
