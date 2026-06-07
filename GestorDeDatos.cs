// Esta clase se encargará de guardar y cargar los datos de los usuarios
using System.Text.Json;

public class GestorDeDatos
{
    private const string RUTA = "jugadores.json";

    public static List<Jugador> CargarJugadores()
    {
        // Si no existe el archivo creamos uno vacío
        if (!File.Exists(RUTA))
        {
            File.WriteAllText(RUTA, "[]");
        }
        string lecturaJson = File.ReadAllText(RUTA);
        // Deserialize puede devolver null (p. ej. si el archivo contiene "null"),
        // así que devolvemos una lista vacía en ese caso.
        List<Jugador> jugadores = JsonSerializer.Deserialize<List<Jugador>>(lecturaJson);
        return jugadores ?? new List<Jugador>();
    }

    public static void GuardarJugadores(List<Jugador> jugadores)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;
        string datos = JsonSerializer.Serialize(jugadores, options);
        File.WriteAllText(RUTA, datos);
    }
}