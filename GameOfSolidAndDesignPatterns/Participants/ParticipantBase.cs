using GameOfSolidAndDesignPatterns.Interfaces;
using GameOfSolidAndDesignPatterns.Items;
using GameOfSolidAndDesignPatterns.Participants.ParticipantState;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Participants
{
    /// <summary>
    /// A Base/Super class for a participant in the game
    /// </summary>
    public class ParticipantBase : IParticipant
    {
        #region Instance fields
        private TraceSource ts;
        private int _maxInitialItems;
        private int _maxInitialWeapons;
        protected IParticipantBaseBehavior _behavior;
        #endregion

        #region Properties

        public string Name { get; }

        public double HealthPoints { get; private set; }

        public bool Dead { get { return HealthPoints <= 0; } }

        public List<IItem> Items { get; }
        public ContextState StateOfParticipant { get; }
        #endregion
        /// <summary>
        /// The constructor of a participant, which is open for change in the startup, and it's behaviors
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="maxStartHealth">Its maximum health at startup</param>
        /// <param name="maxItems">Its maximum Items</param>
        /// <param name="maxWeapons">Its maximum weapons</param>
        /// <param name="startupPaticipant">The class which have the startup</param>
        /// <param name="participantBaseBehavior">The class which have the participants behavior</param>
        #region constructor
        public ParticipantBase(string name, double maxStartHealth, int maxItems, int maxWeapons, IStartupParticipantBase startupPaticipant, IParticipantBaseBehavior participantBaseBehavior)
        {
            Name = name;
            _maxInitialItems = maxItems;
            _maxInitialWeapons = maxWeapons;
            StateOfParticipant = new ContextState(new NormalState());

            HealthPoints = startupPaticipant.SetInitialHealthPoints(maxStartHealth);
            Items = startupPaticipant.SetInitialItems();
            _behavior = participantBaseBehavior;
            ts = new TraceSource("TraceGame");
            ts.Switch = new SourceSwitch("AddItemToParticipant", "All");

            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
        }
        #endregion
        #region Methods
        /// <summary>
        /// Deal damage to the participant
        /// </summary>
        /// <returns>An int of the total damage it can deal</returns>
        public double DealDamage()
        {
            ts.TraceEvent(TraceEventType.Verbose, 19, "Dealing damage");
            ts.Flush();
            return _behavior.DealDamage(Items,StateOfParticipant.OutputCreatureState());
        }
        /// <summary>
        /// Receive damage at the participant
        /// </summary>
        /// <param name="damage">the damage it receives</param>
        public void ReceiveDamage(double damage)
        {
            ts.TraceEvent(TraceEventType.Verbose, 20, "received damage" + damage + " current health: " + HealthPoints);
            HealthPoints = HealthPoints - _behavior.ReceiveDamage(damage, Items);
            ts.TraceEvent(TraceEventType.Verbose, 21, "updated health: " + HealthPoints);
            ts.Flush();
        }
        /// <summary>
        /// Add an item to the participant
        /// </summary>
        /// <param name="item">an item from the Interface IItem</param>
        public void AddItem(IItem item)
        {
            try
            {
                Items.Add(_behavior.AddItem(item,Items,_maxInitialItems,_maxInitialWeapons));
                ts.TraceEvent(TraceEventType.Verbose, 22, "add the item" + item.Name);
                ts.Flush();
            } catch (ArgumentException ex)
            {
                ts.TraceEvent(TraceEventType.Error, 23, "Couldn't add the item" + item.Name);
                ts.Flush();
            }
        }
        /// <summary>
        /// Eat an item
        /// </summary>
        /// <param name="item">Item that can be eaten</param>
        public void Eat(IItem item)
        {
            ts.TraceEvent(TraceEventType.Verbose, 24, "An item is eaten" + item.Name + " and the current state is: " + StateOfParticipant.OutputCreatureState().ToString());
            _behavior.ChangeState(item, StateOfParticipant);
            ts.TraceEvent(TraceEventType.Verbose, 25, "the state is change/not change" + StateOfParticipant.OutputCreatureState().ToString());
            ts.TraceEvent(TraceEventType.Verbose, 26, "health current" + HealthPoints);
            HealthPoints = HealthPoints+ _behavior.Eat(item);
            ts.TraceEvent(TraceEventType.Verbose, 27, "health after" + HealthPoints);
            ts.Flush();
        }
        #endregion
    }
}
