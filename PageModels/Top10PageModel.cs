using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TopMusic.Models;
using TopMusic.Services;

namespace TopMusic.PageModels
{
    [QueryProperty(nameof(ArtistaName), "Artista")]
    public class ArtistPageModel : INotifyPropertyChanged
    {
        private string _artistaName;
        public string ArtistaName
        {
            get => _artistaName;
            set
            {
                if (_artistaName != value)
                {
                    _artistaName = value;
                    OnPropertyChanged(nameof(ArtistaName));
                    // No se puede poner async en setter, llamamos método async aparte
                    LoadArtistDetails();
                }
            }
        }

        private Artist _artist;
        public Artist Artist
        {
            get => _artist;
            set
            {
                _artist = value;
                OnPropertyChanged(nameof(Artist));
            }
        }

        private async void LoadArtistDetails()
        {
            var dataService = new DataService();
            var artists = await dataService.GetArtists();

            Artist = artists.FirstOrDefault(a => a.Name == ArtistaName);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
