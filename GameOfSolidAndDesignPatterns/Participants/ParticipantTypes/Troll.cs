using GameOfSolidAndDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Participants.ParticipantTypes
{
    /// <summary>
    /// A participant in the game
    /// </summary>
    public class Troll : ParticipantBase
    {
        private const double maxStartHealth = 15;
        private const int maxItems = 3;
        private const int maxWeapons = 1;
 
        public Troll(string name,IStartupParticipantBase startupPaticipant, IParticipantBaseBehavior participantBaseBehavior) : base(name, maxStartHealth, maxItems, maxWeapons, startupPaticipant, participantBaseBehavior)
        {
        }
    }
}
