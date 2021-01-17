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
            sexoUsuarioComboBox.ItemsSource = Enum.GetValues(typeof(Mensajes.Emisor));

            colorFondoComboBox.ItemsSource = typeof(Colors).GetProperties();
            colorUsuarioComboBox.ItemsSource = typeof(Colors).GetProperties();
            colorBotComboBox.ItemsSource = typeof(Colors).GetProperties();
        }
    }
}
