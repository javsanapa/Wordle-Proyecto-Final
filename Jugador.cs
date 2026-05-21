public class Jugador
{
    public string Nombre {get; set;}
    public int Victorias {get; set;}
    public int Racha {get; set;}
    public int PartidasJugadas {get; set;}

    // Necesitamos este constructor para que serializer funcione
    public Jugador()
    {
        Nombre = "";
    }
    public Jugador(string nombre)
    {
        Nombre = nombre;
        Victorias = 0;
        Racha = 0;
        PartidasJugadas = 0;
    }

    public void RegistrarVictoria()
    {
        PartidasJugadas++;
        Victorias++;
        Racha++;
    }

    public void RegistrarDerrota()
    {
        PartidasJugadas++;
        Racha = 0;
    }

    public void MostrarEstadisticas()
    {
        Console.WriteLine($"\n--- ESTADÍSTICAS DE {Nombre.ToUpper()} ---");
        Console.WriteLine($"Partidas jugadas: {PartidasJugadas}");
        Console.WriteLine($"Victorias: {Victorias}");
        Console.WriteLine($"Racha actual: {Racha}");

        if(PartidasJugadas > 0)
        {
            double porcentajeVictorias = ((double)Victorias / PartidasJugadas) * 100;
            Console.WriteLine($"% de Victorias: {porcentajeVictorias}");
        }
    }
}