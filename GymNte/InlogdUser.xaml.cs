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
    /// Interaction logic for InlogdUser.xaml
    /// </summary>
    public partial class InlogdUser : Page
    {
        private User user;
        public InlogdUser(User user)
        {
            InitializeComponent();
            this.user = user;
            
            logdInUserLabel.Content = $"Logged in as: {user.Name}";

            Loaded += (sender, e) =>
            {
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    parentWindow.WindowState = WindowState.Maximized;
                    parentWindow.WindowStyle = WindowStyle.None;
                }
            };
            ListBoxUserWorkouts.Items.Clear();
            DatabaseConnection db = new DatabaseConnection();
            List<User_Workout_Info> userWorkouts = db.GetUserWorkout(user.Name);
            ListBoxUserWorkouts.ItemsSource = userWorkouts;
            
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();


            Window.GetWindow(this).Close();
        }
    }
}
