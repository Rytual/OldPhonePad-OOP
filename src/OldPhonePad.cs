namespace OldPhonePad.OOP
{
    /// <summary>
    /// Provides a static entry point for decoding old-style mobile phone keypad input.
    /// This class uses an object-oriented design with separate Keypad and Decoder classes
    /// to maintain clean separation of concerns.
    /// </summary>
    public static class OldPhonePad
    {
        private static readonly Keypad defaultKeypad = new Keypad();
        private static readonly Decoder defaultDecoder = new Decoder(defaultKeypad);

        /// <summary>
        /// Decodes input from an old mobile phone keypad into text.
        /// </summary>
        /// <param name="input">
        /// The input string representing key presses. Should contain:
        /// - Digits 0-9 (representing key presses)
        /// - Spaces (pauses between different keys)
        /// - Asterisks (*) for backspace
        /// - Must end with # to send the message
        /// </param>
        /// <returns>The decoded text string.</returns>
        /// <example>
        /// <code>
        /// string result = OldPhonePad.OldPhonePad("33#"); // Returns "E"
        /// string result = OldPhonePad.OldPhonePad("227*#"); // Returns "B"
        /// string result = OldPhonePad.OldPhonePad("4433555 555666#"); // Returns "HELLO"
        /// </code>
        /// </example>
        public static string OldPhonePad(string input)
        {
            return defaultDecoder.Decode(input);
        }

        /// <summary>
        /// Decodes input using a custom keypad and decoder configuration.
        /// Useful for testing or using alternative key mappings.
        /// </summary>
        /// <param name="input">The input string to decode.</param>
        /// <param name="keypad">A custom Keypad instance.</param>
        /// <returns>The decoded text string.</returns>
        public static string OldPhonePad(string input, Keypad keypad)
        {
            var decoder = new Decoder(keypad);
            return decoder.Decode(input);
        }
    }
}
