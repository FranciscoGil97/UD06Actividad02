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
            sexoUsuarioComboBox.ItemsSource = Enum.GetValues(typeof(Mensajes.Sexo));


            colorFondoComboBox.SelectedItem = typeof(Colors).GetProperty(Properties.Settings.Default.ColorFondo);
            colorUsuarioComboBox.SelectedItem = typeof(Colors).GetProperty(Properties.Settings.Default.ColorUsuario);
            colorBotComboBox.SelectedItem = typeof(Colors).GetProperty(Properties.Settings.Default.ColorBot);  
            sexoUsuarioComboBox.SelectedItem = Enum.Parse(typeof(Mensajes.Sexo), Properties.Settings.Default.Emisor);
        }

        private void AceptarConfiguracionButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorFondo = colorFondoComboBox.Text.Substring(colorFondoComboBox.Text.IndexOf(' ')+1);
            Properties.Settings.Default.ColorUsuario = colorUsuarioComboBox.Text.Substring(colorUsuarioComboBox.Text.IndexOf(' ')+1);
            Properties.Settings.Default.ColorBot = colorBotComboBox.Text.Substring(colorBotComboBox.Text.IndexOf(' ')+1);
            Properties.Settings.Default.Emisor = sexoUsuarioComboBox.SelectedItem.ToString();
            Properties.Settings.Default.Save();

            this.DialogResult = true;
        }

        
    }
}
