using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework.Controllers
{
    public class GameIOController : Controller
    {
        public override void Update(GameTime gameTime)
        {
            if(InputHandler.MostRecentKeyPress == 's')
            {
                Debug.WriteLine("Saving");
                Game.Save();
            }
            if(InputHandler.MostRecentKeyPress == 'l')
            {
                Debug.WriteLine("Loading");
                Game.Load();
            }
        }
    }
}
