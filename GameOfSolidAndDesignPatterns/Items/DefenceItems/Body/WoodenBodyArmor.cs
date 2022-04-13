using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items.DefenceItems.Body
{
    /// <summary>
    /// The wooden body armor which can reduce an amount of damage
    /// </summary>
    public class WoodenBodyArmor : ArmorBase
    {
        public override int ReduceHitPoints => 2;

        public override int ID => 5;

        public override string Name => "Wooden body armor";

        public override string Description => "Wooden body armor made of wood";
    }
}
