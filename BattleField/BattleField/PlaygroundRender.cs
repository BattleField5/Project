using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public class PlaygroundRender : IPlaygroundRender
    {
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
                    result.Append(field[i, j] + " ");
                }

                result.AppendLine();
            }

            this.render.WriteLine(result.ToString());
        }
    }
}
