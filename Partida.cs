using System.Net.Http.Headers;

public class Partida
{
    // He decidido utilizar una constante ya que siempre van a ser máximo 6 intentos
    public const int INTENTOS_MAXIMOS = 6;

    // Asignamos 0 por defecto para empezar a sumar 1 en cada intento
    public int IntentoActual { get; private set; } = 0;
    private Diccionario diccionarioPartida;
    private string palabraSecreta;


    public Partida(Diccionario diccionario)
    {
        diccionarioPartida = diccionario;
        palabraSecreta = diccionarioPartida.ObtenerPalabraAleatoria();
    }

    private string PedirPalabraUsuario()
    {
        bool esPalabraValida = false;
        string intento = "";

        while (!esPalabraValida)
        {
            Console.WriteLine("Introduce tu palabra (5 letras): ");
            intento = Console.ReadLine();

            // Verificamos que la palabra sea valida
            if (!Validador.EsPalabraValida(intento))
            {
                Console.WriteLine("La palabra debe tener exactamente 5 letras y contener solo letras.");
            }
            // Verificamos que la palabra exista en el Diccionario
            else if (!diccionarioPartida.EsPalabraValida(intento))
            {
                Console.WriteLine("Esa palabra no existe en el diccionario de la RAE.");
            }
            // En caso de que haya pasado las dos comprobaciones salimos del bucle
            else
            {
                esPalabraValida = true;
            }
        }
        return intento.ToUpper();
    }

    public void ContadorIntentos()
    {
        Console.Clear();
        Console.WriteLine("¡EMPIEZA EL JUEGO!");
        Console.WriteLine(palabraSecreta);
        Console.WriteLine("Adivina la palabra de 5 letras.");

        // Boleano que servirá para la pantalla de victoria
        bool palabraAcertada = false;

        // El bucle de los 6 intentos como máximo
        while (IntentoActual < INTENTOS_MAXIMOS && !palabraAcertada)
        {
            Console.WriteLine($"--- Intento {IntentoActual + 1} de {INTENTOS_MAXIMOS} ---");

            // Pedimos la palabra
            string palabraJugada = PedirPalabraUsuario();

            // Cambiamos el WriteLine por la función que hemos creada
            EvaluarIntento(palabraJugada);
            // Si acierta la palabra ponemos el booleano a true para cargar el código de la victoria
            if (palabraJugada == palabraSecreta)
            {
                palabraAcertada = true;
            }

            // El contador suma 1 por cada palabra que pida el programa
            IntentoActual++;
        }

        // Usuario gana
        if (palabraAcertada)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Felicidades! Has adivinado la palabra: {palabraSecreta} en {IntentoActual} intentos");
            Console.WriteLine("Pulsa ENTER para volver al menú principal...");
            Console.ReadLine();
        }
        // Usuario pierde
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Has alcanzado el número máximo de intentos. ¡Fin de la partida!");
            Console.WriteLine($"La palabra era: {palabraSecreta}");
            Console.WriteLine("Pulsa ENTER para volver al menú principal...");
            Console.ReadLine();
        }


    }

    // Esta función comprueba todos los estados de las letras pero NO identifica duplicados por lo cual no está completa
    private void EvaluarIntento(string intento)
    {
        for (int i = 0; i < 5; i++)
        {
            if (intento[i] == palabraSecreta[i])
            {
                // Letra correcta en posición correcta = VERDE
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (palabraSecreta.Contains(intento[i]))
            {
                // La letra está en la palabra pero en otra posición = AMARILLA
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                // La letra no está en la palabra = GRIS
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }

            Console.Write(intento[i]);
        }

        Console.ResetColor();
        Console.WriteLine("\n");
    }
}