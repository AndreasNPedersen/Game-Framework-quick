using GameOfSolidAndDesignPatterns.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Interfaces
{
    /// <summary>
    /// The interface to the weapon factory in which you can instantiate ArmorBase objects
    /// </summary>
    public interface IDefenceFactory
    {
        /// <summary>
        /// instantiate a armor item
        /// </summary>
        /// <param name="type">the enum type</param>
        /// <returns>The item</returns>
        public IItem CreateDefenceItem(ItemTypes type);
    }
}
