using GameOfSolidAndDesignPatterns.Interfaces;
using GameOfSolidAndDesignPatterns.Items;
using GameOfSolidAndDesignPatterns.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Factories
{
    public class WeaponFactory : IWeaponFactory
    {
        /// <summary>
        /// The create method of the different weapons
        /// </summary>
        /// <param name="type">the type of weapon (Enum)</param>
        /// <returns>The weapon item</returns>
        public IItem CreateItem(ItemTypes type)
        {
            TraceSource ts = new TraceSource("TraceGame");
            ts.Switch = new SourceSwitch("weaponFactory", "All");

            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
            ts.TraceEvent(TraceEventType.Verbose, 28, "A weapon is created by the weapon factory, of type: " +type.ToString());
            return type switch
            {
                ItemTypes.WoodenSword => new WoodSword(),
                ItemTypes.IronMace => new IronMace(),
                _ => throw new ArgumentException("Not in the Enum from ItemTypes Enum in Items"),

            };
        }
    }
}
