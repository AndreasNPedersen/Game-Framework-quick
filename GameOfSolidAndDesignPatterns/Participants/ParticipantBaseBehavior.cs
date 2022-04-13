using GameOfSolidAndDesignPatterns.Interfaces;
using GameOfSolidAndDesignPatterns.Items;
using GameOfSolidAndDesignPatterns.Participants.ParticipantState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Participants
{
    /// <summary>
    /// The Behavior of a Participant
    /// </summary>
    public class ParticipantBaseBehavior : IParticipantBaseBehavior
    {
        /// <summary>
        /// The participant adds an item to it's list of IItems
        /// </summary>
        /// <param name="item">The picked up item</param>
        /// <param name="items">the list of the participant items</param>
        /// <param name="maxItem">the maximum amount of items it can carry</param>
        /// <param name="maxWeapons">the maximum amount of weapon it can carry</param>
        /// <returns>The list of items</returns>
        /// <exception cref="ArgumentException">Thrown if the item cannot be added</exception>
        public IItem AddItem(IItem item,List<IItem> items, int maxItem, int maxWeapons)
        {

            if (items.Where(c => c is WeaponBase).Count() !> maxWeapons)
            {
                return item;
            }
            else if (items.Where(c => c is ItemBase).Count() !> maxItem)
            {
                return item;
            }
            else
            {
                throw new ArgumentException("Item cannot be added, is not a class, or too many items/weapons already there");
            }
        }

        /// <summary>
        /// Change the participant state
        /// </summary>
        /// <param name="item">The item to change it's state</param>
        /// <param name="state">the participants current state</param>
        /// <returns>the context state object</returns>
        public ContextState ChangeState(IItem item, ContextState state)
        {
            if (item is ItemBase)
            {
                ItemBase baseItem = (ItemBase)item;
                state.InputCreatureState(state.OutputCreatureState(), baseItem);

            }
            return state;
        }
        /// <summary>
        /// The damage a participant can do from it's items and state
        /// </summary>
        /// <param name="items">the participants list of items</param>
        /// <param name="state">the participant state</param>
        /// <returns>the damage</returns>
        public double DealDamage(List<IItem> items, CreatureState state)
        {
            double totalDamage = 0;
            foreach (IItem item in items)
            {
                if (item is WeaponBase)
                {
                    WeaponBase weapon = (WeaponBase)item;
                    totalDamage = totalDamage + weapon.Damage;
                }
            }
            if (state == CreatureState.Superpower)
            {
                totalDamage = totalDamage * 1.5;
            }
            return totalDamage;
        }
        /// <summary>
        /// The received damage to the participant, which gets reduced from the items
        /// </summary>
        /// <param name="damage">the total damage to the participant</param>
        /// <param name="items">the participants items</param>
        /// <returns>the actual received damage</returns>
        public double ReceiveDamage(double damage, List<IItem> items)
        {
            int totalReducedDamage = 0;
            foreach (IItem item in items)
            {
                if (item is ArmorBase)
                {
                    ArmorBase armor = (ArmorBase)item;
                    totalReducedDamage = totalReducedDamage + armor.ReduceHitPoints;
                }
            }
            double recivedmg = damage - totalReducedDamage;
            if (recivedmg < 0)
            {
                return 0;
            }
            return recivedmg;
        }
        /// <summary>
        /// eat an item of which is a ItemBase object
        /// </summary>
        /// <param name="item">the item</param>
        /// <returns>the healing from the eaten item</returns>
        public int Eat(IItem item)
        {
            if (item is ItemBase)
            {
                ItemBase food = (ItemBase) item;
                return food.Healing;
            }
            return 0;
        }
    }
}
