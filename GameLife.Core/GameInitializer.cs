﻿using ConsoleLife.Framework;
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
            Game.AllControllers.Add(new PathfindingController());

            Game.AllControllers.Add(new SpawnFoodController());

            Game.AllControllers.Add(new ActionController());

        }

        private static void InitializeEntities()
        {
            var life = EntityFactory.CreateLifeEntity(0, 0);
            life.Add();

            var life1 = EntityFactory.CreateLifeEntity(25, 0);
            life1.Add();

            var life2 = EntityFactory.CreateLifeEntity(50, 0);
            life2.Add();

            var life3 = EntityFactory.CreateLifeEntity(75, 0);
            life3.Add();

            //var life4 = EntityFactory.CreateLifeEntity(0, Console.WindowHeight - 1);
            //life4.Add();

            //var life5 = EntityFactory.CreateLifeEntity(25, Console.WindowHeight - 1);
            //life5.Add();

            //var life6 = EntityFactory.CreateLifeEntity(50, Console.WindowHeight - 1);
            //life5.Add();

            //var life7 = EntityFactory.CreateLifeEntity(75, Console.WindowHeight - 1);
            //life7.Add();

            InitializeTerrain();
        }

        private static void InitializeTerrain()
        {
            int chanceToSpawnRock = 30;

            for (int x = 1; x < Console.WindowWidth; x++)
            {
                for (int y = 1; y < Console.WindowHeight; y++)
                {
                    if(x == 0)
                    {
                        continue;
                    }

                    if (x == Console.WindowWidth - 1 && y == Console.WindowHeight - 1)
                    {
                        continue;
                    }

                    int randomChance = RNG.Next(100);

                    if(randomChance < chanceToSpawnRock)
                    {
                        var rock = EntityFactory.CreateImpassableEntity(x, y);
                        rock.Add();
                    }
                }
            }
        }
            
            

    }
}
