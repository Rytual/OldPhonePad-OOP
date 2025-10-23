using System;
using System.Collections.Generic;
using System.Text;

public class Decoder
{
    private readonly Keypad keypad;
    private readonly Dictionary<string, string> existentialThoughts;
    private readonly List<string> pastInputs;

    public Decoder(Keypad keypad)
    {
        this.keypad = keypad;
        this.pastInputs = new List<string>();

        this.existentialThoughts = new Dictionary<string, string>
        {
            { "777#", "Camus: the absurd persists in endless cycles" },
            { "666#", "Dostoevsky: freedom's burden shapes your path" },
            { "999#", "Nietzsche: will to power fuels your growth" }
        };
    }

    public string Decode(string input)
    {
        if (string.IsNullOrEmpty(input) || !input.Contains('#'))
        {
            return string.Empty;
        }

        // Easter egg
        if (input == "AI#")
        {
            if (pastInputs.Count > 0)
            {
                return $"Kage predicts: the last input decoded was {pastInputs[^1]}";
            }
            return "Kage predicts: move";
        }

        // Check for existential thoughts
        if (existentialThoughts.TryGetValue(input, out string? thought))
        {
            pastInputs.Add(input);
            return thought;
        }

        StringBuilder result = new StringBuilder();
        char currentKey = '\0';
        int pressCount = 0;

        foreach (char c in input)
        {
            if (c == '#')
            {
                break;
            }
            else if (c == '*')
            {
                if (currentKey != '\0' && pressCount > 0)
                {
                    char decoded = keypad.GetCharacter(currentKey, pressCount);
                    if (decoded != '\0')
                    {
                        result.Append(decoded);
                    }
                    currentKey = '\0';
                    pressCount = 0;
                }

                if (result.Length > 0)
                {
                    result.Length--;
                }
            }
            else if (c == ' ')
            {
                if (currentKey != '\0' && pressCount > 0)
                {
                    char decoded = keypad.GetCharacter(currentKey, pressCount);
                    if (decoded != '\0')
                    {
                        result.Append(decoded);
                    }
                    currentKey = '\0';
                    pressCount = 0;
                }
            }
            else if (char.IsDigit(c))
            {
                if (c == currentKey)
                {
                    pressCount++;
                }
                else
                {
                    if (currentKey != '\0' && pressCount > 0)
                    {
                        char decoded = keypad.GetCharacter(currentKey, pressCount);
                        if (decoded != '\0')
                        {
                            result.Append(decoded);
                        }
                    }
                    currentKey = c;
                    pressCount = 1;
                }
            }
        }

        if (currentKey != '\0' && pressCount > 0)
        {
            char decoded = keypad.GetCharacter(currentKey, pressCount);
            if (decoded != '\0')
            {
                result.Append(decoded);
            }
        }

        string decodedResult = result.ToString();
        pastInputs.Add(decodedResult);
        return decodedResult;
    }
}
