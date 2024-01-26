using GymNote.Items;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GymNote
{
    public class DatabaseConnection
    {
        MySqlConnection connection;
        string connectionString;
        public DatabaseConnection()
        {
            connectionString = "SERVER=localhost;" + "DATABASE=gymnotedb;" + "UID=gymnoteAppUser;" + "PASSWORD=gymnoteUser123;";

            connection = new MySqlConnection(connectionString);
        }

        public Dictionary<int, User> GetUsers()
        {
            Dictionary<int, User> userDictionary = new Dictionary<int, User>();

            connection.Open();

            string query = "SELECT * FROM users;";

            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                User user = new User((int)reader["user_id"], (string)reader["user_name"], (string)reader["user_password"]);
                userDictionary.Add(user.Id, user);
            }

            connection.Close();

            return userDictionary;
        }
        public void AddUser(string userName, string userPassword)
        {
            try
            {
                connection.Open();

                
                MySqlCommand checkCommand = new MySqlCommand("SELECT COUNT(*) FROM users WHERE user_name = @userName", connection);
                checkCommand.Parameters.AddWithValue("@userName", userName);
                int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                    return;
                }

                
                MySqlCommand command = new MySqlCommand("add_user", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new MySqlParameter("user_name_par", userName));
                command.Parameters.Add(new MySqlParameter("user_password_par", userPassword));
                command.ExecuteNonQuery();

                MessageBox.Show("New user added successfully.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public User LogdIn(string userName, string userPassword)
        {
            connection.Open();
            string queri = "SELECT * FROM users WHERE user_name = @userName AND user_password = @userPassword;";
            MySqlCommand command = new MySqlCommand(queri, connection);
            command.Parameters.AddWithValue("@userName", userName);
            command.Parameters.AddWithValue("@userPassword", userPassword);

            MySqlDataReader reader = command.ExecuteReader();

            User LoggedIn = null;

            if (reader.Read())
            {
                LoggedIn = new User((int)reader["user_id"], (string)reader["user_name"], (string)reader["user_password"]);
            }


            connection.Close();

            return LoggedIn;
        }

        public List<User_Workout_Info> GetUserWorkout(string user)
        {
            List<User_Workout_Info> userList = new List<User_Workout_Info>();

            connection.Open();
            string query = "SELECT * FROM users_workout_info WHERE user_name = @user;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@user", user);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User_Workout_Info userOb = new User_Workout_Info
                    {
                        UserName = reader["user_name"].ToString(),
                        WorkoutName = reader["workout_name"].ToString(),
                        Sets = Convert.ToInt32(reader["sets"]),
                        Reps = Convert.ToInt32(reader["reps"]),
                        Weight = Convert.ToInt32(reader["weight"]),
                        Grade = reader["grade"].ToString()
                    };

                    
                    userList.Add(userOb);
                }
            }

            connection.Close();
            return userList;
        }
    }
}
