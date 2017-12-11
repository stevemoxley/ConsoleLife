using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework.Components
{
    public class PositionComponent : Component
    {
        public int PreviousX { get; set; }

        public int PreviousY { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public bool Moved
        {
            get
            {
                return PreviousX != X || PreviousY != Y;
            }
        }

        public bool Placed { get; set; } = false;
    }
}
