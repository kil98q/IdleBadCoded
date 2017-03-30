using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idle
{
    static class GameUtils
    {
        static public string GenerateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
