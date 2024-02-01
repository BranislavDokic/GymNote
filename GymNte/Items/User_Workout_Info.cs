using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNote.Items
{
    public class User_Workout_Info
    {
        public string UserName { get; set; }
        public string WorkoutName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public string Grade { get; set; }
        public int Workoutid { get; set; }

        public User_Workout_Info()
        {
        }
        public User_Workout_Info(string userName, string workutName, int sets, int reps, int weight, string grade, int workoutid)
        {
            UserName = userName;
            WorkoutName = workutName;
            Sets = sets;
            Reps = reps;
            Weight = weight;
            Grade = grade;
            Workoutid = workoutid;
        }
    }

}
