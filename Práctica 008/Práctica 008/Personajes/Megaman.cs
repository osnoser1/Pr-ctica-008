using System;
using System.Collections.Generic;
using Dependencias;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Práctica_008;

// ReSharper disable CheckNamespace
namespace Personajes
// ReSharper restore CheckNamespace
{
    public class Megaman : Personaje
    {
        public GamePad Control { set; get; }

        public Megaman(Texture2D textura, Vector2 posicion, bool derecha, GamePad control)
        {
            Initialize(textura, posicion, derecha, control);
        }

        public Megaman()
        {}

        public override void ColisionaCon(Personaje personaje)
        {
            
        }

        public void Initialize(Texture2D textura, Vector2 posicion, bool derecha, GamePad control)
        {
            Control = control;
            Initialize(posicion, derecha);
            Imagen = new Imagen(textura, 10, 7, posicion);
            Animaciones = new Dictionary<Estados, ControlAnimacion>
            {
                {Estados.Inicio, new ControlAnimacion("0,1,2,3", 1000 / 16)},
                {Estados.Parado, new ControlAnimacion("0", 1000 / 16)},
                {Estados.Camina, new ControlAnimacion("0,1,2,3,4,5,6", 1000 / 16)},
                {Estados.Dispara, new ControlAnimacion("0,0,0", 1000 / 16)}
            };
            EstadoActual = Estados.Parado;
        }

        public override void Update(Game1 juego, GameTime gameTime)
        {
            switch (EstadoActual)
            {
                case Estados.Inicio:
                    estado_inicia();
                    break;
                case Estados.Parado:
                    EstadoParado(gameTime);
                    break;
                case Estados.Camina:
                    EstadoCamina(gameTime);
                    break;
                case Estados.Salta:
                    estado_salta();
                    break;
                case Estados.DisparaSaltando:
                    estado_dispara_saltando();
                    break;
                case Estados.Dispara:
                    EstadoDispara(juego, gameTime);
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

        private void EstadoDispara(Game1 juego, GameTime gameTime)
        {
            AplicarDisparo(juego);
            if(Animaciones[EstadoActual].Update(gameTime))
            {
                EstadoActual = Estados.Parado;
            }
        }

        private void AplicarDisparo(Game1 juego)
        {
            if (juego == null) throw new ArgumentNullException("juego");
        }

        private void estado_dispara_saltando()
        {
            throw new NotImplementedException();
        }

        private void estado_salta()
        {
            throw new NotImplementedException();
        }

        private void EstadoCamina(GameTime gameTime)
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
            Animaciones[EstadoActual].Update(gameTime);
        }

        private void EstadoParado(GameTime gameTime)
        {
            Animaciones[EstadoActual].Update(gameTime);
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
