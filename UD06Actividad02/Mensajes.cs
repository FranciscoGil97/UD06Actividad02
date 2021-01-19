using System.ComponentModel;

namespace UD06Actividad02
{
    public class Mensajes : INotifyPropertyChanged
    {
        public enum Emisor { Hombre, Mujer, Bot }

        public enum Sexo { Hombre, Mujer }

        public Mensajes(Emisor emisor, string mensaje)
        {
            _Emisor = emisor;
            Mensaje = mensaje;
        }

        private Emisor emisor;
        private string mensaje;

        public Emisor _Emisor
        {
            get { return emisor; }
            set
            {
                emisor = value;
                NotifyPropertyChanged("_Emisor");
            }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set
            {
                mensaje = value;
                NotifyPropertyChanged("Mensaje");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
