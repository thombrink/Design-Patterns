/*
   Coding             : M. Krop
   Date               : 3 augustus 2015
   Purpose            : Examples of various Design Patterns
   Intended audience  : Students HBO-ICT of Windesheim University of Applied Sciences
   Copyright          : (c)2015 by M. Krop
*/

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace DesignPatternsExamples
{
    static class Program
    {
        private static FactoryMethodExample game;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            game = new FactoryMethodExample();
            game.Run();
        }
    }
}
