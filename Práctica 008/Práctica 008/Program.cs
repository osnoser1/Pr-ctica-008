using System;

namespace Práctica_008
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (var game = Game1.Instance)
            {
                game.Run();
            }
        }
    }
#endif
}

