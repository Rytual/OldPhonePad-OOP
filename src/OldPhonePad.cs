using System;

public static class Solution
{
    public static string OldPhonePad(string input)
    {
        Keypad keypad = new Keypad();
        Decoder decoder = new Decoder(keypad);
        return decoder.Decode(input);
    }

    public static void PlaySnake(string input)
    {
        Keypad keypad = new Keypad();
        Decoder decoder = new Decoder(keypad);
        string direction = decoder.Decode(input);

        SnakeGame game = new SnakeGame();

        if (direction == "G")
        {
            game.MoveLeft();
        }
        else if (direction == "M")
        {
            game.MoveRight();
        }
        else if (input == "2#")
        {
            game.MoveUp();
        }
        else if (input == "8#")
        {
            game.MoveDown();
        }
        else if (input.Contains("*"))
        {
            game.Pause();
        }
    }
}
