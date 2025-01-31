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
        public static List<TableWindow> Tables { get; set; } = new List<TableWindow>();

        public static void CheckIfNoWindowVisible()
        {
            if(!MenuInstance.IsVisible && Tables.Count < 1)
            {
                MenuInstance.Close();
            }
        }
    }

}
