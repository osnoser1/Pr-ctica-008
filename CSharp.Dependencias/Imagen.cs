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
            _imagenInvertida = InvertirImagen();
            /* El ancho y alto de una imagen de la rejilla 
            es el total entre el número de columnas y el
            total entre el numero de filas respectivamente.*/
            Width = _imagen.Width / columnas;
            Height = _imagen.Height / filas;
            Color = Color.White;
            Active = true;
        }

        private Texture2D InvertirImagen()
        {
            return Flip(_imagen, false, true);
        }

        public static Texture2D Flip(Texture2D source, bool vertical, bool horizontal)
        {
            var flipped = new Texture2D(source.GraphicsDevice, source.Width, source.Height);
            var data = new Color[source.Width * source.Height];
            var flippedData = new Color[data.Length];
            source.GetData(data);
            for (var x = 0; x < source.Width; x++)
                for (var y = 0; y < source.Height; y++)
                {
                    var idx = (horizontal ? source.Width - 1 - x : x) + ((vertical ? source.Height - 1 - y : y) * source.Width);
                    flippedData[x + y * source.Width] = data[idx];
                }
            flipped.SetData(flippedData);
            return flipped;
        }  

        public void Update(int estado, int frameActual, bool derecha)
        {
            if (!Active)
                return;

            if (frameActual < 0 || frameActual > _columnas)
                Console.Error.WriteLine("No existe el cuadro.");
            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            _sourceRect = new Rectangle((derecha ? frameActual : _columnas - 1 - frameActual)*Width, estado*Height,
                                        Width, Height);
            // Grab the correct frame in the image strip by multiplying the currentFrame index by the frame width
            _destinationRect = new Rectangle((int)Posicion.X - (int)(Width * Scale) / 2, (int)Posicion.Y - (int)(Height * Scale) / 2,
            (int)(Width * Scale), (int)(Height * Scale));
        }

        public void Draw(SpriteBatch spriteBatch, bool derecha)
        {
            if (!Active)
                return;
            Texture2D aux;
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
