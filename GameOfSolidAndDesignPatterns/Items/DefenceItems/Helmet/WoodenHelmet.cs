using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items.DefenceItems.Helmet
{
    /// <summary>
    /// The wooden helmet which can reduce an amount of damage
    /// </summary>
    public class WoodenHelmet : ArmorBase
    {
        public override int ReduceHitPoints => 1;

        public override int ID => 3;

        public override string Name => "Wooden Helmet";

        public override string Description => "A helmet carved from wood";
    }
}
