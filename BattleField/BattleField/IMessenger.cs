using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    public interface IMessenger
    {
        void AskForGameboardSize();

        void AskForNewCoordinates();

        void MessageForInvalidMove();


        void MessageForWrongGameboardSize();

        void MessageForWrongCoordinates();

    }
}
