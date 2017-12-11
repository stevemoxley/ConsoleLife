using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework.Components
{
    public class TimedComponent : Component
    {
        /// <summary>
        /// In miliseconds
        /// </summary>
        public int Delay { get; set; } = 1000;

        public int DelayTimer { get; set; }

        public bool Elapsed { get; set; } = false;
    }
}
