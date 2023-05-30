﻿using System;
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
            Console.WriteLine($"How many 'Human' players want to play? 1 or 2\n");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number == 1 || number == 2)
                {
                    return number;
                }
                else 
                {
                    Console.WriteLine("Your input is out of range. Please choose 1 or 2!");
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
            //Instantiate each player object to grab the name variable. 
            Console.WriteLine($"This match is best of 3 between {playerOne.name} and {playerTwo.name}");
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
