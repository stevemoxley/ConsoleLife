using ConsoleLife.Framework;
using ConsoleLife.Framework.Controllers;
using GameLife.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Controllers
{
    public abstract class BaseConsoleLifeController : Controller
    {

        /// <summary>
        /// Checks if this entity is at its target
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AtTarget(Entity entity)
        {
            bool result = false;

            if(entity.HasComponent<PathfindingComponent>())
            {
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();
                if(pathfindingComponent.ArrivedAtTarget)
                {
                    result = true;
                }
            }
            else
            {
                throw new Exception("Tried to check if at target when entity has no pathfinding component");
            }

            return result;
        }

    }
}
