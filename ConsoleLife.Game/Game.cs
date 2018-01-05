using ConsoleLife.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleLife.Framework
{
    public static class Game
    {

        public static GameTime GameTime { get; } = new GameTime();

        public static List<Entity> AllEntities { get; } = new List<Entity>();

        public static List<Controller> AllControllers { get; } = new List<Controller>();

        public static World World { get; } = new World();

        public static void Start()
        {
            GameInitializer.InitializeControllers();

            while (true)
            {
                Update();
            }
        }

        public static void Save()
        {

        }

        public static void Load()
        {

        }

        public static void AddEntity(Entity entity)
        {
            _addWaitList.Add(entity);
        }

        public static void RemoveEntity(Entity entity)
        {
            _deleteWaitList.Add(entity);
        }

        public static void RemoveEntity(Guid id)
        {
            var entity = AllEntities.Where(e => e.Id == id).FirstOrDefault();
            RemoveEntity(entity);
        }

        private static void Update()
        {
            //These first
            DetectUserInput();
            AddEntities();
            RemoveEntities();

            //Update controllers
            foreach (var controller in AllControllers)
            {
                controller.Update(GameTime);
            }

            //Post Update controllers
            foreach (var controller in AllControllers)
            {
                controller.PostUpdate(GameTime);
            }

            //This last
            GameTime.Update();
            Thread.Sleep(17);
        }

        private static void AddEntities()
        {
            AllEntities.AddRange(_addWaitList);
            _addWaitList.Clear();
        }

        private static void RemoveEntities()
        {
            foreach (var entity in _deleteWaitList)
            {
                AllEntities.Remove(entity);
            }
            _deleteWaitList.Clear();
        }

        private static void DetectUserInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                Debug.WriteLine(string.Format("A key was pressed {0}", key.KeyChar.ToString()));
                InputHandler.Update(key.KeyChar);
            }
        }

        private static List<Entity> _addWaitList = new List<Entity>();
        private static List<Entity> _deleteWaitList = new List<Entity>();


    }
}
