using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

// ReSharper disable CheckNamespace
namespace Dependencias
// ReSharper restore CheckNamespace
{
    public class GamePad
    {
        public enum Botones
        {
            Arriba,
            Abajo,
            Izquierda,
            Derecha,
            A,
            B,
            R,
            L,
            Start,
            Select
        }

        public Dictionary<Botones, Keys> TeclasConfiguradas { get; set; }
        private KeyboardState _teclasActuales;
        private KeyboardState _teclasPrevias;

        public bool this[Botones boton]
        {
            get
            {
// ReSharper disable ConditionIsAlwaysTrueOrFalse
                return _teclasActuales != null && _teclasActuales.IsKeyDown(TeclasConfiguradas[boton]);
            }
        }   

        public GamePad()
        {
            TeclasConfiguradas = new Dictionary<Botones, Keys>
            {
                {Botones.Arriba, Keys.Up},
                {Botones.Abajo, Keys.Down},
                {Botones.Izquierda, Keys.Left},
                {Botones.Derecha, Keys.Right},
                {Botones.A, Keys.X},
                {Botones.B, Keys.C},
                {Botones.R, Keys.A},
                {Botones.L, Keys.S},
                {Botones.Start, Keys.Enter},
                {Botones.Select, Keys.Back}
            };
        }

        public void ActualizarTeclas()
        {
            _teclasPrevias = _teclasActuales;
            _teclasActuales = Keyboard.GetState();
        }
    }
}
