using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga_App_V1.Models;

namespace Yoga_App_V1.Services
{
    public class ExerciseDataStore : IDataStore<Exercise>
    {
        private readonly List<Exercise> exercises;

        public ExerciseDataStore()
        {
            exercises = new List<Exercise>()
            {
                new Exercise()
                {
                    ExerciseID = Guid.NewGuid().ToString(),
                    Name = "Inhale & Exhale Basic",
                    DifficultyRating = 1,
                    ExerciseDuration = 5,
                    Thumbnail = "Example_Thumbnail.jpg",
                    VideoURL = "<iframe width=\"1864\" height=\"770\" src=\"https://www.youtube.com/embed/1d7FDA2M-9E\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>"
                },
                new Exercise()
                {
                    ExerciseID = Guid.NewGuid().ToString(),
                    Name = "Inhale & Exhale w/ Posing",
                    DifficultyRating = 2,
                    ExerciseDuration = 5,
                    Thumbnail = "Example_Thumbnail.jpg",
                    VideoURL = "<iframe width=\"1864\" height=\"770\" src=\"https://www.youtube.com/embed/1d7FDA2M-9E\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>"
                },
                new Exercise()
                {
                    ExerciseID = Guid.NewGuid().ToString(),
                    Name = "NHS - Pliates for beginners",
                    DifficultyRating = 1,
                    ExerciseDuration = 45,
                    Thumbnail = "Example_Thumbnail.jpg",
                    VideoURL = "https://www.nhs.uk/conditions/nhs-fitness-studio/pilates-for-beginners/"
                },
                new Exercise()
                {
                    ExerciseID = Guid.NewGuid().ToString(),
                    Name = "Wrist Pain Releif Extensions 1",
                    DifficultyRating = 1,
                    ExerciseDuration = 40,
                    Thumbnail = "WS1.jpg",
                    ExerciseContent = 
                    "Stretch your arm out in front of you straight. \n" +
                    "Begin to stretch the lower wrist by raising towards you so you can see your finger nails to a point where it is comfortable. \n" +
                    "Place your other hand behind it and lightly apply pressure towards you being sure not to do so rapidly or to go past the point of discomfort. \n" +
                    "Hold for 30 seconds and then move on to the next exercise"
                },
                new Exercise()
                {
                    ExerciseID = Guid.NewGuid().ToString(),
                    Name = "Wrist Pain Releif Extensions 2",
                    DifficultyRating = 1,
                    ExerciseDuration = 40,
                    Thumbnail = "WS2.jpg",
                    ExerciseContent =
                    "Stretch your arm out in front of you straight. \n" +
                    "Begin to stretch the upper wrist by turning it away from you so you can see the palm of your hand to the point where it is comfortable. \n" +
                    "Place your other hand behind it and lightly apply pressure towards you being sure not to do so rapidly or to go past the point of discomfort. \n" +
                    "Hold for 30 seconds and then move on to the next exercise"
                },
                new Exercise()
                {
                    ExerciseID = Guid.NewGuid().ToString(),
                    Name = "Wrist Pain Releif Extensions 3",
                    DifficultyRating = 1,
                    ExerciseDuration = 40,
                    Thumbnail = "Example_Thumbnail.jpg",
                    ExerciseContent =
                    "Stretch your arm out in front of you straight. \n" +
                    "Begin to stretch the right side of the wrist by turning it towards you so that your thumb is closer to your face to the point where it is comfortable. \n" +
                    "Place your other hand behind it and lightly apply pressure towards you being sure not to do so rapidly or to go past the point of discomfort. \n" +
                    "Hold for 30 seconds and then move on to the next exercise"
                },
                new Exercise()
                {
                    ExerciseID = Guid.NewGuid().ToString(),
                    Name = "Wrist Pain Releif Extensions 4",
                    DifficultyRating = 1,
                    ExerciseDuration = 40,
                    Thumbnail = "Example_Thumbnail.jpg",
                    ExerciseContent =
                    "Stretch your arm out in front of you straight. " +
                    "Begin to stretch the right side of the wrist by turning it away from you so that your thumb is further from your face to the point where it is comfortable. \n" +
                    "Place your other hand behind it and lightly apply pressure away fom you being sure not to do so rapidly or to go past the point of discomfort. \n" +
                    "Hold for 30 seconds then lightly shake your hands to improve circulation and relax the stretched muscles. \n" +
                    "You're all done! Hopefully you should feel you wrist being slightly more mobile and will have warmed you up to use it"
                },
                new Exercise()
                {
                    ExerciseID = Guid.NewGuid().ToString(),
                    Name = "Posture Improvement 1",
                    DifficultyRating = 2,
                    ExerciseDuration = 20,
                    Thumbnail = "chestopener.jpg",
                    ExerciseContent =
                    "Strech your arm behind your back such that your hands can touch and lightly grip each other. \n" +
                    "Straighten your posture to an ideal angle, with back arched with your head pointed up wards towards the ceiling. \n" +
                    "Breath in and hold the breath while slowly pulling your shulder blades back. \n " +
                    "You should feel a strech across the chest and shoulders but little to no discomfort and none atall in the back or neck. \n" +
                    "Hold for 5 seconds breathing in and out. \n" +
                    "Repeat 10 times and then move on to the next exercise (Or otherwise as these exercises can be done throughout the day whenever you have a free moment)"
                },
                new Exercise()
                {
                    ExerciseID = Guid.NewGuid().ToString(),
                    Name = "Posture Improvement 2",
                    DifficultyRating = 2,
                    ExerciseDuration = 60,
                    Thumbnail = "isometricrows.PNG",
                    ExerciseContent =
                    "Stand straight and tall or in a chair with a soft backing. " +
                    "Bend your arms so your fingers are facing forward and your palms are facing each other (As though you were holding to object in your hands with your arms at a 90 degree angle). " +
                    "Exhale as you pull your elbows behind you (into the chair back if applicable) then hold this position and breathe deeply for 10 seconds. " +
                    "Repeat for around a minute and then move on to the next exercise (Or otherwise as these exercises can be done throughout the day whenever you have a free moment)"
                }
            };
        }

        public async Task<bool> AddItemAsync(Exercise exercise)
        {
            exercises.Add(exercise);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string ExerciseID)
        {
            var oldExercise = exercises.Where((Exercise arg) => arg.ExerciseID == ExerciseID).FirstOrDefault();
            exercises.Remove(oldExercise);

            return await Task.FromResult(true);
        }

        public async Task<Exercise> GetItemAsync(string ExerciseID)
        {
            return await Task.FromResult(exercises.FirstOrDefault(s => s.ExerciseID == ExerciseID));
        }

        public async Task<IEnumerable<Exercise>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(exercises);
        }

        public async Task<bool> UpdateItemAsync(Exercise exercise)
        {
            var oldExercise = exercises.Where((Exercise arg) => arg.ExerciseID == exercise.ExerciseID).FirstOrDefault();
            exercises.Remove(oldExercise);
            exercises.Add(exercise);

            return await Task.FromResult(true);
        }

        public List<Exercise> GetExercises()
        {
            return exercises;
        }
    }
}
