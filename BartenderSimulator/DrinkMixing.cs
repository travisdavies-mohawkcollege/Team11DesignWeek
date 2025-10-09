using MohawkTerminalGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travis
{
    class Drink
    {
        public string Name { get; }
        public List<string> Ingredients { get; }

        public Drink(string name, List<string> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }

    class Mixing
    {
        public int score = 0;
        public Drink drink;

        public void MixDrink()
        {
            // Define recipes
            var recipes = new List<Drink>
            {
                new Drink("Mojito", new List<string>{ "Rum", "Mint", "Sugar", "Lime", "Soda" }),
                new Drink("Margarita", new List<string>{ "Tequila", "Triple Sec", "Lime Juice", "Salt" }),
                new Drink("Old Fashioned", new List<string>{ "Whiskey", "Sugar", "Bitters", "Orange Peel" }),
                new Drink("Whiskey on the Rocks", new List<string>{ "Whiskey", "Ice" }),
                new Drink("Whiskey Neat", new List<string>{ "Whiskey" }),
                new Drink("Gin and Tonic", new List<string>{ "Gin", "Tonic Water", "Lime" }),
                new Drink("Pina Colada", new List<string>{ "Rum", "Coconut Cream", "Pineapple Juice" }),
                new Drink("Peach Margarita", new List<string>{ "Tequila", "Peach Schnapps", "Lime Juice", "Salt" }),
            };

            // Pick a drink
            Terminal.WriteLine("Available drinks to mix:");
            foreach (var d in recipes)
                Console.WriteLine(d.Name);

            Terminal.WriteLine("\nType the name of the drink you want to mix (not case sensitive):");

            drink = null; // use class field
            while (drink == null)
            {
                Console.Write("> ");
                var input = Console.ReadLine()?.Trim();
                drink = recipes.FirstOrDefault(d => d.Name.Equals(input, StringComparison.OrdinalIgnoreCase));

                if (drink == null)
                    Console.WriteLine("❌ That drink isn’t available! Try again.");
            }

            Console.WriteLine("Available ingredients:");

            var allIngredients = new HashSet<string>(
                recipes.SelectMany(r => r.Ingredients).OrderBy(x => x),
                StringComparer.OrdinalIgnoreCase
            );

            foreach (var ing in allIngredients)
                Console.WriteLine($"- {ing}");

            Console.WriteLine("\nType an ingredient, then hit enter. Type 'done' when finished adding ingredients, and hit enter (not case sensitive):");

            var playerMix = new List<string>();
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine()?.Trim();

                if (string.Equals(input, "done", StringComparison.OrdinalIgnoreCase))
                    break;

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (!allIngredients.Contains(input))
                {
                    Console.WriteLine("❌ That ingredient isn’t available!");
                    continue;
                }

                playerMix.Add(input);
            }

            // Scoring - New Friendlier System
            int correct = playerMix.Intersect(drink.Ingredients, StringComparer.OrdinalIgnoreCase).Count();
            int missing = drink.Ingredients.Except(playerMix, StringComparer.OrdinalIgnoreCase).Count();
            int extras = playerMix.Except(drink.Ingredients, StringComparer.OrdinalIgnoreCase).Count();

            Console.WriteLine($"\nYou made a {drink.Name} with: {string.Join(", ", playerMix)}");
            Console.WriteLine($"Correct ingredients: {correct}");
            Console.WriteLine($"Missing ingredients: {missing}");
            Console.WriteLine($"Extra ingredients: {extras}");
            Terminal.WriteLine("\nMissing ingredients: " + (missing > 0 ? string.Join(", ", drink.Ingredients.Except(playerMix, StringComparer.OrdinalIgnoreCase)) : "None"));

            // Final score calc
            int totalExpected = drink.Ingredients.Count;
            score = (int)(((double)correct / totalExpected) * 100);
            score -= extras * 5;
            score = Math.Clamp(score, 0, 100);

            if (missing == 0 && extras == 0)
                score = 100;

            Console.WriteLine($"\n⭐ Final score: {score}/100 ⭐");

            if (score == 100)
                Console.WriteLine("Perfect! Your customer is thrilled!");
            else if (score >= 60)
                Console.WriteLine("Pretty good! The customer enjoys it.");
            else
                Console.WriteLine("Yikes... they send it back.");

            Terminal.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Terminal.Clear();
        }
    }
}
