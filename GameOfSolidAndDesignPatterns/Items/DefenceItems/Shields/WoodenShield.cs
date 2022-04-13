using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items.DefenceItems.Shields
{
    /// <summary>
    /// The wooden shield which can reduce an amount of damage
    /// </summary>
    public class WoodenShield : ArmorBase
    {
        public override int ReduceHitPoints => 2;

        public override int ID => 7;

        public override string Name => "Wooden Shield";

        public override string Description => "A shield made out of wood";
    }
}
