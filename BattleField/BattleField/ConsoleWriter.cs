using System;
using System.Linq;
using System.Text;

namespace BattleField
{    
    /// <summary>
    /// Writes on the Console.
    /// </summary>
    public class ConsoleWriter : IUiRender
    {
        private const char EmptyCellSymbol = '-';
        private const char ExplodedCellSymbol = 'X';

        /// <summary>
        /// Write a line on the Console.
        /// </summary>
        /// <param name="text">Line to write</param>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Writes on the current line of the console.
        /// </summary>
        /// <param name="text">Text to write</param>
        public void Write(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Renders Field on the Console.
        /// </summary>
        /// <param name="field"></param>
        public void RenderField(Cell[,] field)
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
                    else if (field[i, j] is Mine)
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

            this.WriteLine(result.ToString());
        }
    }
}
