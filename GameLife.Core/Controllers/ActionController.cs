using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLife.Framework;
using GameLife.Core.Components;
using GameLife.Core.Action;

namespace GameLife.Core.Controllers
{
    public class ActionController : BaseConsoleLifeController
    {

        public ActionController()
        {
            _determineActionService = new DetermineActionService();
        }

        public override void Update(GameTime gameTime)
        {
            var entities = GetEntities(new List<Type>
            {
                typeof(ActionComponent),
            });

            foreach (var entity in entities)
            {
                var actionComponent = entity.GetComponent<ActionComponent>();

                //Determine the action first
                if (actionComponent.Action == null)
                {
                    actionComponent.Action = _determineActionService.DetermineAction(entity);
                }

                //Do the action
                actionComponent.Action.DoAction(gameTime, entity);

                //Set the action to null if its been completed
                if(actionComponent.Action.Complete)
                {
                    actionComponent.Action = null;
                }
            }
        }

        private DetermineActionService _determineActionService;


    }
}
