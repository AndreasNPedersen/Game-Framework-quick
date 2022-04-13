using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Interfaces
{
    /// <summary>
    /// The interface to initialize the different items and health in the participant
    /// </summary>
    public interface IStartupParticipantBase
    {
        /// <summary>
        /// Set the health of the participant
        /// </summary>
        /// <param name="maxHealth">The maximum health the participant can do</param>
        /// <returns>the health</returns>
        double SetInitialHealthPoints(double maxHealth);
        /// <summary>
        /// set the items the participant should spawn with
        /// </summary>
        /// <returns>the list of items</returns>
        List<IItem> SetInitialItems();
    }
}
