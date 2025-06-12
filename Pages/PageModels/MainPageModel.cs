using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TopMusic.Models;
using System.Windows.Input;

namespace TopMusic.PageModels
{
    public partial class MainPageModel
    {
        // Comando que navegará al Top10Page
        public ICommand StartCommand { get; set; }

        public MainPageModel()
        {
            // Configuramos el comando para navegar al Top10Page
            StartCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("Top10Page");
            });
        }
    }
}