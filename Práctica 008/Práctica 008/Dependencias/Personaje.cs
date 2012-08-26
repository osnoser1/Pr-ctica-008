using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Práctica_008;

// ReSharper disable CheckNamespace
namespace Dependencias
// ReSharper restore CheckNamespace
{
    public abstract class Personaje
    {
        public enum Participantes
        {
            Megaman,
            BeeBlader
        }

        public enum Estados
        {
            Inicio,
            Parado,
            Camina,
            Salta,
            Dispara,
            DisparaSaltando,
            DisparaCorriendo,
            Muere,
            Golpeado,
            Golpea
        }

        protected Estados EstadoAnterior;
        protected Vector2 Posicion;
        public Estados EstadoActual
        {
            get { return _estadoActual; }
            protected set
            {
                EstadoAnterior = _estadoActual;
                _estadoActual = value;
            }
        }

        protected Imagen Imagen { get; set; }
        public float VelocidadSalto { get; protected set; }
        protected Dictionary<Estados, ControlAnimacion> Animaciones;
        private Estados _estadoActual;

        protected bool Izquierda
        {
            get { return !Derecha; }
            set { Derecha = !value; }
        }

        protected bool Derecha { get; set; }

        protected void Initialize(Vector2 posicion, bool derecha)
        {
            Posicion = posicion;
            Derecha = derecha;
        }

        public abstract void Update(Game1 juego);

        public abstract void ColisionaCon(Personaje personaje);

        public virtual void Draw(SpriteBatch g)
        {
            Imagen.Update((int)EstadoActual, Animaciones[EstadoActual].CuadroActual);
            Imagen.Draw(g, Derecha);
        }

    }
}
