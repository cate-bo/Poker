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
using System.Windows.Shapes;

namespace Poker
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        TablePage t1 = new TablePage();
        TablePage t2 = new TablePage();
        TablePage t3 = new TablePage();
        TablePage t4 = new TablePage();

        Frame f1 = new Frame();
        Frame f2 = new Frame();
        Frame f3 = new Frame();
        Frame f4 = new Frame();
        public Test()
        {
            InitializeComponent();

            f1.Content = t1;
            f2.Content = t2;
            f3.Content = t3;
            f4.Content = t4;

            f1.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            f2.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            f3.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            f4.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            f1.BorderThickness = new Thickness(5);
            f2.BorderThickness = new Thickness(5);
            f3.BorderThickness = new Thickness(5);
            f4.BorderThickness = new Thickness(5);

            grd_main.Children.Add(f1);
            grd_main.Children.Add(f2);
            grd_main.Children.Add(f3);
            grd_main.Children.Add(f4);

            Grid.SetColumn(f1, 0);
            Grid.SetColumn(f2, 1);
            Grid.SetColumn(f3, 0);
            Grid.SetColumn(f4, 1);

            Grid.SetRow(f1, 0);
            Grid.SetRow(f2, 0);
            Grid.SetRow(f3, 1);
            Grid.SetRow(f4, 1);


            
        }
    }
}
