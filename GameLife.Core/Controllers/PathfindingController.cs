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
    public class PathfindingController : BaseConsoleLifeController
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

                if (pathfindingComponent.Elapsed && pathfindingComponent.HasTarget)
                {
                    if (!HasNewLocation(positionComponent, pathfindingComponent))
                    {
                        //We are at the target
                        pathfindingComponent.ArrivedAtTarget = true;
                        continue;
                    }
                    else
                    {
                        pathfindingComponent.ArrivedAtTarget = false;
                        pathfindingComponent.UnableToFindPath = false;
                    }

                    //Find the path
                    var path = _pathfindingService.FindPath(positionComponent, pathfindingComponent);
                    if (path != null && path.Count > 0)
                    {
                        var nextStep = path[0];
                        var nextMovement = NextMovement(positionComponent.X, positionComponent.Y, nextStep.X, nextStep.Y);
                        movableComponent.MoveX = nextMovement.Item1;
                        movableComponent.MoveY = nextMovement.Item2;
                    }
                    else
                    {
                        //No path 
                        pathfindingComponent.UnableToFindPath = true;
                    }

                    if (pathfindingComponent.ArrivedAtTarget || pathfindingComponent.UnableToFindPath)
                    {
                        //What do we do when we have arrived at our target or cant find a path?
                    }
                }
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {
            var entities = GetEntities(new List<Type>()
            {
                typeof(PathfindingComponent),
                typeof(PositionComponent),
                typeof(MoveableComponent)
            });

            foreach (var entity in entities)
            {
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();

                if (pathfindingComponent.ArrivedAtTarget || pathfindingComponent.UnableToFindPath)
                {
                    pathfindingComponent.Reset();
                }
            }
        }

        private bool HasNewLocation(PositionComponent positionComponent, PathfindingComponent pathfindingComponent)
        {
            if (positionComponent.X != pathfindingComponent.TargetX || positionComponent.Y != pathfindingComponent.TargetY)
            {
                return true;
            }
            return false;
        }

        private Tuple<int, int> NextMovement(int currentX, int currentY, int nextX, int nextY)
        {
            return new Tuple<int, int>(nextX - currentX, nextY - currentY);
        }

        private PathfindingService _pathfindingService;


    }
}
