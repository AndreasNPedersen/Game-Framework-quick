using GameOfSolidAndDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items
{
    public abstract class ArmorBase : IItem, IDefenceItem
    {
        /// <summary>
        /// The Base/super class of the armor created in the game
        /// </summary>
        public abstract int ReduceHitPoints { get; }

        public abstract int ID { get; }

        public abstract string Name { get; }

        public abstract string Description { get; }
    }
}
