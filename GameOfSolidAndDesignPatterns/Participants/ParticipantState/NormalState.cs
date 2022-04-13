
using GameOfSolidAndDesignPatterns.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Participants.ParticipantState
{
    /// <summary>
    /// The Normal state a participant can be in
    /// </summary>
    public class NormalState : CharacterStateAbstract
    {
        CreatureState creatureState = CreatureState.normal;

        /// <summary>
        /// The input that can change the state
        /// </summary>
        /// <param name="state">The state which the participant is in</param>
        /// <param name="item">the item that the participant is eating</param>
        public override void InputCreatureState(CreatureState state, ItemBase item)
        {
            TraceSource ts = new TraceSource("TraceGame");
            ts.Switch = new SourceSwitch("NormalState", "All");

            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
            ts.TraceEvent(TraceEventType.Verbose, 13, $"State Input with {state.ToString()} and itemID: {item.ID}");
            if (item.ID==9 && CreatureState.normal == state)
            {
                ts.TraceEvent(TraceEventType.Verbose, 14, $"State is changing to superpowered");
                this._context.TransistionTo(new Superpowered());
                creatureState = CreatureState.Superpower;
            } else
            {
                ts.TraceEvent(TraceEventType.Verbose, 15, $"State is not changeing, current state " + state.ToString());
                creatureState = CreatureState.normal;

            }
            ts.Flush();
        }
        /// <summary>
        /// outputs the state of the participant
        /// </summary>
        /// <returns>The state of the participant</returns>
        public override CreatureState OutputCreatureState()
        {
            return creatureState;
        }
    }
}
