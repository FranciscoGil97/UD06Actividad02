using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UD06Actividad02
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Mensajes> mensajes;
        public MainWindow()
        {
            InitializeComponent();

            mensajes = new ObservableCollection<Mensajes>();

            listaMensajesItemsControl.DataContext = mensajes;
        }
        private void Enviar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mensajes.Add(new Mensajes(Mensajes.Emisor.Usuario, mensajeUsuarioTextBox.Text));
            mensajes.Add(new Mensajes(Mensajes.Emisor.Bot));
            mensajeUsuarioTextBox.Text = "";
        }

        private void Enviar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mensajeUsuarioTextBox != null && mensajeUsuarioTextBox.Text != "";
        }

        private void NuevaConversacion_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (mensajes.Count > 0)
                mensajes = new ObservableCollection<Mensajes>();

            listaMensajesItemsControl.DataContext = mensajes;
        }

        private void NuevaConversacion_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaMensajesItemsControl != null)
                e.CanExecute = listaMensajesItemsControl.Items.Count > 0;
        }

        private void Guardar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string urlArchivo = "";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if ((bool)saveFileDialog.ShowDialog())
                {
                    urlArchivo = saveFileDialog.FileName;

                    StringBuilder mensajesChat = new StringBuilder();
                    for (int i = 0; i < listaMensajesItemsControl.Items.Count; i++)
                    {
                        Mensajes mensaje = ((Mensajes)listaMensajesItemsControl.Items[i]);
                        mensajesChat.Append(mensaje._Emisor + ": " + mensaje.Mensaje + "\n");
                    }

                    File.WriteAllText(urlArchivo, mensajesChat.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Guardar_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaMensajesItemsControl != null)
                e.CanExecute = listaMensajesItemsControl.Items.Count > 0;
        }

        private void Salir_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Salir_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Configuracion_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException("Este evento aun no está implementado");
        }

        private void Configuracion_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
        }

        private void ComprobarConexion_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string messageBoxText = "Conexión correcta con el servidor del Bot";
            string caption = "Comprobar conexión";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void ComprobarConexion_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

    }
}
