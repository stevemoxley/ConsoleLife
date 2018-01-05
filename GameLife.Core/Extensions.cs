using ConsoleLife.Framework;
using ConsoleLife.Framework.Components;
using GameLife.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core
{
    public static class Extensions
    {

        /// <summary>
        /// Checks if this entity is at its current target
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsAtTarget(this Entity entity)
        {
            if(entity.HasComponent<PathfindingComponent>())
            {
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();

                return pathfindingComponent.ArrivedAtTarget;
            }
            else
            {
                throw new Exception("This entity doesnt have a pathfinding component");
            }
        }

        public static bool HasTarget(this Entity entity)
        {
            if (entity.HasComponent<PathfindingComponent>())
            {
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();

                return pathfindingComponent.HasTarget;
            }
            else
            {
                throw new Exception("This entity doesnt have a pathfinding component");
            }
        }

        /// <summary>
        /// Sets this entities target
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="target"></param>
        public static void SetTarget(this Entity entity, Entity target)
        {
            if(target == null)
            {
                throw new Exception("Target cannot be null");
            }
            if (entity.HasComponent<PathfindingComponent>())
            {
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();

                pathfindingComponent.SetTarget(target);
            }
            else
            {
                throw new Exception("This entity doesnt have a pathfinding component");
            }
        }

        public static void ResetTarget(this Entity entity)
        {
            if (entity.HasComponent<PathfindingComponent>())
            {
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();

                pathfindingComponent.Reset();
            }
            else
            {
                throw new Exception("This entity doesnt have a pathfinding component");
            }
        }

        public static Guid GetTargetId(this Entity entity)
        {
            if (entity.HasComponent<PathfindingComponent>())
            {
                var pathfindingComponent = entity.GetComponent<PathfindingComponent>();

                return pathfindingComponent.TargetId;
            }
            else
            {
                throw new Exception("This entity doesnt have a pathfinding component");
            }
        }

        public static Entity GetTargetEntity(this Entity entity)
        {
            var targetId = entity.GetTargetId();
            if(!HasTarget(entity))
            {
                return null;
            }
            return Game.AllEntities.Where(e => e.Id == targetId).SingleOrDefault();
        }
    }
}
