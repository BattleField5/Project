using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public class ConsoleMessenger : IMessenger
    {
        private IUiRender render;
        public ConsoleMessenger()
            : this(new ConsoleWriter())
        {

        }

        public ConsoleMessenger(IUiRender render)
        {
            this.render = render;
        }

        public void AskForGameboardSize()
        {
            this.render.Write("Please enter the size of the gameboard: ");
        }

        public void AskForNewCoordinates()
        {
            this.render.Write("Please enter coordinates: ");
        }

        public void MessageForInvalidMove()
        {
            this.render.WriteLine("Invalid move!");
        }

        public void MessageForWrongGameboardSize()
        {
            this.render.WriteLine("Wrong input! Size must be number between 2-10");
        }
        public void MessageForWrongCoordinates()
        {
            this.render.WriteLine("Wrong input! Coordinates must be 2 numbers between 0-9 , separated by space");
        }
    }
}
