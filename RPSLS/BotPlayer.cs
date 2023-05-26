using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    internal class BotPlayer : Player 
    {
        //Build a constructor for this player.
        public BotPlayer(string name) : base("RoboKiller") 
        {
         
        }
        //Override gesture method to have this players choice be random. 
        public override void ChooseGesture()
        {
            Console.WriteLine($"{name}'s Turn");
            //Instantiate the randomizer
            Random random = new Random();
            //Choice represents the index that is chosen when we randomize. 
            int choice = random.Next(gestures.Count);
            //ChosenGesture holds the chosen index so we can compare it to the other players gesture. 
            chosenGesture = gestures[choice];
        }
    }
}
