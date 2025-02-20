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
        TextBlock tbl_chips = new TextBlock();
        TextBlock tbl_name = new TextBlock();
        Grid grd_box = new Grid();
        Player _player;
        public PlayerGrid(Player player)
        {
            this._player = player;
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

            ColumnDefinitions[0].Width = new GridLength(150);

            Children.Add(brd_box);
            Children.Add(img_character);

            Grid.SetColumn(img_character, 0);
            Grid.SetColumn(brd_box, 0);

            Grid.SetRow(img_character, 0);
            Grid.SetRow(brd_box, 1);

            //grid box
            grd_box.ColumnDefinitions.Add(new ColumnDefinition());

            grd_box.RowDefinitions.Add(new RowDefinition());
            grd_box.RowDefinitions.Add(new RowDefinition());

            grd_box.Children.Add(tbl_name);
            grd_box.Children.Add(tbl_chips);

            Grid.SetColumn(tbl_name, 0);
            Grid.SetColumn(tbl_chips, 0);

            Grid.SetRow(tbl_name, 0);
            Grid.SetRow(tbl_chips, 1);

            grd_box.Background = new SolidColorBrush(Color.FromArgb(0,0,0,0));
            

            //border box
            brd_box.BorderBrush = new SolidColorBrush(Color.FromRgb(200,200,200));
            brd_box.Background = new SolidColorBrush(Color.FromArgb(255, 80, 80, 80));
            brd_box.BorderThickness = new Thickness(5);
            brd_box.Child = grd_box;
            brd_box.CornerRadius = new CornerRadius(20);

            //box content
            tbl_chips.Foreground = new SolidColorBrush(Color.FromArgb(255,255,255,255));
            tbl_name.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            tbl_name.TextAlignment = TextAlignment.Center;
            tbl_chips.TextAlignment = TextAlignment.Center;

            tbl_name.FontFamily = new FontFamily("Comic Sans MS");
            tbl_chips.FontFamily = new FontFamily("Comic Sans MS");

            tbl_name.Text = player.Name;
        }


        public void DisplayCards(bool showFront)
        {
            if (!showFront)
            {
                bmi_card1.BeginInit();
                bmi_card1.UriSource = new Uri(@"C:\Users\cate\source\repos\Poker\Poker\view\assets\cards\back.png");
                bmi_card1.EndInit();
                bmi_card2.BeginInit();
                bmi_card2.UriSource = new Uri(@"C:\Users\cate\source\repos\Poker\Poker\view\assets\cards\back.png");
                bmi_card2.EndInit();
            }
            else
            {
                bmi_card1.BeginInit();
                bmi_card1.UriSource = new Uri(@"C:\Users\cate\source\repos\Poker\Poker\view\assets\cards\" + (((int)_player.Card1.value)).ToString() + "_" + (((int)_player.Card1.suit)).ToString() + ".png");
                bmi_card1.EndInit();
                bmi_card2.BeginInit();
                bmi_card2.UriSource = new Uri(@"C:\Users\cate\source\repos\Poker\Poker\view\assets\cards\" + (((int)_player.Card2.value)).ToString() + "_" + (((int)_player.Card2.suit)).ToString() + ".png");
                bmi_card2.EndInit();
            }
            img_card1.Source = bmi_card1;
            img_card2.Source = bmi_card2;
            img_card1.Width = 20;
            img_card2.Width = 20;

            img_card1.Margin = new Thickness(20, 70, 0, 0);
            img_card2.Margin = new Thickness(0, 70, 20, 0);

            if (this.Children.Contains(img_card1))
            {
                this.Children.Remove(img_card1);
                this.Children.Remove(img_card2);
            }

            this.Children.Add(img_card1);
            this.Children.Add(img_card2);

            this.Children.Add(img_card1);
            this.Children.Add(img_card2);

            Grid.SetColumn(img_card1, 0);
            Grid.SetColumn(img_card2, 0);

            Grid.SetRow(img_card1 , 0);
            Grid.SetRow(img_card2 , 0);
        }

        public void UpdateChipcount()
        {
            tbl_chips.Text = _player.Chips.ToString();
        }

        public void UpdateName()
        {
            tbl_name.Text = _player.Name;
        }
    }
}
