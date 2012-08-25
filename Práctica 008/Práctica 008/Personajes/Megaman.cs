using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dependencias;
using Microsoft.Xna.Framework;
using Práctica_008.Personajes;

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
    }

}
