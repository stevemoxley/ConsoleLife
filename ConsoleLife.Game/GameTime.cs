using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife.Framework
{
    public class GameTime
    {
        public GameTime()
        {
            _startTime = DateTime.Now;
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                return DateTime.Now - _startTime;
            }
        }

        public TimeSpan TimeSinceLastUpdate
        {
            get
            {
                return DateTime.Now - _lastUpdateTime;
            }
        }

        public int ElapsedMiliseconds
        {
            get
            {
                return TimeSinceLastUpdate.Milliseconds;
            }
        }

        /// <summary>
        /// Gets called by the game update loop
        /// </summary>
        internal void Update()
        {
            _lastUpdateTime = DateTime.Now;
        }

        private DateTime _startTime;
        private DateTime _lastUpdateTime;

    }
}
