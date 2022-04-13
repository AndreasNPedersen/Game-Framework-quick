using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items.DefenceItems.Pants
{
    /// <summary>
    /// The wooden pants which can reduce an amount of damage
    /// </summary>
    public class WoodenPants : ArmorBase
    {
        public override int ReduceHitPoints => 1;

        public override int ID => 6;

        public override string Name => "Wooden pants";

        public override string Description => "Pants out of wood, very stiff";
    }
}
