using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TopMusic.Models;

namespace TopMusic.Services
{
    class DataService
    {
        public async Task<List<Artist>> GetArtists()
        {
            // Abrimos el archivo JSON desde los recursos de la app
            using var stream = await FileSystem.OpenAppPackageFileAsync("music.json");

            // Creamos un lector para leer el contenido del archivo
            using var reader = new StreamReader(stream);

            // Leemos todo el contenido del archivo JSON como texto
            var contenido = await reader.ReadToEndAsync();

            // Deserializamos el texto JSON a una lista de objetos Artista
            // JsonSerializer mapea directamente las propiedades del JSON a las propiedades de las clases
            return JsonSerializer.Deserialize<List<Artist>>(contenido);
        }
    }
}
