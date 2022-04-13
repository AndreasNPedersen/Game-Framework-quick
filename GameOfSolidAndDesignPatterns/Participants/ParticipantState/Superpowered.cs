
using GameOfSolidAndDesignPatterns.Items;
using System.Diagnostics;

namespace GameOfSolidAndDesignPatterns.Participants.ParticipantState
{
    /// <summary>
    /// The Super powered state a participant can be in
    /// </summary>
    public class Superpowered : CharacterStateAbstract
    {
        private CreatureState creatureState;
        /// <summary>
        /// The input that can change the state
        /// </summary>
        /// <param name="state">The state which the participant is in</param>
        /// <param name="item">the item that the participant is eating</param>
        public override void InputCreatureState(CreatureState state, ItemBase item)
        {
            TraceSource ts = new TraceSource("TraceGame");
            ts.Switch = new SourceSwitch("SuperpoweredState", "All");

            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
            ts.TraceEvent(TraceEventType.Verbose, 16, $"State Input with {state.ToString()} and itemID: {item.ID}");
            if (item.ID==8 && CreatureState.Superpower == state)
            {
                ts.TraceEvent(TraceEventType.Verbose, 17, $"State is changing to normal");
                this._context.TransistionTo(new NormalState());
                creatureState = CreatureState.normal;
            } else
            {
                creatureState = CreatureState.Superpower;
                ts.TraceEvent(TraceEventType.Verbose, 18, $"State is not changeing, current state " + state.ToString());
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
