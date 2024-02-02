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
    
    public partial class InlogdUser : Page
    {
        private User user;

        private void NumericInputOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }

        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }
        public InlogdUser(User user)
        {
            InitializeComponent();
            this.user = user;
            
            logdInUserLabel.Content = user.Name;

            Loaded += (sender, e) =>
            {
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    parentWindow.WindowState = WindowState.Maximized;
                    parentWindow.WindowStyle = WindowStyle.None;
                }
            };

            TextBoxSets.PreviewTextInput += NumericInputOnly;
            TextBoxReps.PreviewTextInput += NumericInputOnly;
            TextBoxWeight.PreviewTextInput += NumericInputOnly;

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

       

        private void ButtonAddWorkout_Click(object sender, RoutedEventArgs e)
        {
            string workoutName = TextBoxWorkoutName.Text;
            int sets = int.Parse(TextBoxSets.Text);
            int reps = int.Parse(TextBoxReps.Text);
            int weight = int.Parse(TextBoxWeight.Text);
            string grade = TextBoxGrade.Text;
            string userName = (string)logdInUserLabel.Content;

            if (workoutName.Length <= 45 && grade.Length <= 10)
            {
                DatabaseConnection db = new DatabaseConnection();

                db.AddWorkoutToUser(userName, workoutName, sets, reps, weight, grade);

                ListBoxUserWorkouts.ItemsSource = db.GetUserWorkout(user.Name);
            }
            else
            {
                MessageBox.Show("Too many characters");
            }
        }

        private void SerchButton_Click(object sender, RoutedEventArgs e)
        {
            string workout = SerchBox.Text;
            string userName = (string)logdInUserLabel.Content;
            DatabaseConnection db = new DatabaseConnection();
            db.Serchworkout(userName, workout);
            ListBoxUserWorkouts.ItemsSource = db.Serchworkout(user.Name, workout);
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxUserWorkouts.SelectedItem != null)
            {
                string userName = (string)logdInUserLabel.Content;

                User_Workout_Info selectedWorkout = (User_Workout_Info)ListBoxUserWorkouts.SelectedItem;

                if (selectedWorkout != null)
                {
                    int workoutId = selectedWorkout.Workoutid;

                    DatabaseConnection db = new DatabaseConnection();

                    db.DeleteWorkout(userName, workoutId);

                    List<User_Workout_Info> userWorkouts = db.GetUserWorkout(user.Name);
                    ListBoxUserWorkouts.ItemsSource = userWorkouts;
                }
                else
                {
                    MessageBox.Show("Selected workout is null. Please select a valid workout.");
                }
            }
            else
            {
                MessageBox.Show("You have to select a workout to delete");
            }
        }

        private void ListBoxUserWorkouts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }

        private void UppdateButton_Click(object sender, RoutedEventArgs e)
        {
            string userPassword1 = UppdatePasswordTxtBox.Password;
            string userPassword2 = UppdatePasswordTxtBox2.Password;

            if (userPassword1.Length <= 15 && userPassword2.Length <= 15)
            {

                if (userPassword1 == userPassword2)
                {
                    string userName = (string)logdInUserLabel.Content;
                    DatabaseConnection db = new DatabaseConnection();
                    db.ChangePassword(userName, userPassword2);
                    MessageBox.Show("Password changed Successfully");
                }
                else
                {
                    MessageBox.Show("The Password do not match");
                    UppdatePasswordTxtBox.Password = "";
                    UppdatePasswordTxtBox2.Password = "";
                }
            }
            else
            {
                MessageBox.Show("Too many characters");
                UppdatePasswordTxtBox.Password = "";
                UppdatePasswordTxtBox2.Password = "";
            }
        }
    }
}
