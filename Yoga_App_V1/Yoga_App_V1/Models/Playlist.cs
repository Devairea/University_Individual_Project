using System;
using System.Collections.Generic;
using System.Text;

namespace Yoga_App_V1.Models
{
    public class Playlist
    {
        // Properties
        public string PlaylistID { get; set; }

        public string Name { get; set; }

        public int DifficultyRating { get; set; }

        public List<Exercise> Exercises { get; set; }

        public double PlaylistDuration
        {
            get
            {
                double v = 0.0;
                foreach (Exercise e in Exercises)
                {
                    v += e.ExerciseDuration;
                }
                return TimeSpan.FromSeconds(v).Minutes;
            }
        }

        public string PlaylistDescription
        {
            get
            {
                return "Difficulty Rating: " + DifficultyRating+ " | Duration: " + PlaylistDuration + " mins";
            }
        }

        public string ContentDescription { get; set; }

        public string Thumbnail { get; set; }
    }
}
