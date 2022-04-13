using GameOfSolidAndDesignPatterns.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Interfaces
{
    /// <summary>
    /// The interface to the Participant factory in which you can instantiate ParticipantBase objects
    /// </summary>
    public interface IParticipantFactory
    {
        /// <summary>
        /// Create the main character of the game
        /// </summary>
        /// <param name="types">The type of participant enum</param>
        /// <param name="name">the name of the character</param>
        /// <returns>The character</returns>
        public IParticipant CreateParticipantCharacter(ParticipantTypesEnum types, string name);
        /// <summary>
        /// Create an NPC
        /// </summary>
        /// <param name="types">The ype of NPC from enum</param>
        /// <returns>the NPC</returns>
        public IParticipant CreateParticipantNPC(ParticipantTypesEnum types);
    }
}
