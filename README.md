# **Ahorcado-Grupo5**

Proyecto final del curso de Programación Avanzada (SC-601) que consiste en una aplicación web del juego "Ahorcado", desarrollada con ASP.NET MVC y Entity Framework.

## **Integrantes del Grupo**

| Nombre Completo | Carné | Usuario de Git | Correo Electrónico |
| :---- | :---- | :---- | :---- |
| Valeria Arias Castro | FH22011062 | ValeriaAriasC | varias50158@ufide.ac.cr |
| Shernna Corrales Cárdenas | FI21022687 | Shernna | shercorrales318@gmail.com |
| Jeremy Valverde Fallas | FI13005945 | jerevf | jerevf@gmail.com |
| Rachel Cortés Torres | FH22011786 | RachelCortes | cortestrachel10@gmail.com |

## **Diagrama de la Base de Datos**

El diseño de la base de datos se implementó utilizando Entity Framework en modo "Code First". A continuación se muestra un diagrama que representa las entidades y sus relaciones.

erDiagram  
    JUGADOR {  
        int Identificacion PK "unique, positive integer"  
        string Nombre "max 50 chars"  
        int Marcador  
        int PartidasGanadas  
        int PartidasPerdidas  
        string AvatarUrl  
    }

    PALABRA {  
        int Id PK "auto-increment"  
        string TextoPalabra "5-10 chars, letters only"  
        bool HaSidoUsada  
    }

    PARTIDA {  
        int Id PK "auto-increment"  
        bool Victoria "true for win, false for loss"  
        string Nivel "Fácil, Normal, Difícil"  
        datetime Fecha  
        int JugadorId FK  
        int PalabraId FK  
    }

    JUGADOR ||--o{ PARTIDA : "tiene"  
    PALABRA ||--o{ PARTIDA : "es usada en"

## **Referencias y Recursos Utilizados**

Para el desarrollo de este proyecto, se consultaron diversas fuentes de documentación y se utilizaron varias tecnologías estándar en el desarrollo web con .NET.

### **Tecnologías Principales**

* **ASP.NET MVC**: Documentación oficial para la estructura del proyecto.  
  * [https://docs.microsoft.com/en-us/aspnet/mvc/](https://www.google.com/search?q=https://docs.microsoft.com/en-us/aspnet/mvc/)  
* **Entity Framework (Code First)**: Guías para la creación del modelo de datos y las migraciones.  
  * [https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database](https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database)  
* **Bootstrap 5**: Utilizado para el diseño responsivo y componentes de la interfaz.  
  * [https://getbootstrap.com/docs/5.3/getting-started/introduction/](https://getbootstrap.com/docs/5.3/getting-started/introduction/)  
* **jQuery**: Empleado para la manipulación del DOM y la interactividad en las vistas.  
  * [https://api.jquery.com/](https://api.jquery.com/)

### **Snippets de Código y Lógica Específica**

* **Normalización de texto para quitar tildes (case-insensitive)**: Se investigaron métodos para comparar strings ignorando acentos.  
  * *Prompt de ejemplo para IA*: "How to compare strings in C\# ignoring accents and case sensitivity?"  
  * *Referencia web*: [Stack Overflow: How to remove diacritics](https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net)  
* **Lógica de temporizador en JavaScript**: Se consultaron ejemplos para implementar una cuenta regresiva.  
  * *Prompt* de ejemplo *para IA*: "Create a countdown timer in JavaScript that updates a div every second and executes a function when it reaches zero."  
  * *Referencia web*: [W3Schools: How To Create a Countdown Timer](https://www.w3schools.com/howto/howto_js_countdown.asp)  
* **Uso de Fetch API para llamadas asíncronas a controlador MVC**: Guías para enviar datos desde JavaScript a un Action de C\#.  
  * *Prompt de ejemplo para IA*: "JavaScript fetch POST request to an ASP.NET MVC controller action, including AntiForgeryToken."  
  * *Referencia web*: [Learn.Microsoft: Call a controller action using JavaScript Fetch](https://www.google.com/search?q=https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/fetch-data)

### **Recursos de Diseño y Sonido**

* **Generador de Gradientes**: Para el fondo de la aplicación.  
  * [https://cssgradient.io/](https://cssgradient.io/)  
* **Sonidos gratuitos**: Para los efectos de sonido del juego.  
  * [https://pixabay.com/sound-effects/](https://pixabay.com/sound-effects/)  
* **Avatares**: Las imágenes de avatar fueron realizadas con canva en línea.  
  * [https://www.canva.com/design/DAGvREon1mc/EqT83BcMlzTnXnXI2ibZVw/edit?utm_content=DAGvREon1mc&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton](https://www.canva.com/design/DAGvREon1mc/EqT83BcMlzTnXnXI2ibZVw/edit?utm_content=DAGvREon1mc&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton/)