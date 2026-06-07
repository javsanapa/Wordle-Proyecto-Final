// Clase que comprueba que la palabra introducida por el usuario es valida usando expresiones regulares
using System.Text.RegularExpressions;

public class Validador
{
    public static bool EsPalabraValida(string intento)
    {
        // Early return si ha dejado el input vacio
        if(string.IsNullOrWhiteSpace(intento))
        {
            return false;
        }
        
        Regex regexPalabra = new Regex(@"^[a-zA-ZñÑ]{5}$");
        return regexPalabra.IsMatch(intento);
    }
}