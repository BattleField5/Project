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
            var gameboard = new Gameboard(2);
            gameboard[0, 0] = new Mine(MineRadius.MineRadiusOne);
            gameboard[0, 1] = new EmptyCell();
            gameboard[0, 1].Explode();
            gameboard[1, 0] = new EmptyCell();
            gameboard[1, 1] = new EmptyCell();
            return gameboard;
        }

        internal static IGameboard GenerateFieldWithSizeTenWithEmptyCells()
        {
            var gameboard = new Gameboard(10);

            for (int i = 0; i < gameboard.Size; i++)
            {
                for (int k = 0; k < gameboard.Size; k++)
                {
                    gameboard[i, k] = new EmptyCell();
                }
            }

            return gameboard;
        }
    }
}
