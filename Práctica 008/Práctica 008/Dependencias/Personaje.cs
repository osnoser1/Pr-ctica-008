using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dependencias;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Práctica_008;

// ReSharper disable CheckNamespace
namespace Dependencias
// ReSharper restore CheckNamespace
{

    public class Personaje
    {
        public enum Participantes
        {
            Megaman,
            BeeBlader
        }
        public enum Estados
        {
            Parado,
            Caminar,
            Saltar,
            Morir,
            Eliminar,
            Golpear
        }
        protected Estados EstadoAnterior;
        protected Vector2 Posicion;
        public Estados EstadoActual { get; protected set; }
        protected Imagen Imagen { get; set; }
        public float VelocidadSalto { get; protected set; }
        protected Dictionary<Estados, ControlAnimacion> Animaciones;
        protected bool Izquierda
        {
            get { return !Derecha; }
            set { Derecha = !value; }
        }
        protected bool Derecha { get; set; }

        public Personaje(Vector2 posicion, bool derecha)
        {
            Posicion = posicion;
            Derecha = derecha;
        }

        public virtual void Update(Game1 juego) { }

        public void Draw(SpriteBatch g)
        {
            Imagen.Update((int)EstadoActual, Animaciones[EstadoActual].CuadroActual);
            Imagen.Draw(g, Derecha);
        }

    }
}
