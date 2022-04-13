using GameOfSolidAndDesignPatterns;
using GameOfSolidAndDesignPatterns.Factories;
using GameOfSolidAndDesignPatterns.Interfaces;
using GameOfSolidAndDesignPatterns.Items;
using GameOfSolidAndDesignPatterns.Participants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameGui
{
    public class Game
    {
        private Position[,] board;
        private IParticipant character;
        public Game()
        {
            try
            {
            board = new GameBoard().Positions();
            } catch (Exception ex)
            {
                TraceSource ts = new TraceSource("TraceGame");
                ts.Switch = new SourceSwitch("Game", "All");

                ts.Listeners.Add(TraceListenerSingleton.GetTrace().Trace());
                ts.TraceEvent(TraceEventType.Critical, 0, "Board couldn't be made : " + ex.Message);
            }

            Startup();
            Play();

        }

        public void Startup()
        {
           
            Console.WriteLine("Your name:");
            character = new ParticipantFactory().CreateParticipantCharacter(ParticipantTypesEnum.Character, Console.ReadLine());
 
            Console.WriteLine(character.Name + " is on a new adventure through a "+(board.GetUpperBound(0) + 1) +"x"+ (board.GetUpperBound(1) + 1) +
                " grid, with the health of: " + character.HealthPoints);
            foreach (IItem item in character.Items)
            {
                Console.WriteLine("Your character has : " + item.Name + " with the description of: " + item.Description);
            }
        }


        public void ShowGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int y = 0; y < 3; y++)
                {

                    foreach (IItem we in board[i, y].Items)
                    {
                        Console.WriteLine("There is: " + we.Name + " item on X:" + i + " and Y:" + y);
                    }
                    foreach (ParticipantBase ce in board[i, y].Participants)
                    {

                        Console.WriteLine("There is: " + ce.Name + " enemy or friend on X:" + i + " and Y:" + y);
                    }

                }
                Console.WriteLine("");
            }


        }

        public void Play()
        {

            while (!character.Dead)
            {
                ShowGrid();

                if (character.Items.Where(e => e.ID == 8 || e.ID == 9).Any())
                {
                    Console.WriteLine("You can enhance/heal yourself with a mushroom or bread, [yes] or [no]");
                    if (Console.ReadLine() == "yes")
                    {
                        if (character.Items.Contains(character.Items.Find(e => e.ID == 8)))
                        {
                            character.StateOfParticipant.InputCreatureState(character.StateOfParticipant.OutputCreatureState(),(ItemBase) character.Items.Find(e => e.ID == 8));
                            character.Items.Remove(character.Items.Find(e => e.ID == 8));

                        }
                        if (character.Items.Contains(character.Items.Find(e => e.ID == 9)))
                        {
                            character.StateOfParticipant.InputCreatureState(character.StateOfParticipant.OutputCreatureState(), (ItemBase) character.Items.Find(e => e.ID == 9));
                            character.Items.Remove(character.Items.Find(e => e.ID == 9));

                        }
                    }
                }
                Console.WriteLine("What do you wanna do? [Write the X and Y coordinate you wanna teleport to]");
                Console.WriteLine("Write the X coordinate:");
                try
                {
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Write the Y coordinate:");
                int y = Convert.ToInt32(Console.ReadLine());
                    if (board[x, y].Participants.Count > 0)
                    {
                        Fight(x, y);
                    }
                    if (board[x, y].Items.Count > 0)
                    {
                        PickupItem(x, y);
                    }
                    
                } catch (FormatException)
                {
                    Console.WriteLine("Not a value in the board, or wrong input (Only numbers)");
                }

            }
        }

        public void Fight(int x, int y)
        {
            Console.WriteLine("You picked fighting the enemies");
            
            Console.WriteLine("You begin the fight, and even if you hit with a number, the enemy could resist it" +
                " which would make the total damage 0");
            bool isOver = false;


            while (!isOver)
            {
                int totalenemyDeath = 0;
                
                Console.WriteLine("which enemy to hit? [1] out of [" + board[x,y].Participants.Count+"]");
                try
                {
                    int readConsole = Convert.ToInt32(Console.ReadLine());
                    board[x, y].Participants[readConsole-1].ReceiveDamage(character.DealDamage());
                    Console.WriteLine("You hit with:" + character.DealDamage() + ", Enemy health:" + 
                        board[x,y].Participants[readConsole-1].HealthPoints);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wrong enemy, you missed, sad times");
                }
                if (board[x,y].Participants.Count != 0)
                {
                    foreach (IParticipant par in board[x, y].Participants)
                    {
                        if (!par.Dead)
                        {
                            character.ReceiveDamage(par.DealDamage());
                            Console.WriteLine("You got hit with:" + par.DealDamage() + ", your health:" + character.HealthPoints);

                        } else { totalenemyDeath++; }   
                    }
                }

                if (character.Dead)
                {
                    Console.WriteLine("You Lost");
                    isOver = true;   
                }
                
                if (board[x, y].Participants.Count == totalenemyDeath)
                {
                    board[x, y].Participants.Clear();
                    Console.WriteLine("You won");
                    isOver = true;
                }
            }


            

        }

        public void PickupItem(int x, int y)
        {
            // switch case if I had more objects to go through
            
                foreach (IItem item in board[x, y].Items)
                {
                    Console.WriteLine("You picked up " + item.Name);
                    character.Items.Add(item);
                }
                board[x, y].Items.Clear();
            

        }
    }
}
