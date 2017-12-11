using ConsoleLife.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLife.Framework;
using GameLife.Core.Components;
using ConsoleLife.Framework.Components;
using System.Diagnostics;
using GameLife.Core.Pathfinding;

namespace GameLife.Core.Controllers
{
    public class PathfindingController : Controller
    {

        public PathfindingController()
        {
            _pathfindingService = new PathfindingService();
        }

        public override void Update(GameTime gameTime)
        {

            var entities = GetEntities(new List<Type>()
            {
                typeof(PathfindingComponent),
                typeof(PositionComponent),
                typeof(MoveableComponent)
            });


            foreach (var entity in entities)
            {
                var positionComponent = entity.GetComponent<PositionComponent>();
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();
                var movableComponent = entity.GetComponent<MoveableComponent>();

                if(pathfindingComponent.Elapsed)
                {
                    
                    if(!HasNewLocation(positionComponent, pathfindingComponent))
                    {
                        continue;
                    }

                    //Find the path
                    var path = _pathfindingService.FindPath(positionComponent.X, positionComponent.Y, pathfindingComponent.TargetX, pathfindingComponent.TargetY, GenerateNodeMap());
                    if (path != null && path.Count > 0)
                    {
                        var nextStep = path[0];
                        var nextMovement = NextMovement(positionComponent.X, positionComponent.Y, nextStep.X, nextStep.Y);
                        movableComponent.MoveX = nextMovement.Item1;
                        movableComponent.MoveY = nextMovement.Item2;
                    }
                }
            }
        }

        private bool HasNewLocation(PositionComponent positionComponent, PathfindingComponent pathfindingComponent)
        {
            if(positionComponent.X != pathfindingComponent.TargetX || positionComponent.Y != pathfindingComponent.TargetY)
            {
                return true;
            }
            return false;
        }

        private Tuple<int, int> NextMovement(int currentX, int currentY, int nextX, int nextY)
        {
            return new Tuple<int, int>(nextX - currentX, nextY - currentY);
        }

        private Node[,] GenerateNodeMap()
        {
            Node[,] result = new Node[Console.WindowWidth, Console.WindowHeight];
            var entities = Game.AllEntities.Where(e => e.HasComponent<PositionComponent>());

            foreach (var entity in entities)
            {
                var positionComponent = entity.GetComponent<PositionComponent>();
                Node node = new Node();
                node.X = positionComponent.X;
                node.Y = positionComponent.Y;

                if (entity.HasComponent<MoveableComponent>())
                {
                    var moveableComponent = entity.GetComponent<MoveableComponent>();
                    node.X = positionComponent.X + moveableComponent.MoveX;
                    node.Y = positionComponent.Y + moveableComponent.MoveY;
                }

                if(entity.HasComponent<ImpassableComponent>())
                {
                    node.IsValid = false;
                }

                result[node.X, node.Y] = node;
            }


            for (int x = 0; x < Console.WindowWidth; x++)
            {
                for (int y = 0; y < Console.WindowHeight; y++)
                {
                    var node = result[x, y];
                    if(node == null)
                    {
                        node = new Node();
                        node.X = x;
                        node.Y = y;
                        result[node.X, node.Y] = node;
                    }
                }
            }

            return result;

        }

        private PathfindingService _pathfindingService;


    }
}
