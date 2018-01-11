using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework.Controllers
{
    public abstract class Controller
    {
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// This will run after all controllers have been updated
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void PostUpdate(GameTime gameTime)
        {

        }

        public List<Entity> GetEntities<T>() where T : Components.Component
        {
            var entities = Game.AllEntities.Where(e => e.HasComponent<T>() && e.Scene == Game.Scene).ToList();
            return entities;
        }

        public List<Entity> GetEntities(List<Type> componentTypes)
        {
            var result = new List<Entity>();

            result.AddRange(Game.AllEntities);

            foreach (var type in componentTypes)
            {
                result.RemoveAll(e => !e.HasComponent(type));
            }

            result.RemoveAll(e => e.Scene != Game.Scene);

            return result;

        }

    }
}
