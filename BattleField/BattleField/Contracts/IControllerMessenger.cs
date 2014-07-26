using System;

namespace BattleField.Contracts
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
