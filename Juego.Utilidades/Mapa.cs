using System;

// ReSharper disable CheckNamespace
namespace Dependencias
// ReSharper restore CheckNamespace
{
    public class Mapa
    {
        private string[,] Matriz { get; set; }
        public short Columnas, Filas;

        public Mapa(short filas, short columnas)
        {
            Filas = filas;
            Columnas = columnas;
            Matriz = new String[Filas, Columnas];
        }

        public String this[short fila, short columna]
        {
            get { return Matriz[fila, columna]; }
            set { Matriz[fila, columna] = value; }
        }

        public void BorrarMapa(){
            Matriz = new string[Filas, Columnas];
        }

    }
}
