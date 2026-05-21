// Esta clase encargará de guardar y cargar los datos de los usuarios
using System.Text.Json;
using System.Text.Json.Nodes;

public class GestorDeDatos
{
    private const string RUTA = "jugadores.json"; 

    public static List<Jugador> CargarJugadores()
    {
        // Si no existe el archivo creamos uno vaciío
        if(!File.Exists(RUTA))
        {
            File.WriteAllText(RUTA, "");
        }
        string lecturaJson = File.ReadAllText(RUTA);
        List<Jugador> jugadores = JsonSerializer.Deserialize<List<Jugador>>(lecturaJson);
        return jugadores;
    }
}