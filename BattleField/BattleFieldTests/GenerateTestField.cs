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
        internal static IGameboard GenerateFieldWithSizeTwo()
        {
            var gameboard = new Gameboard();
            gameboard.Size = 2;
            gameboard.Field = new Cell[2, 2];
            gameboard.Field[0, 0] = new Mine(MineRadius.MineRadiusOne);
            gameboard.Field[0, 1] = new EmptyCell();
            gameboard.Field[0, 1].Explode();
            gameboard.Field[1, 0] = new EmptyCell();
            gameboard.Field[1, 1] = new EmptyCell();
            return gameboard;
        }

        internal static IGameboard GenerateFieldWithSizeTenWithEmptyCells()
        {
            var gameboard = new Gameboard();
            
            gameboard.Field = new Cell[10, 10];
            gameboard.Size = 10;
            for (int i = 0; i < gameboard.Field.GetLength(0); i++)
            {
                for (int k = 0; k < gameboard.Field.GetLength(1); k++)
                {
                    gameboard.Field[i, k] = new EmptyCell();
                }
            }

            return gameboard;
        }
    }
}
