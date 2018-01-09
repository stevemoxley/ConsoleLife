using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework
{
    public static class InputHandler
    {

        public static void Update(char @char)
        {
            PreviousKeyPress = MostRecentKeyPress;
            MostRecentKeyPress = @char;
        }

        public static char MostRecentKeyPress { get; private set; }

        public static char PreviousKeyPress { get; private set; }


    }
}
