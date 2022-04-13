using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Interfaces
{
    /// <summary>
    /// An Item interface
    /// </summary>
    public interface IItem
    {
        int ID { get; }
        string Name { get; }
        string Description { get; }
    }
}
