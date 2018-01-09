using ConsoleLife.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Action
{
    public class BaseAction
    {
        public bool Complete { get; set; }

        public virtual void DoAction(GameTime gameTime, Entity entity)
        {

        }
    }

 }
