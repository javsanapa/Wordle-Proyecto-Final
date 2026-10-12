using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;

namespace Wordle;

// Ventana principal del juego, gestiona el jugador activo, la partida en curso
// (palabra secreta, intentos, tablero) y las estadísticas.
public partial class MainWindow : Window
{
    // Número de intentos máximos del jugador antes de perder la partida.
    public const int INTENTOS_MAXIMOS = 6;

    // Array bidimensional que representa las filas y columnas.
    // Guardamos las 30 celdas
    private TextBlock[,] celdas = new TextBlock[INTENTOS_MAXIMOS, 5];
    // Bordes que contienen cada celda, guardan el color de fondo de la casilla
    private Border[,] casillas = new Border[INTENTOS_MAXIMOS, 5];

    private Diccionario diccionarioPartida = new Diccionario();
    private List<Jugador> jugadores;
    private Jugador jugadorActivo = null;
    private string palabraSecreta = "";
    private int intentoActual = 0;

    // Indica si hay una partida activa esperando intentos del jugador
    private bool partidaEnCurso = false;

    // Al abrir el juego inicializa los controles, carga jugadores y diccionario
    // desde disco, y construye el tablero
    public MainWindow()
    {
        InitializeComponent();
        jugadores = GestorDeDatos.CargarJugadores();
        diccionarioPartida.CargarPalabras("diccionario.txt");
        CrearGridLetras();
    }

    // Construye el tablero como una cuadrícula de TextBlock
    // y los guarda en un array bidimensional llamado 'celdas' para poder actualizarlos durante la partida
    private void CrearGridLetras()
    {
        // Recorremos las filas que representan los intentos máximos del jugador
        for (int fila = 0; fila < INTENTOS_MAXIMOS; fila++)
        {
            StackPanel filaSP = new StackPanel();
            filaSP.Orientation = Orientation.Horizontal;
            filaSP.Spacing = 5;

            // Anidamos otro bucle con las 5 columnas para las 5 letras
            for (int col = 0; col < 5; col++)
            {
                // El Border es la casilla de tamaño fijo y lleva el color de fondo;
                // el TextBlock va dentro centrado en horizontal y vertical
                Border casilla = new Border();
                casilla.Width = 54;
                casilla.Height = 54;
                // El color de fondo lo ponemos con Brushes ya que luego cambiará durante el juego
                casilla.Background = Brushes.LightGray;

                TextBlock tb = new TextBlock();
                tb.FontSize = 22;
                tb.FontWeight = FontWeight.Bold;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                tb.VerticalAlignment = VerticalAlignment.Center;
                casilla.Child = tb;

                celdas[fila, col] = tb;
                casillas[fila, col] = casilla;
                filaSP.Children.Add(casilla);
            }

            GridLetras.Children.Add(filaSP);
        }
    }

    // Maneja el inicio de sesión del jugador, buscando un jugador existente por nombre
    // Si no encuentra uno crea uno nuevo, dejando habilitados los botones de juego
    private void Confirmar_Click(object? sender, RoutedEventArgs e)
    {
        // ?? Hace que no pete el programa al dejar vacio el nombre introducido y pulsar el botón
        string nombre = InputNombre.Text ?? "";
        nombre = nombre.Trim().ToUpper();
        if (string.IsNullOrEmpty(nombre))
        {
            return;
        }

        // Usamos una expresion LAMBDA  que busca en la lista el primer jugador
        // que cumpla la condición, si no creamos un jugador nuevo
        Jugador encontrado = jugadores.FirstOrDefault(j => j.Nombre == nombre);
        if (encontrado != null)
        {
            jugadorActivo = encontrado;
        }
        else
        {
            jugadorActivo = new Jugador(nombre);
            jugadores.Add(jugadorActivo);
            GestorDeDatos.GuardarJugadores(jugadores);
        }

        InfoJugador.Text = $"Jugador: {jugadorActivo.Nombre}";

        BtnNuevaPartida.IsEnabled = true;
        BtnEstadisticas.IsEnabled = true;
        Mensaje.Text = $"¡Bienvenido, {jugadorActivo.Nombre}!";
    }

    // Empieza una partida nueva, elige la palabra secreta y reinicia el contador de
    // Intentos, limpia visualmente el tablero y muestra el panel de entrada
    private void NuevaPartida_Click(object? sender, RoutedEventArgs e)
    {
        palabraSecreta = diccionarioPartida.ObtenerPalabraAleatoria();
        intentoActual = 0;
        partidaEnCurso = true;

        // Recorremos el array bidimensional para limpiar todas las celdas
        for (int fila = 0; fila < INTENTOS_MAXIMOS; fila++)
        {
            for (int col = 0; col < 5; col++)
            {
                celdas[fila, col].Text = "";
                celdas[fila, col].Foreground = Brushes.Black;
                casillas[fila, col].Background = Brushes.LightGray;
            }

        }
        InputPalabra.Text = "";
        PanelInput.IsVisible = true;
        Mensaje.Text = "¡Adivina la palabra de 5 letras!";
    }

