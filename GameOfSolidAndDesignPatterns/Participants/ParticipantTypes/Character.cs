

using GameOfSolidAndDesignPatterns.Interfaces;

namespace GameOfSolidAndDesignPatterns.Participants.ParticipantTypes
{
    /// <summary>
    /// The main character in the game
    /// </summary>
    public class Character : ParticipantBase
    {
        private const double maxStartHealth = 10;
        private const int maxItems = 5;
        private const int maxWeapons = 2;
        public Character(string name,  IStartupParticipantBase startupPaticipant, IParticipantBaseBehavior participantBaseBehavior) : 
            base(name, maxStartHealth, maxItems, maxWeapons, startupPaticipant, participantBaseBehavior)
        {
        }
    }
}
