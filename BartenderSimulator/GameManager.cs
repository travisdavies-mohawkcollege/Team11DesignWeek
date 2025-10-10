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
        int cleaveReputation = 0;
        int cleaveTip = 0;
        bool cleaveLeft = false;
        bool cleaveServed = false;
        bool cleaveDone = false;
        //Patron 2
        int patron2Reputation = 0;
        int patron2Tip = 0;
        bool patron2Left = false;
        bool patron2Served = false;
        bool patron2Done = false;
        //Patron 3
        int patron3Reputation = 0;
        int patron3Tip = 0;
        bool patron3Left = false;
        bool patron3Served = false;
        bool patron3Done = false;
        //Patron 4
        int patron4Reputation = 0;
        int patron4Tip = 0;
        bool patron4Left = false;
        bool patron4Served = false;
        bool patron4Done = false;

        //Script References
        new ASCII ascii = new ASCII();
        new Mixing mixing = new Mixing();

        public void Setup()
        {
            Program.TerminalExecuteMode = TerminalExecuteMode.ExecuteOnce;
            Program.TerminalInputMode = TerminalInputMode.KeyboardReadAndReadLine;

            Terminal.SetTitle("The Long Drift");
            Terminal.UseRoboType = true;
            Terminal.RoboTypeIntervalMilliseconds = defaultTextSpeed;
            Terminal.WriteWithWordBreaks = true;
            Terminal.WordBreakCharacter = ' ';
        }

        public void StartMenu()
        {
            ascii.DrawStartMenu();
        }

        public void Execute()
        {
            StartMenu();
            Terminal.ReadLine();
            
            Intro();
            CustomerSelection();
        }

        public void Intro()
        {
            //Intro Sequence - Game State 0
            Terminal.Clear();
            Terminal.WriteLine("Welcome to The Long Drift, the only good bar this side of the solar system!");
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
            //Check if all customers have been served or left
            if (cleaveDone && patron2Done && patron3Done && patron4Done)
            {
                EndGame();
            }
            Terminal.WriteLine("Four customers are spread across the bar. Who do you want to serve?");
            Terminal.WriteLine("1. Cleave");
            Terminal.WriteLine("2. Lyra");
            Terminal.WriteLine("3. Kael");
            Terminal.WriteLine("4. Atlas");
            Terminal.WriteLine("Type the number of the customer you want to serve, then press Enter:");
            string customerChoice = Terminal.ReadLine();
            switch (customerChoice)
            {
                case "1":
                    if (cleaveServed)
                    {
                        Terminal.WriteLine("You've already served Cleave. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    if (cleaveLeft)
                    {
                        Terminal.WriteLine("Cleave has already left. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    ServeCleave();
                    break;
                case "2":
                    if (patron2Served)
                    {
                        Terminal.WriteLine("You've already served Lyra. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    if (patron2Left)
                    {
                        Terminal.WriteLine("Lyra has already left. Please choose another customer.");
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
                        Terminal.WriteLine("You've already served Kael. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    if (patron3Left)
                    {
                        Terminal.WriteLine("Kael has already left. Please choose another customer.");
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
                        Terminal.WriteLine("You've already served Atlas. Please choose another customer.");
                        Terminal.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        CustomerSelection();
                        return;
                    }
                    if (patron4Left)
                    {
                        Terminal.WriteLine("Atlas has already left. Please choose another customer.");
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

        public void EndGame()
        {
            Terminal.Clear();
            Terminal.WriteLine("The bar is quiet now. All your patrons have been served or have left.");
            int totalTips = cleaveTip + patron2Tip + patron3Tip + patron4Tip;
            Terminal.WriteLine("You count your tips: " + totalTips + " credits.");
            Terminal.WriteLine("Thanks for playing The Long Drift!");
            Terminal.WriteLine("Press Enter to exit...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        //====================================================================================================
        // Patron: Cleave “Graveljaw” Murdock - Ex-Mercenary
        //====================================================================================================

        public void ServeCleave()
        {
            Terminal.Clear();
            ascii.DrawCleave();
            Terminal.WriteLine("You approach a slab of a man. Steel-jawed, hunched, and twice as unwelcoming");
            Terminal.WriteLine("Cleave “Graveljaw” Murdock doesn’t look up. Three teeth glint in the low barlight.");
            Terminal.WriteLine("Some folks say Cleave tips in teeth... if he likes you.");
            Terminal.WriteLine("\"Unless you're pourin’ fire, don't speak.\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. “You look like the kind of man who drinks to remember, not to forget.”");
            Terminal.WriteLine("2. “What brings a merc to a jazz bar?”");
            Terminal.WriteLine("3. “I talk less with people who threaten me.”");

            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Sharp call. Neat it is. Back in the war, neat was the only way to drink before a mission.\"");
                    cleaveReputation += 1;
                    CleavePath1();
                    break;
                case "2":
                    Terminal.WriteLine("\"Ain’t here for the jazz. I wait. I watch.\"");
                    CleavePath2();
                    break;
                case "3":
                    Terminal.WriteLine("\"Not smart to mouth off in orbit, bartender.\"");
                    cleaveReputation -= 2;
                    CleaveChoice1();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    ServeCleave();
                    return;
            }
        }

        public void CleavePath1()
        {
            Terminal.WriteLine("He eyes your bottle hand. No tremble. Good.");
            Terminal.WriteLine("\"Say... you always this sharp, or just lucky today?\"");
            Terminal.WriteLine("1. “Luck runs dry. Skill stays poured.”");
            Terminal.WriteLine("2. “I'm just here for tips, old man.”");

            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Heh. Keep that steel. Might tip you somethin’ real.\"");
                    CleaveDrink();
                    break;
                case "2":
                    Terminal.WriteLine("\"Then maybe I’ll keep my teeth to myself.\"");
                    cleaveReputation -= 1;
                    CleaveDrink();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    CleavePath1();
                    return;
            }
        }

        public void CleavePath2()
        {
            Terminal.WriteLine("His gaze darkens — not angry, but heavy.");
            Terminal.WriteLine("\"Lost someone here. Every jazz note's a ghost.”");
            Terminal.WriteLine("1. “I won’t ask who, but I’ll raise a glass.”");
            Terminal.WriteLine("2. “A merc crying in his drink. Pathetic.”");

            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Respect. Even silence earns steel here.\"");
                    cleaveReputation += 1;
                    CleaveDrink();
                    break;
                case "2":
                    Terminal.WriteLine("\"Keep that lip, barkeep. Else I unpin memories.\"");
                    cleaveReputation -= 2;
                    CleaveBadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    CleavePath2();
                    return;
            }
        }

        public void CleaveChoice1()
        {
            Terminal.WriteLine("He leans in, voice low and dangerous.");
            Terminal.WriteLine("\"You got two choices: make my drink right, or make it my last.\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Calm down, I’m just doing my job.\"");
            Terminal.WriteLine("2. \"You want a fight, you’ll find one outside.\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Hmph. Just make it right.\"");
                    cleaveReputation -= 1;
                    CleaveDrink();
                    break;
                case "2":
                    Terminal.WriteLine("\"Big mistake, barkeep.\"");
                    cleaveReputation -= 3;
                    CleaveBadEnd();
                    return;
            }
        }

        public void CleaveDrink()
        {
            Terminal.Clear();
            Terminal.WriteLine("\"Whiskey. Neat. No garnish. If there's fruit in there, I find your family.\"");
            //-----------------------------------------------------------------------------------------
            ascii.DrawWhiskeyGlass();
            mixing.MixDrink();
            drinkScore = mixing.score;

            if (drinkScore == 100 && mixing.drink.Name.Equals("Whiskey Neat", StringComparison.OrdinalIgnoreCase))
            {
                Terminal.WriteLine("\"Perfect. You get a tooth — not from me. From someone who owed me.\"");
                cleaveReputation += 2;
            }
            else if (drinkScore >= 60 && mixing.drink.Name.Equals("Whiskey Neat", StringComparison.OrdinalIgnoreCase))
            {
                Terminal.WriteLine("\"Tolerable. Guess even rust shines in the right light.\"");
                cleaveReputation += 1;
            }
            else if (!mixing.drink.Name.Equals("Whiskey Neat", StringComparison.OrdinalIgnoreCase))
            {
                Terminal.WriteLine("\"Did I stutter? I said whiskey. Neat.\"");
                cleaveReputation -= 2;
            }
            else
            {
                Terminal.WriteLine("\"That swill could strip starship paint.\"");
                cleaveReputation -= 1;
            }


            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            CleaveEnding();
        }

        public void CleaveBadEnd()
        {
            Terminal.WriteLine("Cleave tosses a shell casing on the bar.");
            Terminal.WriteLine("\"For your troubles. Hollow, like that attitude.\"");
            Terminal.WriteLine("He leaves without another word.");
            Terminal.WriteLine("Press Enter to continue...");
            cleaveLeft = true;
            cleaveDone = true;
            cleaveReputation = 0;
            Console.ReadLine();
            Terminal.WriteLine("You have a chance to get a last word in as the man leaves.");
            Terminal.WriteLine("1. (Stay silent.)");
            Terminal.WriteLine("2. \"Watch your back, merc.\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("You stay silent as he leaves.");
                    CustomerSelection();
                    break;
                case "2":
                    Terminal.WriteLine("You warn him to watch his back.");
                    CleaveDeath();
                    return;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    CleaveBadEnd();
                    return;
            }
        }

        public void CleaveDeath()
        {
            Terminal.WriteLine("Cleave's eyes flash. In a blur, he draws a hidden pistol and fires.");
            Terminal.RoboTypeIntervalMilliseconds = blackoutTextSpeed;
            Terminal.WriteLine("You feel a sharp pain as the bullet hits you. Everything fades to black.");
            Terminal.WriteLine("Game over...");
            Terminal.WriteLine("Press Enter to continue...");
            cleaveLeft = true;
            cleaveReputation = 0;
            Console.ReadLine();
            Environment.Exit(1);
        }

        public void CleaveEnding()
        {
            Terminal.WriteLine("He downs the drink. Slow. Then gives a dry nod.");
            if (cleaveReputation <= 0)
            {
                Terminal.WriteLine("\"Could’ve been jet fuel. Lucky it ain’t. Either way, I’ll watch.\"");
            }
            else if (cleaveReputation == 1)
            {
                Terminal.WriteLine("\"Hmph. You got the grit. Needs polish.\"");
            }
            else
            {
                Terminal.WriteLine("*He slides a gold tooth across the bar.*");
                Terminal.WriteLine("\"Keep it. Might buy silence someday.\"");
            }

            cleaveTip = cleaveReputation * 10;
            if (cleaveTip < 0) cleaveTip = 0;
            Terminal.WriteLine("Cleave leaves you a tip of " + cleaveTip + " credits.");
            Terminal.WriteLine("Press Enter to continue...");
            cleaveServed = true;
            cleaveDone = true;
            Console.ReadLine();
            CustomerSelection();
        }
        //====================================================================================================
        //Patron 2 - Lyra
        //====================================================================================================

        public void ServePatron2()
        {
            Terminal.Clear();
            ascii.DrawPatron2();
            Terminal.WriteLine("The singer finishes her song in the bar's lounge. The song’s tone is bittersweet—about young love, fleeting moments, hardship. She pulls out a cigarette and sits by the bar.");
            Terminal.WriteLine("\"You've been watching me sing.\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"You've got a hell of a voice.\"");
            Terminal.WriteLine("2. \"How couldn't I?\"");
            Terminal.WriteLine("3. \"Not much else to do in this place.\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Mm thank you. I've been singing since I was 10.\"");
                    patron2Reputation -= 1;
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Patron2Path1();
                    break;
                case "2":
                    Terminal.WriteLine("\"Careful bartender... curiosity can be dangerous. Remember that.\"");
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Patron2Path2();
                    break;
                case "3":
                    Terminal.WriteLine("\"Maybe I'm just a distraction.\"");
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Patron2Path3();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    ServePatron2();
                    return;


            }
        }

        public void Patron2Path1()
        {
            Terminal.WriteLine();
            Terminal.WriteLine("She finishes a puff of her drag, drifts toward the window."); 
            Terminal.WriteLine("\"So uh, tell me barkeep... why are you really here?\"");
            Terminal.WriteLine("\nHow do you respond?");
            Terminal.WriteLine("1. \"Cheaper than therapy, and the stories are better.\"");
            Terminal.WriteLine("2. \"Because I ran out of places that’d still have me.\"");
            Terminal.WriteLine("3. [Stay silent]");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Ha. Maybe I should start running a tab here then.\"");
                    Terminal.WriteLine("She leans on the counter, ash falling from her cigarette. \"You must hear a lot of broken souls spill out after last call.\"");
                    Terminal.WriteLine("You shrug, polishing a glass. \"Comes with the job. Everyone’s got ghosts. Some just tip better than others.\"");
                    patron2Reputation += 1;
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Patron2Drink1();
                    break;


                case "2":
                    Terminal.WriteLine("\"Guess that makes two of us,\" she says softly, eyes lowering for just a second.");
                    Terminal.WriteLine("Then she smiles, a little forced but charming. \"Maybe this station’s where all the strays end up.\"");
                    Terminal.WriteLine("You smirk. \"Could be worse places to get lost.\"");
                    patron2Reputation += 1;
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Patron2Drink2();
                    break;

                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                    
            }
        }



        public void Patron2Path2()
        {
            Terminal.WriteLine("\nShe takes another puff of her drag, eyes drifting toward the viewport—Earth just a blue smear in the black.");
            Terminal.WriteLine("\"Funny, isn’t it? All that life down there, and somehow this place feels more alive.\"");
            Terminal.WriteLine("\nHow do you respond?");
            Terminal.WriteLine("1. \"A girl like you could make anywhere feel alive.\"");
            Terminal.WriteLine("2. \"If this is alive, I don't want to see dead.\"");
            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Such a flirt,\" she says, but there’s warmth behind it. \"You keep that up, and I might forget why I came here.\"");
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Patron2GoodEnd();
                    break;


                case "2":
                    Terminal.WriteLine("\"Hm... maybe. But sometimes the dead places are the ones that remember us best.\"");
                    Terminal.WriteLine("She flicks ash into a tray and looks out again, quieter now.");
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Patron2Drink2();
                    break;


                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Patron2Path2();
                    break;



            }
        }

        public void Patron2Path3()
        {
            Terminal.WriteLine("\"Not much for talking, huh?\" she teases, exhaling smoke. \"Fine, I’ll carry the conversation.\"");
            Terminal.WriteLine("She looks out the window, voice softer. \"You ever wonder what it’s all for? The drift, the endless space?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Maybe it’s not about the destination, but the journey.\"");
            Terminal.WriteLine("2. \"Never cared to give it much thought.\"");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Philosophical for a bartender,\" she says with a smirk. \"I like that.\"");
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    patron2Reputation += 1;
                    Patron2Drink1();
                    break;
                case "2":
                    Terminal.WriteLine("\"A cynic, huh? Well, I suppose that’s fitting for this place.\"");
                    patron2Reputation -= 1;
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Patron2BadEnd();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Terminal.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }

        public void Patron2Drink1()
        {
            Terminal.Clear();
            Terminal.WriteLine("\"Let's see if you can also impress me with your drinks, make me a Peach Margarita.\"");
            // -------------------------------------------------------------------
            ascii.DrawWhiskeyGlass();
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"It's perfect. I'm learing to expect nothing less of you.\"");
                    patron2Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't an Peach Margarita. You've got talent though.\"");
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
                    Console.WriteLine("\"You can do a bit better then that, surely?\"");
                    patron2Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Peach Margarita")
                {
                    Console.WriteLine("\"Disappointing.. to say the least.\"");
                    patron2Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"I have half a mind to charge your bar double for my performance. What kind of drink was that supposed to be?\"");
                    patron2Reputation -= 2;
                }
            }
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();

            Patron2Ending();
        }

        public void Patron2Drink2()
        {
            Terminal.Clear();
            Terminal.WriteLine("\"Make me a Pina Colada. Hopefully it'll make me think of better places.\"");
            ascii.DrawMartiniGlass();
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100)
            {
                if (mixing.drink.Name == "Pina Colada")
                {
                    Console.WriteLine("\"You've done a wonderful job on this.\"");
                    patron2Reputation += 2;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Pina Colada, but you seem to know what you're doing. I'll trust you.\"");
                    patron2Reputation += 1;
                }
            }
            else if (drinkScore >= 60)
            {
                if (mixing.drink.Name == "Pina Colada")
                {
                    Console.WriteLine("\"Good enough. You’ll improve with time.\"");
                    patron2Reputation += 1;
                }
                else
                {
                    Console.WriteLine("\"This isn't a Pina Colada, nor is it good.\"");
                    patron2Reputation -= 1;
                }
            }
            else
            {
                if (mixing.drink.Name == "Pina Colada")
                {
                    Console.WriteLine("\"I suppose this counts as a Pina Colada...\"");
                    patron2Reputation -= 1;
                }
                else
                {
                    Console.WriteLine("\"Are you trying to insult me? Could you at least try to make my drink right?\"");
                    patron2Reputation -= 2;
                }
            }

            Patron2Ending();
        }

        public void Patron2BadEnd()
        {
            Terminal.WriteLine("She sighs, finishing her cigarette. \"Maybe some places are just meant to be forgotten.\"");
            Terminal.WriteLine("She leaves without another word.");
            Terminal.WriteLine("Press Enter to continue...");
            patron2Left = true;
            patron2Done = true;
            patron2Reputation = 0;
            Console.ReadLine();
            CustomerSelection();
        }

        public void Patron2GoodEnd()
        {
            Terminal.WriteLine("\"You're impressive, barkeep.\"");
            Terminal.WriteLine("She stands, smoothing her dress. \"Maybe this station isn’t so bad after all.\"");
            Terminal.WriteLine("\"Leave my tab open, I'll be back.\"");
            Terminal.WriteLine("Press Enter to continue...");
            patron2Reputation = 10;
            patron2Left = true;
            patron2Done = true;
            Console.ReadLine();
            Patron2Ending();

        }

        public void Patron2Ending()
        {
            if (patron2Reputation < 0)
            {
                Terminal.WriteLine("Lyra seems displeased with your service.");
            }
            else if (patron2Reputation == 0)
            {
                Terminal.WriteLine("Lyra seems indifferent about your service.");
            }
            else if (patron2Reputation > 0 && patron2Reputation <= 2)
            {
                Terminal.WriteLine("Lyra seems satisfied with your service.");
            }
            else if (patron2Reputation > 2)
            {
                Terminal.WriteLine("Lyra seems very pleased with your service.");
            }
            else
            {
                Terminal.WriteLine("Error in calculating Lyra's reaction.");
            }
            patron2Tip = patron2Reputation * 5;
            if (patron2Tip < 0)
                patron2Tip = 0;
            Terminal.WriteLine("Lyra leaves you a tip of " + patron2Tip + " credits.");
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            patron2Served = true;
            patron2Done = true;
            CustomerSelection();
        }

        //====================================================================================================
        // Patron 3: Kael "Steelheart" Arden - Station Security
        //====================================================================================================

        public void ServePatron3()
        {
            Terminal.Clear();
            ascii.DrawKael();
            Terminal.WriteLine("The bar doors hiss open. Kael \"Steelheart\" Arden steps in, polished boots echoing.");
            Terminal.WriteLine("His uniform is crisp, but there's a bright tropical pin on his collar.");
            Terminal.WriteLine("\"Evening, bartender. Got anything sweeter than this job?\"");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Long shift, Officer? Thought I’d prep something that doesn’t taste like paperwork.\"");
            Terminal.WriteLine("2. \"You look like you could use a vacation.\"");
            Terminal.WriteLine("3. \"Rules say I don’t serve on-duty officers.\"");

            string responseChoice = Terminal.ReadLine();

            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Ha! Now we're talkin'. Surprise me — but make it tropical.\"");
                    patron3Reputation += 1;
                    Patron3Path1();
                    break;
                case "2":
                    Terminal.WriteLine("\"Don’t tempt me. But the stars need guarding.\"");
                    Patron3Path2();
                    break;
                case "3":
                    Terminal.WriteLine("\"Relax, champ. Shift’s over. Uniform stays on, but the badge is off.\"");
                    patron3Reputation -= 1;
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
            Terminal.WriteLine("Kael leans closer, voice lowering.");
            Terminal.WriteLine("\"You ever heard of a smuggler called Atlas? Callsign rings bells here?\"");
            Terminal.WriteLine("1. \"Can’t say I have.\"");
            Terminal.WriteLine("2. \"Might’ve seen someone sketchy — depends who’s asking.\"");

            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Hmm. Either you’re honest or a good liar. I’ll sip on that.\"");
                    Patron3Drink1();
                    break;
                case "2":
                    Terminal.WriteLine("\"You’re sharp. That’s good. I watch the sharp ones.\"");
                    patron3Reputation += 1;
                    Patron3Choice1();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Path1();
                    return;
            }
        }

        public void Patron3Path2()
        {
            Terminal.WriteLine("He chuckles, undoing his collar slightly.");
            Terminal.WriteLine("\"You joke, but the only beach I know’s holographic. What’s your escape?\"");
            Terminal.WriteLine("1. \"Sweet drinks, good music, no questions.\"");
            Terminal.WriteLine("2. \"Getting off this station for good.\"");

            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Now that’s a philosophy I can toast to.\"");
                    patron3Reputation += 1;
                    Patron3Drink2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Ambition’s a strong pour. Let’s see how yours mixes.\"");
                    Patron3Drink1();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Path2();
                    return;
            }
        }

        public void Patron3Path3()
        {
            Terminal.WriteLine("Kael raises an eyebrow, amused.");
            Terminal.WriteLine("\"You and Cleave would get along. He also thinks I’m still on duty.\"");
            Terminal.WriteLine("1. \"Cleave talks about you. Calls you the \"loud one.\"\"");
            Terminal.WriteLine("2. \"Guess old habits die loud.\"");

            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"He said that? Ha! That tooth-rattling grump.\"");
                    patron3Reputation += 1;
                    Patron3Drink2();
                    break;
                case "2":
                    Terminal.WriteLine("\"Touché, bartender. Pour something before I regret coming in.\"");
                    Patron3Drink1();
                    break;
                default:
                    Terminal.WriteLine("Invalid choice. Please try again.");
                    Patron3Path3();
                    return;
            }
        }

        public void Patron3Choice1()
        {
            Terminal.WriteLine("\"An off duty cop is still a cop. You seen this Atlas fellow or not?\"");
            Terminal.WriteLine("1. \"Nope, never heard of him.\" (Lie)");
            Terminal.WriteLine("2. \"That cloaked figure in the corner....\" (Truth)");
            string responseChoice = Terminal.ReadLine();
            switch (responseChoice)
            {
                case "1":
                    Terminal.WriteLine("\"Sure you haven’t. I’ll be watching you.\"");
                    patron3Reputation -= 2;
                    Patron3Drink1();
                    break;
                case "2":
                    Terminal.WriteLine("\"Hmm. Interesting. Thanks for the tip.\"");
                    patron3Reputation += 2;
                    Patron3ArrestEnding();
                    break;
            }
        }


        public void Patron3Drink1()
        {
            Terminal.Clear();
            Terminal.WriteLine("\"Make it a Margarita. I trust your hand more than most cadets.\"");
            ascii.DrawMartiniGlass();
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100 && mixing.drink.Name.Equals("Margarita", StringComparison.OrdinalIgnoreCase))
            {
                Terminal.WriteLine("\"That hits the spot. I hope you don't ever think of switching careers.\"");
                Terminal.WriteLine("\"That hits the spot. I hope you don't ever think of switching careers.\"");
                patron3Reputation += 2;
            }
            else if (drinkScore >= 60 && mixing.drink.Name.Equals("Margarita", StringComparison.OrdinalIgnoreCase))
            {
                Terminal.WriteLine("\"Close enough for orbital work.\"");
                patron3Reputation += 1;
            }
            else if (!mixing.drink.Name.Equals("Margarita", StringComparison.OrdinalIgnoreCase))
            {
                Terminal.WriteLine("\"Told you I don’t do surprises.\"");
                patron3Reputation -= 1;
            }
            else
            {
                Terminal.WriteLine("\"That tasted like regret and lime.\"");
                patron3Reputation -= 2;
            }

            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Patron3Ending();
        }

        public void Patron3Drink2()
        {
            Terminal.Clear();
            Terminal.WriteLine("\"Gimme a Pina Colada. Let’s pretend this tin can’s a cabana.\"");
            ascii.DrawMartiniGlass();
            mixing.MixDrink();
            drinkScore = mixing.score;
            if (drinkScore == 100 && mixing.drink.Name.Equals("Pina Colada", StringComparison.OrdinalIgnoreCase))
            {
                Terminal.WriteLine("\"Whew. That'll keep the stardust off my soul.\"");
                patron3Reputation += 2;
            }
            else if (drinkScore >= 60 && mixing.drink.Name.Equals("Pina Colada", StringComparison.OrdinalIgnoreCase))
            {
                Terminal.WriteLine("\"Tastes like a vacation in a can. I’ll take it.\"");
                patron3Reputation += 1;
            }
            else if (!mixing.drink.Name.Equals("Pina Colada", StringComparison.OrdinalIgnoreCase))
            {
                Terminal.WriteLine("\"That’s not even close to tropical, friend.\"");
                patron3Reputation -= 1;
            }
            else
            {
                Terminal.WriteLine("\"That tastes like shore leave in a thunderstorm.\"");
                patron3Reputation -= 2;
            }

            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Patron3Ending();
        }





        public void Patron3Ending()
        {
            if (patron4Reputation < 0)
            {
                Terminal.WriteLine("Kael seems displeased with your service.");
            }
            else if (patron4Reputation == 0)
            {
                Terminal.WriteLine("Kael seems indifferent about your service.");
            }
            else if (patron4Reputation > 0 && patron4Reputation <= 2)
            {
                Terminal.WriteLine("Kael seems satisfied with your service.");
            }
            else if (patron4Reputation > 2)
            {
                Terminal.WriteLine("Kael seems very pleased with your service.");
            }
            else
            {
                Terminal.WriteLine("Error in calculating Patron4's reaction.");
            }
            patron3Tip = patron3Reputation * 5;
            if (patron3Tip < 0)
                patron3Tip = 0;
            Terminal.WriteLine("Atlas leaves you a tip of " + patron3Tip + " credits.");
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            patron3Served = true;
            patron3Done = true;
            CustomerSelection();
        }

        public void Patron3ArrestEnding()
        {
            Terminal.WriteLine("Kael's eyes narrow. He steals a glance at the customer in the corner.");
            Terminal.WriteLine("Atlas wastes no time when they notice, and they smoothly slip out of the building.");
            Terminal.WriteLine("Kael sighs, shaking his head. \"Damn smuggler slipped away again. A tip for the tip, bartender.\"");
            Terminal.WriteLine("He leaves you a tip and exits the bar.");
            Terminal.WriteLine("Press Enter to continue...");
            patron3Left = true;
            patron4Left = true;
            patron3Done = true;
            patron4Done = true;
            patron3Reputation = 5;
            Console.ReadLine();
            Patron3Ending();
        }


        //====================================================================================================
        //Patron 4 - Atlas, Androgynous Robot Smuggler
        //====================================================================================================

        public void ServePatron4()
        {
            Terminal.Clear();
            ascii.DrawPatron4();
            Terminal.WriteLine("In the dim corner, Atlas sits alone, figure hidden by a heavy cloak.");
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
            Terminal.WriteLine("2. (Recount some of the hardships that made you wind up here.)");
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
            Terminal.WriteLine("1. Tell him some of your struggles.");
            Terminal.WriteLine("2. Recall the rumour you overheard patrons in the bar discussing earlier about a distress beacon.");
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
            Terminal.WriteLine("You feel you can trust this stranger. You can tell them your stories or cut the conversation a bit short.");
            Terminal.WriteLine("1. (Tell your stories.)");
            Terminal.WriteLine("2. (Cut the conversation short.)");
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
                    Patron3Path2();
                    return;
            }
        }

        public void Patron4Choice3()
        {
            Terminal.WriteLine("Have you seriously heard something about a distress beacon?");
            Terminal.WriteLine("How do you respond?");
            Terminal.WriteLine("1. \"Yeah, I heard some patrons talking about it earlier. \" (Share the details extensively)");
            Terminal.WriteLine("2. \"Yeah, I... think... . \" (Keep it vague)");
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
            Terminal.Clear();
            Terminal.WriteLine("\"Tell you what, make me an Old Fashioned.\"");
            ascii.DrawWhiskeyGlass();
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
            Terminal.Clear();
            Terminal.WriteLine("\"Tell you what, make me a Peach Margarita. It's good to mix it up a little.\"");
            ascii.DrawMartiniGlass();
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
            Terminal.WriteLine("The figure stands, revealing battle scarred metallic face. \"Some truths are better left unknown.\"");
            Terminal.WriteLine("Before you can react, they vanish into the shadows, leaving you with a chilling silence.");
            Terminal.WriteLine("Press Enter to continue...");
            patron4Left = true;
            patron4Done = true;
            Console.ReadLine();
        }

        public void Patron4GoodEnd()
        {
            Terminal.WriteLine("The figure looks up, and a display panel lights up in the place of their eyes. \"You may have just saved a life tonight.\"");
            Terminal.WriteLine("They stand, leaving a small pouch of credits on the bar. \"For your kindness. Farewell, " + playerName + ".\"");
            Terminal.WriteLine("Press Enter to continue...");
            patron4Reputation = 10;
            patron4Left = true;
            patron4Done = true;
            Console.ReadLine();
            Patron4Ending();
        }

        public void Patron4Ending()
        {
            if (patron4Reputation < 0)
            {
                Terminal.WriteLine("Atlas seems displeased with your service.");
            }
            else if (patron4Reputation == 0)
            {
                Terminal.WriteLine("Atlas seems indifferent about your service.");
            }
            else if (patron4Reputation > 0 && patron4Reputation <= 2)
            {
                Terminal.WriteLine("Atlas seems satisfied with your service.");
            }
            else if (patron4Reputation > 2)
            {
                Terminal.WriteLine("Atlas seems very pleased with your service.");
            }
            else
            {
                Terminal.WriteLine("Error in calculating Patron4's reaction.");
            }
            patron4Tip = patron4Reputation * 5;
            if (patron4Tip < 0)
                patron4Tip = 0;
            Terminal.WriteLine("Atlas leaves you a tip of " + patron4Tip + " credits.");
            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            patron4Served = true;
            patron4Done = true;
            CustomerSelection();
        }




    }
}
