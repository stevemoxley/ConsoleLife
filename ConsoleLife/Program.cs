using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLife.Framework;
using GameLife.Core;

namespace ConsoleLife
{
    class Program
    {
        static void Main(string[] args)
        {
            GameInitializer.InitializeGame();

            Game.Start();
        }
    }
}
