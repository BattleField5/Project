using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public interface IRandomGenerator
    {
        int GetRandom(int min, int max);
    }
}
