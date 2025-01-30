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
    /// Interaction logic for TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        BitmapImage bmi_background = new BitmapImage();
        ImageBrush imb_background = new ImageBrush();
        public TableWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            

            //background
            this.Background = imb_background;
            bmi_background.BeginInit();
            bmi_background.UriSource = new Uri("C:\\Users\\cate\\source\\repos\\Poker\\Poker\\assets\\background.png");
            bmi_background.EndInit();
            imb_background.ImageSource = bmi_background;
            imb_background.Stretch = Stretch.UniformToFill;
            imb_background.TileMode = TileMode.Tile;
            imb_background.AlignmentX = AlignmentX.Left;
            imb_background.AlignmentY = AlignmentY.Top;
            imb_background.Viewport = new Rect(0, 0, 32, 32);
            imb_background.ViewportUnits = BrushMappingMode.Absolute;


        }
    }
}
