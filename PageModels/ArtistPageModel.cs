using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TopMusic.Models;
using TopMusic.Services;

namespace TopMusic.PageModels
{
    public class Top10PageModel : INotifyPropertyChanged
    {
        public ObservableCollection<Artist> Artists { get; set; } = new ObservableCollection<Artist>();

        private Artist _selectedArtist;
        public Artist SelectedArtist
        {
            get => _selectedArtist;
            set
            {
                if (_selectedArtist != value)
                {
                    _selectedArtist = value;
                    OnPropertyChanged(nameof(SelectedArtist));

                    if (_selectedArtist != null)
                    {
                        // Navegación cuando cambia la selección
                        Shell.Current.GoToAsync(nameof(ArtistPage), new Dictionary<string, object>
                    {
                        { "Artista", _selectedArtist }
                    });

                        // Limpia la selección para poder volver a seleccionar el mismo artista después
                        SelectedArtist = null;
                    }
                }
            }
        }

        public Top10PageModel()
        {
            // No se puede usar await en el constructor, así que iniciamos la tarea de forma no bloqueante.
            LoadArtists();
        }

        private async void LoadArtists()
        {
            var dataService = new DataService();
            var artists = await dataService.GetArtists();

            foreach (var artist in artists)
                Artists.Add(artist);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
