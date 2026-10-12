# 🟩🟨⬜ Adivina la Palabra (Wordle)

Este repositorio contiene el Proyecto Final para el módulo de Programación del **1º curso de FP Grado Superior DAW (Desarrollo de Aplicaciones Web)**.

## 📖 Descripción del Proyecto

"Adivina la Palabra" es un videojuego de lógica y vocabulario inspirado en las mecánicas del popular juego *Wordle*, con **interfaz gráfica de escritorio** desarrollada con **Avalonia UI**.

El objetivo del jugador es adivinar una palabra secreta de cinco letras en un máximo de seis intentos. Tras cada intento, el programa evalúa la palabra introducida y proporciona retroalimentación visual mediante colores en el tablero:
* 🟩 **Verde (Correcto):** La letra está en la palabra y en la posición correcta.
* 🟨 **Amarillo (Presente):** La letra pertenece a la palabra, pero está en una posición errónea.
* ⬜ **Gris (Ausente):** La letra no pertenece a la palabra a adivinar.

## ✨ Funcionalidades Principales

* **Interfaz gráfica de escritorio:** Tablero visual de 6x5 celdas que se colorea en tiempo real según el resultado de cada intento, construido con controles de Avalonia.
* **Gestión de Jugadores:** Sistema de identificación de jugador por nombre: si el jugador ya existe se recupera su perfil, y si no, se crea uno nuevo automáticamente.
* **Persistencia de Datos:** Los perfiles de los jugadores (partidas jugadas, victorias, racha) se guardan y cargan desde un archivo `jugadores.json` mediante serialización JSON.
* **Gestión de Diccionario:** Lectura de palabras desde un archivo de texto local (`diccionario.txt`), filtrando en memoria únicamente aquellas de 5 letras.
* **Validación de Intentos:** Comprobación de que la palabra introducida tiene exactamente 5 letras y existe en el diccionario antes de aceptarla.
* **Motor Lógico de Evaluación:** Algoritmo en dos pasadas que compara cada intento con la palabra secreta, resolviendo correctamente el caso de letras repetidas (evitando "falsos positivos" en amarillo).
* **Estadísticas del Jugador:** Panel que muestra las partidas jugadas, victorias, racha actual y porcentaje de victorias del jugador activo.

## 🛠️ Tecnologías Utilizadas

El proyecto está desarrollado completamente en **C#** bajo la plataforma **.NET 10**.

* **Avalonia UI:** Framework multiplataforma para construir la interfaz gráfica de escritorio.
* **POO:** Clases principales como `MainWindow`, `Jugador`, `Diccionario`, `Validador` y `GestorDeDatos`. Uso de encapsulación y modificadores de acceso.
* **Serialización JSON:** Persistencia de los perfiles de jugador con `System.Text.Json`.
* **Manejo de Ficheros (I/O):** Lectura del diccionario de palabras y lectura/escritura de los datos de jugadores (`System.IO`).
* **Control de Versiones:** Repositorio gestionado con **Git** para el registro del progreso.

## 🧩 Estructura del Proyecto

* **`MainWindow`**: Ventana principal de la aplicación. Gestiona el flujo del juego ("login" del jugador, inicio de partida, evaluación de intentos, resultado y estadísticas).
* **`Diccionario`**: Carga las palabras válidas desde `diccionario.txt` y permite obtener una palabra aleatoria o comprobar si una palabra existe.
* **`Jugador`**: Representa el perfil de un jugador (nombre, partidas jugadas, victorias, racha) y registra el resultado de cada partida.
* **`GestorDeDatos`**: Carga y guarda la lista de jugadores en `jugadores.json`.
* **`Validador`**: Comprueba que una palabra cumple el formato esperado (5 letras, solo caracteres alfabéticos).

## 🚀 Cómo ejecutar el proyecto

1. Asegúrate de tener instalado el SDK de **.NET 10** (o superior) en tu equipo. Las dependencias (Avalonia 12) se descargan automáticamente al compilar.
2. Clona este repositorio:

   ```bash
   git clone https://github.com/javsanapa/Wordle-Proyecto-Final.git
   ```

3. Entra en la carpeta del proyecto y ejecútalo:

   ```bash
   cd Wordle-Proyecto-Final
   dotnet run
   ```

4. Se abrirá la ventana del juego: introduce tu nombre, pulsa "Entrar", luego "Nueva Partida" y comienza a adivinar la palabra de 5 letras!
