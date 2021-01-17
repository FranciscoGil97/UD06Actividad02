using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace UD06Actividad02
{
    public partial class Configuracion : Window
    {
        public Configuracion()
        {
            InitializeComponent();

            colorFondoComboBox.ItemsSource = typeof(Colors).GetProperties();
            colorUsuarioComboBox.ItemsSource = typeof(Colors).GetProperties();
            colorBotComboBox.ItemsSource = typeof(Colors).GetProperties();
            sexoUsuarioComboBox.ItemsSource = Enum.GetValues(typeof(Mensajes.Emisor));
            

            colorFondoComboBox.SelectedItem= ((Color)ColorConverter.ConvertFromString(Properties.Settings.Default.ColorFondo));
            //colorUsuarioComboBox.SelectedItem= (Color)ColorConverter.ConvertFromString(Properties.Settings.Default.ColorUsuario);
            //colorBotComboBox.SelectedItem = (Color)ColorConverter.ConvertFromString(Properties.Settings.Default.ColorBot);
            //sexoUsuarioComboBox.SelectedItem = Enum.Parse(typeof(Mensajes.Emisor), Properties.Settings.Default.Emisor);
        }

        private void AceptarConfiguracionButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorFondo = colorFondoComboBox.SelectedItem.ToString();
            Properties.Settings.Default.ColorUsuario = colorUsuarioComboBox.SelectedItem.ToString();
            Properties.Settings.Default.ColorBot = colorBotComboBox.SelectedItem.ToString();
            Properties.Settings.Default.Emisor = sexoUsuarioComboBox.SelectedItem.ToString();


            this.DialogResult = true;
        }

        private void prueba(string color)
        {
            
        }
    }
}
