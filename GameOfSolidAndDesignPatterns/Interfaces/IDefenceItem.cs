using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Interfaces
{
    /// <summary>
    /// A defence item interface, for armor and shields items
    /// </summary>
    public interface IDefenceItem
    {
        int ReduceHitPoints { get; }
    }
}
