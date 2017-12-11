using ConsoleLife.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLife.Framework;
using ConsoleLife.Framework.Components;
using GameLife.Core.Components;

namespace GameLife.Core.Controllers
{
    public class MovementPatternController : Controller
    {
        public override void Update(GameTime gameTime)
        {
            var entities = GetEntities(new List<Type>()
            {
                typeof(PositionComponent),
                typeof(MovementPatternComponent),
                typeof(MoveableComponent)
            });

            foreach (var entity in entities)
            {
                var movementPatternComponent = entity.GetComponent<MovementPatternComponent>();
                var moveableComponent = entity.GetComponent<MoveableComponent>();

                if(CanMove(gameTime, movementPatternComponent))
                {
                    DoMove(movementPatternComponent, moveableComponent);
                }

              
            }
        }

        private void DoMove(MovementPatternComponent movementPatternComponent, MoveableComponent moveableComponent)
        {
            switch (movementPatternComponent.MovementPattern)
            {
                case MovementPatterns.None:
                    {
                        break;
                    }
                case MovementPatterns.Straight:
                    {
                        moveableComponent.MoveY = movementPatternComponent.DistanceY;
                        break;
                    }
                case MovementPatterns.ZigZag:
                    {
                        moveableComponent.MoveY = movementPatternComponent.DistanceY;
                        moveableComponent.MoveX = movementPatternComponent.DistanceX;

                        movementPatternComponent.DistanceX *= -1;

                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("This movement pattern isnt implemented yet");
                    }
            }
        }


        private bool CanMove(GameTime gameTime, MovementPatternComponent movementPatternComponent)
        {
            var result = false;

            movementPatternComponent.DelayTimer -= gameTime.ElapsedMiliseconds;

            if(movementPatternComponent.DelayTimer <= 0)
            {
                result = true;
                movementPatternComponent.DelayTimer = movementPatternComponent.Delay;
            }

            return result;
        }
    }
}
