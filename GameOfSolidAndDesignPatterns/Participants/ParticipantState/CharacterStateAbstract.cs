
using GameOfSolidAndDesignPatterns.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Participants.ParticipantState
{
    /// <summary>
    /// The abstract class which the States shall inherent from
    /// </summary>
    public abstract class CharacterStateAbstract
    {
        protected ContextState _context;

        public void SetContext(ContextState context)
        {
            this._context = context;
        }
        /// <summary>
        /// The input that can change the state
        /// </summary>
        /// <param name="state">The state which the participant is in</param>
        /// <param name="item">the item that the participant is eating</param>
        public abstract void InputCreatureState(CreatureState state, ItemBase item);
        /// <summary>
        /// outputs the state of the participant
        /// </summary>
        /// <returns>The state of the participant</returns>
        public abstract CreatureState OutputCreatureState();

    }
}
