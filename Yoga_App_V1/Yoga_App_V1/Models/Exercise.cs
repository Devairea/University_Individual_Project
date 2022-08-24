using System;
using System.Collections.Generic;
using System.Text;

namespace Yoga_App_V1.Models
{
    public class Exercise
    {
        // Properties
        public string ExerciseID { get; set; }

        public string Name { get; set; }

        public int DifficultyRating { get; set; }

        public double ExerciseDuration { get; set; }

        public string ExerciseContent { get; set; }

        public string Thumbnail { get; set; }

        public string VideoURL { get; set; }
    }
}
