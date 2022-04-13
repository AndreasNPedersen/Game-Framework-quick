using GameOfSolidAndDesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns
{
    /// <summary>
    /// The Position which a participant or an item can be in
    /// </summary>
    public class Position
    {
        public List<IParticipant> Participants { get; set; }
        public List<IItem> Items { get; set; }

        public Position()
        {
            Participants = new List<IParticipant>();
            Items = new List<IItem>();
        }
    }
}
