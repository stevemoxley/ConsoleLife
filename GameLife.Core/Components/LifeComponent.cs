using ConsoleLife.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Components
{

    /// <summary>
    /// Represents a life form
    /// </summary>
    public class LifeComponent: Component
    {
        bool IsCurrentlySelected { get; set; }

    }
}
