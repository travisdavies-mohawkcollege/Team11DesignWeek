using MohawkTerminalGame;
using static System.Formats.Asn1.AsnWriter;

namespace Travis
{
    public class GameManager
    {

        //Variables
        //Text Speed in Milliseconds
        public int slowTextSpeed = 100;
        public int fastTextSpeed = 10;
        public int defaultTextSpeed = 25;
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
        bool patron1Left = false;
        bool patron1Served = false;
        //Patron 2
        int patron2Reputation = 0;
        int patron2Tip = 0;
        bool patron2Left = false;
        bool patron2Served = false;
        //Patron 3
        int patron3Reputation = 0;
        int patron3Tip = 0;
        bool patron3Left = false;
        bool patron3Served = false;
        //Patron 4
        int patron4Reputation = 0;
        int patron4Tip = 0;
        bool patron4Left = false;
        bool patron4Served = false;
        //Patron 5 (Experimental)
        int patron5Reputation = 0;
        int patron5Tip = 0;
        bool patron5Left = false;
        bool patron5Served = false;

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
            Terminal.WriteLine("What name do you write on your nametag? (Enter your name and press Enter)");
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
            Terminal.WriteLine("Type the number of the customer you want to serve, then press Enter:");
            string customerChoice = Terminal.ReadLine();
            switch (customerChoice)
            {
                case "1":
                    if (patron1Served)
                    {
                        Terminal.WriteLine("You've already served Patron1. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    if(patron1Left)
                    {
                        Terminal.WriteLine("Patron1 has already left. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    ServePatron1();
                    break;
                case "2":
                    if (patron2Served)
                    {
                        Terminal.WriteLine("You've already served Patron2. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    if (patron2Left)
                    {
                        Terminal.WriteLine("Patron2 has already left. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    ServePatron2();
                    break;
                case "3":
                    if (patron3Served)
                    {
                        Terminal.WriteLine("You've already served Patron3. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    if (patron3Left)
                    {
                        Terminal.WriteLine("Patron3 has already left. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    ServePatron3();
                    break;
                case "4":
                    if (patron4Served)
                    {
                        Terminal.WriteLine("You've already served Patron4. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    if (patron4Left)
                    {
                        Terminal.WriteLine("Patron4 has already left. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
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
            Terminal.WriteLine("In the dim corner, Patron1 sits alone, cloaked in shadow.");
            Terminal.WriteLine("\"You seem... different from the others. Why are you here, really?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"What's it to you?\"");
            Terminal.WriteLine("2. \"Maybe I like listening to people’s stories.\"");
            Terminal.WriteLine("3. \"Why do you ask?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Calm down. I was just making conversation.\"");
                    patron1Reputation -= 1;
                    Patron1Path1();
                    break;
                case "2":
                    Terminal.WriteLine("\"A noble pursuit. But be careful — not every story ends well.\"");
                    Patron1Path2();
                    break;
                case "3":
                    Terminal.WriteLine("\"Curiosity can be dangerous. Remember that.\"");
                    Patron1Path3();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    ServePatron1();
                    return;
            }
        }

        public void Patron1Path1()
        {
            Terminal.WriteLine("Is this how you treat all your customers?");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Sorry, it's been a rough night. Truth is, I'm saving up to leave this dump.\"");
            Terminal.WriteLine("2. \"Who do you think you are? You think you're special or something?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron1Choice1();
                    break;
                case "2":
                    Terminal.WriteLine("\"You couldn't just leave it alone, huh?\"");
                    patron1Reputation -= 3;
                    Patron1BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron1Path1();
                    return;
            }
        }

        public void Patron1Path2()
        {
            Terminal.WriteLine("I would tell you mine, but I wouldn't say it's that interesting.");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"I aspire to be more than a barkeep in a dump like this.\"");
            Terminal.WriteLine("2. \"Recount some of the hardships that made you wind up here.\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron1Choice1();
                    break;
                case "2":
                    Terminal.WriteLine("\"I see... would you care to tell me more?\"");
                    patron1Reputation += 1;
                    Patron1Choice2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron1Path2();
                    return;
            }
        }

        public void Patron1Path3()
        {
            Terminal.WriteLine("I take an interest in people, and barkeeps never disappoint.");
            Terminal.WriteLine("\"I'm here looking for tips on my lost partner. They got stranded on a supply run to a nearby outpost.\"");
            Terminal.WriteLine("I've told you my story, care to return the favour?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Tell him some of your struggles.\"");
            Terminal.WriteLine("2. \"Recall the rumour you overheard patrons in the bar discussing earlier about a distress beacon.\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron1Choice2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Oh?\"");
                    Patron1Choice3();
                    break;
            }
        }

        public void Patron1Choice1()
        {
            Terminal.WriteLine("You can tell them the truth, or make something up.");
            Terminal.WriteLine("1. Tell the truth.");
            Terminal.WriteLine("2. Make something up.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I see. Sometimes the truth is the heaviest burden.\"");
                    patron1Reputation += 1;
                    Patron1Drink1();
                    break;
                case "2":
                    Terminal.WriteLine("\"Lies are easy to tell, but hard to keep. I hope you find what you're looking for.\"");
                    Patron1BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron1Choice1();
                    return;
            }
        }

        public void Patron1Choice2()
        {
            Terminal.WriteLine("You feel you can trust this stranger. You can tell him your stories or cut the conversation a bit short.");
            Terminal.WriteLine("1. Tell your stories.");
            Terminal.WriteLine("2. Cut the conversation short.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Stories are the threads that weave our lives together. Thank you for sharing.\"");
                    patron1Reputation += 1;
                    Patron1Drink2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Sometimes silence speaks louder than words. I won't press for more.\"");
                    Patron1Drink1();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron1Choice2();
                    return;
            }
        }

        public void Patron1Choice3()
        {
            Terminal.WriteLine("Have you seriously heard something about a distress beacon?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Yeah, I heard some patrons talking about it earlier. (Share the details extensively)\"");
            Terminal.WriteLine("2. \"Yeah, I... think... . (Keep it vague)\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Information is power. Thank you for trusting me with it.\"");
                    Patron1GoodEnd();
                    break;
                case "2":
                    Terminal.WriteLine("\"Even a hint can be a lifeline. I appreciate your discretion.\"");
                    patron1Reputation -= 1;
                    Patron1Drink2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron1Choice3();
                    return;
            }
        }

        public void Patron1Drink1()
        {
            Terminal.WriteLine("\"Tell you what, make me an Old Fashioned.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron1Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. But it's well made.\"");
                    patron1Reputation += 1;
                }
            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron1Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron1Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron1Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. And it's poorly made.\"");
                    patron1Reputation -= 2;
                }
            }
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Patron1Ending();
        }

        public void Patron1Drink2()
        {
            Terminal.WriteLine("\"Tell you what, make me a Peach Margarita. It's good to mix it up a little.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron1Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. But it's well made.\"");
                    patron1Reputation += 1;
                }
            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron1Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron1Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron1Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. And it's poorly made.\"");
                    patron1Reputation -= 2;
                }
            }

            Patron1Ending();
        }

        public void Patron1BadEnd()
        {
            Terminal.WriteLine("The figure stands, revealing a face scarred and weary. \"Some truths are better left unknown.\"");
            Terminal.WriteLine("Before you can react, they vanish into the shadows, leaving you with a chilling silence.");
            Terminal.WriteLine("Press Enter to continue...");
            patron1Left = true;
            Console.ReadLine();
        }

        public void Patron1GoodEnd()
        {
            Terminal.WriteLine("The figure's eyes light up with hope. \"You may have just saved a life tonight.\"");
            Terminal.WriteLine("They stand, leaving a small pouch of credits on the bar. \"For your kindness. Farewell, " + playerName + ".\"");
            Terminal.WriteLine("Press Enter to continue...");
            patron1Reputation += 3;
            Console.ReadLine();
        }

        public void Patron1Ending()
        {
            if (patron1Reputation < 0)
            {
                Terminal.WriteLine("Patron1 seems displeased with your service.");
            }
            else if (patron1Reputation == 0)
            {
                Terminal.WriteLine("Patron1 seems indifferent about your service.");
            }
            else if (patron1Reputation > 0 && patron1Reputation <= 2)
            {
                Terminal.WriteLine("Patron1 seems satisfied with your service.");
            }
            else if (patron1Reputation > 2)
            {
                Terminal.WriteLine("Patron1 seems very pleased with your service.");
            }
            else
            {
                Terminal.WriteLine("Error in calculating Patron1's reaction.");
            }
            patron1Tip = patron1Reputation * 5;
            if (patron1Tip < 0)
                patron1Tip = 0;
            Terminal.WriteLine("Patron1 leaves you a tip of " + patron1Tip + " credits.");
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            patron1Served = true;
            CustomerSelection();
        }


        //====================================================================================================
        //Patron 2
        //====================================================================================================

        public void ServePatron2()
        {
            Terminal.Clear();
            Terminal.WriteLine("In the dim corner, Patron1 sits alone, cloaked in shadow.");
            Terminal.WriteLine("\"You seem... different from the others. Why are you here, really?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"What's it to you?\"");
            Terminal.WriteLine("2. \"Maybe I like listening to people’s stories.\"");
            Terminal.WriteLine("3. \"Why do you ask?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Calm down. I was just making conversation.\"");
                    patron2Reputation -= 1;
                    Patron2Path1();
                    break;
                case "2":
                    Terminal.WriteLine("\"A noble pursuit. But be careful — not every story ends well.\"");
                    Patron2Path2();
                    break;
                case "3":
                    Terminal.WriteLine("\"Curiosity can be dangerous. Remember that.\"");
                    Patron2Path3();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    ServePatron2();
                    return;
            }
        }

        public void Patron2Path1()
        {
            Terminal.WriteLine("Is this how you treat all your customers?");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Sorry, it's been a rough night. Truth is, I'm saving up to leave this dump.\"");
            Terminal.WriteLine("2. \"Who do you think you are? You think you're special or something?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron2Choice1();
                    break;
                case "2":
                    Terminal.WriteLine("\"You couldn't just leave it alone, huh?\"");
                    patron2Reputation -= 3;
                    Patron2BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron2Path1();
                    return;
            }
        }

        public void Patron2Path2()
        {
            Terminal.WriteLine("I would tell you mine, but I wouldn't say it's that interesting.");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"I aspire to be more than a barkeep in a dump like this.\"");
            Terminal.WriteLine("2. \"Recount some of the hardships that made you wind up here.\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron2Choice1();
                    break;
                case "2":
                    Terminal.WriteLine("\"I see... would you care to tell me more?\"");
                    patron2Reputation += 1;
                    Patron2Choice2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron2Path2();
                    return;
            }
        }

        public void Patron2Path3()
        {
            Terminal.WriteLine("I take an interest in people, and barkeeps never disappoint.");
            Terminal.WriteLine("\"I'm here looking for tips on my lost partner. They got stranded on a supply run to a nearby outpost.\"");
            Terminal.WriteLine("I've told you my story, care to return the favour?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Tell him some of your struggles.\"");
            Terminal.WriteLine("2. \"Recall the rumour you overheard patrons in the bar discussing earlier about a distress beacon.\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron2Choice2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Oh?\"");
                    Patron2Choice3();
                    break;
            }
        }

        public void Patron2Choice1()
        {
            Terminal.WriteLine("You can tell them the truth, or make something up.");
            Terminal.WriteLine("1. Tell the truth.");
            Terminal.WriteLine("2. Make something up.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I see. Sometimes the truth is the heaviest burden.\"");
                    patron2Reputation += 1;
                    Patron2Drink1();
                    break;
                case "2":
                    Terminal.WriteLine("\"Lies are easy to tell, but hard to keep. I hope you find what you're looking for.\"");
                    Patron2BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron2Choice1();
                    return;
            }
        }

