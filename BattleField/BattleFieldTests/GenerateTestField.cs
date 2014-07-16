using BattleField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldTests
{
    internal static class GenerateTestField
    {
        internal static Cell[,] GenerateFieldWithSizeTwo()
        {
            var field = new Cell[2, 2];
            field[0, 0] = new Cell(0, 0, true, 1);
            field[0, 1] = new Cell(0, 1);
            field[0, 1].Detonate();
            field[1, 0] = new Cell(1, 0);
            field[1, 1] = new Cell(1, 1);

            return field;
        }

        internal static Cell[,] GenerateFieldWithSizeTenWithEmptyCells()
        {
            var field = new Cell[10, 10];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    field[i, k] = new Cell(i, k);
                }
            }
            return field;
        }
    }
}
