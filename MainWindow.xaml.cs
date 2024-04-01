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
using HellPie_Tools.Utility;

namespace HellPie_Tools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     private readonly PositionStuffVM positionStuffVM;
        public MainWindow()
        {
            positionStuffVM = new();
            DataContext = positionStuffVM;
            SettingsHandler.Setup();
            InitializeComponent();
        }

        private void GetCoordsButton_OnClick(object sender, RoutedEventArgs e)
        {
            positionStuffVM.GetCoords();
        }

        private void SetCoordsButton_OnClick(object sender, RoutedEventArgs e)
        {
            positionStuffVM.SetCoords();
        }

        private void HookIn_OnClick(object sender, RoutedEventArgs e)
        {
            GameProcess.FindProcess();
        }
    }
}