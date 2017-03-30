using System;

namespace Idle
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static public Game1 game = new Game1();
        [STAThread]
        static void Main()
        {   
            game.Run();
        }
    }
#endif
}
