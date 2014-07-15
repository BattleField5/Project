using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public interface IControllerMessenger
    {
        void MessageForGameOver(int detonatedMines);
        void AskForGameboardSize();

        void AskForNewCoordinates();

        void MessageForInvalidMove();

        void MessageForWrongGameboardSize();

        void MessageForWrongCoordinates();

    }
}
