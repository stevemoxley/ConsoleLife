using ConsoleLife.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Components
{
    public class MovementPatternComponent : TimedComponent
    {
        public MovementPatterns MovementPattern { get; set; }

        /// <summary>
        /// How far they move each time they move
        /// </summary>
        public int DistanceX { get; set; } = 1;

        /// <summary>
        /// How far they move each time they move
        /// </summary>
        public int DistanceY { get; set; } = 1;
  
    }

    public enum MovementPatterns
    {
        None,
        Straight,
        ZigZag
    }
}
