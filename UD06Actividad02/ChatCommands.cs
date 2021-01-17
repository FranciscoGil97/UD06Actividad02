using System.Windows.Input;

namespace UD06Actividad02
{
    public static class ChatCommands
    {
        public static readonly RoutedUICommand Enviar = new RoutedUICommand
        (
            "Enviar",
            "Enviar",
            typeof(ChatCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter)
            }
        );

        public static readonly RoutedUICommand NuevaConversacion = new RoutedUICommand
        (
            "NuevaConversacion",
            "NuevaConversacion",
            typeof(ChatCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.N,ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Guardar = new RoutedUICommand
        (
            "Guardar",
            "Guardar" +
            "",
            typeof(ChatCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.G,ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Salir = new RoutedUICommand
        (
            "Salir",
            "Salir",
            typeof(ChatCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S,ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Configuracion = new RoutedUICommand
        (
            "Configuracion",
            "Configuracion",
            typeof(ChatCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.C,ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand ComprobarConexion = new RoutedUICommand
        (
            "ComprobarConexion",
            "ComprobarConexion",
            typeof(ChatCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.O,ModifierKeys.Control)
            }
        );




    }
}
