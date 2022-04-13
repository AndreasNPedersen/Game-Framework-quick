using GameOfSolidAndDesignPatterns.Items;
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
    public interface IWeaponFactory
    {
        /// <summary>
        /// instantiate a weapon item
        /// </summary>
        /// <param name="type">the enum type</param>
        /// <returns>The weapon item</returns>
        public IItem CreateItem(ItemTypes type);
    }
}
