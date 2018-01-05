using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLife.Framework;
using GameLife.Core.Components;

namespace GameLife.Core.Action
{
    public class EatAction : BaseAction
    {
        public override void DoAction(GameTime gameTime, Entity entity)
        {
            //So here will will eat the food
            var target = entity.GetTargetEntity();

            if (target != null && entity.IsAtTarget())
            {
                if (target.HasComponent<FoodComponent>())
                {
                    var foodComponent = target.GetComponent<FoodComponent>();
                    //Eat it and whatever
                    Complete = true;
                    target.Remove();
                }
                else
                {
                    throw new Exception("Somehow targeted an entity that isnt food");
                }
            }
            else
            {
                //Find some food
                var food = Game.AllEntities.Where(e => e.HasComponent<FoodComponent>());
                if (food.Count() > 0)
                {
                    var targetFood = food.ElementAt(0);
                    entity.SetTarget(targetFood);
                }
            }
        }
    }
}
