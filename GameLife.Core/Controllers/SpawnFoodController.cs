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
    public class SpawnFoodController : BaseConsoleLifeController
    {
        public override void Update(GameTime gameTime)
        {
            var foodEntities = GetEntities<FoodComponent>();

            if (foodEntities.Count == 0)
            {
                bool foodPlaced = false;
                while (!foodPlaced)
                {
                    //pick a random location
                    int randomX = RNG.Next(0, Console.WindowWidth);
                    int randomY = RNG.Next(0, Console.WindowHeight);

                    //Check if something exists there already
                    var allPositionEntities = Game.AllEntities.Where(e => e.HasComponent<PositionComponent>());
                    foreach (var entity in allPositionEntities)
                    {
                        var positionComponent = entity.GetComponent<PositionComponent>();
                        if (positionComponent.X != randomX && positionComponent.Y != randomY)
                        {
                            //place it here
                            var food = EntityFactory.CreateFoodEntity(randomX, randomY);
                            food.Add();
                            foodPlaced = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}
