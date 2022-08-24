using System;
using System.Collections.Generic;
using System.Text;
using Yoga_App_V1.Services;
using Xamarin.Forms;
using Yoga_App_V1.Models;
using System.Diagnostics;

namespace Yoga_App_V1.ViewModels
{
    [QueryProperty(nameof(PlaylistID), nameof(PlaylistID))]
    public class PlaylistDetailViewModel : BaseViewModel
    {
        private string playlistID;
        private string name;
        private int difficultyRating;
        private double duration;
        private List<Exercise> exercises;
        private string thumbnail;
        private string contentDecription;
        public string Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public int DifficultyRating
        {
            get => difficultyRating;
            set => SetProperty(ref difficultyRating, value);
        }

        public double Duration
        {
            get => duration;
            set => SetProperty(ref duration, value);
        }

        public List<Exercise> Exercises
        {
            get => exercises;
            set => SetProperty(ref exercises, value);
        }

        public string Thumbnail
        {
            get => thumbnail;
            set => SetProperty(ref thumbnail, value);
        }
        public string ContentDescription
        {
            get => contentDecription;
            set => SetProperty(ref contentDecription, value);
        }
        public string PlaylistID
        {
            get
            {
                return playlistID;
            }
            set
            {
                playlistID = value;
                LoadPlaylistID(value);
            }
        }


        public async void LoadPlaylistID(string playlistID)
        {
            Debug.WriteLine(playlistID);
            try
            {
                Playlist playlist = await new PlaylistDataStore().GetItemAsync(playlistID);
                Id = playlist.PlaylistID;
                Name = playlist.Name;
                DifficultyRating = playlist.DifficultyRating;
                Duration = playlist.PlaylistDuration;
                Exercises = playlist.Exercises;
                Thumbnail = playlist.Thumbnail;
                ContentDescription = playlist.ContentDescription;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
