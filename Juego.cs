public class Juego
{
    public void MostrarMenuPrincipal()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();

            Console.WriteLine("====================================");
            Console.WriteLine("     Adivina la palabra secreta     ");
            Console.WriteLine("====================================");
            Console.WriteLine("1- Jugar nueva partida");
            Console.WriteLine("2- Ver mi perfil / Estadísticas");
            Console.WriteLine("3- Salir");
            Console.WriteLine("====================================");
            Console.WriteLine("Selecciona una opción");

            int opcion = 0;

            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                while (opcion != 1 && opcion != 2 && opcion != 3)
                {
                    Console.WriteLine("Elige una opción correcta (1,2,3)");
                    opcion = Convert.ToInt32(Console.ReadLine());
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

            catch
            {
                Console.WriteLine("Error: No se pueden utilizar opciones diferentes");
            }

            if (!salir)
            {
                Console.WriteLine("\nPulsa ENTER para continuar...");
                Console.ReadLine(); 
            }
        }
    }
}