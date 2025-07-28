namespace Ahorcado_Grupo5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ahorcado_Grupo5.Models;
    using System.Collections.Generic; // Necesario para usar List<>

    internal sealed class Configuration : DbMigrationsConfiguration<Ahorcado_Grupo5.Models.AhorcadoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Ahorcado_Grupo5.Models.AhorcadoContext context)
        {
            var palabras = new List<Palabra>
            {
                // Letra A
                new Palabra { TextoPalabra = "ANÁLISIS" },
                new Palabra { TextoPalabra = "ÁRBOL" },
                new Palabra { TextoPalabra = "AMABLE" },
 
                // Letra B
                new Palabra { TextoPalabra = "BÚSQUEDA" },
                new Palabra { TextoPalabra = "BENÉVOLO" },
                new Palabra { TextoPalabra = "BILINGUE" },
 
                // Letra C
                new Palabra { TextoPalabra = "CÉLEBRE" },
                new Palabra { TextoPalabra = "CÓDIGO" },
                new Palabra { TextoPalabra = "COMETA" },
 
                // Letra D
                new Palabra { TextoPalabra = "DÓCILES" },
                new Palabra { TextoPalabra = "DIÁLOGO" },
                new Palabra { TextoPalabra = "DANZAR" },
 
                // Letra E
                new Palabra { TextoPalabra = "ÉBANO" },
                new Palabra { TextoPalabra = "ÉXITO" },
                new Palabra { TextoPalabra = "EJEMPLO" },
 
                // Letra F
                new Palabra { TextoPalabra = "FÁCIL" },
                new Palabra { TextoPalabra = "FÉTIDO" },
                new Palabra { TextoPalabra = "FUTURO" },
 
                // Letra G
                new Palabra { TextoPalabra = "GÉISER" },
                new Palabra { TextoPalabra = "GÓTICO" },
                new Palabra { TextoPalabra = "GALAXIA" },
 
                // Letra H
                new Palabra { TextoPalabra = "HÁBITAT" },
                new Palabra { TextoPalabra = "HÉROE" },
                new Palabra { TextoPalabra = "HONESTO" },
 
                // Letra I
                new Palabra { TextoPalabra = "ÍMPETU" },
                new Palabra { TextoPalabra = "ÍNDICE" },
                new Palabra { TextoPalabra = "INVIERNO" },
 
                // Letra J
                new Palabra { TextoPalabra = "JÍCARA" },
                new Palabra { TextoPalabra = "JOLGORIO" },
                new Palabra { TextoPalabra = "JAZMÍN" },
 
                // Letra K
                new Palabra { TextoPalabra = "KERMÉS" },
                new Palabra { TextoPalabra = "KIOSCO" },
                new Palabra { TextoPalabra = "KÁRSTICO" },
 
                // Letra L
                new Palabra { TextoPalabra = "LÁPIZ" },
                new Palabra { TextoPalabra = "LÍMITE" },
                new Palabra { TextoPalabra = "LEALTAD" },
 
                // Letra M
                new Palabra { TextoPalabra = "MÁQUINA" },
                new Palabra { TextoPalabra = "MÉTODO" },
                new Palabra { TextoPalabra = "MISTERIO" },
 
                // Letra N
                new Palabra { TextoPalabra = "NÁUFRAGO" },
                new Palabra { TextoPalabra = "NÉCTAR" },
                new Palabra { TextoPalabra = "NOBLEZA" },
 
                // Letra Ñ
                new Palabra { TextoPalabra = "ÑANDÚ" },
                new Palabra { TextoPalabra = "ÑOQUIS" },
                new Palabra { TextoPalabra = "ÑÁÑIGO" },
 
                // Letra O
                new Palabra { TextoPalabra = "OCÉANO" },
                new Palabra { TextoPalabra = "ÓLEOS" },
                new Palabra { TextoPalabra = "ORGULLO" },
 
                // Letra P
                new Palabra { TextoPalabra = "PÁGINA" },
                new Palabra { TextoPalabra = "PÉSIMO" },
                new Palabra { TextoPalabra = "PINTURA" },
 
                // Letra Q
                new Palabra { TextoPalabra = "QUEHACER" },
                new Palabra { TextoPalabra = "QUESERO" },
                new Palabra { TextoPalabra = "QUÍMICA" },
 
                // Letra R
                new Palabra { TextoPalabra = "RÁPIDO" },
                new Palabra { TextoPalabra = "RÉCORD" },
                new Palabra { TextoPalabra = "RESPETO" },
 
                // Letra S
                new Palabra { TextoPalabra = "SÁBADO" },
                new Palabra { TextoPalabra = "SÍLABA" },
                new Palabra { TextoPalabra = "SOLIDARIO" },
 
                // Letra T
                new Palabra { TextoPalabra = "TELÉFONO" },
                new Palabra { TextoPalabra = "TÉRMINO" },
                new Palabra { TextoPalabra = "TRABAJO" },
 
                // Letra U
                new Palabra { TextoPalabra = "ÚLTIMO" },
                new Palabra { TextoPalabra = "ÚNICO" },
                new Palabra { TextoPalabra = "UNIVERSO" },
 
                // Letra V
                new Palabra { TextoPalabra = "VÁLIDO" },
                new Palabra { TextoPalabra = "VÉRTICE" },
                new Palabra { TextoPalabra = "VALIENTE" },
 
                // Letra W
                new Palabra { TextoPalabra = "WAFLE" },
                new Palabra { TextoPalabra = "WEBINARIO" },
                new Palabra { TextoPalabra = "WÉSTERN" },
 
                // Letra X
                new Palabra { TextoPalabra = "XENÓFOBO" },
                new Palabra { TextoPalabra = "XILÓFONO" },
                new Palabra { TextoPalabra = "XERÓFILO" },
 
                // Letra Y
                new Palabra { TextoPalabra = "YACIMIENTO" },
                new Palabra { TextoPalabra = "YEGUADA" },
                new Palabra { TextoPalabra = "YÓQUEY" },
 
                // Letra Z
                new Palabra { TextoPalabra = "ZAPATEO" },
                new Palabra { TextoPalabra = "ZOZOBRA" },
                new Palabra { TextoPalabra = "ZÁNGANO" },
 
                // Palabras Adicionales
                new Palabra { TextoPalabra = "ACCIÓN" },
                new Palabra { TextoPalabra = "CÍRCULO" },
                new Palabra { TextoPalabra = "DESAFÍO" },
                new Palabra { TextoPalabra = "ESTRELLA" },
                new Palabra { TextoPalabra = "ESPÍRITU" },
                new Palabra { TextoPalabra = "FAMILIA" },
                new Palabra { TextoPalabra = "GRÁFICO" },
                new Palabra { TextoPalabra = "HUÉSPED" },
                new Palabra { TextoPalabra = "HISTORIA" },
                new Palabra { TextoPalabra = "IMÁGENES" },
                new Palabra { TextoPalabra = "LÁGRIMA" },
                new Palabra { TextoPalabra = "MONTAÑA" },
                new Palabra { TextoPalabra = "NOTICIA" },
                new Palabra { TextoPalabra = "OBJETO" },
                new Palabra { TextoPalabra = "PROPÓSITO" },
                new Palabra { TextoPalabra = "RELÁMPAGO" },
                new Palabra { TextoPalabra = "SATÉLITE" },
                new Palabra { TextoPalabra = "TRÁNSITO" },
                new Palabra { TextoPalabra = "VIERNES" },

            };
            // AddOrUpdate es para no crear duplicados si el método Seed se ejecuta de nuevo.
            // Revisa cada palabra en la lista y la agrega si no existe una con el mismo TextoPalabra.
            foreach (var palabra in palabras)
            {
                context.Palabras.AddOrUpdate(p => p.TextoPalabra, palabra);
            }

            // Guarda los cambios en la base de datos.
            context.SaveChanges();

        }
    }
}