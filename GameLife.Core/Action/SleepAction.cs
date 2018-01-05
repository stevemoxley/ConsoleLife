using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLife.Framework;
using ConsoleLife.Framework.Components;
using GameLife.Core.Components;

namespace GameLife.Core.Action
{
    public class SleepAction : BaseAction
    {

        public SleepAction()
        {
            _sleepTimer = _sleepTime;
        }

        public override void DoAction(GameTime gameTime, Entity entity)
        {
            var elapsed = gameTime.ElapsedMiliseconds;

            _sleepTimer -= elapsed;

            var drawingComponent = entity.GetComponent<DrawingComponent>();
            var lifeComponent = entity.GetComponent<LifeComponent>();

            if(!_oldColorSet)
            {
                _oldColor = drawingComponent.Color;
                drawingComponent.Color = ConsoleColor.Blue;
                _oldColorSet = true;
            }

            if(_sleepTimer <= 0)
            {
                Complete = true;
                drawingComponent.Color = _oldColor;
            }
            else
            {
                lifeComponent.Sleep += 1;
            }
        }

        private bool _oldColorSet = false;
        private ConsoleColor _oldColor;
        private int _sleepTime = 5000;
        private int _sleepTimer;


    }
}
