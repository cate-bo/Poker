using System.Configuration;
using System.Data;
using System.Windows;

namespace Poker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MenuWindow MenuInstance { get; set; }
        public static List<TableWindow> TableWindows { get; set; } = new List<TableWindow>();

        public static double MinTablePageWidth { get; set; } = 1000;
        public static double MinTablePageHeight { get; set; } = 500;

        public static void CloseTableWindow(TableWindow tableWindow)
        {
            TableWindows.Remove(tableWindow);
            if (!MenuInstance.IsVisible) CheckIfNoWindowVisible();
        }
        public static void CheckIfNoWindowVisible()
        {
            if(!MenuInstance.IsVisible && TableWindows.Count < 1)
            {
                MenuInstance.Close();
            }
        }
    }

}
