using System;
using System.Collections.Generic;

public class Keypad
{
    private readonly Dictionary<char, string> keyMappings; // Mapping a traveler's keypad

    public Keypad()
    {
        keyMappings = new Dictionary<char, string>
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" },
            { '0', " " },
            { '1', "&'(" }
        };
    }

    public char GetCharacter(char key, int presses)
    {
        if (keyMappings.TryGetValue(key, out string? characters))
        {
            int index = (presses - 1) % characters.Length;
            return char.ToUpper(characters[index]);
        }
        return '\0';
    }

    public void CulturalShift(string region)
    {
        if (region == "India")
        {
            keyMappings['2'] += "आइ";
        }
        else if (region == "Holland")
        {
            keyMappings['6'] += "ij";
        }
        else if (region == "Thailand")
        {
            keyMappings['8'] += "ทธ";
        }
    }
}
