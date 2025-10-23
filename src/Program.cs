using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("OldPhonePad T9 Decoder");
        Console.WriteLine();

        // Texting across cultures shaped this - from Delhi's markets to Bangkok's training gyms
        Console.WriteLine("Enter T9 input or type 'snake' for the game, 'quit' to exit:");
        Console.WriteLine();

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.ToLower() == "quit")
            {
                Console.WriteLine("\nThanks for texting across cultures! 🌏");
                break;
            }

            if (input.ToLower() == "snake")
            {
                // Launch Snake game
                SnakeGame game = new SnakeGame();
                game.Run();
                Console.WriteLine("\nGame over! Back to T9 decoding...\n");
            }
            else if (input.EndsWith("#"))
            {
                // Decode T9 input
                string result = Solution.OldPhonePad(input);
                Console.WriteLine($"  → {result}");
            }
            else
            {
                Console.WriteLine("  (Don't forget to end with #)");
            }
        }
    }
}
