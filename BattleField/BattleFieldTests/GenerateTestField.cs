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
            Cell[,] field = new Cell[2, 2];
            field[0, 0] = new Mine(MineRadius.MineRadiusOne);
            field[0, 1] = new EmptyCell();
            field[0, 1].Explode();
            field[1, 0] = new EmptyCell();
            field[1, 1] = new EmptyCell();
            return field;
        }

        internal static Cell[,] GenerateFieldWithSizeTenWithEmptyCells()
        {
            var field = new Cell[10, 10];
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int k = 0; k < field.GetLength(1); k++)
                {
                    field[i, k] = new EmptyCell();
                }
            }

            return field;
        }
    }
}
