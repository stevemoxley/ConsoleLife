using ConsoleLife.Framework;
using ConsoleLife.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core.Components
{
    public class PathfindingComponent : TimedComponent
    {
        public int TargetX { get; private set; } = -1;

        public int TargetY { get; private set; } = -1;

        public bool ArrivedAtTarget { get; set; } = false;

        public bool UnableToFindPath { get; set; } = false;

        public Guid TargetId { get; private set; } = Guid.Empty;

        public bool HasTarget
        {
            get
            {
                return TargetX != -1 && TargetY != -1;
            }
        }

        public PathfindingComponent()
        {
            Delay = 25;
        }

        public void Reset()
        {
            TargetX = -1;
            TargetY = -1;
            ArrivedAtTarget = false;
            UnableToFindPath = false;
            TargetId = Guid.Empty;
        }

        public void SetTarget(Entity entity)
        {
            if(entity.HasComponent<PositionComponent>())
            {
                var positionComponent = entity.GetComponent<PositionComponent>();
                TargetX = positionComponent.X;
                TargetY = positionComponent.Y;
                TargetId = entity.Id;
                ArrivedAtTarget = false;
                UnableToFindPath = false;
            }
            else
            {
                throw new Exception("tried to set target that has no position");
            }
        }
  
    }
}
