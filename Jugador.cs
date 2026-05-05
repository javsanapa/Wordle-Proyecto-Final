public class Jugador
{
    public string Nombre {get; set;}
    public int Victorias {get; set;}
    public int Racha {get; set;}
    public int PartidasJugadas {get; set;}

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Victorias = 0;
        Racha = 0;
        PartidasJugadas = 0;
    }
}