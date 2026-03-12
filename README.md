# 🟩🟨⬜ Adivina la Palabra (Wordle)

Este repositorio contiene el Proyecto Final para el módulo de Programación del **1º curso de FP Grado Superior DAW (Desarrollo de Aplicaciones Web)**. 

Desarrollado en el **IES Miguel Ballesteros Viana**.

## 📖 Descripción del Proyecto

"Adivina la Palabra" es un videojuego de lógica y vocabulario ejecutado íntegramente por consola. Está inspirado en las mecánicas del popular juego *Wordle*. 

El objetivo del jugador es adivinar una palabra secreta de cinco letras en un máximo de seis intentos. Tras cada intento, el programa evalúa la palabra introducida y proporciona retroalimentación visual mediante colores en la terminal:
* **Verde (Correcto):** La letra está en la palabra y en la posición correcta.
* **Amarillo (Presente):** La letra pertenece a la palabra, pero está en una posición errónea.
* **Gris (Ausente):** La letra no pertenece a la palabra a adivinar.

## ✨ Funcionalidades Principales

* **Menú Interactivo y Robusto:** Interfaz de consola con protección contra entradas inválidas mediante control de excepciones (`try-catch`).
* **Gestión de Diccionario Dinámica:** Lectura de palabras desde un archivo de texto local (`.txt`), almacenando y filtrando en memoria únicamente aquellas de 5 letras mediante Arrays.
* **Motor Lógico Avanzado:** Algoritmo que compara los intentos del usuario con la palabra secreta, resolviendo el problema de los "falsos positivos" con letras repetidas.
* **Sistema de Usuarios y Estadísticas:** Registro de perfiles para guardar las partidas jugadas, el porcentaje de victorias y la racha actual de cada jugador.

## 🛠️ Tecnologías Utilizadas

El proyecto está desarrollado completamente en **C#** bajo la plataforma **.NET**, aplicando estrictamente el paradigma de la **Programación Orientada a Objetos (POO)**:

* **POO:** Clases principales como `Juego`, `Jugador`, `Partida` y `Diccionario`. Uso de encapsulación y modificadores de acceso.
* **Estructuras de Datos:** Uso de Arrays clásicos (`string[]`) y variables contadoras para la gestión en memoria estática.
* **Manejo de Ficheros (I/O):** Lectura del diccionario de texto completo (`File.ReadAllLines` del espacio de nombres `System.IO`).
* **Control de Versiones:** Repositorio gestionado con **Git** para el registro del progreso.

## 🚀 Cómo ejecutar el proyecto

1. Asegúrate de tener instalado el SDK de .NET en tu equipo.
2. Clona este repositorio:

   ```bash
   git clone [https://github.com/TU_USUARIO/TU_REPOSITORIO.git](https://github.com/TU_USUARIO/TU_REPOSITORIO.git)
