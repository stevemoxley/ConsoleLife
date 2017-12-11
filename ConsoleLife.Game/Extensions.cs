using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework
{
    public static class Extensions
    {
        public static bool HasComponent<T>(this Entity entity)
        {
            return entity.Components.Any(c => c.GetType() == typeof(T));
        }

        public static bool HasComponent(this Entity entity, Type type)
        {
            var result = entity.Components.Any(c => c.GetType() == type);

            return result;
        }

        public static T GetComponent<T>(this Entity entity) where T : Components.Component
        {
            return entity.Components.Where(c => c.GetType() == typeof(T)).FirstOrDefault() as T;
        }

        public static void Add(this Entity entity)
        {
            Game.AddEntity(entity);
        }

        public static void Remove(this Entity entity)
        {
            Game.RemoveEntity(entity);
        }

    }
}
