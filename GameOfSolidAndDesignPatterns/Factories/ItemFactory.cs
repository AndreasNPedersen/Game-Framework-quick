using GameOfSolidAndDesignPatterns.Interfaces;
using GameOfSolidAndDesignPatterns.Items;
using GameOfSolidAndDesignPatterns.Items.WorldItems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Factories
{
        /// <summary>
        /// The Item factory class to create item objects
        /// </summary>
    public class ItemFactory : IItemFactory
    {
        
        /// <summary>
        /// The create method of the different items
        /// </summary>
        /// <param name="type">the type of item (Enum)</param>
        /// <returns>The item</returns>
        public IItem CreateItem(ItemTypes type)
        {
            TraceSource ts = new TraceSource("TraceGame");
            ts.Switch = new SourceSwitch("ItemFactory", "All");

            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
            ts.TraceEvent(TraceEventType.Verbose, 30, "An Item is created by the item factory, of type: " + type.ToString());
            return type switch
            {
                ItemTypes.Mushroom => new Bread(),
                ItemTypes.Bread => new Mushroom(),
                _ => throw new ArgumentException("Not in the Enum from ItemTypes Enum in Items"),

            };
        }
    }
}
