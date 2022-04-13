using GameOfSolidAndDesignPatterns.Participants.ParticipantState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns.Interfaces
{
    /// <summary>
    /// The participant interface
    /// </summary>
    public interface IParticipant
    {
        string Name { get; }
        double HealthPoints { get; }
        bool Dead { get; }
        List<IItem> Items { get; }
        ContextState StateOfParticipant {get;}
        double DealDamage();
        public void ReceiveDamage(double damage);
        public void AddItem(IItem item);
        public void Eat(IItem item);


    }
}
