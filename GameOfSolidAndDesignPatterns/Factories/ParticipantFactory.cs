using GameOfSolidAndDesignPatterns.Interfaces;
using GameOfSolidAndDesignPatterns.Participants;
using GameOfSolidAndDesignPatterns.Participants.ParticipantTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Factories
{
    public class ParticipantFactory: IParticipantFactory
    {
        private TraceSource ts;
        public ParticipantFactory()
        {
            ts = new TraceSource("TraceGame");
            ts.Switch = new SourceSwitch("participantFactory", "All");
            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
        }

        /// <summary>
        /// A Character Factory creator method 
        /// </summary>
        /// <param name="type">The enum type of participant type</param>
        /// <param name="name">The name of the Character</param>
        /// <returns>The Participant Character</returns>
        public IParticipant CreateParticipantCharacter(ParticipantTypesEnum type, string name)
        {

            ts.TraceEvent(TraceEventType.Verbose, 29, "A character is created by the participant factory, of type: " + type.ToString());
            ts.Flush();
            return type switch 
            {
                ParticipantTypesEnum.Character => new Character(name,new ParticipantBaseStartup(), new ParticipantBaseBehavior()),
                ParticipantTypesEnum.Troll => new Troll(name,new ParticipantBaseStartup(), new ParticipantBaseBehavior()),
                _=> throw new ArgumentException("Not in the Enum from ParticipantTypesEnum in Participants"),
                
            };
        }

        /// <summary>
        /// A NPC Factory creator method
        /// </summary>
        /// <param name="type">The enum type of participant type</param>
        /// <returns>The NPC participant</returns>
        public IParticipant CreateParticipantNPC(ParticipantTypesEnum type)
        {
            ts.TraceEvent(TraceEventType.Verbose, 30, "A NPC is created by the participant factory, of type: " + type.ToString());
            ts.Flush();
            return type switch
            {
                ParticipantTypesEnum.Character => new Golem("Golem",new ParticipantBaseStartup(), new ParticipantBaseBehavior()),
                ParticipantTypesEnum.Troll => new Troll("Troll",new ParticipantBaseStartup(), new ParticipantBaseBehavior()),
                ParticipantTypesEnum.Golem => new Golem("Golem",new ParticipantBaseStartup(), new ParticipantBaseBehavior()),
                _ => throw new ArgumentException("Not in the Enum from ParticipantTypesEnum in Participants"),

            };
        }


    }
}
