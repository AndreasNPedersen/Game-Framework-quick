using GameOfSolidAndDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items
{
    /// <summary>
    /// The Base/super class of the weapons created in the game
    /// </summary>
    public abstract class WeaponBase : IItem, IWeapon
    {
        public abstract int Damage {get;}

        public abstract int ID { get; }

        public abstract string Name { get; }

        public abstract string Description { get; }
    }
}
