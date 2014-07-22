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

        public void RenderPlayground(Cell[,] field)
        {
            StringBuilder result = new StringBuilder();
            result.Append("   ");
            int size = field.GetLength(0);
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
                    else if(field[i, j] is Mine)
                    {
                        int mineType = (int)(field[i, j] as Mine).Radius + 1;
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
