using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    internal class Game
    {
        //Member Variabes (HAS A)
        public Player playerOne;
        public Player playerTwo;

        //Constructor
        public Game()
        {

        }

        //Member Methods (CAN DO)
        public void WelcomeMessage()
            //List out welcome and rules. 
        {
            Console.WriteLine("Welcome to RPSLS! Here are the rules:\n");
            
            Console.WriteLine("Scissors cut Paper");
            Console.WriteLine("Paper covers Rock");
            Console.WriteLine("Rock crushes Lizard");
            Console.WriteLine("Lizard poisons Spock");
            Console.WriteLine("Spock smashes Scissors");
            Console.WriteLine("Scissors decapitates Lizard");
            Console.WriteLine("Lizard eats Paper");
            Console.WriteLine("Paper disproves Spock");
            Console.WriteLine("Spock vaporizes Rock");
            Console.WriteLine("and as it always has, Rock crushes Scissors\n");

            Console.WriteLine("Best of 3 Rounds!\n");
        }

        public int ChooseNumberOfHumanPlayers()
            //Have a user choose between 1 or 2 human players. Need a variable to hold the user choice.
        {
            Console.WriteLine("How many 'Human' players want to play? 1 or 2");
            int numHumans = Convert.ToInt32(Console.ReadLine());
            return numHumans;
        }

        public void CreatePlayerObjects(int numberOfHumanPlayers)
            //Conditional to create the players depending on the chosen # of human players. 
        {
            //If only 1 human player selected. 
            if (numberOfHumanPlayers == 1)
            {
                Console.WriteLine("Please enter your name:");
                string playerOneName = Console.ReadLine();
                playerOne = new HumanPlayer(playerOneName);
                playerTwo = new BotPlayer("RoboKiller");
            }

        }

        public void CompareGestures()
        {

        }

        public void DisplayGameWinner()
        {

        }

        public void RunGame()
            //Call each method in order they need to execute. 
        {
            WelcomeMessage();
            int numPlayers = ChooseNumberOfHumanPlayers();
            CreatePlayerObjects(numPlayers);

        }
    }
}
