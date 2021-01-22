using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace UD06Actividad02
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Mensajes> mensajes;


        public MainWindow()
        {
            mensajes = new ObservableCollection<Mensajes>();
            InitializeComponent();


            listaMensajesItemsControl.DataContext = mensajes;
        }
        private async void Enviar_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mensajes.Add(new Mensajes((Mensajes.Emisor)Enum.Parse(typeof(Mensajes.Emisor), Properties.Settings.Default.Emisor), mensajeUsuarioTextBox.Text));
            mensajes.Add(new Mensajes(Mensajes.Emisor.Bot, "Procesando..."));

            string pregunta = mensajeUsuarioTextBox.Text;
            mensajeUsuarioTextBox.Text = "";
            await ObtenRespuestaBotAsync(pregunta, mensajes.Count - 1);

        }

        private async Task ObtenRespuestaBotAsync(string pregunta, int indice)
        {
            try
            {
                string EndPoint = Properties.Settings.Default.EndPoint;
                string EndPointKey = Properties.Settings.Default.EndPointKey;
                string KnowledgeBaseId = Properties.Settings.Default.KnowledgeBaseId;
                QnAMakerRuntimeClient cliente = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(EndPointKey)) { RuntimeEndpoint = EndPoint };

                //Realizamos la pregunta a la API
                QnASearchResultList response = await (cliente.Runtime.GenerateAnswerAsync(KnowledgeBaseId, new QueryDTO { Question = pregunta }));
                string respuesta = response.Answers[0].Answer;
                mensajes[indice].Mensaje = respuesta;
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.Message;
                string caption = "Error Bot";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show(messageBoxText, caption, button, icon);
                mensajes[indice].Mensaje = "No he podifo obtener una respuesta.";
            }
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

            Configuracion dialogoConfiguracion = new Configuracion();

            dialogoConfiguracion.ColorFondo =
                Properties.Settings.Default.ColorFondo;
            dialogoConfiguracion.ColorUsuario =
                Properties.Settings.Default.ColorUsuario;
            dialogoConfiguracion.ColorBot =
                Properties.Settings.Default.ColorBot;
            dialogoConfiguracion.Sexo =
                Properties.Settings.Default.Emisor;

            dialogoConfiguracion.Owner = this;

            if ((bool)dialogoConfiguracion.ShowDialog())
            {
                Properties.Settings.Default.ColorFondo = dialogoConfiguracion.ColorFondo;
                Properties.Settings.Default.ColorUsuario = dialogoConfiguracion.ColorUsuario;
                Properties.Settings.Default.ColorBot = dialogoConfiguracion.ColorBot;
                Properties.Settings.Default.Emisor = dialogoConfiguracion.Sexo;

                Properties.Settings.Default.Save();
            }

        }

        private void Configuracion_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private async void ComprobarConexion_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string EndPoint = Properties.Settings.Default.EndPoint;
                string EndPointKey = Properties.Settings.Default.EndPointKey;
                string KnowledgeBaseId = Properties.Settings.Default.KnowledgeBaseId;
                QnAMakerRuntimeClient cliente = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(EndPointKey)) { RuntimeEndpoint = EndPoint };

                //Realizamos la pregunta a la API
                QnASearchResultList response = await(cliente.Runtime.GenerateAnswerAsync(KnowledgeBaseId, new QueryDTO { Question = "Hola" }));
                _ = response.Answers[0].Answer;

                string messageBoxText = "Conexión correcta con el servidor del Bot";
                string caption = "Comprobar conexión";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            catch (Exception)
            {
                string caption = "Error Bot";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBox.Show("No se ha podido establecer la conexión con el servidor del bot", caption, button, icon);
            }
        }

        private void ComprobarConexion_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
