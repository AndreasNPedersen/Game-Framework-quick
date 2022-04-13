using GameOfSolidAndDesignPatterns.Factories;
using GameOfSolidAndDesignPatterns.Interfaces;
using GameOfSolidAndDesignPatterns.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Participants
{
    /// <summary>
    /// The initialization of a participants item and stats 
    /// </summary>
    public class ParticipantBaseStartup : IStartupParticipantBase
    {

        /// <summary>
        /// Set the health of the participant, which is generated randomly
        /// </summary>
        /// <param name="maxHealth">Set the maximum health the participant </param>
        /// <returns>A double of the health</returns>
        public double SetInitialHealthPoints(double maxHealth)
        {
            try
            {
                return new Random().Next(1, Convert.ToInt32(maxHealth));
            } catch (Exception)
            {
                return maxHealth/3;
            }
        }

        /// <summary>
        /// Set the Items at spawn, generated randomly
        /// </summary>
        /// <returns>A list of IItems</returns>
        public List<IItem> SetInitialItems()
        {
            ArmorFactory armorFactory = new ArmorFactory();
            ItemFactory itemFactory = new ItemFactory();
            WeaponFactory weaponFactory = new WeaponFactory();
            List<IItem> items = new List<IItem>();
            items.Add(armorFactory.CreateDefenceItem((ItemTypes)new Random().Next(0, 5)));
            items.Add(itemFactory.CreateItem((ItemTypes)new Random().Next(7, 9)));
            items.Add(weaponFactory.CreateItem((ItemTypes)new Random().Next(5, 7)));
            return items;
        }
    }
}
