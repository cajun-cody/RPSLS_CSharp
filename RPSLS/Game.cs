using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            //Have a user choose between 1 or 2 human players.
            //Need to convert the user input from a string to an int. 
            //Data validation needed
            //Need to add conditional to handle if user input is a number and can be parsed.
            //Need condition if input is a number and can be parsed but out of range.
            //Need a catch conditional if the user input cannot be parsed at all. 
        {   
            Console.WriteLine($"How many 'Human' players want to play? 0 (BotVsBot) or 1(HumanVsBot) or 2(HumanVsHuman)\n");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number == 0 || number == 1 || number == 2)
                {
                    return number;
                }
                else 
                {
                    Console.WriteLine("Your input is out of range. Please choose 0 or 1 or 2!");
                    return ChooseNumberOfHumanPlayers();
                }
            }
            else
            {
                Console.WriteLine("Your input is invalid. Please enter a number value.");
                return ChooseNumberOfHumanPlayers();
            }

        }

        public void CreatePlayerObjects(int numberOfHumanPlayers)
            //Conditional to create the players depending on the chosen # of human players. 
        {
            //If only 1 human player selected. 
            if (numberOfHumanPlayers == 1)
            {
                Console.WriteLine("Please enter Player's name:");
                string playerOneName = Console.ReadLine();
                playerOne = new HumanPlayer(playerOneName);
                playerTwo = new BotPlayer("RoboKiller");
            }
            //If 2 human players are selected. 
            else if (numberOfHumanPlayers == 2)
            {
                Console.WriteLine("Please enter Player One's name:");
                string playerOneName = Console.ReadLine();
                playerOne = new HumanPlayer(playerOneName);
                Console.WriteLine("Please enter Player Two's name:");
                string playerTwoName = Console.ReadLine();
                playerTwo = new HumanPlayer(playerTwoName);
            }
            //If no humans chosen and Robots will compete. 
            else if (numberOfHumanPlayers == 0)
            {
                playerOne = new BotPlayer("RoboKiller");
                playerTwo = new BotPlayer("Superbot");
            }
            //Instantiate each player object to grab the name variable. 
            Console.WriteLine($"This match is best of 3 between {playerOne.name} and {playerTwo.name}");
        }

        public void CompareGestures()
            //Need a loop to run throuh each round to compare scores between players. 
            //Need to call the function for each player to choose a gesture.
            //Need conditionals to compare gestures for each player.
            //Need to add a point to each playerScore for each round won.
            //Loop ends when a player reaches 3 points.
        {
            while (playerOne.score < 3 && playerTwo.score < 3)
            {
                Console.WriteLine($"\nNew Round!\n");
                playerOne.ChooseGesture();
                playerTwo.ChooseGesture();
                //Conditional to compare identical gestures.
                if (playerOne.chosenGesture == playerTwo.chosenGesture)
                {
                    Console.WriteLine("Round Tied");
                    Console.WriteLine("No Points Awarded!");
                    Console.WriteLine($"Score is {playerOne.name} has {playerOne.score} & {playerTwo.name} has {playerTwo.score} \n");
                }
                //Conditional to compare playerOne gesture to all winning hands.
                else if ((playerOne.chosenGesture == "rock" && playerTwo.chosenGesture == "scissors") ||
                    (playerOne.chosenGesture == "rock" && playerTwo.chosenGesture == "lizard") ||
                    (playerOne.chosenGesture == "paper" && playerTwo.chosenGesture == "rock") ||
                    (playerOne.chosenGesture == "paper" && playerTwo.chosenGesture == "spock") ||
                    (playerOne.chosenGesture == "scissors" && playerTwo.chosenGesture == "paper") ||
                    (playerOne.chosenGesture == "scissors" && playerTwo.chosenGesture == "lizard") ||
                    (playerOne.chosenGesture == "lizard" && playerTwo.chosenGesture == "paper") ||
                    (playerOne.chosenGesture == "lizard" && playerTwo.chosenGesture == "spock") ||
                    (playerOne.chosenGesture == "spock" && playerTwo.chosenGesture == "scissors") ||
                    (playerOne.chosenGesture == "spock" && playerTwo.chosenGesture == "rock"))
                {
                    //If any of the above conditionals is true player 1 gets a point. 
                    playerOne.score++;
                    Console.WriteLine($"{playerOne.name} wins this round");
                    Console.WriteLine($"Score is {playerOne.name} has {playerOne.score} & {playerTwo.name} has {playerTwo.score}\n");
                }
                //Conditional to add a point to player 2 if the first 2 conditions are not met.
                else
                {
                    playerTwo.score++;
                    Console.WriteLine($"{playerTwo.name} wins this round");
                    Console.WriteLine($"Score is {playerOne.name} has {playerOne.score} & {playerTwo.name} has {playerTwo.score}\n");
                }
            }
        }

        public void DisplayGameWinner()
        {
            if (playerOne.score == 3 )
            {
                Console.WriteLine($"{playerOne.name} is the Champ.");
            }
            else
            {
                Console.WriteLine($"{playerTwo.name} is the Champ.");
            }

        }

        public void RunGame()
            //Call each method in order they need to execute. 
            //My while loop occurs in the CompareGestures function. I could do a do while loop here in my rungame to 
            //do compare gestures while the score is < 3. 
        {
            WelcomeMessage();
            //Variable to hold the value of how many human players are in the game. 
            int numPlayers = ChooseNumberOfHumanPlayers();
            //Use the variable to pass in as a parameter for instantiating players. 
            CreatePlayerObjects(numPlayers);
            CompareGestures();
            DisplayGameWinner();

        }
    }
}
