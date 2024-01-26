using GymNote.Items;
using GymNte;
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

namespace GymNote
{
    /// <summary>
    /// Interaction logic for CreateAccPage.xaml
    /// </summary>
    public partial class CreateAccPage : Page
    {
        DatabaseConnection db = new DatabaseConnection();
        Dictionary<int, User> usersDictionary;
        public CreateAccPage()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string userName = CreateNickNameBox.Text;
            string userPassword1 = CreatePasswordBox1.Password;
            string userPassword2 = CreatePasswordBox2.Password;
            DatabaseConnection db =new DatabaseConnection();
            if (userPassword1 != userPassword2)
            {
                MessageBox.Show("The Password do not match");
                CreateNickNameBox.Text = "";
                CreatePasswordBox1.Password = "";
                CreatePasswordBox2.Password = "";
            }
            else
            {
                db.AddUser(userName, userPassword1);
                CreateNickNameBox.Text = "";
                CreatePasswordBox1.Password = "";
                CreatePasswordBox2.Password = "";
            }
        }

        private void GoBackToLogInButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

           
            Window.GetWindow(this).Close();
        }
    }
}
