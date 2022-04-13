using GameOfSolidAndDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items
{
    /// <summary>
    /// The Base/super class of the items created in the game
    /// </summary>
    public abstract class ItemBase : IItem
    {
        public abstract int ID { get; }

        public abstract string Name { get; }

        public abstract string Description { get;}
        public virtual int Healing { get; }
    }
}
