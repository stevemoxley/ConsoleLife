using System;
using System.Collections.Generic;
using System.ComponentModel;
using ConsoleLife.Framework.Components;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework
{
    public class Entity
    {
        public List<Components.Component> Components { get; set; } = new List<Components.Component>();
    }
}
