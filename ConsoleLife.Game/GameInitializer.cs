using ConsoleLife.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework
{
    internal class GameInitializer
    {

        public static void InitializeControllers()
        {
            Game.AllControllers.Add(new DrawingController());
            Game.AllControllers.Add(new TimerController());
            Game.AllControllers.Add(new MovingController());
            Game.AllControllers.Add(new GameIOController());
        }
        
    }
}
