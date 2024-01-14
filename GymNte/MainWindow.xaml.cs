using GymNote;
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

namespace GymNte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void CreateAccButton_Click(object sender, RoutedEventArgs e)
        {
            //CreateAccPage createAccPage = new CreateAccPage();
            //NavigationService navService = NavigationService.GetNavigationService(this);
            //navService.Navigate(createAccPage);
            CreateAccPage createAccPage = new CreateAccPage();
            this.Content = createAccPage;
        }
    }
}