        public void Patron2Choice2()
        {
            Terminal.WriteLine("You feel you can trust this stranger. You can tell him your stories or cut the conversation a bit short.");
            Terminal.WriteLine("1. Tell your stories.");
            Terminal.WriteLine("2. Cut the conversation short.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Stories are the threads that weave our lives together. Thank you for sharing.\"");
                    patron2Reputation += 1;
                    Patron2Drink2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Sometimes silence speaks louder than words. I won't press for more.\"");
                    Patron2Drink1();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron2Choice2();
                    return;
            }
        }

        public void Patron2Choice3()
        {
            Terminal.WriteLine("Have you seriously heard something about a distress beacon?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Yeah, I heard some patrons talking about it earlier. (Share the details extensively)\"");
            Terminal.WriteLine("2. \"Yeah, I... think... . (Keep it vague)\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Information is power. Thank you for trusting me with it.\"");
                    Patron2GoodEnd();
                    break;
                case "2":
                    Terminal.WriteLine("\"Even a hint can be a lifeline. I appreciate your discretion.\"");
                    patron2Reputation -= 1;
                    Patron2Drink2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron2Choice3();
                    return;
            }
        }

        public void Patron2Drink1()
        {
            Terminal.WriteLine("\"Tell you what, make me an Old Fashioned.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron2Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. But it's well made.\"");
                    patron2Reputation += 1;
                }
            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron2Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron2Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron2Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. And it's poorly made.\"");
                    patron2Reputation -= 2;
                }
            }
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Patron2Ending();
        }

        public void Patron2Drink2()
        {
            Terminal.WriteLine("\"Tell you what, make me a Peach Margarita. It's good to mix it up a little.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron2Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. But it's well made.\"");
                    patron2Reputation += 1;
                }
            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron2Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron2Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron2Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. And it's poorly made.\"");
                    patron2Reputation -= 2;
                }
            }

            Patron2Ending();
        }

        public void Patron2BadEnd()
        {
            Terminal.WriteLine("The figure stands, revealing a face scarred and weary. \"Some truths are better left unknown.\"");
            Terminal.WriteLine("Before you can react, they vanish into the shadows, leaving you with a chilling silence.");
            Terminal.WriteLine("Press Enter to continue...");
            patron2Left = true;
            Console.ReadLine();
        }

        public void Patron2GoodEnd()
        {
            Terminal.WriteLine("The figure's eyes light up with hope. \"You may have just saved a life tonight.\"");
            Terminal.WriteLine("They stand, leaving a small pouch of credits on the bar. \"For your kindness. Farewell, " + playerName + ".\"");
            Terminal.WriteLine("Press Enter to continue...");
            patron2Reputation += 3;
            Console.ReadLine();
        }

        public void Patron2Ending()
        {
            if (patron2Reputation < 0)
            {
                Terminal.WriteLine("Patron2 seems displeased with your service.");
            }
            else if (patron2Reputation == 0)
            {
                Terminal.WriteLine("Patron2 seems indifferent about your service.");
            }
            else if (patron2Reputation > 0 && patron2Reputation <= 2)
            {
                Terminal.WriteLine("Patron2 seems satisfied with your service.");
            }
            else if (patron2Reputation > 2)
            {
                Terminal.WriteLine("Patron2 seems very pleased with your service.");
            }
            else
            {
                Terminal.WriteLine("Error in calculating Patron2's reaction.");
            }
            patron2Tip = patron2Reputation * 5;
            if (patron2Tip < 0)
                patron2Tip = 0;
            Terminal.WriteLine("Patron2 leaves you a tip of " + patron2Tip + " credits.");
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            patron2Served = true;
            CustomerSelection();
        }

        //====================================================================================================
        //Patron 3
        //====================================================================================================

        public void ServePatron3()
        {
            Terminal.Clear();
            Terminal.WriteLine("In the dim corner, Patron1 sits alone, cloaked in shadow.");
            Terminal.WriteLine("\"You seem... different from the others. Why are you here, really?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"What's it to you?\"");
            Terminal.WriteLine("2. \"Maybe I like listening to people’s stories.\"");
            Terminal.WriteLine("3. \"Why do you ask?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Calm down. I was just making conversation.\"");
                    patron3Reputation -= 1;
                    Patron3Path1();
                    break;
                case "2":
                    Terminal.WriteLine("\"A noble pursuit. But be careful — not every story ends well.\"");
                    Patron3Path2();
                    break;
                case "3":
                    Terminal.WriteLine("\"Curiosity can be dangerous. Remember that.\"");
                    Patron3Path3();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    ServePatron3();
                    return;
            }
        }

        public void Patron3Path1()
        {
            Terminal.WriteLine("Is this how you treat all your customers?");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Sorry, it's been a rough night. Truth is, I'm saving up to leave this dump.\"");
            Terminal.WriteLine("2. \"Who do you think you are? You think you're special or something?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron3Choice1();
                    break;
                case "2":
                    Terminal.WriteLine("\"You couldn't just leave it alone, huh?\"");
                    patron3Reputation -= 3;
                    Patron3BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Path1();
                    return;
            }
        }

        public void Patron3Path2()
        {
            Terminal.WriteLine("I would tell you mine, but I wouldn't say it's that interesting.");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"I aspire to be more than a barkeep in a dump like this.\"");
            Terminal.WriteLine("2. \"Recount some of the hardships that made you wind up here.\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron3Choice1();
                    break;
                case "2":
                    Terminal.WriteLine("\"I see... would you care to tell me more?\"");
                    patron3Reputation += 1;
                    Patron3Choice2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Path2();
                    return;
            }
        }

        public void Patron3Path3()
        {
            Terminal.WriteLine("I take an interest in people, and barkeeps never disappoint.");
            Terminal.WriteLine("\"I'm here looking for tips on my lost partner. They got stranded on a supply run to a nearby outpost.\"");
            Terminal.WriteLine("I've told you my story, care to return the favour?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Tell him some of your struggles.\"");
            Terminal.WriteLine("2. \"Recall the rumour you overheard patrons in the bar discussing earlier about a distress beacon.\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron3Choice2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Oh?\"");
                    Patron3Choice3();
                    break;
            }
        }

        public void Patron3Choice1()
        {
            Terminal.WriteLine("You can tell them the truth, or make something up.");
            Terminal.WriteLine("1. Tell the truth.");
            Terminal.WriteLine("2. Make something up.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I see. Sometimes the truth is the heaviest burden.\"");
                    patron3Reputation += 1;
                    Patron3Drink1();
                    break;
                case "2":
                    Terminal.WriteLine("\"Lies are easy to tell, but hard to keep. I hope you find what you're looking for.\"");
                    Patron3BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Choice1();
                    return;
            }
        }

        public void Patron3Choice2()
        {
            Terminal.WriteLine("You feel you can trust this stranger. You can tell him your stories or cut the conversation a bit short.");
            Terminal.WriteLine("1. Tell your stories.");
            Terminal.WriteLine("2. Cut the conversation short.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Stories are the threads that weave our lives together. Thank you for sharing.\"");
                    patron3Reputation += 1;
                    Patron3Drink2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Sometimes silence speaks louder than words. I won't press for more.\"");
                    Patron3Drink1();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Choice2();
                    return;
            }
        }

        public void Patron3Choice3()
        {
            Terminal.WriteLine("Have you seriously heard something about a distress beacon?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Yeah, I heard some patrons talking about it earlier. (Share the details extensively)\"");
            Terminal.WriteLine("2. \"Yeah, I... think... . (Keep it vague)\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Information is power. Thank you for trusting me with it.\"");
                    Patron3GoodEnd();
                    break;
                case "2":
                    Terminal.WriteLine("\"Even a hint can be a lifeline. I appreciate your discretion.\"");
                    patron3Reputation -= 1;
                    Patron3Drink2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Choice3();
                    return;
            }
        }

        public void Patron3Drink1()
        {
            Terminal.WriteLine("\"Tell you what, make me an Old Fashioned.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron3Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. But it's well made.\"");
                    patron3Reputation += 1;
                }
            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron3Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron3Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron3Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. And it's poorly made.\"");
                    patron3Reputation -= 2;
                }
            }
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Patron3Ending();
        }

        public void Patron3Drink2()
        {
            Terminal.WriteLine("\"Tell you what, make me a Peach Margarita. It's good to mix it up a little.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron3Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. But it's well made.\"");
                    patron3Reputation += 1;
                }
            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron3Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron3Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron3Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. And it's poorly made.\"");
                    patron3Reputation -= 2;
                }
            }

            Patron3Ending();
        }

        public void Patron3BadEnd()
        {
            Terminal.WriteLine("The figure stands, revealing a face scarred and weary. \"Some truths are better left unknown.\"");
            Terminal.WriteLine("Before you can react, they vanish into the shadows, leaving you with a chilling silence.");
            Terminal.WriteLine("Press Enter to continue...");
            patron3Left = true;
            Console.ReadLine();
        }

        public void Patron3GoodEnd()
        {
            Terminal.WriteLine("The figure's eyes light up with hope. \"You may have just saved a life tonight.\"");
            Terminal.WriteLine("They stand, leaving a small pouch of credits on the bar. \"For your kindness. Farewell, " + playerName + ".\"");
            Terminal.WriteLine("Press Enter to continue...");
            patron3Reputation += 3;
            Console.ReadLine();
        }

        public void Patron3Ending()
        {
            if (patron3Reputation < 0)
            {
                Terminal.WriteLine("Patron3 seems displeased with your service.");
            }
            else if (patron3Reputation == 0)
            {
                Terminal.WriteLine("Patron3 seems indifferent about your service.");
            }
            else if (patron3Reputation > 0 && patron3Reputation <= 2)
            {
                Terminal.WriteLine("Patron3 seems satisfied with your service.");
            }
            else if (patron3Reputation > 2)
            {
                Terminal.WriteLine("Patron3 seems very pleased with your service.");
            }
            else
            {
                Terminal.WriteLine("Error in calculating Patron1's reaction.");
            }
            patron3Tip = patron3Reputation * 5;
            if (patron3Tip < 0)
                patron3Tip = 0;
            Terminal.WriteLine("Patron3 leaves you a tip of " + patron3Tip + " credits.");
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            patron3Served = true;
            CustomerSelection();
        }

        //====================================================================================================
        //Patron 4
        //====================================================================================================

        public void ServePatron4()
        {
            Terminal.Clear();
            Terminal.WriteLine("In the dim corner, Patron1 sits alone, cloaked in shadow.");
            Terminal.WriteLine("\"You seem... different from the others. Why are you here, really?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"What's it to you?\"");
            Terminal.WriteLine("2. \"Maybe I like listening to people’s stories.\"");
            Terminal.WriteLine("3. \"Why do you ask?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Calm down. I was just making conversation.\"");
                    patron4Reputation -= 1;
                    Patron4Path1();
                    break;
                case "2":
                    Terminal.WriteLine("\"A noble pursuit. But be careful — not every story ends well.\"");
                    Patron4Path2();
                    break;
                case "3":
                    Terminal.WriteLine("\"Curiosity can be dangerous. Remember that.\"");
                    Patron4Path3();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    ServePatron4();
                    return;
            }
        }

        public void Patron4Path1()
        {
            Terminal.WriteLine("Is this how you treat all your customers?");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Sorry, it's been a rough night. Truth is, I'm saving up to leave this dump.\"");
            Terminal.WriteLine("2. \"Who do you think you are? You think you're special or something?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron4Choice1();
                    break;
                case "2":
                    Terminal.WriteLine("\"You couldn't just leave it alone, huh?\"");
                    patron4Reputation -= 3;
                    Patron4BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron4Path1();
                    return;
            }
        }

        public void Patron4Path2()
        {
            Terminal.WriteLine("I would tell you mine, but I wouldn't say it's that interesting.");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"I aspire to be more than a barkeep in a dump like this.\"");
            Terminal.WriteLine("2. \"Recount some of the hardships that made you wind up here.\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron4Choice1();
                    break;
                case "2":
                    Terminal.WriteLine("\"I see... would you care to tell me more?\"");
                    patron4Reputation += 1;
                    Patron4Choice2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron4Path2();
                    return;
            }
        }

        public void Patron4Path3()
        {
            Terminal.WriteLine("I take an interest in people, and barkeeps never disappoint.");
            Terminal.WriteLine("\"I'm here looking for tips on my lost partner. They got stranded on a supply run to a nearby outpost.\"");
            Terminal.WriteLine("I've told you my story, care to return the favour?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Tell him some of your struggles.\"");
            Terminal.WriteLine("2. \"Recall the rumour you overheard patrons in the bar discussing earlier about a distress beacon.\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron4Choice2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Oh?\"");
                    Patron4Choice3();
                    break;
            }
        }

        public void Patron4Choice1()
        {
            Terminal.WriteLine("You can tell them the truth, or make something up.");
            Terminal.WriteLine("1. Tell the truth.");
            Terminal.WriteLine("2. Make something up.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"I see. Sometimes the truth is the heaviest burden.\"");
                    patron4Reputation += 1;
                    Patron4Drink1();
                    break;
                case "2":
                    Terminal.WriteLine("\"Lies are easy to tell, but hard to keep. I hope you find what you're looking for.\"");
                    Patron4BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron4Choice1();
                    return;
            }
        }

        public void Patron4Choice2()
        {
            Terminal.WriteLine("You feel you can trust this stranger. You can tell him your stories or cut the conversation a bit short.");
            Terminal.WriteLine("1. Tell your stories.");
            Terminal.WriteLine("2. Cut the conversation short.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Stories are the threads that weave our lives together. Thank you for sharing.\"");
                    patron4Reputation += 1;
                    Patron4Drink2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Sometimes silence speaks louder than words. I won't press for more.\"");
                    Patron4Drink1();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Choice2();
                    return;
            }
        }

        public void Patron4Choice3()
        {
            Terminal.WriteLine("Have you seriously heard something about a distress beacon?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Yeah, I heard some patrons talking about it earlier. (Share the details extensively)\"");
            Terminal.WriteLine("2. \"Yeah, I... think... . (Keep it vague)\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Information is power. Thank you for trusting me with it.\"");
                    Patron4GoodEnd();
                    break;
                case "2":
                    Terminal.WriteLine("\"Even a hint can be a lifeline. I appreciate your discretion.\"");
                    patron4Reputation -= 1;
                    Patron4Drink2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron4Choice3();
                    return;
            }
        }

        public void Patron4Drink1()
        {
            Terminal.WriteLine("\"Tell you what, make me an Old Fashioned.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron4Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. But it's well made.\"");
                    patron4Reputation += 1;
                }
            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron4Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron4Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron4Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. And it's poorly made.\"");
                    patron4Reputation -= 2;
                }
            }
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Patron4Ending();
        }

        public void Patron4Drink2()
        {
            Terminal.WriteLine("\"Tell you what, make me a Peach Margarita. It's good to mix it up a little.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron4Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. But it's well made.\"");
                    patron4Reputation += 1;
                }
            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron4Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron4Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron4Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. And it's poorly made.\"");
                    patron4Reputation -= 2;
                }
            }

            Patron4Ending();
        }

        public void Patron4BadEnd()
        {
            Terminal.WriteLine("The figure stands, revealing a face scarred and weary. \"Some truths are better left unknown.\"");
            Terminal.WriteLine("Before you can react, they vanish into the shadows, leaving you with a chilling silence.");
            Terminal.WriteLine("Press Enter to continue...");
            patron3Left = true;
            Console.ReadLine();
        }

        public void Patron4GoodEnd()
        {
            Terminal.WriteLine("The figure's eyes light up with hope. \"You may have just saved a life tonight.\"");
            Terminal.WriteLine("They stand, leaving a small pouch of credits on the bar. \"For your kindness. Farewell, " + playerName + ".\"");
            Terminal.WriteLine("Press Enter to continue...");
            patron4Reputation += 3;
            Console.ReadLine();
        }

        public void Patron4Ending()
        {
            if (patron4Reputation < 0)
            {
                Terminal.WriteLine("Patron4 seems displeased with your service.");
            }
            else if (patron4Reputation == 0)
            {
                Terminal.WriteLine("Patron4 seems indifferent about your service.");
            }
            else if (patron4Reputation > 0 && patron4Reputation <= 2)
            {
                Terminal.WriteLine("Patron4 seems satisfied with your service.");
            }
            else if (patron4Reputation > 2)
            {
                Terminal.WriteLine("Patron4 seems very pleased with your service.");
            }
            else
            {
                Terminal.WriteLine("Error in calculating Patron4's reaction.");
            }
            patron4Tip = patron4Reputation * 5;
            if (patron4Tip < 0)
                patron4Tip = 0;
            Terminal.WriteLine("Patron4 leaves you a tip of " + patron4Tip + " credits.");
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            patron4Served = true;
            CustomerSelection();
        }


        //====================================================================================================
        //Experimental Branchs
        //====================================================================================================

        public void ServePatron5()
        {
            Terminal.Clear();
            Terminal.WriteLine("In the dim corner, Patron5 sits alone, cloaked in shadow.");
            Terminal.WriteLine("\"You seem... different from the others. Why are you here, really?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"What's it to you?\"");
            Terminal.WriteLine("2. \"Maybe I like listening to people’s stories.\"");
            Terminal.WriteLine("3. \"Why do you ask?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    //path 1
                    Terminal.WriteLine("\"Calm down. I was just making conversation.\"");
                    patron5Reputation -= 1;
                    Patron5Path1();
                    break;
                case "2":
                    //path 2
                    Terminal.WriteLine("\"A noble pursuit. But be careful — not every story ends well.\"");
                    Patron5Path2();
                    break;
                case "3":
                    //path 3
                    Terminal.WriteLine("\"Curiosity can be dangerous. Remember that.\"");
                    Patron5Path3();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    ServePatron5();
                    return;
            }


            
        }


        public void Patron5Path1()
        {
            //Path 1 Dialogue
            Terminal.WriteLine("Is this how you treat all your customers?");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Sorry, it's been a rough night. Truth is, I'm saving up to leave this dump.\"");
            Terminal.WriteLine("2. \"Who do you think you are? You think you're special or something?\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    //TO CHOICE 1
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron5Choice1();
                    break;
                case "2":
                    //BAD END
                    Terminal.WriteLine("\"You couldn't just leave it alone, huh?\"");
                    patron5Reputation -= 3;
                    Patron5BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron5Path1();
                    return;
            }
        }

        public void Patron5Path2()
        {
            //Path 2 Dialogue
            Terminal.WriteLine("I would tell you mine, but I wouldn't say it's that interesting.");
            Terminal.WriteLine("\"So, tell me barkeep. Why are you really here?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"I aspire to be more than a barkeep in a dump like this.\"");
            Terminal.WriteLine("2. \"Recount some of the hardships that made you wind up here.\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    //TO CHOICE 1
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron5Choice1();
                    break;
                case "2":
                    //TO CHOICE 2
                    Terminal.WriteLine("\"I see... would you care to tell me more?\"");
                    patron5Reputation += 1;
                    Patron5Choice2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron5Path2();
                    return;
            }
        }

        public void Patron5Path3()
        {
            //Path 3 Dialogue
            Terminal.WriteLine("I take an interest in people, and barkeeps never disapoint.");
            Terminal.WriteLine("\"I'm here looking for tips on my lost partner. They got stranded on a supply run to a nearby outpost.\"");
            Terminal.WriteLine("I've told you my story, care to return the favour?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Tell him some of your struggles.\"");
            Terminal.WriteLine("2. \"Recall the rumour you over heard patrons in the bar discussing earlier about a distress beacon.\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    //TO CHOICE 2
                    Terminal.WriteLine("\"I get it, but I have a feeling that isn't the full truth.\"");
                    Patron5Choice2();
                    break;
                case "2":
                    //TO CHOICE 3 
                    Terminal.WriteLine("\"Oh?\"");
                    Patron5Choice3();
                    break;



            }
        }

        public void Patron5Choice1()
        {
            //Choice 1 Dialogue
            Terminal.WriteLine("You can tell them the truth, or make something up.");
            Terminal.WriteLine("1. Tell the truth.");
            Terminal.WriteLine("2. Make something up.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    //TO DRINK 1
                    Terminal.WriteLine("\"I see. Sometimes the truth is the heaviest burden.\"");
                    patron5Reputation += 1;
                    Patron5Drink1();
                    break;
                case "2":
                    //TO BAD END
                    Terminal.WriteLine("\"Lies are easy to tell, but hard to keep. I hope you find what you're looking for.\"");
                    Patron5BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron5Choice1();
                    return;
            }
        }

        public void Patron5Choice2()
        {
            //Choice 2 Dialogue
            Terminal.WriteLine("You feel you can trust this stranger. You can tell him your stories or cut the conversation a bit short.");
            Terminal.WriteLine("1. Tell your stories.");
            Terminal.WriteLine("2. Cut the conversation short.");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    //TO DRINK 2
                    Terminal.WriteLine("\"Stories are the threads that weave our lives together. Thank you for sharing.\"");
                    patron5Reputation += 1;
                    Patron5Drink2();
                    break;
                case "2":
                    //TO DRINK 1
                    Terminal.WriteLine("\"Sometimes silence speaks louder than words. I won't press for more.\"");
                    Patron5Drink1();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron5Choice2();
                    return;
            }
        }

        public void Patron5Choice3()
        {
            //Choice 3 Dialogue
            Terminal.WriteLine("Have you seriously heard something about a distress beacon?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Yeah, I heard some patrons talking about it earlier. (Share the details extensively)\"");
            Terminal.WriteLine("2. \"Yeah, I... think... . (Keep it vague)\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    //TO GOOD END
                    Terminal.WriteLine("\"Information is power. Thank you for trusting me with it.\"");
                    Patron5GoodEnd();
                    break;
                case "2":
                    //TO DRINK 2
                    Terminal.WriteLine("\"Even a hint can be a lifeline. I appreciate your discretion.\"");
                    patron5Reputation -= 1;
                    Patron5Drink2();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron5Choice3();
                    return;
            }
        }

        public void Patron5Drink1()
        {
            Terminal.WriteLine("\"Tell you what, make me an Old Fashioned.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100 )
            {
                if(mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron5Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. But it's well made.\"");
                    patron5Reputation += 1;
                }
                
            }
            else if (drinkScore >= 60)
            {
                if(mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron5Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron5Reputation -= 1;
                }
            }
            else
            {
                if(mixing.drink.Name == "Old Fashioned")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron5Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. And it's poorly made.\"");
                    patron5Reputation -= 2;
                }
            }
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Patron5Ending();


        }

        public void Patron5Drink2()
        {
            Terminal.WriteLine("\"Tell you what, make me a Peach Margarita. It's good to mix it up a little.\"");
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Excellent. Perhaps we’ll meet again.\"");
                    patron5Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. But it's well made.\"");
                    patron5Reputation += 1;
                }

            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron5Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Old Fashioned. It's passable, I suppose.\"");
                    patron5Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Hmm. Still learning, I see.\"");
                    patron5Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Peach Margarita. And it's poorly made.\"");
                    patron5Reputation -= 2;
                }
            }

            Patron5Ending();

        }

        public void Patron5BadEnd()
        {
            //Bad Ending Dialogue.
            Terminal.WriteLine("The figure stands, revealing a face scarred and weary. \"Some truths are better left unknown.\"");
            Terminal.WriteLine("Before you can react, they vanish into the shadows, leaving you with a chilling silence.");
            Terminal.WriteLine("Press Enter to continue...");
            patron5Left = true;
            Console.ReadLine();
        }

        public void Patron5GoodEnd()
        {
            //Good Ending Dialogue.
            Terminal.WriteLine("The figure's eyes light up with hope. \"You may have just saved a life tonight.\"");
            Terminal.WriteLine("They stand, leaving a small pouch of credits on the bar. \"For your kindness. Farewell, " + playerName + ".\"");
            Terminal.WriteLine("Press Enter to continue...");
            patron5Reputation += 3;
            Console.ReadLine();
        }

        public void Patron5Ending()
        {
            
            if (patron5Reputation < 0)
            {
                Terminal.WriteLine("Patron5 seems displeased with your service.");
            }
            else if (patron5Reputation == 0)
            {
                Terminal.WriteLine("Patron5 seems indifferent about your service.");
            }
            else if (patron5Reputation > 0 && patron5Reputation <= 2)
            {
                Terminal.WriteLine("Patron5 seems satisfied with your service.");
            }
            else if (patron5Reputation > 2)
            {
                Terminal.WriteLine("Patron5 seems very pleased with your service.");
            }
            else
            {
                Terminal.WriteLine("Error in calculating Patron5's reaction.");
            }
            patron5Tip = patron5Reputation * 5;
            if (patron5Tip < 0)
                patron5Tip = 0;
            Terminal.WriteLine("Patron5 leaves you a tip of " + patron5Tip + " credits.");
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            patron4Served = true;
            CustomerSelection();
        }

    }
}
