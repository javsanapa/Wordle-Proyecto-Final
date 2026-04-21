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
            
            try
            {
                intento = Console.ReadLine();

                // Validamos que la palabra no esté en blanco
                if (intento == "")
                {
                    throw new Exception("No puedes dejar la palabra en blanco.");
                }

                // Validamos que la palabra tenga una longitud exacta de 5
                if (intento.Length != 5)
                {
                    throw new Exception("La palabra debe tener exactamente 5 letras.");
                }

                // Controlamos que la palabra no contenga ningún numero para reforzar la validación
                for (int i = 0; i < intento.Length; i++)
                {
                    // Con la función char.IsDigit podemos comprobar que [i] sea un caracter numérico
                    if (char.IsDigit(intento[i]))
                    {
                        throw new Exception("No se permiten números, solo letras.");
                    }
                }

                // Bloqueamos palabras inventadas usando la función que hemos creado en la clase Diccionario
                if (!diccionarioPartida.EsPalabraValida(intento))
                {
                    throw new Exception("Esa palabra no existe en el diccionario de la RAE.");
                }

                esPalabraValida = true;
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
        }

        return intento.ToUpper();
    }

    public void ContadorIntentos()
    {
        Console.Clear();
        Console.WriteLine("¡EMPIEZA EL JUEGO!");
        Console.WriteLine("Adivina la palabra de 5 letras.");

        // El bucle de los 6 intentos como máximo
        while (IntentoActual < INTENTOS_MAXIMOS)
        {
            Console.WriteLine($"--- Intento {IntentoActual + 1} de {INTENTOS_MAXIMOS} ---");
            
            // Pedimos la palabra
            string palabraJugada = PedirPalabraUsuario();
            
            Console.WriteLine($"Has jugado: {palabraJugada}");

            // El contador suma 1 por cada palabra que pida el programa
            IntentoActual++;
        }

        Console.WriteLine("Has alcanzado el número máximo de intentos. ¡Fin de la partida!");
        Console.WriteLine("Pulsa ENTER para volver al menú principal...");
        Console.ReadLine();
    }
}