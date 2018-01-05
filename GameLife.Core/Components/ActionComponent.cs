using System;
using System.Collections.Generic;
using ConsoleLife.Framework.Components;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLife.Core.Action;

namespace GameLife.Core.Components
{
    public class ActionComponent : Component
    {
        public BaseAction Action { get; set; }

        public bool HasAction
        {
            get
            {
                return Action != null;
            }
        }


    }
}
