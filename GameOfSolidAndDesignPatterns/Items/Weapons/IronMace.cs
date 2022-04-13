using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items.Weapons
{
    /// <summary>
    /// The iron mace which can deal an amount of damage
    /// </summary>
    public class IronMace : WeaponBase
    {
        public override int ID => 2;

        public override string Name => "Iron Mace";

        public override string Description => "An iron Mace forged on metals";

        public override int Damage => 3;
    }
}
