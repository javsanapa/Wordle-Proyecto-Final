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
}