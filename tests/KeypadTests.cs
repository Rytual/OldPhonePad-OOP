using System;
using Xunit;

namespace OldPhonePad.OOP.Tests
{
    /// <summary>
    /// Unit tests for the Keypad class.
    /// These tests verify the behavior of the physical keypad abstraction.
    /// </summary>
    public class KeypadTests
    {
        private readonly Keypad keypad;

        public KeypadTests()
        {
            keypad = new Keypad();
        }

        [Theory]
        [InlineData('2', 1, 'A')]
        [InlineData('2', 2, 'B')]
        [InlineData('2', 3, 'C')]
        [InlineData('3', 1, 'D')]
        [InlineData('3', 2, 'E')]
        [InlineData('3', 3, 'F')]
        [InlineData('4', 1, 'G')]
        [InlineData('4', 2, 'H')]
        [InlineData('4', 3, 'I')]
        [InlineData('5', 1, 'J')]
        [InlineData('5', 2, 'K')]
        [InlineData('5', 3, 'L')]
        [InlineData('6', 1, 'M')]
        [InlineData('6', 2, 'N')]
        [InlineData('6', 3, 'O')]
        [InlineData('7', 1, 'P')]
        [InlineData('7', 2, 'Q')]
        [InlineData('7', 3, 'R')]
        [InlineData('7', 4, 'S')]
        [InlineData('8', 1, 'T')]
        [InlineData('8', 2, 'U')]
        [InlineData('8', 3, 'V')]
        [InlineData('9', 1, 'W')]
        [InlineData('9', 2, 'X')]
        [InlineData('9', 3, 'Y')]
        [InlineData('9', 4, 'Z')]
        [InlineData('0', 1, ' ')]
        [InlineData('1', 1, '&')]
        [InlineData('1', 2, '\'')]
        [InlineData('1', 3, '(')]
        public void GetCharacter_ValidKeyAndPressCount_ReturnsCorrectCharacter(char key, int pressCount, char expected)
        {
            var result = keypad.GetCharacter(key, pressCount);

            Assert.True(result.HasValue);
            Assert.Equal(expected, result.Value);
        }

        [Theory]
        [InlineData('2', 0)]
        [InlineData('2', 4)]
        [InlineData('7', 5)]
        [InlineData('9', 5)]
        public void GetCharacter_InvalidPressCount_ReturnsNull(char key, int pressCount)
        {
            var result = keypad.GetCharacter(key, pressCount);

            Assert.False(result.HasValue);
        }

        [Theory]
        [InlineData('a')]
        [InlineData('Z')]
        [InlineData('*')]
        [InlineData('#')]
        [InlineData(' ')]
        public void GetCharacter_InvalidKey_ReturnsNull(char key)
        {
            var result = keypad.GetCharacter(key, 1);

            Assert.False(result.HasValue);
        }

        [Theory]
        [InlineData('0', " ")]
        [InlineData('1', "&'(")]
        [InlineData('2', "ABC")]
        [InlineData('3', "DEF")]
        [InlineData('4', "GHI")]
        [InlineData('5', "JKL")]
        [InlineData('6', "MNO")]
        [InlineData('7', "PQRS")]
        [InlineData('8', "TUV")]
        [InlineData('9', "WXYZ")]
        public void GetAvailableCharacters_ValidKey_ReturnsCorrectString(char key, string expected)
        {
            var result = keypad.GetAvailableCharacters(key);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('a')]
        [InlineData('*')]
        [InlineData('#')]
        public void GetAvailableCharacters_InvalidKey_ReturnsNull(char key)
        {
            var result = keypad.GetAvailableCharacters(key);

            Assert.Null(result);
        }

        [Theory]
        [InlineData('0', 1)]
        [InlineData('1', 3)]
        [InlineData('2', 3)]
        [InlineData('3', 3)]
        [InlineData('4', 3)]
        [InlineData('5', 3)]
        [InlineData('6', 3)]
        [InlineData('7', 4)]
        [InlineData('8', 3)]
        [InlineData('9', 4)]
        public void GetMaxPressCount_ValidKey_ReturnsCorrectCount(char key, int expected)
        {
            var result = keypad.GetMaxPressCount(key);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('a')]
        [InlineData('*')]
        [InlineData('#')]
        public void GetMaxPressCount_InvalidKey_ReturnsZero(char key)
        {
            var result = keypad.GetMaxPressCount(key);

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData('0', true)]
        [InlineData('1', true)]
        [InlineData('2', true)]
        [InlineData('3', true)]
        [InlineData('4', true)]
        [InlineData('5', true)]
        [InlineData('6', true)]
        [InlineData('7', true)]
        [InlineData('8', true)]
        [InlineData('9', true)]
        public void IsValidKey_NumericKeys_ReturnsTrue(char key, bool expected)
        {
            var result = keypad.IsValidKey(key);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData('*')]
        [InlineData('#')]
        [InlineData(' ')]
        [InlineData('a')]
        [InlineData('A')]
        public void IsValidKey_NonNumericKeys_ReturnsFalse(char key)
        {
            var result = keypad.IsValidKey(key);

            Assert.False(result);
        }
    }
}
