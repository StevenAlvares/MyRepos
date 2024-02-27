using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MiApp.ViewModels
{
    public class ReproductorViewModel : INotifyPropertyChanged
    {
        private bool _estaReproduciendo;
        public bool EstaReproduciendo
        {
            get => _estaReproduciendo;
            set
            {
                if (_estaReproduciendo != value)
                {
                    _estaReproduciendo = value;
                    OnPropertyChanged(nameof(EstaReproduciendo));
                }
            }
        }

        public ObservableCollection<CancionModel> ListaCanciones { get; set; }

        public ICommand VerificarPermisoCommand { get; private set; }
        public ICommand ReproducirCommand { get; private set; }

        public ReproductorViewModel()
        {
            // Inicializa la lista de canciones (puedes cargarlas desde archivos)
            ListaCanciones = new ObservableCollection<CancionModel>
            {
                new CancionModel { Titulo = "Canción 1", Artista = "Artista 1" },
                new CancionModel { Titulo = "Canción 2", Artista = "Artista 2" }
                // Agrega más canciones aquí...
            };

            // Configura los comandos
            VerificarPermisoCommand = new Command(VerificarYRequerirPermiso);
            ReproducirCommand = new Command(ReproducirCancion);
        }

        // Método para verificar y solicitar permiso de acceso a archivos de audio
        private async void VerificarYRequerirPermiso()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.StorageRead>();
                if (status != PermissionStatus.Granted)
                {
                    // El usuario denegó el permiso, maneja esto según tus necesidades
                    // Puedes mostrar un mensaje o guiar al usuario a la configuración de la aplicación.
                    Console.WriteLine("Permiso denegado para acceder a archivos de audio.");
                }
            }
        }

        // Método para reproducir una canción (simulado aquí)
        private void ReproducirCancion()
        {
            // Lógica para reproducir la canción aquí (simulado)
            EstaReproduciendo = !EstaReproduciendo;
            Console.WriteLine($"Canción {(EstaReproduciendo ? "reproducida" : "pausada")}");
        }

        // Resto de la lógica del ViewModel...

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
