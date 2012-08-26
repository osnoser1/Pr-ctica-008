using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

// ReSharper disable CheckNamespace
namespace Dependencias
// ReSharper restore CheckNamespace
{
    public class Imagen
    {

        private readonly Texture2D _imagen;
        private readonly Texture2D _imagenInvertida;
        private readonly int _columnas;
        private int _filas;
        private Rectangle _sourceRect;
        private Rectangle _destinationRect;
        public Vector2 Posicion { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Active { get; set; }
        public Color Color { get; set; }
        // The scale used to display the sprite strip
        public float Scale { get; set; }


        public Imagen(Texture2D textura, int filas, int columnas, Vector2 posicion, float scale = 1)
        {
            _filas = filas;
            _columnas = columnas;
            Posicion = posicion;
            Scale = scale;
            _imagen = textura;
            _imagenInvertida = invertir_imagen();
            /* El ancho y alto de una imagen de la rejilla 
            es el total entre el número de columnas y el
            total entre el numero de filas respectivamente.*/
            Width = _imagen.Width / columnas;
            Height = _imagen.Height / filas;
            Color = Color.White;
            Active = true;
        }

        private Texture2D invertir_imagen()
        {
            throw new NotImplementedException();
        }

        public void Update(int estado, int frameActual)
        {
            if (!Active)
                return;

            if (frameActual < 0 || frameActual > _columnas)
                Console.Error.WriteLine("No existe el cuadro.");
            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            _sourceRect = new Rectangle(frameActual * Width, estado * Height, Width, Height);
            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            _destinationRect = new Rectangle((int)Posicion.X - (int)(Width * Scale) / 2, (int)Posicion.Y - (int)(Height * Scale) / 2,
            (int)(Width * Scale), (int)(Height * Scale));
        }

        public void Draw(SpriteBatch spriteBatch, bool derecha)
        {
            if (!Active)
                return;
            Texture2D aux = null;
            switch (derecha)
            {
                case true:
                    aux = _imagen;
                    break;
                default:
                    aux = _imagenInvertida;
                    break;
            }
            spriteBatch.Draw(aux, _destinationRect, _sourceRect, Color);
        }

    }
}
