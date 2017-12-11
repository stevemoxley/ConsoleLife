using ConsoleLife.Framework.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework.Controllers
{
    public class DrawingController : Controller
    {

        public DrawingController()
        {
            Console.CursorVisible = false;
        }

        public override void Update(GameTime gameTime)
        {
            var entities = GetEntities(new List<Type>
            {
                typeof(DrawingComponent),
                typeof(PositionComponent)
            }).OrderBy(x => x.GetComponent<PositionComponent>().Y).ThenBy(x => x.GetComponent<PositionComponent>().X);


            foreach (var entity in entities)
            {
                var positionComponent = entity.GetComponent<PositionComponent>();
                var drawingComponent = entity.GetComponent<DrawingComponent>();

                if (!positionComponent.Placed)
                {
                    Console.SetCursorPosition(positionComponent.X, positionComponent.Y);
                    Console.ForegroundColor = drawingComponent.Color;
                    Console.Write(drawingComponent.Symbol);

                    positionComponent.PreviousX = positionComponent.X;
                    positionComponent.PreviousY = positionComponent.Y;
                    positionComponent.Placed = true;
                }

                if (positionComponent.Moved)
                {
                    //Clear the previous position
                    Console.SetCursorPosition(positionComponent.PreviousX, positionComponent.PreviousY);
                    Console.Write(" ");

                    //Write the new position
                    Console.SetCursorPosition(positionComponent.X, positionComponent.Y);
                    Console.ForegroundColor = drawingComponent.Color;
                    Console.Write(drawingComponent.Symbol);
                    
                }
         
            }
        }
    }
}
