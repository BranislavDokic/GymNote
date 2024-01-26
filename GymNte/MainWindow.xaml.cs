using GymNote;
using GymNote.Items;
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

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = LogInNickNameBox.Text;
                string password = LogInPasswordBox.Password;

                DatabaseConnection dbConnection = new DatabaseConnection();

                
                User loggedInUser = dbConnection.LogdIn(username, password);

                if (loggedInUser != null)
                {
                   
                    InlogdUser userLoggedInPage = new InlogdUser(loggedInUser);
                    this.Content = userLoggedInPage;
                }
                else
                {
                    
                    MessageBox.Show("Invalid username or password. Please try again.");
                    LogInNickNameBox.Text = "";
                    LogInPasswordBox.Password = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}