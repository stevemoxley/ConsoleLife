﻿using ConsoleLife.Framework;
using ConsoleLife.Framework.Components;
using GameLife.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core
{
    public static class EntityFactory
    {

        public static Entity CreateLifeEntity(int x, int y)
        {
            Entity entity = new Entity();

            entity.Components.Add(new DrawingComponent
            {
                Symbol = "O",
                Color = ConsoleColor.Green
            });

            entity.Components.Add(new PositionComponent
            {
                X=x,
                Y=y
            });

            entity.Components.Add(new MoveableComponent());

            entity.Components.Add(new HealthComponent());

            return entity;
        }

        public static Entity CreateEnemyEntity(int x, int y)
        {
            var entity = CreateLifeEntity(x, y);

            entity.Components.Add(new EnemyComponent());
            entity.Components.Add(new MovementPatternComponent());

            var drawingComponent = entity.GetComponent<DrawingComponent>();
            drawingComponent.Symbol = "X";
            drawingComponent.Color = ConsoleColor.Red;

            return entity;
        }

        public static Entity CreateStraightMoveEnemy(int x, int y)
        {
            var entity = CreateEnemyEntity(x, y);

            var movementPatternComponent = entity.GetComponent<MovementPatternComponent>();
            movementPatternComponent.MovementPattern = MovementPatterns.Straight;

            return entity;
        }

        public static Entity CreateZigZagMoveEnemy(int x, int y)
        {
            var entity = CreateEnemyEntity(x, y);

            var movementPatternComponent = entity.GetComponent<MovementPatternComponent>();
            movementPatternComponent.MovementPattern = MovementPatterns.ZigZag;

            return entity;
        }

    }
}
