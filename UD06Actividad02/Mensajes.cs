using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD06Actividad02
{
    public class Mensajes : INotifyPropertyChanged
    {
        public enum Emisor { Hombre,Mujer, Bot }

        public Mensajes(Emisor emisor, string mensaje)
        {
            _Emisor = emisor;
            Mensaje = mensaje;
        }

        public Mensajes(Emisor emisor)
        {
            _Emisor = emisor;

            Mensaje = _Emisor == Emisor.Bot ? "Lo siento, estoy un poco cansado para hablar." : "";

        }

        private Emisor emisor;
        private string mensaje;

        public Emisor _Emisor
        {
            get { return emisor; }
            set
            {
                emisor = value;
                NotifyPropertyChanged("Emisor");
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
