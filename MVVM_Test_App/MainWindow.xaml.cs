using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVVM_Test_Library;
using MVVM_Test_Library.View;

namespace MVVM_Test_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMvvmLibraryService mvmLibraryService = new MvvmLibraryService();
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(mvmLibraryService.MainPage);
        }
    }
}