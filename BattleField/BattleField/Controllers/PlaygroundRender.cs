namespace BattleField.Controllers
{
    using System;
    using System.Text;
    using BattleField.Cells;
    using BattleField.Contracts;
    using BattleField.Controllers;
    using BattleField.Enumerations;

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
                    if (gameboard[i, j].Exploded)
                    {
                        result.Append(ExplodedCellSymbol + " ");
                    }
                    else if (gameboard[i, j].IsMine)
                    {
                        int mineType = (int)((Mine)gameboard[i, j]).Radius + 1;
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
