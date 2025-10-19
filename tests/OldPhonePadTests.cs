using System;
using Xunit;

namespace OldPhonePad.OOP.Tests
{
    /// <summary>
    /// Comprehensive test suite for the OldPhonePad decoder.
    /// Tests cover basic functionality, edge cases, error handling, and complex scenarios.
    /// </summary>
    public class OldPhonePadTests
    {
        [Fact]
        public void OldPhonePad_SingleKeyPress_ReturnsFirstCharacter()
        {
            var result = OldPhonePad.OldPhonePad("2#");
            Assert.Equal("A", result);
        }

        [Fact]
        public void OldPhonePad_DoubleKeyPress_ReturnsSecondCharacter()
        {
            var result = OldPhonePad.OldPhonePad("22#");
            Assert.Equal("B", result);
        }

        [Fact]
        public void OldPhonePad_TripleKeyPress_ReturnsThirdCharacter()
        {
            var result = OldPhonePad.OldPhonePad("222#");
            Assert.Equal("C", result);
        }

        [Fact]
        public void OldPhonePad_Key7FourPresses_ReturnsS()
        {
            var result = OldPhonePad.OldPhonePad("7777#");
            Assert.Equal("S", result);
        }

        [Fact]
        public void OldPhonePad_Key9FourPresses_ReturnsZ()
        {
            var result = OldPhonePad.OldPhonePad("9999#");
            Assert.Equal("Z", result);
        }

        [Fact]
        public void OldPhonePad_SpaceBetweenKeys_DecodesMultipleCharacters()
        {
            var result = OldPhonePad.OldPhonePad("2 2#");
            Assert.Equal("AA", result);
        }

        [Fact]
        public void OldPhonePad_HelloWorld_ReturnsCorrectText()
        {
            var result = OldPhonePad.OldPhonePad("4433555 555666#");
            Assert.Equal("HELLO", result);
        }

        [Fact]
        public void OldPhonePad_BackspaceRemovesLastCharacter()
        {
            var result = OldPhonePad.OldPhonePad("227*#");
            Assert.Equal("B", result);
        }

        [Fact]
        public void OldPhonePad_MultipleBackspaces_RemovesMultipleCharacters()
        {
            var result = OldPhonePad.OldPhonePad("2223**#");
            Assert.Equal("A", result);
        }

        [Fact]
        public void OldPhonePad_BackspaceOnEmptyString_ReturnsEmpty()
        {
            var result = OldPhonePad.OldPhonePad("*#");
            Assert.Equal("", result);
        }

        [Fact]
        public void OldPhonePad_BackspaceMoreThanAvailable_ReturnsEmpty()
        {
            var result = OldPhonePad.OldPhonePad("2***#");
            Assert.Equal("", result);
        }

        [Fact]
        public void OldPhonePad_OnlyHashSign_ReturnsEmpty()
        {
            var result = OldPhonePad.OldPhonePad("#");
            Assert.Equal("", result);
        }

        [Fact]
        public void OldPhonePad_OnlySpaces_ReturnsEmpty()
        {
            var result = OldPhonePad.OldPhonePad("   #");
            Assert.Equal("", result);
        }

        [Fact]
        public void OldPhonePad_Key0_ReturnsSpace()
        {
            var result = OldPhonePad.OldPhonePad("0#");
            Assert.Equal(" ", result);
        }

        [Fact]
        public void OldPhonePad_Key1FirstPress_ReturnsAmpersand()
        {
            var result = OldPhonePad.OldPhonePad("1#");
            Assert.Equal("&", result);
        }

        [Fact]
        public void OldPhonePad_Key1SecondPress_ReturnsApostrophe()
        {
            var result = OldPhonePad.OldPhonePad("11#");
            Assert.Equal("'", result);
        }

        [Fact]
        public void OldPhonePad_Key1ThirdPress_ReturnsOpenParen()
        {
            var result = OldPhonePad.OldPhonePad("111#");
            Assert.Equal("(", result);
        }

        [Fact]
        public void OldPhonePad_WordWithSpaces_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("4433555 555666 0 9966 6660 777 555 3#");
            Assert.Equal("HELLO WORLD", result);
        }

