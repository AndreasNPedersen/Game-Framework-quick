using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items.WorldItems
{
    /// <summary>
    /// The mushroom which can change the state of a participant and heal
    /// </summary>
    public class Mushroom : ItemBase
    {
        public override int ID => 9;

        public override string Name => "Mushroom";

        public override string Description => "A mushroom that heals you 2 points";
        public override int Healing => 2;
    }
}
