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
            return entity.Components.Any(c => c.GetType() == typeof(T) || c.GetType().IsSubclassOf(typeof(T)));
        }

        public static bool HasComponent(this Entity entity, Type type)
        {
            var result = entity.Components.Any(c => c.GetType() == type || c.GetType().IsSubclassOf(type));

            return result;
        }

        public static T GetComponent<T>(this Entity entity) where T : Components.Component
        {
            return entity.Components.Where(c => c.GetType() == typeof(T) || c.GetType().IsSubclassOf(typeof(T))).FirstOrDefault() as T;
        }

        public static List<Components.Component> GetComponents<T>(this Entity entity) where T : Components.Component
        {
            return entity.Components.Where(c => c.GetType() == typeof(T) || c.GetType().IsSubclassOf(typeof(T))).ToList();
        }

        /// <summary>
        /// Add this entity to the game
        /// </summary>
        /// <param name="entity"></param>
        public static void Add(this Entity entity)
        {
            Game.AddEntity(entity);
        }

        /// <summary>
        /// Remove this entity from the game
        /// </summary>
        /// <param name="entity"></param>
        public static void Remove(this Entity entity)
        {
            Game.RemoveEntity(entity);
        }

    }
}
