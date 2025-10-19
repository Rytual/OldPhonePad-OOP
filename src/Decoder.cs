using System;
using System.Text;

namespace OldPhonePad.OOP
{
    /// <summary>
    /// Decodes input sequences from an old-style mobile phone keypad into text.
    /// Uses a Keypad instance to translate key presses into characters.
    /// </summary>
    public class Decoder
    {
        private readonly Keypad keypad;

        /// <summary>
        /// Initializes a new instance of the Decoder class with a specified keypad.
        /// </summary>
        /// <param name="keypad">The keypad to use for character mapping.</param>
        /// <exception cref="ArgumentNullException">Thrown when keypad is null.</exception>
        public Decoder(Keypad keypad)
        {
            this.keypad = keypad ?? throw new ArgumentNullException(nameof(keypad));
        }

        /// <summary>
        /// Decodes an input string representing key presses into the corresponding text.
        /// </summary>
        /// <param name="input">
        /// The input string containing digits (0-9), spaces (pause), asterisks (backspace),
        /// and ending with a hash (#) to send.
        /// </param>
        /// <returns>The decoded text string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        /// <exception cref="ArgumentException">Thrown when input doesn't end with '#'.</exception>
        public string Decode(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (string.IsNullOrEmpty(input) || input[input.Length - 1] != '#')
            {
                throw new ArgumentException("Input must end with '#' to send the message.", nameof(input));
            }

            var result = new StringBuilder();
            int i = 0;

            // Remove the trailing '#' for processing
            string sequence = input.Substring(0, input.Length - 1);

            while (i < sequence.Length)
            {
                char currentChar = sequence[i];

                // Handle backspace
                if (currentChar == '*')
                {
                    if (result.Length > 0)
                    {
                        result.Length--;
                    }
                    i++;
                    continue;
                }

                // Handle pause (space between different keys)
                if (currentChar == ' ')
                {
                    i++;
                    continue;
                }

                // Handle digit keys
                if (keypad.IsValidKey(currentChar))
                {
                    int pressCount = CountConsecutivePresses(sequence, i, currentChar);
                    char? character = keypad.GetCharacter(currentChar, pressCount);

                    if (character.HasValue)
                    {
                        result.Append(character.Value);
                    }

                    i += pressCount;
                }
                else
                {
                    // Skip invalid characters
                    i++;
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Counts how many times a specific key is pressed consecutively in the sequence.
        /// Had to think through the maxPresses limit here
        /// </summary>
        /// <param name="sequence">The full input sequence.</param>
        /// <param name="startIndex">The starting position to count from.</param>
        /// <param name="key">The key to count.</param>
        /// <returns>The number of consecutive presses.</returns>
        private int CountConsecutivePresses(string sequence, int startIndex, char key)
        {
            int count = 0;
            int maxPresses = keypad.GetMaxPressCount(key);

            for (int i = startIndex; i < sequence.Length && count < maxPresses; i++)
            {
                if (sequence[i] == key)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}
