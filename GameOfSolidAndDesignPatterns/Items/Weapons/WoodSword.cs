using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items.Weapons
{
    /// <summary>
    /// The wooden sword which can deal an amount of damage
    /// </summary>
    public class WoodSword : WeaponBase
    {
        public override int Damage => 2;

        public override int ID => 1;

        public override string Name => "WoodenSword";

        public override string Description => "A WoodenSword Made by a man";
    }
}
