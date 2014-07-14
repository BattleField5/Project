using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public class GameboardProxy : IGameboard
    {        
        private static IGameboard gameboard = null;

        public static IGameboard Initialize(int size)
        {
            if (gameboard == null)
            {
                //gameboard = new Gameboard(size);
            }
            return gameboard;
        }

        public Cell[,] Field
        {
            get { return gameboard.Field; }
        }

        public int MinesCount
        {
            get { return gameboard.MinesCount; }
        }

        public int Size
        {
            get { return gameboard.Size; }
        }
    }
}
