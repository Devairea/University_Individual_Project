using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Yoga_App_V1.Models;
using Yoga_App_V1.Services;
using Yoga_App_V1.Views;

namespace Yoga_App_V1.ViewModels
{
    public class PlaylistsViewModel : BaseViewModel
    {
        private Playlist _selectedPlaylist;

        public ObservableCollection<Playlist> Playlists { get; }
        public Command LoadPlaylistsCommand { get; }
        public Command<Playlist> PlaylistTapped { get; }

        public PlaylistsViewModel()
        {
            Title = "Recommended Playlists";
            Playlists = new ObservableCollection<Playlist>();
            LoadPlaylistsCommand = new Command(async () => await ExecuteLoadPlaylistsCommand());

            PlaylistTapped = new Command<Playlist>(OnPlaylistSelected);
        }

        async Task ExecuteLoadPlaylistsCommand()
        {
            IsBusy = true;

            try
            {
                Playlists.Clear();
                var playlists = await new PlaylistDataStore().GetItemsAsync();
                foreach (var playlist in playlists)
                {
                    Playlists.Add(playlist);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        // Here down to do 

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPlaylist = null;
        }

        public Playlist SelectedPlaylist
        {
            get => _selectedPlaylist;
            set
            {
                SetProperty(ref _selectedPlaylist, value);
                OnPlaylistSelected(value);
            }
        }


        async void OnPlaylistSelected(Playlist playlist)
        {
            if (playlist == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PlaylistDetailPage)}?{nameof(PlaylistDetailViewModel.PlaylistID)}={playlist.PlaylistID}");
        }
    }
}
