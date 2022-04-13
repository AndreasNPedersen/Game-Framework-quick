using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items.DefenceItems.Boots
{
    /// <summary>
    /// The wooden boots which can reduce an amount of damage
    /// </summary>
    public class WoodenBoots : ArmorBase
    {
        public override int ReduceHitPoints => 1;

        public override int ID => 4;

        public override string Name => "Wooden Boots";

        public override string Description => "Wooden boots carved from wood";
    }
}
