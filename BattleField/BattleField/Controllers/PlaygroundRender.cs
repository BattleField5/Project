using System;
using System.Text;

namespace BattleField
{
    public class PlaygroundRender : IPlaygroundRender
    {
        private const char EmptyCellSymbol = '-';
        private const char ExplodedCellSymbol = 'X';

        private IUiRender render;

        public PlaygroundRender(IUiRender render)
        {
            this.render = render;
        }

        public void RenderPlayground(IGameboard gameboard)
        {
            int size = gameboard.Size;
            var field = gameboard.Field;

            StringBuilder result = new StringBuilder();
            result.Append("   ");
            for (int i = 0; i < size; i++)
            {
                result.Append(i + " ");
            }

            result.AppendLine();
            result.Append("   ");
            for (int i = 0; i < size * 2; i++)
            {
                result.Append("-");
            }

            result.AppendLine();

            for (int i = 0; i < size; i++)
            {
                result.Append(i + " |");
                for (int j = 0; j < size; j++)
                {
                    if (field[i, j].Exploded)
                    {
                        result.Append(ExplodedCellSymbol + " ");
                    }
                    else if(field[i, j].IsMine)
                    {
                        int mineType = (int)((Mine)field[i, j]).Radius + 1;
                        result.Append(mineType + " ");
                    }
                    else
                    {
                        result.Append(EmptyCellSymbol + " ");
                    }                    
                }

                result.AppendLine();
            }

            this.render.WriteLine(result.ToString());
        }
    }
}
