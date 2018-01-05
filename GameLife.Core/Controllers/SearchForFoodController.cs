using ConsoleLife.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLife.Framework;
using GameLife.Core.Components;
using ConsoleLife.Framework.Components;

namespace GameLife.Core.Controllers
{
    public class SearchForFoodController : BaseConsoleLifeController
    {
        public override void Update(GameTime gameTime)
        {
            var entities = GetEntities<LifeComponent>();

            foreach (var entity in entities)
            {
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();

                if (!pathfindingComponent.HasTarget)
                {
                    //Check for some food
                    var foodEntities = GetEntities<FoodComponent>();
                    if (foodEntities.Count > 0)
                    {
                        var food = foodEntities[0];
                        pathfindingComponent.SetTarget(food);
                    }
                }
                else
                {
                    if (pathfindingComponent.ArrivedAtTarget)
                    {
                        Game.RemoveEntity(pathfindingComponent.TargetId);
                    }                    
                }
            }
        }
    }
}
