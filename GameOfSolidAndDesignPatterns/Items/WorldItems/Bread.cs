using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Items.WorldItems
{
    /// <summary>
    /// The bread which can change the state of a participant and heal
    /// </summary>
    public class Bread : ItemBase
    {
        public override int ID => 8;

        public override string Name => "Bread";

        public override string Description => "Bread you can eat and get 2 healing points";
        public override int Healing => 2;
    }
}
