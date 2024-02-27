using System.ComponentModel; // Necesario para INotifyPropertyChanged

namespace MiApp.ViewModels
{
    public class CancionModel : INotifyPropertyChanged
    {
        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set
            {
                if (_titulo != value)
                {
                    _titulo = value;
                    OnPropertyChanged(nameof(Titulo));
                }
            }
        }

        private string _artista;
        public string Artista
        {
            get => _artista;
            set
            {
                if (_artista != value)
                {
                    _artista = value;
                    OnPropertyChanged(nameof(Artista));
                }
            }
        }

        // Puedes agregar más propiedades según tus necesidades (por ejemplo, duración, género, etc.).

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
