using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework.Components
{
    public class DrawingComponent : Component
    {
        public string Symbol { get; set; }

        public ConsoleColor Color { get; set; } = ConsoleColor.White;

    }
}
