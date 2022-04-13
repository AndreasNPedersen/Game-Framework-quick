using GameOfSolidAndDesignPatterns.Participants.ParticipantState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Interfaces
{
    /// <summary>
    /// The interface to the weapon factory in which you can instantiate WeaponBase objects
    /// </summary>
    public interface IParticipantBaseBehavior
    {
        /// <summary>
        /// Deal damage from all the weapons and state of the participant
        /// </summary>
        /// <param name="items">the list of items of the participant</param>
        /// <param name="state">the current state of the character</param>
        /// <returns>the total damage</returns>
        double DealDamage(List<IItem> items, CreatureState state);
        /// <summary>
        /// Receive damage to the participant, and reduce it with the items of the participant
        /// </summary>
        /// <param name="damage">the total damage</param>
        /// <param name="items">all the items of the participant</param>
        /// <returns>the total received damage</returns>
        double ReceiveDamage(double damage, List<IItem> items);
        /// <summary>
        /// Add and item to the participant items list
        /// </summary>
        /// <param name="item">the item to be added</param>
        /// <param name="items">the current participant list</param>
        /// <param name="maxItem">the maximum amount of item the participant can carry</param>
        /// <param name="maxWeapons">the maximum amount of weapons the participant can carry</param>
        /// <returns>the item to be added</returns>
        IItem AddItem(IItem item, List<IItem> items, int maxItem, int maxWeapons);
        /// <summary>
        /// Change the state of the participant
        /// </summary>
        /// <param name="item">the item to change the state of the participant</param>
        /// <param name="state">the participants current state</param>
        /// <returns></returns>
        ContextState ChangeState(IItem item, ContextState state);
        /// <summary>
        /// Eat and item to get health
        /// </summary>
        /// <param name="item">the item to get eaten</param>
        /// <returns>the heal</returns>
        int Eat(IItem item);

    }
}
