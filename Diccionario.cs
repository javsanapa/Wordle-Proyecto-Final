using System;
using System.Collections.Generic;
using System.IO;
public class Diccionario
{
    public string[] PalabrasValidas {get; set;}

    public int TotalPalabras {get; set;}

    public Diccionario()
    {
        TotalPalabras = 0;
    }

    public void CargarPalabras(string archivo)
    {
        string[] lineasDelArchivo = File.ReadAllLines("/home/jossanapa3/ConsoleApp1/si/Wordle/s.txt");
        PalabrasValidas = new string[lineasDelArchivo.Length];

        for(int i = 0; i < lineasDelArchivo.Length; i++)
        {
            string linea = lineasDelArchivo[i];
            string palabraLimpia = linea.Trim().ToUpper();

            if(palabraLimpia.Length == 5)
            {
                PalabrasValidas[TotalPalabras] = palabraLimpia;
                TotalPalabras++;
                Console.WriteLine(palabraLimpia);
            }
        }
    }
}