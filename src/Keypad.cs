using System;
using System.Collections.Generic;

namespace OldPhonePad.OOP
{
    /// <summary>
    /// Represents a physical mobile phone keypad with traditional T9-style key mappings.
    /// Each numeric key (2-9) corresponds to a set of letters that can be typed by
    /// pressing the key multiple times in sequence.
    /// </summary>
    public class Keypad
    {
        private readonly Dictionary<char, string> keyMappings;

        /// <summary>
        /// Initializes a new instance of the Keypad class with standard T9 key mappings.
        /// </summary>
        public Keypad()
        {
            keyMappings = new Dictionary<char, string>
            {
                { '0', " " },
                { '1', "&'(" },
                { '2', "ABC" },
                { '3', "DEF" },
                { '4', "GHI" },
                { '5', "JKL" },
                { '6', "MNO" },
                { '7', "PQRS" },
                { '8', "TUV" },
                { '9', "WXYZ" }
            };
        }

        /// <summary>
        /// Gets the character associated with pressing a specific key a certain number of times.
        /// </summary>
        /// <param name="key">The numeric key pressed (0-9).</param>
        /// <param name="pressCount">The number of consecutive presses (1-based).</param>
        /// <returns>The character corresponding to the key and press count, or null if invalid.</returns>
        public char? GetCharacter(char key, int pressCount)
        {
            if (!keyMappings.ContainsKey(key))
            {
                return null;
            }

            string characters = keyMappings[key];

            if (pressCount < 1 || pressCount > characters.Length)
            {
                return null;
            }

            // Convert to 0-based index
            return characters[pressCount - 1];
        }

        /// <summary>
        /// Gets all characters available on a specific key.
        /// </summary>
        /// <param name="key">The numeric key (0-9).</param>
        /// <returns>A string containing all characters available on the key, or null if invalid.</returns>
        public string GetAvailableCharacters(char key)
        {
            return keyMappings.ContainsKey(key) ? keyMappings[key] : null;
        }

        /// <summary>
        /// Gets the maximum number of presses allowed for a specific key.
        /// </summary>
        /// <param name="key">The numeric key (0-9).</param>
        /// <returns>The maximum press count, or 0 if the key is invalid.</returns>
        public int GetMaxPressCount(char key)
        {
            return keyMappings.ContainsKey(key) ? keyMappings[key].Length : 0;
        }

        /// <summary>
        /// Checks if a given key is valid on this keypad.
        /// </summary>
        /// <param name="key">The key to validate.</param>
        /// <returns>True if the key is valid; otherwise, false.</returns>
        public bool IsValidKey(char key)
        {
            return keyMappings.ContainsKey(key);
        }
    }
}
