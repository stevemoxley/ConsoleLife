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
    public class SearchForFoodController : Controller
    {
        public override void Update(GameTime gameTime)
        {
            var entities = GetEntities<LifeComponent>();

            foreach (var entity in entities)
            {
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();

                if(pathfindingComponent == null)
                {
                    //Check for some food
                    var foodEntities = GetEntities<FoodComponent>();
                    if(foodEntities.Count > 0)
                    {
                        var food = foodEntities[0];
                        var foodLocation = food.GetComponent<PositionComponent>();

                        pathfindingComponent = new PathfindingComponent();
                        pathfindingComponent.TargetX = foodLocation.X;
                        pathfindingComponent.TargetY = foodLocation.Y;
                        pathfindingComponent.Delay = 75;
                        pathfindingComponent.TargetId = food.Id;
                        entity.Components.Add(pathfindingComponent);

                    }
                }
                else
                {
                    if(pathfindingComponent.ArrivedAtTarget || pathfindingComponent.UnableToFindPath)
                    {
                        entity.Components.Remove(pathfindingComponent);
                        Game.RemoveEntity(pathfindingComponent.TargetId);
                    }
                }

            }
        }
    }
}
