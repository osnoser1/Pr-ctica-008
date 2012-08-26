using System.Collections.Generic;
using Microsoft.Xna.Framework;

// ReSharper disable CheckNamespace
namespace Dependencias
// ReSharper restore CheckNamespace
{
    public class ControlAnimacion
    {

        private int Paso { get; set; }
        public List<int> Cuadros { get; private set; }
        public int FrameTime { get; private set; }

        // The time we display a frame until the next one
        // The time since we last updated the frame
        private int _elapsedTime;
        public int CuadroActual
        {
            get
            {
                return Cuadros[Paso];
            }
        }
        public bool PrimerCuadro
        {
            get { return Paso == 0; }
        }

        public ControlAnimacion(string frames, int frameTime)
        {
            FrameTime = frameTime;
            Cuadros = new List<int>();
            var framesTmp = frames.Split(',');
            foreach (var frame in framesTmp)
                Cuadros.Add(int.Parse(frame));
            Cuadros.Add(-1);
        }

        public bool Update(ref GameTime gameTime)
        {
            // Update the elapsed time
            _elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            // If the elapsed time is larger than the frame time
            // we need to switch frames
            if (_elapsedTime > FrameTime)
            {
                if (Cuadros[++Paso] == -1)
                {
                    Paso = 0;
                    // If we are not looping deactivate the animation
                    return true;
                }
                // Reset the elapsed time to zero
                _elapsedTime = 0;
            }
            return false;
        }

        public void Reiniciar()
        {
            _elapsedTime = 0;
            Paso = 0;
        }

    }
}
