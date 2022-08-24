using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga_App_V1.Models;

namespace Yoga_App_V1.Services
{
    public class PlaylistDataStore : IDataStore<Playlist>
    {
        private readonly List<Playlist> playlists;
        public PlaylistDataStore()
        {
            List<Exercise> exercises = new ExerciseDataStore().GetExercises();
            playlists = new List<Playlist>() 
            {
                new Playlist()
                {
                    PlaylistID = "PL 1",
                    Name = "Beginner program #1",
                    DifficultyRating = 1,
                    Thumbnail = "Default_Playlist.jpeg",
                    Exercises = new List<Exercise>()
                    {
                        exercises.FirstOrDefault((Exercise arg) => arg.Name == "Inhale & Exhale Basic") }
                }, 
                new Playlist()
                {
                    PlaylistID = "PL 2",
                    Name = "Intermediate Program #1",
                    DifficultyRating = 2,
                    Thumbnail = "Default_Playlist.jpeg",
                    Exercises = new List<Exercise>()
                    {
                        exercises.FirstOrDefault((Exercise arg) => arg.Name == "Inhale & Exhale Basic"),
                        exercises.FirstOrDefault((Exercise arg) => arg.Name == "Inhale & Exhale w/ Posing")
                    }
                },
                new Playlist()
                {
                    PlaylistID = "Wrist Pain Releif Workout",
                    Name = "Wrist Pain Relief Workout",
                    DifficultyRating = 1,
                    Thumbnail = "Default_Playlist.jpeg",
                    ContentDescription = "One of the first place that pain from repetitive strain is the joints. " +
                    "In this set of exercises we will show how to reduce pain in the wrist joints and to warmup the wrists for activity. " +
                    "Starting with the right hand once you've done this playlist for one hand repeat for the other, this shouldn't take more than a few minutes and can provide long lasting relief.",
                    Exercises = new List<Exercise>()
                    {
                        exercises.FirstOrDefault((Exercise arg) => arg.Name == "Wrist Pain Releif Extensions 1"),
                        exercises.FirstOrDefault((Exercise arg) => arg.Name == "Wrist Pain Releif Extensions 2"),
                        exercises.FirstOrDefault((Exercise arg) => arg.Name == "Wrist Pain Releif Extensions 3"),
                        exercises.FirstOrDefault((Exercise arg) => arg.Name == "Wrist Pain Releif Extensions 4")
                    }
                },
                new Playlist()
                {
                    PlaylistID = "Posture Correction Workout",
                    Name = "Posture Correction Workout",
                    DifficultyRating = 2,
                    Thumbnail = "Default_Playlist.jpeg",
                    ContentDescription = "It is incredibly common to live life putting up with back pain. " +
                    "This should never become the norm and if you are having back pain it is important to visit a doctor" +
                    "However we know this is not always an option, so instead lets target a common cause." +
                    "Poor posture, it is easily corrected at any age and fixing poor posture helps stop pain now and prevent it in the future. " +
                    "Do a few of these a day whenever you have free time but never past the point exertion, nothing here should hurt.",
                    Exercises = new List<Exercise>()
                    {
                        exercises.FirstOrDefault((Exercise arg) => arg.Name == "Posture Improvement 1"),
                        exercises.FirstOrDefault((Exercise arg) => arg.Name == "Posture Improvement 2"),
                    }
                }
            };
        }

        public async Task<bool> AddItemAsync(Playlist playlist)
        {
            playlists.Add(playlist);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string PlaylistID)
        {
            var oldPlaylist = playlists.Where((Playlist arg) => arg.PlaylistID == PlaylistID).FirstOrDefault();
            playlists.Remove(oldPlaylist);

            return await Task.FromResult(true);
        }

        public async Task<Playlist> GetItemAsync(string PlaylistID)
        {
            return await Task.FromResult(playlists.FirstOrDefault(s => s.PlaylistID == PlaylistID));
        }

        public async Task<IEnumerable<Playlist>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(playlists.OrderBy(p => p.DifficultyRating).ToList());
        }

        public async Task<bool> UpdateItemAsync(Playlist playlist)
        {
            var oldPlaylist = playlists.Where((Playlist arg) => arg.PlaylistID == playlist.PlaylistID).FirstOrDefault();
            playlists.Remove(oldPlaylist);
            playlists.Add(playlist);

            return await Task.FromResult(true);
        }
    }
}