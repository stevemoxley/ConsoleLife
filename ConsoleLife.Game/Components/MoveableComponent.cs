using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework.Components
{

    /// <summary>
    /// Signals that this entity can move
    /// </summary>
    public class MoveableComponent : Component
    {
        ///Set to zero if this entity isnt going to move this cycle
        public int MoveX { get; set; }

        ///Set to zero if this entity isnt going to move this cycle
        public int MoveY { get; set; }

    }
}
