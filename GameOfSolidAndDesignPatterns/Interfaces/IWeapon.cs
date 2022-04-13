using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Interfaces
{
    /// <summary>
    /// The interface to the weapon in which you can inherent with the IItem
    /// </summary>
    public interface IWeapon
    {
        /// <summary>
        /// The damage of the weapon
        /// </summary>
        int Damage { get; }
    }
}
