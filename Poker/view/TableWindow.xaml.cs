using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public TableWindow(TablePage table)
        {
            this.DataContext = this;
            InitializeComponent();
            App.TableWindows.Add(this);
            this.Closing += ClosingEvent;
            this.Content = table;
            this.Show();
        }

        private void ClosingEvent(object? sender, CancelEventArgs e)
        {
            App.CloseTableWindow(this);
        }
    }
}
