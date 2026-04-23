// Clase totalmente enfocada a generar todas las palabras admitidas en la RAE que tengan una longitud de 5 letras
// Investigar como hacer un archivo externo que filtre todas las palabras de longitud de 5 letras para optimizar el rendimiento del programa

using System;
using System.Collections.Generic;
using System.IO;

public class Diccionario
{
    // En un principio había utilizado Arrays, después de la clase del Jueves pasado decidí probar implementando una lista
    public List<string> PalabrasValidas { get; set; } 

    public Diccionario()
    {
        // Inicializamos la lista
        PalabrasValidas = new List<string>();
    }

    public void CargarPalabras(string archivo)
    {
        // De momento he utilizado la ruta absoluta del ordenador de clase, lo cambiaré para que busque el archivo en la ruta relativa donde se encuentre el proyecto
        string[] lineasDelArchivo = File.ReadAllLines("diccionario.txt");
        
        for (int i = 0; i < lineasDelArchivo.Length; i++)
        {
            string linea = lineasDelArchivo[i];
            string palabraLimpia = linea.Trim().ToUpper();

            if (palabraLimpia.Length == 5)
            {
                // Tenemos que realizar una comprobación ya que las listas permiten valores duplicados, no como los arrays

                if (!PalabrasValidas.Contains(palabraLimpia))
                {
                    PalabrasValidas.Add(palabraLimpia);
                    Console.WriteLine(palabraLimpia);
                }
            }
        }
    }

    // Esta función comprueba que la palabra introducida exista en el diccionario, evitando palabras inventadas
    public bool EsPalabraValida(string palabra)
    {
        // Normalizamos la palabra quitando espacios y convirtiéndola a mayúsculas
        string palabraIntroducida = palabra.Trim().ToUpper();

        // En caso de encontrarla devuelve true
        return PalabrasValidas.Contains(palabraIntroducida); 
    }

    // Esta función escogerá una palabra aleatoria de la lista en la que tenemos todas las palabras
    public string ObtenerPalabraAleatoria()
    {
        // Clase random para generar el número
        Random generarNumero = new Random(); 
        // Elegimos un numero aleatorio entre la longitud de la lista
        int numeroAleatorio = generarNumero.Next(0, PalabrasValidas.Count);
        // Devolvemos la palabra aleatoria
        return PalabrasValidas[numeroAleatorio];
    }
}