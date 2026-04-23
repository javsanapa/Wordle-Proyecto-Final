// Esta clase esta totlamente enfocada al inicio del programa, con su interfaz de usuario y sus correspondientes opciones

public class Juego
{
    public void MostrarMenuPrincipal()
    {
        bool salir = false;

        
            Console.Clear();

            Console.WriteLine("====================================");
            Console.WriteLine("     Adivina la palabra secreta     ");
            Console.WriteLine("====================================");
            Console.WriteLine("1- Jugar nueva partida");
            Console.WriteLine("2- Ver mi perfil / Estadísticas");
            Console.WriteLine("3- Salir");
            Console.WriteLine("====================================");
            Console.WriteLine("Selecciona una opción");

        while (!salir)
        {
            int opcion = 0;
        
            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                while (opcion != 1 && opcion != 2 && opcion != 3)
                {
                    Console.WriteLine("Elige una opción correcta (1,2,3)");
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Estoy probando a añadir manejo de errores con try catch que vimos el jueves pasado
            catch
            {
                Console.WriteLine("Error: Elige una opción correcta (1,2,3)");
            }

                switch(opcion)
                {
                    case 1: 
                    Console.WriteLine("");
                    break;

                    case 2:
                    Console.WriteLine("");
                    break;

                    case 3:
                    Console.WriteLine("");
                    salir = true;
                    break;
                }
        }
    }
}