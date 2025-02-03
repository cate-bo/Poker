using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Poker.view
{
    internal class PlayerGrid : Grid
    {
        Image img_character = new Image();
        Border brd_box = new Border();
        TextBlock Chips = new TextBlock();
        TextBlock Name = new TextBlock();
        Grid grd_box = new Grid();
        public PlayerGrid()
        {
            //this grid
            ColumnDefinitions.Add(new ColumnDefinition());

            RowDefinitions.Add(new RowDefinition());
            RowDefinitions.Add(new RowDefinition());
            
            //grid box
            grd_box.ColumnDefinitions.Add(new ColumnDefinition());

            grd_box.RowDefinitions.Add(new RowDefinition());
            grd_box.RowDefinitions.Add(new RowDefinition());

            grd_box.Children.Add(Name);
            grd_box.Children.Add(Chips);

            Grid.SetColumn(Name, 0);
            Grid.SetColumn(Chips, 0);

            Grid.SetRow(Name, 0);
            Grid.SetRow(Chips, 1);

            grd_box.Background = new SolidColorBrush(Color.FromRgb(100,100,100));

            //border box
            brd_box.BorderBrush = new SolidColorBrush(Color.FromRgb(200,200,200));
            brd_box.BorderThickness = new Thickness(5);
            brd_box.Child = grd_box;
            brd_box.SizeChanged += PlayerBox_SizeChanged;

            Chips.Foreground = new SolidColorBrush(Color.FromArgb(255,255,255,255));
            Name.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void PlayerBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            brd_box.CornerRadius = new CornerRadius(this.Height / 2);
        }
    }
}
