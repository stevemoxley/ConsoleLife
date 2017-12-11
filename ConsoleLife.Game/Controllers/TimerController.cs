using ConsoleLife.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework.Controllers
{
    public class TimerController : Controller
    {
        public override void Update(GameTime gameTime)
        {
            var entities = GetEntities<TimedComponent>();

            var elapsed = gameTime.ElapsedMiliseconds;


            foreach (var entity in entities)
            {
                var timerComponents = entity.GetComponents<TimedComponent>();

                foreach (var component in timerComponents)
                {
                    var timerComponent = component as TimedComponent;
                    if (timerComponent == null)
                        continue;

                    timerComponent.DelayTimer -= elapsed;
                    if(timerComponent.DelayTimer <= 0)
                    {
                        timerComponent.Elapsed = true;
                        timerComponent.DelayTimer = timerComponent.Delay;
                    }
                    else
                    {
                        timerComponent.Elapsed = false;
                    }
                }
            }
        }
    }
}
