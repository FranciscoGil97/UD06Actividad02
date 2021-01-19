using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace UD06Actividad02
{
    public partial class Configuracion : Window
    {
        public string ColorFondo { get; set; }
        public string ColorUsuario { get; set; }
        public string ColorBot { get; set; }
        public string Sexo { get; set; }

        public Configuracion()
        {
            InitializeComponent();
            DataContext = this;

            colorFondoComboBox.ItemsSource = typeof(Colors).GetProperties();
            colorUsuarioComboBox.ItemsSource = typeof(Colors).GetProperties();
            colorBotComboBox.ItemsSource = typeof(Colors).GetProperties();
            sexoUsuarioComboBox.ItemsSource = Enum.GetNames(typeof(Mensajes.Sexo));
        }

        private void AceptarConfiguracionButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }


    }
}
