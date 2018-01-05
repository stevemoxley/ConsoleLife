using ConsoleLife.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Action
{
    public abstract class BaseAction
    {
        public bool Complete { get; set; }

        public abstract void DoAction(GameTime gameTime, Entity entity);
    }

 }
