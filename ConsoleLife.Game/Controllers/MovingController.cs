using ConsoleLife.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework.Controllers
{
    public class MovingController : Controller
    {
        public override void Update(GameTime gameTime)
        {

            var entities = GetEntities(new List<Type>
            {
                typeof(MoveableComponent),
                typeof(PositionComponent)
            });

            foreach (var entity in entities)
            {
                var moveableComponent = entity.GetComponent<MoveableComponent>();
                var positionComponent = entity.GetComponent<PositionComponent>();

                positionComponent.PreviousX = positionComponent.X;
                positionComponent.PreviousY = positionComponent.Y;

                if(moveableComponent.MoveX != 0)
                {
                    positionComponent.X += moveableComponent.MoveX;
                    moveableComponent.MoveX = 0;
                }

                if(moveableComponent.MoveY != 0)
                {
                    positionComponent.Y += moveableComponent.MoveY;
                    moveableComponent.MoveY = 0;
                }

            }

        }
    }
}
