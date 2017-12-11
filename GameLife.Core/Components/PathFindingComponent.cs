﻿using ConsoleLife.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Components
{
    public class PathfindingComponent : TimedComponent
    {
        public int TargetX { get; set; }

        public int TargetY { get; set; }
  
    }
}