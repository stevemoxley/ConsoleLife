﻿using ConsoleLife.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Components
{
    public class MovementPatternComponent : Component
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


        /// <summary>
        /// In miliseconds
        /// </summary>
        public int Delay { get; set; } = 1000;
        
        public int DelayTimer { get; set; }
    }

    public enum MovementPatterns
    {
        None,
        Straight,
        ZigZag
    }
}
