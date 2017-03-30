using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idle
{
    public abstract class GameObject
    {
        public string ObjectID;


        public GameObject()
        {
            ObjectID = GameUtils.GenerateID();
        }
        public abstract void Update();
        public abstract void Draw();
    }
}
