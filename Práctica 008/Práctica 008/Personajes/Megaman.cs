using System;
using Dependencias;
using Microsoft.Xna.Framework;

// ReSharper disable CheckNamespace
namespace Personajes
// ReSharper restore CheckNamespace
{
    public class Megaman : Personaje
    {
        public GamePad Control { set; get; }

        public Megaman(Vector2 posicion, bool derecha, GamePad control) : base(posicion, derecha)
        {
            Control = control;
        }

        public Megaman()
        {}

        public void ColisionaCon(Personaje personaje)
        {
            
        }

        public void Initialize(Vector2 posicion, bool derecha, GamePad control)
        {
            Control = control;
            base.Initialize(posicion, derecha);
        }

        public override void Update(Práctica_008.Game1 juego)
        {
            Console.WriteLine("Hola");
            base.Update(juego);
        }
    }

}
