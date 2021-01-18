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
