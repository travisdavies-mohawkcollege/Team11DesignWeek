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
        int patron1Reputation = 0;
        int patron1Tip = 0;
        bool patron1Served = false;
        //Patron 2
        int patron2Reputation = 0;
        int patron2Tip = 0;
        bool patron2Served = false;
        //Patron 3
        int patron3Reputation = 0;
        int patron3Tip = 0;
        bool patron3Served = false;
        //Patron 4
        int patron4Reputation = 0;
        int patron4Tip = 0;
        bool patron4Served = false;

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
            Terminal.WriteLine("Time to clock in, " + playerName + ". Time to pour drinks and ease their weary souls.");
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
                    if (patron1Served)
                    {
                        Terminal.WriteLine("You've already served The Regular. Please choose another customer.");
                        CustomerSelection();
                        return;
                    }
                    ServeRegular();
                    break;
                case "2":
                    if (patron2Served)
                    {
                        Terminal.WriteLine("You've already served The Flirt. Please choose another customer.");
                        CustomerSelection();
                        return;
                    }
                    ServeFlirt();
                    break;
                case "3":
                    if (patron3Served)
                    {
                        Terminal.WriteLine("You've already served The Drunk. Please choose another customer.");
                        CustomerSelection();
                        return;
                    }
                    // ServeDrunk();
                    break;
                case "4":
                    if (patron4Served)
                    {
                        Terminal.WriteLine("You've already served The Mysterious Stranger. Please choose another customer.");
                        CustomerSelection();
                        return;
                    }
                    //ServeMysteriousStranger();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    CustomerSelection();
                    break;
            }
        }

        //====================================================================================================
        //Patron 1 - The Regular
        //====================================================================================================

        public void ServeRegular()
        {
            //Serve The Regular - Game State 2
            //Intro to Character and First Drink Mini Game
            Terminal.Clear();
            Terminal.WriteLine("You approach The Regular, who is already nursing a beer.");
            Terminal.WriteLine("\"Hey " + playerName + ", just the usual,\" they say with a nod.");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                Console.WriteLine("Impressive man, you really know how to pour them.");
            }
            else if (drinkScore >= 60)
            {
                Console.WriteLine("Not bad. Could still use some work though.");
            }
            else
            {
                Console.WriteLine("Do you even know how to pour? What the hell was that?");
            }
            RegularContinued();
        }

        public void RegularContinued()
        {
            //Next Dialogue Segment, with a choice
            Terminal.WriteLine("\"Thanks, " + playerName + ". This hits the spot. You know, you're pretty good at this bartending thing.\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Thanks! I've had some practice.\"");
            Terminal.WriteLine("2. \"Just doing my job.\"");
            Terminal.WriteLine("3. \"Something flirty\"");
            Terminal.WriteLine("Enter the number of your response:");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Well, it shows! Keep it up, " + playerName + ".\"");
                    break;
                case "2":
                    Terminal.WriteLine("\"Humble too, I like that. You're going to do great here, " + playerName + ".\"");
                    break;
                case "3":
                    Terminal.WriteLine("\"Haha, you're quite the charmer, " + playerName + ". Maybe I'll stick around for a while.\"");
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    RegularContinued();
                    break;
            }
            RegularEnding();

        }

        public void RegularEnding()
        {
            Terminal.WriteLine("Well, I should probably get the bill. ");
            Terminal.WriteLine("Wanna pour me one first?");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                Console.WriteLine("Impressive man, you really know how to pour them.");
                patron1Reputation += 2;
            }
            else if (drinkScore >= 60)
            {
                Console.WriteLine("Not bad. Could still use some work though.");
                patron1Reputation += 1;
            }
            else
            {
                Console.WriteLine("Do you even know how to pour? What the hell was that?");
                patron1Reputation -= 1;
            }

        }

        //====================================================================================================
        //Patron 2 - The Flirt
        //====================================================================================================

        public void ServeFlirt()
        {
            //Serve The Flirt - Game State 2
            //Intro to Character and First Drink Mini Game
            Terminal.Clear();
            Terminal.WriteLine("You approach The Flirt, who is already nursing a beer.");
            Terminal.WriteLine("\"Hey " + playerName + ", just the usual,\" they say with a nod.");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                Console.WriteLine("Impressive man, you really know how to pour them.");
            }
            else if (drinkScore >= 60)
            {
                Console.WriteLine("Not bad. Could still use some work though.");
            }
            else
            {
                Console.WriteLine("Do you even know how to pour? What the hell was that?");
            }
            FlirtContinued();
        }

        public void FlirtContinued()
        {
            //Next Dialogue Segment, with a choice
            Terminal.WriteLine("\"Thanks, " + playerName + ". This hits the spot. You know, you're pretty good at this bartending thing.\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Thanks! I've had some practice.\"");
            Terminal.WriteLine("2. \"Just doing my job.\"");
            Terminal.WriteLine("3. \"Something flirty\"");
            Terminal.WriteLine("Enter the number of your response:");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Well, it shows! Keep it up, " + playerName + ".\"");
                    break;
                case "2":
                    Terminal.WriteLine("\"Humble too, I like that. You're going to do great here, " + playerName + ".\"");
                    break;
                case "3":
                    Terminal.WriteLine("\"Haha, you're quite the charmer, " + playerName + ". Maybe I'll stick around for a while.\"");
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    FlirtContinued();
                    break;
            }
            FlirtEnding();

        }

        public void FlirtEnding()
        {
            Terminal.WriteLine("Well, I should probably get the bill. ");
            Terminal.WriteLine("Wanna pour me one first?");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                Console.WriteLine("Impressive man, you really know how to pour them.");
                patron2Reputation += 2;
            }
            else if (drinkScore >= 60)
            {
                Console.WriteLine("Not bad. Could still use some work though.");
                patron2Reputation += 1;
            }
            else
            {
                Console.WriteLine("Do you even know how to pour? What the hell was that?");
                patron2Reputation -= 1;
            }

        }

    }
}