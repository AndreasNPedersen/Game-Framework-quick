
using GameOfSolidAndDesignPatterns.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Participants.ParticipantState
{
    /// <summary>
    /// The State class that uses the State pattern to change state.
    /// </summary>
    public class ContextState
    {
        public CharacterStateAbstract _state = null;
        /// <summary>
        /// A context state constructor that instantiate the state which the character is in.
        /// </summary>
        /// <param name="state"></param>
        public ContextState(CharacterStateAbstract state)
        {
            this.TransistionTo(state);
        }
        /// <summary>
        /// Transition of a state
        /// </summary>
        /// <param name="state">The abstract state of the participant</param>
        public void TransistionTo (CharacterStateAbstract state)
        {
            this._state = state;
            this._state.SetContext(this);
        }
        /// <summary>
        /// outputs the state of the participant
        /// </summary>
        /// <returns>The state of the participant</returns>
        public CreatureState OutputCreatureState()
        {
            return this._state.OutputCreatureState();
        }
        /// <summary>
        /// The input that can change the state
        /// </summary>
        /// <param name="state">The state which the participant is in</param>
        /// <param name="item">the item that the participant is eating</param>
        public void InputCreatureState(CreatureState state, ItemBase item)
        {
            this._state.InputCreatureState(state, item);
        }
    }
}
