using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework
{
    public static class GameIO
    {


        public static void Save(string filename)
        {
            var jsonString = JsonConvert.SerializeObject(Game.AllEntities);
            File.WriteAllText(jsonString, jsonString);
        }


        public static void Load(string filename)
        {
            var jsonString = File.ReadAllText(filename);
            var allEntities = JsonConvert.DeserializeObject<List<Entity>>(jsonString);
            Game.AllEntities.Clear();
            Game.AllEntities.AddRange(allEntities);
        }



    }
}
