using GameOfSolidAndDesignPatterns.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Interfaces
{
    /// <summary>
    /// The interface to the item factory in which you can instantiate ItemBase objects
    /// </summary>
    public interface IItemFactory
    {
        /// <summary>
        /// instantiate an item
        /// </summary>
        /// <param name="type">the enum type</param>
        /// <returns>The item item</returns>
        public IItem CreateItem(ItemTypes type);
    }
}
