using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public interface IDetonator
    {
        void Detonate(Cell cell);
        Cell[,] Field { get; set; }
    }
}
