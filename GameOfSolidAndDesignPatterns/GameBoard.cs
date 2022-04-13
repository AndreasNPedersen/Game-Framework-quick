using GameOfSolidAndDesignPatterns.Factories;
using GameOfSolidAndDesignPatterns.Items;
using GameOfSolidAndDesignPatterns.Participants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfSolidAndDesignPatterns
{
    /// <summary>
    /// The Game start which loads the configuration and makes a board
    /// </summary>
    public class GameBoard
    {
   
        List<int> _values;
        public GameBoard()
        {
            _values = ConfigFileRead.GetConfigFileReadInstance().ReadConfig();   
        }
        /// <summary>
        /// Positions of what Item and Participants in each field 
        /// </summary>
        /// <returns>An multidimensional array of position objects</returns>
        public Position[,] Positions()
        {
            TraceSource ts = new TraceSource("TraceGame");
            ts.Switch = new SourceSwitch("Gameboard", "All");
            ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
            if (_values.Count != 4)
            {
                ts.TraceEvent(TraceEventType.Critical, 8, "GameBoard couldn't load, because of no values in list");
                throw new FileNotFoundException("File wasn't read");
            }
            ts.TraceEvent(TraceEventType.Verbose, 8, "GameBoard loading with values: " + _values[0] +" "+ _values[1] + " "+ _values[2] +" " + _values[3]);

            Position[,] positions = new Position[_values[0], _values[1]];
            ItemFactory factory = new ItemFactory();
            ParticipantFactory participantFactory = new ParticipantFactory();
            for (int i = 0; i < 3; i++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int raNumber = new Random().Next(1, 10);
                    positions[i, y] = new Position();
                    if (raNumber < _values[2])
                    {
                        ts.TraceEvent(TraceEventType.Verbose, 9, "GameBoard An enemy spawn at " +i + ", " + y);

                        
                        positions[i, y].Participants.Add(participantFactory.CreateParticipantNPC((ParticipantTypesEnum)new Random().Next(0, 2)));
                    }
                    if (raNumber > _values[3])
                    {
                        ts.TraceEvent(TraceEventType.Verbose, 9, "GameBoard An Item spawn at " + i + ", " + y);
                        positions[i, y].Items.Add(factory.CreateItem((ItemTypes)new Random().Next(7,9)));
                    }


                }
            }
            ts.Flush();
            return positions;
        }
    }
}
