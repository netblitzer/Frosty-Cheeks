#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Frosty_Cheeks
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
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
        public static void WriteLine(string str)
        {
            System.Diagnostics.Debug.WriteLine(str);
        }
    }
#endif
}
