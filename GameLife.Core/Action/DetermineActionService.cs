using ConsoleLife.Framework;
using GameLife.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Action
{
    public class DetermineActionService
    {

        public BaseAction DetermineAction(Entity entity)
        {
            if(!entity.HasComponent<LifeComponent>() || !entity.HasComponent<ActionComponent>())
            {
                throw new Exception("Entity must have life and action components");
            }

            var actionComponent = entity.GetComponent<ActionComponent>();
            var lifeComponent = entity.GetComponent<LifeComponent>();

            if(!actionComponent.HasAction)
            {
                if(lifeComponent.Sleep == 0)
                {
                    return new SleepAction();
                }
                else
                {
                    return new EatAction();
                }
            }

            throw new Exception("Wasnt able to determine an action");
        }

    }
}
