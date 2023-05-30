using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    internal class HumanPlayer : Player
    {
        //Build a constructor for this player.
        public HumanPlayer(string name) : base(name)
        {
            
        }
        //Override gesture method to have this players choice be random. 
        //List out the possible gestures a HumanPlayer can choose from. 
        //Create a variable to hold the users choice. 
        //Data Validation needed.
        public override void ChooseGesture()
        {
            Console.WriteLine($"{this.name}'s Turn. Choose your weapon!");
            //Create a loop to display possible gestures to the player.
            foreach (string gesture in gestures)
            {
                Console.WriteLine($"{gesture}");
            }
            //Create variable to hold the users choice in gesture. 
            chosenGesture = Console.ReadLine().ToLower();
            //To validate users response, the loop confirms that the users choice is spelled the same as the optional choices.
            while (!gestures.Contains(chosenGesture))
            {
                Console.WriteLine("This is not a valid choice. Please pick again.");
                chosenGesture = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"{name} throws {chosenGesture}");
        }

    }
}