    // Procesa el intento introducido por el jugador luego lo valida y pinta la fila
    // Del tablero con los colores correspondientes y comprueba si la
    // partida ha terminado (victoria o sin más intentos)
    private void Enviar_Click(object? sender, RoutedEventArgs e)
    {
        if (!partidaEnCurso)
        {
            return;
        }

        string intento = InputPalabra.Text ?? "";
        intento = intento.Trim().ToUpper();

        // La palabra debe tener 5 letras y existir en el diccionario.txt

        if (!Validador.EsPalabraValida(intento))
        {
            Mensaje.Text = "La palabra debe tener exactamente 5 letras.";
            return;
        }
        if (!diccionarioPartida.EsPalabraValida(intento))
        {
            Mensaje.Text = "Esa palabra no existe en el diccionario.";
            return;
        }

        // Pedimos a Evaluar Intento un array con los colores de la fila
        IBrush[] colores = EvaluarIntento(intento);
        for (int col = 0; col < 5; col++)
        {
            // Accedemos a la celda por su posición
            celdas[intentoActual, col].Text = intento[col].ToString();
            celdas[intentoActual, col].Foreground = Brushes.White;
            casillas[intentoActual, col].Background = colores[col];
        }

        intentoActual++;
        InputPalabra.Text = "";

        // Tras evaluar el intento, el programa comprueba si el jugador ha acertado la palabra
        // También si el jugador se ha quedado sin intentos o si debe seguir jugando
        if (intento == palabraSecreta)
        {
            Mensaje.Text = $"¡Adivinaste en {intentoActual} intento(s)!";
            TerminarPartida(true);
        }
        else if (intentoActual >= INTENTOS_MAXIMOS)
        {
            Mensaje.Text = $"Sin más intentos. La palabra era: {palabraSecreta}";
            TerminarPartida(false);
        }
        else
        {
            Mensaje.Text = $"Intento {intentoActual} de {INTENTOS_MAXIMOS}. ¡Sigue intentando!";
        }
    }

    // Esta función devuelve un array de IBRUSH
    // IBRUSH es la función de avalonia de tipo "color"
    // En vez de devolver los colores de la interfaz de consola devolvemos lo que usa Avalonia
    private IBrush[] EvaluarIntento(string intento)
    {
        IBrush[] colores = new IBrush[5];
        bool[] letraUsada = new bool[5];

        for (int i = 0; i < 5; i++)
        {
            if (intento[i] == palabraSecreta[i])
            {
                colores[i] = Brushes.ForestGreen;
                letraUsada[i] = true;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (colores[i] == Brushes.ForestGreen)
            {
                continue;
            }
            colores[i] = Brushes.DarkGray;

            for (int j = 0; j < 5; j++)
            {
                if (!letraUsada[j] && intento[i] == palabraSecreta[j])
                {
                    colores[i] = Brushes.Goldenrod;
                    letraUsada[j] = true;
                    break;
                }
            }
        }

        return colores;
    }

    // Terminamos la partida actual, ocultamos el panel de entrada, registramos el resultado
    // En las estadísticas del jugador activo y las guarda en el JSON
    private void TerminarPartida(bool victoria)
    {
        partidaEnCurso = false;
        PanelInput.IsVisible = false;

        if (victoria) jugadorActivo.RegistrarVictoria();
        else jugadorActivo.RegistrarDerrota();

        GestorDeDatos.GuardarJugadores(jugadores);
    }

    // Mostramos por pantalla las estadísticas del jugador cuando
    // el jugador hace clic en Estadísticas
    private void Estadisticas_Click(object? sender, RoutedEventArgs e)
    {
        if (jugadorActivo == null)
        {
            return;
        }

        double porcentajeVictorias = 0;
        if (jugadorActivo.PartidasJugadas > 0)
        {
            porcentajeVictorias = Math.Round((double)jugadorActivo.Victorias / jugadorActivo.PartidasJugadas * 100, 2);
        }

        Mensaje.Text =
            $"── Estadísticas de {jugadorActivo.Nombre} ──\n" +
            $"Partidas jugadas: {jugadorActivo.PartidasJugadas}\n" +
            $"Victorias:        {jugadorActivo.Victorias}\n" +
            $"Racha actual:     {jugadorActivo.Racha}\n" +
            $"% de victorias:   {porcentajeVictorias}%";
    }
}