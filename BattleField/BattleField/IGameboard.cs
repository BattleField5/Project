using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public interface IGameboard
    {
        Cell[,] Field
        {
            get;
        }

        int MinesCount
        {
            get;
        }

        int Size
        {
            get;
        }
    }
}
