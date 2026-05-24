// Esta clase esta totlamente enfocada al inicio del programa, con su interfaz de usuario y sus correspondientes opciones

public class Juego
{
    // Necesitamos estas dos variables privadas para identificar al jugador y tener acceso a todos los jugadores
    // Para hacer una comprobación de qué perfiles existen
    private List<Jugador> jugadores;
    private Jugador jugadorActivo;
    public Juego()
    {
        jugadores = GestorDeDatos.CargarJugadores();
        jugadorActivo = null;
    }
    public void MostrarMenuPrincipal()
    {
        bool salir = false;

        while (!salir)
        {

            Console.Clear();

            Console.WriteLine("====================================");
            Console.WriteLine("     Adivina la palabra secreta     ");
            Console.WriteLine("====================================");

            // Damos la bienvenida al jugador cuando ya esté registrado
            if (jugadorActivo != null)
            {
                Console.WriteLine($" Jugador: {jugadorActivo.Nombre}");
            }
            Console.WriteLine("1- Jugar nueva partida");
            Console.WriteLine("2- Ver mi perfil / Estadísticas");
            Console.WriteLine("3- Introducir nombre");
            Console.WriteLine("4- Salir");
            Console.WriteLine("====================================");
            Console.WriteLine("Selecciona una opción");

            int opcion = 0;

            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                while (opcion != 1 && opcion != 2 && opcion != 3 && opcion != 4)
                {
                    Console.WriteLine("Elige una opción correcta (1,2,3,4)");
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Estoy probando a añadir manejo de errores con try catch que vimos el jueves pasado
            catch
            {
                Console.WriteLine("Error: Elige una opción correcta (1,2,3)");
            }

            switch (opcion)
            {
                case 1:

                    // Early return si no hay un jugador activo
                    if (jugadorActivo == null)
                    {
                        Console.WriteLine("Debes introducir un nombre para jugar!");
                        Console.WriteLine("Pulsa ENTER para volver al menú...");
                        Console.ReadLine();
                        break;
                    }
                    // Instanciamos el diccionario
                    Diccionario miDiccionario = new Diccionario();
                    // Llamamos a la función que carga todas las palabras del diccionario
                    miDiccionario.CargarPalabras("diccionario.txt");
                    // Instanciamos la partida
                    Partida nuevaPartida = new Partida(miDiccionario);
                    bool victoria = nuevaPartida.Iniciar();

                    if (victoria)
                    {
                        jugadorActivo.RegistrarVictoria();
                    }
                    else
                    {
                        jugadorActivo.RegistrarDerrota();
                    }
                    // Guardamos el resultado de la partida en el JSON para vincular las estadísticas
                    GestorDeDatos.GuardarJugadores(jugadores);
                    break;


                case 2:
                    // Early return si no hay un jugador activo
                    if (jugadorActivo == null)
                    {
                        Console.WriteLine("Debes introducir un nombre para jugar!");
                        Console.WriteLine("Pulsa ENTER para volver al menú...");
                        Console.ReadLine();
                    }
                    else
                    {
                        jugadorActivo.MostrarEstadisticas();
                        Console.WriteLine("Pulsa ENTER para volver al menú...");
                        Console.ReadLine();
                    }
                    break;

                case 3:
                    Console.Write("Introduce tu nombre:");
                    string nombre = Console.ReadLine().Trim().ToUpper();
                    // Mi idea era hacerlo con un foreach, pero buscando encontre esta expresión lambda que simplifica mucho el código
                    Jugador encontrado = jugadores.FirstOrDefault(j => j.Nombre == nombre);
                    if (encontrado != null)
                    {
                        jugadorActivo = encontrado;
                        Console.WriteLine($"¡Bienvenido de nuevo, {jugadorActivo.Nombre}!");
                    }
                    else
                    {
                        // En caso de que en nuestro JSON no esté ese nombre instanciamos el jugador solo con el nombre
                        // Por eso en jugador he utilizado dos constructores
                        Jugador nuevo = new Jugador(nombre);
                        jugadores.Add(nuevo);
                        jugadorActivo = nuevo;
                        // Guardamos en el JSON
                        GestorDeDatos.GuardarJugadores(jugadores);
                        Console.WriteLine($"Perfil '{nombre}' creado. ¡Bienvenido, {jugadorActivo.Nombre}!");
                        Console.WriteLine("Pulsa ENTER para volver al menú...");
                        Console.ReadLine();
                    }
                    break;

                case 4:
                    salir = true;
                    break;
            }
        }
    }
}