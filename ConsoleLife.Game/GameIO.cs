using ConsoleLife.Framework.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework
{
    internal static class GameIO
    {

        public static void Save(string filename)
        {
            
            var jsonString = JsonConvert.SerializeObject(Game.AllEntities, settings);
            File.WriteAllText(filename, jsonString);
        }

        public static void Load(string filename)
        {
            var jsonString = File.ReadAllText(filename);
            var allEntities = JsonConvert.DeserializeObject<List<Entity>>(jsonString, settings);
            Game.AllEntities.Clear();
            Console.Clear();
            foreach (var entity in allEntities)
            {
                entity.Add();

                entity.GetComponent<DrawingComponent>().ForceRedraw = true;
            }
        }

        private static JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

    }
}
