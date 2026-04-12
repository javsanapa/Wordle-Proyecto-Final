public class Partida
{
    private Diccionario diccionarioPartida;

    public Partida(Diccionario diccionario)
    {
        diccionarioPartida = diccionario;
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
}