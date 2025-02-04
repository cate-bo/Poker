using Poker.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Poker.view
{
    public class PlayerGrid : Grid
    {
        BitmapImage bmi_card1 = new BitmapImage();
        BitmapImage bmi_card2 = new BitmapImage();
        Image img_card1 = new Image();
        Image img_card2 = new Image();
        BitmapImage bmi_character = new BitmapImage();
        Image img_character = new Image();
        Border brd_box = new Border();
        TextBlock tbx_chips = new TextBlock();
        TextBlock tbx_name = new TextBlock();
        Grid grd_box = new Grid();
        Player player;
        public PlayerGrid(Player player)
        {
            this.player = player;
            //character image
            bmi_character.BeginInit();
            bmi_character.UriSource = new Uri(@"C:\Users\cate\source\repos\Poker\Poker\view\assets\Player.png");
            bmi_character.EndInit();
            img_character.Source = bmi_character;
            img_character.Width = 100;
            //this grid
            ColumnDefinitions.Add(new ColumnDefinition());

            RowDefinitions.Add(new RowDefinition());
            RowDefinitions.Add(new RowDefinition());

            ColumnDefinitions[0].Width = new GridLength(100);

            Children.Add(brd_box);
            Children.Add(img_character);

            Grid.SetColumn(img_character, 0);
            Grid.SetColumn(grd_box, 0);

            Grid.SetRow(img_character, 0);
            Grid.SetRow(grd_box, 1);

            //grid box
            grd_box.ColumnDefinitions.Add(new ColumnDefinition());

            grd_box.RowDefinitions.Add(new RowDefinition());
            grd_box.RowDefinitions.Add(new RowDefinition());

            grd_box.Children.Add(tbx_name);
            grd_box.Children.Add(tbx_chips);

            Grid.SetColumn(tbx_name, 0);
            Grid.SetColumn(tbx_chips, 0);

            Grid.SetRow(tbx_name, 0);
            Grid.SetRow(tbx_chips, 1);

            grd_box.Background = new SolidColorBrush(Color.FromRgb(100,100,100));

            //border box
            brd_box.BorderBrush = new SolidColorBrush(Color.FromRgb(200,200,200));
            brd_box.BorderThickness = new Thickness(5);
            brd_box.Child = grd_box;
            brd_box.SizeChanged += PlayerBox_SizeChanged;

            tbx_chips.Foreground = new SolidColorBrush(Color.FromArgb(255,255,255,255));
            tbx_name.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void PlayerBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            brd_box.CornerRadius = new CornerRadius(brd_box.Height / 2);
        }

        public void DisplayCards(bool showFront)
        {
            if (!showFront)
            {
                bmi_card1.BeginInit();
                bmi_card1.UriSource = new Uri(@"C:\Users\cate\source\repos\Poker\Poker\view\assets\cards\back.png");
                bmi_card1.EndInit();
                //TODO
            }
        }
    }
}
