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
        // Este array guardará el color final de cada letra
        ConsoleColor[] colores = new ConsoleColor[5];
        // Este array de booleanos empieza con todo en false, cuando una letra queda asignada
        // A una letra del intento la marcaremos true para que no se vuelva a usar
        bool[] letraUsada = new bool[5];

        // 1er bucle, solo verdes
        for (int i = 0; i < 5; i++)
        {
            if (intento[i] == palabraSecreta[i])
            {
                colores[i] = ConsoleColor.Green;
                letraUsada[i] = true;
            }
        }

        // 2ndo bucle, amarillas y grises
        for (int i = 0; i < 5; i++)
        {
            // Saltamos las letras que sean verdes, ya que no nos interesan
            if (colores[i] == ConsoleColor.Green)
            {
                continue;
            }
            // Todas las restantes son grises por defecto
            colores[i] = ConsoleColor.DarkGray; 
            for (int j = 0; j < 5; j++)
            {
                // Pintamos de amarilla si la letra está en la palabra y la asignamos como true
                if (!letraUsada[j] && intento[i] == palabraSecreta[j])
                {
                    colores[i] = ConsoleColor.Yellow;
                    letraUsada[j] = true;
                    break;
                }
            }
        }

        // 4to bucle para mostrar todo el intento
        for (int i = 0; i < 5; i++)
        {
            Console.ForegroundColor = colores[i];
            Console.Write(intento[i]);
        }
        Console.ResetColor();
        Console.WriteLine("\n");
    }
}