        [Fact]
        public void OldPhonePad_ComplexSentence_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("44 444#");
            Assert.Equal("HI", result);
        }

        [Fact]
        public void OldPhonePad_AllLettersAToZ_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("2 22 222 3 33 333 4 44 444 5 55 555 6 66 666 7 77 777 7777 8 88 888 9 99 999 9999#");
            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVWXYZ", result);
        }

        [Fact]
        public void OldPhonePad_ExcessivePressesWrapsAround_Key2()
        {
            var result = OldPhonePad.OldPhonePad("222#");
            Assert.Equal("C", result);
        }

        [Fact]
        public void OldPhonePad_MixedWithBackspace_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("2 22 222 2222*#");
            Assert.Equal("ABC", result);
        }

        [Fact]
        public void OldPhonePad_BackspaceInMiddleOfSequence_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("222 3*33#");
            Assert.Equal("CE", result);
        }

        [Theory]
        [InlineData(null)]
        public void OldPhonePad_NullInput_ThrowsArgumentNullException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => OldPhonePad.OldPhonePad(input));
        }

        [Theory]
        [InlineData("")]
        [InlineData("222")]
        [InlineData("2 3 4")]
        public void OldPhonePad_MissingHashSign_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => OldPhonePad.OldPhonePad(input));
        }

        [Fact]
        public void OldPhonePad_LongMessage_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("8 44 444 7777 0 444 7777 0 2 0 8 33 7777 8#");
            Assert.Equal("THIS IS A TEST", result);
        }

        [Fact]
        public void OldPhonePad_RepeatedCharacters_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("2 2 2#");
            Assert.Equal("AAA", result);
        }

        [Fact]
        public void OldPhonePad_Key7AllCharacters_ReturnsAllFour()
        {
            var result = OldPhonePad.OldPhonePad("7 77 777 7777#");
            Assert.Equal("PQRS", result);
        }

        [Fact]
        public void OldPhonePad_Key9AllCharacters_ReturnsAllFour()
        {
            var result = OldPhonePad.OldPhonePad("9 99 999 9999#");
            Assert.Equal("WXYZ", result);
        }

        [Fact]
        public void OldPhonePad_AlternatingKeys_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("23#");
            Assert.Equal("AD", result);
        }

        [Fact]
        public void OldPhonePad_MultipleSpacesBetweenKeys_IgnoresExtraSpaces()
        {
            var result = OldPhonePad.OldPhonePad("2  2#");
            Assert.Equal("AA", result);
        }

        [Fact]
        public void OldPhonePad_SpaceAtBeginning_IgnoresLeadingSpace()
        {
            var result = OldPhonePad.OldPhonePad(" 2#");
            Assert.Equal("A", result);
        }

        [Fact]
        public void OldPhonePad_BackspaceAfterSpace_RemovesLastCharacter()
        {
            var result = OldPhonePad.OldPhonePad("2 3*#");
            Assert.Equal("A", result);
        }

        [Fact]
        public void OldPhonePad_ComplexBackspaceScenario_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("44 33 555 555 666***43 555 555 666#");
            Assert.Equal("HELLO", result);
        }

        [Fact]
        public void OldPhonePad_NumberSequence_Key1Characters()
        {
            var result = OldPhonePad.OldPhonePad("1 11 111#");
            Assert.Equal("&'(", result);
        }

        [Fact]
        public void OldPhonePad_MixedNumbersAndLetters_DecodesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("2 0 3#");
            Assert.Equal("A D", result);
        }

        [Fact]
        public void OldPhonePad_SingleSpace_ReturnsSpace()
        {
            var result = OldPhonePad.OldPhonePad("0 0 0#");
            Assert.Equal("   ", result);
        }

        [Fact]
        public void OldPhonePad_EmptyBetweenBackspaces_HandlesCorrectly()
        {
            var result = OldPhonePad.OldPhonePad("2*3#");
            Assert.Equal("D", result);
        }

        [Fact]
        public void Decoder_WithCustomKeypad_UsesCustomMapping()
        {
            var customKeypad = new Keypad();
            var result = OldPhonePad.OldPhonePad("2#", customKeypad);
            Assert.Equal("A", result);
        }

        [Fact]
        public void Decoder_NullKeypad_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Decoder(null));
        }
    }
}
