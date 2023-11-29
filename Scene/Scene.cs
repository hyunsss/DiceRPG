using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public abstract class Scene
    {
        Running running;

        public Scene(Running running)
        {
            this.running = running;
        }

        public abstract void Render();
        public abstract void Update();

    }

    
}
