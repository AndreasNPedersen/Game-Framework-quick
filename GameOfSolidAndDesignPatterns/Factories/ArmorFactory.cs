using GameOfSolidAndDesignPatterns.Interfaces;
using GameOfSolidAndDesignPatterns.Items;
using GameOfSolidAndDesignPatterns.Items.DefenceItems.Body;
using GameOfSolidAndDesignPatterns.Items.DefenceItems.Boots;
using GameOfSolidAndDesignPatterns.Items.DefenceItems.Helmet;
using GameOfSolidAndDesignPatterns.Items.DefenceItems.Pants;
using GameOfSolidAndDesignPatterns.Items.DefenceItems.Shields;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Factories
{
    /// <summary>
    /// The Armor factory class to create armor objects
    /// </summary>
    public class ArmorFactory : IDefenceFactory
    {
        /// <summary>
        /// The create method of the different armor
        /// </summary>
        /// <param name="type">the type of armor (Enum)</param>
        /// <returns>The armor item</returns>
        public IItem CreateDefenceItem(ItemTypes type)
        {
            TraceSource ts = new TraceSource("TraceGame");
            ts.Switch = new SourceSwitch("AmorFactory", "All");

            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
            ts.TraceEvent(TraceEventType.Verbose, 31, "An Armor is created by the armor factory, of type: " + type.ToString());
            return type switch
            {
                ItemTypes.WoodenBodyArmor => new WoodenBodyArmor(),
                ItemTypes.WoodenBoots => new WoodenBoots(),
                ItemTypes.WoodenHelmet => new WoodenHelmet(),
                ItemTypes.WoodenPants => new WoodenPants(),
                ItemTypes.WoodenShield => new WoodenShield(),
                _ => throw new ArgumentException("Not in the Enum from ItemTypes Enum in Items"),

            };
        }
    }
}
