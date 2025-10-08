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
            Terminal.WriteLine("1. Patron1");
            Terminal.WriteLine("2. Patron2");
            Terminal.WriteLine("3. Patron3");
            Terminal.WriteLine("4. Patron4");
            Terminal.WriteLine("Enter the number of the customer you want to serve:");
            string customerChoice = Terminal.ReadLine();
            switch (customerChoice)
            {
                case "1":
                    if (patron1Served)
                    {
                        Terminal.WriteLine("You've already served Patron1. Please choose another customer.");
                        CustomerSelection();
                        return;
                    }
                    ServePatron1();
                    break;
                case "2":
                    if (patron2Served)
                    {
                        Terminal.WriteLine("You've already served Patron2. Please choose another customer.");
                        CustomerSelection();
                        return;
                    }
                    ServePatron2();
                    break;
                case "3":
                    if (patron3Served)
                    {
                        Terminal.WriteLine("You've already served Patron3. Please choose another customer.");
                        CustomerSelection();
                        return;
                    }
                    ServePatron3();
                    break;
                case "4":
                    if (patron4Served)
                    {
                        Terminal.WriteLine("You've already served Patron4. Please choose another customer.");
                        CustomerSelection();
                        return;
                    }
                    ServePatron4();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    CustomerSelection();
                    break;
            }
        }

        //====================================================================================================
        //Patron 1
        //====================================================================================================

        public void ServePatron1()
        {
            Terminal.Clear();
            Terminal.WriteLine("You approach Patron1, who is already nursing a beer.");
            Terminal.WriteLine("\"Hey " + playerName + ", just the usual,\" they say with a nod.");
            mixing.MixDrink();
            drinkScore = mixing.score;

            if (drinkScore == 100)
                Console.WriteLine("Impressive man, you really know how to pour them.");
            else if (drinkScore >= 60)
                Console.WriteLine("Not bad. Could still use some work though.");
            else
                Console.WriteLine("Do you even know how to pour? What the hell was that?");

            Patron1Continued();
        }

        public void Patron1Continued()
        {
            Terminal.WriteLine("\"Thanks, " + playerName + ". This hits the spot. You know, you're pretty good at this bartending thing.\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Thanks! I've had some practice.\"");
            Terminal.WriteLine("2. \"Just doing my job.\"");
            Terminal.WriteLine("3. \"Something flirty\"");
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
                    Patron1Continued();
                    return;
            }

            Patron1Ending();
        }

        public void Patron1Ending()
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

            patron1Served = true;
            CustomerSelection();
        }

        //====================================================================================================
        //Patron 2
        //====================================================================================================

        public void ServePatron2()
        {
            Terminal.Clear();
            Terminal.WriteLine("You approach Patron2, lounging confidently at the bar with a playful grin.");
            Terminal.WriteLine("\"Well hey there, " + playerName + ". Care to make me something... special?\"");
            mixing.MixDrink();
            drinkScore = mixing.score;

            if (drinkScore == 100)
                Console.WriteLine("\"Mmm, perfection. You sure know how to please.\"");
            else if (drinkScore >= 60)
                Console.WriteLine("\"Not bad. Maybe next time you can show me your best.\"");
            else
                Console.WriteLine("\"Oh dear... that’s not going to impress anyone.\"");

            Patron2Continued();
        }

        public void Patron2Continued()
        {
            Terminal.WriteLine("\"So tell me, " + playerName + ", do you flirt with all your customers or just the cute ones?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Only the cute ones.\"");
            Terminal.WriteLine("2. \"Just being friendly.\"");
            Terminal.WriteLine("3. \"I'm here to work, not flirt.\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Ha! I knew it. I might have to come by more often then.\"");
                    break;
                case "2":
                    Terminal.WriteLine("\"Friendly works too. I like a bartender who knows their boundaries.\"");
                    break;
                case "3":
                    Terminal.WriteLine("\"Such a professional... though I bet I could change that.\"");
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron2Continued();
                    return;
            }

            Patron2Ending();
        }

        public void Patron2Ending()
        {
            Terminal.WriteLine("\"Alright, one more drink before I go. Make it worth my while, " + playerName + ".\"");
            mixing.MixDrink();
            drinkScore = mixing.score;

            if (drinkScore == 100)
            {
                Console.WriteLine("\"Mmm, you never disappoint.\"");
                patron2Reputation += 2;
            }
            else if (drinkScore >= 60)
            {
                Console.WriteLine("\"Pretty good. I’ll give you that.\"");
                patron2Reputation += 1;
            }
            else
            {
                Console.WriteLine("\"Yikes. Maybe I should’ve stuck with wine.\"");
                patron2Reputation -= 1;
            }

            patron2Served = true;
            CustomerSelection();
        }

        //====================================================================================================
        //Patron 3
        //====================================================================================================

        public void ServePatron3()
        {
            Terminal.Clear();
            Terminal.WriteLine("You walk over to Patron3, who’s already had more than a few too many.");
            Terminal.WriteLine("\"H-Hey " + playerName + "! Another one, buddy!\"");
            mixing.MixDrink();
            drinkScore = mixing.score;

            if (drinkScore == 100)
                Console.WriteLine("\"Thash... perfect. You’re my besht friend, ya know that?\"");
            else if (drinkScore >= 60)
                Console.WriteLine("\"Not bad, not bad. Keep ‘em coming!\"");
            else
                Console.WriteLine("\"Blegh! What’s that supposed to be?!\"");

            Patron3Continued();
        }

        public void Patron3Continued()
        {
            Terminal.WriteLine("\"You ever think about how... like... we’re all just bubbles in a beer?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"You might want to slow down, buddy.\"");
            Terminal.WriteLine("2. \"That’s... actually kind of deep.\"");
            Terminal.WriteLine("3. \"Let’s get you some water instead.\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Aww, don’t be like that, " + playerName + "!\"");
                    break;
                case "2":
                    Terminal.WriteLine("\"Right?! You get it! You really get it!\"");
                    break;
                case "3":
                    Terminal.WriteLine("\"Water? Pffft. Fine, but only ‘cause you’re cool.\"");
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Continued();
                    return;
            }

            Patron3Ending();
        }

        public void Patron3Ending()
        {
            Terminal.WriteLine("\"One more for the road! C’mon, make it a good one!\"");
            mixing.MixDrink();
            drinkScore = mixing.score;

            if (drinkScore == 100)
            {
                Console.WriteLine("\"Thash... that’sh the shtuff!\"");
                patron3Reputation += 2;
            }
            else if (drinkScore >= 60)
            {
                Console.WriteLine("\"Pretty good, buddy!\"");
                patron3Reputation += 1;
            }
            else
            {
                Console.WriteLine("\"Ugh, maybe I’ve had enough...\"");
                patron3Reputation -= 1;
            }

            patron3Served = true;
            CustomerSelection();
        }

        //====================================================================================================
        //Patron 4
        //====================================================================================================

        public void ServePatron4()
        {
            Terminal.Clear();
            Terminal.WriteLine("In the dim corner, Patron4 sits alone, cloaked in shadow.");
            Terminal.WriteLine("\"Bartender,\" they say quietly, \"something... strong.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;

            if (drinkScore == 100)
                Console.WriteLine("\"Perfect. Just the way I like it.\"");
            else if (drinkScore >= 60)
                Console.WriteLine("\"Adequate. You’ve got skill, but not focus.\"");
            else
                Console.WriteLine("\"Disappointing. I expected more.\"");

            Patron4Continued();
        }

        public void Patron4Continued()
        {
            Terminal.WriteLine("\"You seem... different from the others. Why are you here, really?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Just trying to make a living.\"");
            Terminal.WriteLine("2. \"Maybe I like listening to people’s stories.\"");
            Terminal.WriteLine("3. \"Why do you ask?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Fair enough. Everyone’s chasing something.\"");
                    break;
                case "2":
                    Terminal.WriteLine("\"A noble pursuit. But be careful — not every story ends well.\"");
                    break;
                case "3":
                    Terminal.WriteLine("\"Curiosity can be dangerous. Remember that.\"");
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron4Continued();
                    return;
            }

            Patron4Ending();
        }

        public void Patron4Ending()
        {
            Terminal.WriteLine("\"One last drink before I disappear into the night.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;

            if (drinkScore == 100)
            {
                Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                patron4Reputation += 2;
            }
            else if (drinkScore >= 60)
            {
                Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                patron4Reputation += 1;
            }
            else
            {
                Console.WriteLine("\"Hmm. Still learning, I see.\"");
                patron4Reputation -= 1;
            }

            patron4Served = true;
            CustomerSelection();
        }

    }
}
