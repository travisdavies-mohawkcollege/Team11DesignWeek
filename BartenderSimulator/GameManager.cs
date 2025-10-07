using MohawkTerminalGame;
using static System.Formats.Asn1.AsnWriter;

namespace Travis
{
    public class GameManager
    {

        //Variables
        //Text Speed in Milliseconds
        public int slowTextSpeed = 100;
        public int fastTextSpeed = 25;
        public int defaultTextSpeed = 50;
        public int blackoutTextSpeed = 200;

        //Player Inputs
        public string playerName = "";

        //Drink Scores
        public int drinkScore = 0;

        //Game States
        int currentGameState = 0; //Variable to hold current game state

        //Patron 1

        //Patron 2

        //Patron 3

        //Patron 4


        //Script References
        new ASCII ascii = new ASCII();
        new Mixing mixing = new Mixing();
        public void Setup()
        {
            Program.TerminalExecuteMode = TerminalExecuteMode.ExecuteOnce;
            Program.TerminalInputMode = TerminalInputMode.KeyboardReadAndReadLine;

            Terminal.SetTitle("Junior's");
            Terminal.UseRoboType = true;
            Terminal.RoboTypeIntervalMilliseconds = defaultTextSpeed;
            Terminal.WriteWithWordBreaks = true;
            Terminal.WordBreakCharacter = ' ';
        }

        public void Execute()
        {
            Intro();
            CustomerSelection();
        }

        public void Intro()
        {
            //Intro Sequence - Game State 0
            Terminal.Clear();
            Terminal.WriteLine("Welcome to Junior's, the only bar in town!");
            Terminal.WriteLine("You are the new bartender here, and your job is to make drinks for the customers.");
            Terminal.WriteLine("What name do you write on your nametag?");
            playerName = Terminal.ReadLine();
            Terminal.WriteLine("Time to clock in, " +playerName + ". Time to pour drinks and ease their weary souls.");
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        public void CustomerSelection()
        {
            //Customer Selection - Game State 1
            Terminal.Clear();
            Terminal.WriteLine("Four customers are spread across the bar. Who do you want to serve?");
            Terminal.WriteLine("1. The Regular");
            Terminal.WriteLine("2. The Flirt");
            Terminal.WriteLine("3. The Drunk");
            Terminal.WriteLine("4. The Mysterious Stranger");
            Terminal.WriteLine("Enter the number of the customer you want to serve:");
            string customerChoice = Terminal.ReadLine();
            switch (customerChoice)
            {
                case "1":
                    ServeRegular();
                    break;
                case "2":
                   // ServeFlirt();
                    break;
                case "3":
                   // ServeDrunk();
                    break;
                case "4":
                    //ServeMysteriousStranger();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    CustomerSelection();
                    break;
            }
        }

        public void ServeRegular()
        {
            //Serve The Regular - Game State 2
            Terminal.Clear();
            Terminal.WriteLine("You approach The Regular, who is already nursing a beer.");
            Terminal.WriteLine("\"Hey " + playerName + ", just the usual,\" they say with a nod.");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
                Console.WriteLine("Impressive man, you really know how to pour them.");
            else if (drinkScore >= 60)
                Console.WriteLine("Not bad. Could still use some work though.");
            else
                Console.WriteLine("Do you even know how to pour? What the hell was that?");


        }



    }

}