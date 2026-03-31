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
        string[] lineasDelArchivo = File.ReadAllLines("/home/jossanapa3/ConsoleApp1/si/Wordle/s.txt");
        
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
}