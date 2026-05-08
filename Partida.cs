public class Partida
{
    public const int INTENTOS_MAXIMOS = 6;
    public int IntentoActual { get; private set; } = 0;
    private Diccionario diccionarioPartida;
    private string palabraSecreta;

    public Partida(Diccionario diccionario)
    {
        diccionarioPartida = diccionario;
        palabraSecreta = diccionarioPartida.ObtenerPalabraAleatoria();
    }

    // Coordina el flujo completo de la partida
    public void Iniciar()
    {
        MostrarInicio();
        bool victoria = EjecutarRondas();
        MostrarResultado(victoria);
    }

    private void MostrarInicio()
    {
        Console.Clear();
        Console.WriteLine("¡EMPIEZA EL JUEGO!");
        Console.WriteLine("Adivina la palabra de 5 letras.");
    }

    private bool EjecutarRondas()
    {
        bool palabraAcertada = false;

        while (IntentoActual < INTENTOS_MAXIMOS && !palabraAcertada)
        {
            Console.WriteLine($"--- Intento {IntentoActual + 1} de {INTENTOS_MAXIMOS} ---");

            string palabraJugada = LeerIntento();
            EvaluarIntento(palabraJugada);

            if (palabraJugada == palabraSecreta)
                palabraAcertada = true;

            IntentoActual++;
        }

        return palabraAcertada;
    }

    private void MostrarResultado(bool victoria)
    {
        if (victoria)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"¡Felicidades! Has adivinado la palabra: {palabraSecreta} en {IntentoActual} intentos");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Has alcanzado el número máximo de intentos. ¡Fin de la partida!");
            Console.WriteLine($"La palabra era: {palabraSecreta}");
        }

        Console.ResetColor();
        Console.WriteLine("Pulsa ENTER para volver al menú principal...");
        Console.ReadLine();
    }

    private string LeerIntento()
    {
        bool esPalabraValida = false;
        string intento = "";

        while (!esPalabraValida)
        {
            Console.WriteLine("Introduce tu palabra (5 letras): ");
            intento = Console.ReadLine();

            if (!Validador.EsPalabraValida(intento))
                Console.WriteLine("La palabra debe tener exactamente 5 letras y contener solo letras.");
            else if (!diccionarioPartida.EsPalabraValida(intento))
                Console.WriteLine("Esa palabra no existe en el diccionario de la RAE.");
            else
                esPalabraValida = true;
        }

        return intento.ToUpper();
    }

    private void EvaluarIntento(string intento)
    {
        for (int i = 0; i < 5; i++)
        {
            if (intento[i] == palabraSecreta[i])
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            else if (palabraSecreta.Contains(intento[i]))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            Console.Write(intento[i]);
        }
        Console.ResetColor();
        Console.WriteLine("\n");
    }
}