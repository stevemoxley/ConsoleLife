using ConsoleLife.Framework;
using GameLife.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLife.Core
{
    public class GameInitializer
    {
        public static void InitializeGame()
        {
            InitializeControllers();

            InitializeEntities();
        }

        private static void InitializeControllers()
        {
            Game.AllControllers.Add(new MovementPatternController());
        }

        private static void InitializeEntities()
        {

            var life = EntityFactory.CreateLifeEntity(10, 10);
            life.Add();

            var enemy1 = EntityFactory.CreateStraightMoveEnemy(0, 0);
            enemy1.Add();

            var enemy2 = EntityFactory.CreateZigZagMoveEnemy(50, 0);
            enemy2.Add();
        }
            
            

    }
}
