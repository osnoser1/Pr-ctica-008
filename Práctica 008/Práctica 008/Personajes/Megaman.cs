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

        public Megaman(Vector2 posicion, bool derecha, GamePad control)
        {
            Initialize(posicion, derecha, control);
        }

        public Megaman()
        {}

        public override void ColisionaCon(Personaje personaje)
        {
            
        }

        public void Initialize(Vector2 posicion, bool derecha, GamePad control)
        {
            Control = control;
            Initialize(posicion, derecha);
        }

        public override void Update(Práctica_008.Game1 juego)
        {
            switch (EstadoActual)
            {
                case Estados.Inicio:
                    estado_inicia();
                    break;
                case Estados.Parado:
                    EstadoParado();
                    break;
                case Estados.Camina:
                    EstadoCamina();
                    break;
                case Estados.Salta:
                    estado_salta();
                    break;
                case Estados.DisparaSaltando:
                    estado_dispara_saltando();
                    break;
                case Estados.Dispara:
                    estado_dispara();
                    break;
                case Estados.DisparaCorriendo:
                    estado_dispara_corriendo();
                    break;
                case Estados.Golpeado:
                    estado_golpeado();
                    break;
            }
        }

        private void estado_golpeado()
        {
            throw new NotImplementedException();
        }

        private void estado_dispara_corriendo()
        {
            throw new NotImplementedException();
        }

        private void estado_dispara()
        {
            throw new NotImplementedException();
        }

        private void estado_dispara_saltando()
        {
            throw new NotImplementedException();
        }

        private void estado_salta()
        {
            throw new NotImplementedException();
        }

        private void EstadoCamina()
        {
            if (Control[GamePad.Botones.Derecha])
            {
                Derecha = true;
                MoverSobreX(4);
            }
            else
            {
                if(Control[GamePad.Botones.Izquierda])
                {
                    Derecha = false;
                }
                else
                {
                    EstadoActual = Estados.Parado;
                }
            }
        }

        private void EstadoParado()
        {
            if(Control[GamePad.Botones.B])
            {
                EstadoActual = Estados.Dispara;
            }
            if(Control[GamePad.Botones.Derecha] || Control[GamePad.Botones.Izquierda])
            {
                EstadoActual = Estados.Camina;
            } 
        }

        private void estado_inicia()
        {
            throw new NotImplementedException();
        }
    }

}
