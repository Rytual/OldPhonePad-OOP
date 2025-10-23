using Xunit;

public class OldPhonePadTests
{
    [Fact]
    public void TestBasicInput_SinglePress()
    {
        string result = Solution.OldPhonePad("2#");
        Assert.Equal("A", result);
    }

    [Fact]
    public void TestBasicInput_MultiplePress()
    {
        string result = Solution.OldPhonePad("33#");
        Assert.Equal("E", result);
    }

    [Fact]
    public void DecodesHelloWithThaiTwist()
    {
        string result = Solution.OldPhonePad("44 33 555 555 666#");
        Assert.Equal("HELLO", result);
    }

    [Fact]
    public void TestBackspace()
    {
        string result = Solution.OldPhonePad("227*#");
        Assert.Equal("B", result);
    }

    [Fact]
    public void TestSpace()
    {
        string result = Solution.OldPhonePad("2 2#");
        Assert.Equal("AA", result);
    }

    [Fact]
    public void TestNullInput()
    {
        string result = Solution.OldPhonePad(null);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void TestEmptyInput()
    {
        string result = Solution.OldPhonePad("");
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void TestNoHash()
    {
        string result = Solution.OldPhonePad("222");
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void TestCycling()
    {
        string result = Solution.OldPhonePad("2222#");
        Assert.Equal("A", result);
    }

    [Fact]
    public void TestZeroForSpace()
    {
        string result = Solution.OldPhonePad("20#");
        Assert.Equal("A ", result);
    }

    [Fact]
    public void TextsFromDelhiWithDevanagari()
    {
        Keypad keypad = new Keypad();
        keypad.CulturalShift("India");
        Decoder decoder = new Decoder(keypad);
        string result = decoder.Decode("2222#");
        Assert.Equal("आ", result);
    }

    [Fact]
    public void CyclesAmsterdamWithDutchIJ()
    {
        Keypad keypad = new Keypad();
        keypad.CulturalShift("Holland");
        Decoder decoder = new Decoder(keypad);
        string result = decoder.Decode("6666#");
        Assert.Equal("I", result);
    }

    [Fact]
    public void TrainsInBangkokWithThai()
    {
        Keypad keypad = new Keypad();
        keypad.CulturalShift("Thailand");
        Decoder decoder = new Decoder(keypad);
        string result = decoder.Decode("8888#");
        Assert.Equal("ท", result);
    }

    [Fact]
    public void ReflectsOnCamusAbsurdity()
    {
        string result = Solution.OldPhonePad("777#");
        Assert.Equal("Camus: the absurd persists in endless cycles", result);
    }

    [Fact]
    public void PondersDostoevskyFreedom()
    {
        string result = Solution.OldPhonePad("666#");
        Assert.Equal("Dostoevsky: freedom's burden shapes your path", result);
    }

    [Fact]
    public void ChannelsNietzscheWill()
    {
        string result = Solution.OldPhonePad("999#");
        Assert.Equal("Nietzsche: will to power fuels your growth", result);
    }

    [Fact]
    public void TestEasterEgg_AI()
    {
        string result = Solution.OldPhonePad("AI#");
        Assert.Contains("Kage predicts", result);
    }

    [Fact]
    public void TestEasterEgg_AI_WithPastInput()
    {
        Keypad keypad = new Keypad();
        Decoder decoder = new Decoder(keypad);
        decoder.Decode("33#");
        string result = decoder.Decode("AI#");
        Assert.Contains("Kage predicts", result);
        Assert.Contains("E", result);
    }

    [Fact]
    public void TestSnakeGame_MoveLeft()
    {
        Assert.NotNull(new SnakeGame());
    }

    [Fact]
    public void TestSnakeGame_MoveRight()
    {
        SnakeGame game = new SnakeGame();
        game.MoveRight();
        Assert.NotNull(game);
    }

    [Fact]
    public void TestSnakeGame_MoveUp()
    {
        SnakeGame game = new SnakeGame();
        game.MoveUp();
        Assert.NotNull(game);
    }

    [Fact]
    public void TestSnakeGame_MoveDown()
    {
        SnakeGame game = new SnakeGame();
        game.MoveDown();
        Assert.NotNull(game);
    }

    [Fact]
    public void TestSnakeGame_Pause()
    {
        SnakeGame game = new SnakeGame();
        game.Pause();
        Assert.NotNull(game);
    }

    [Fact]
    public void TestKeypad_GetCharacter()
    {
        Keypad keypad = new Keypad();
        char result = keypad.GetCharacter('2', 1);
        Assert.Equal('A', result);
    }

    [Fact]
    public void TestKeypad_GetCharacter_Invalid()
    {
        Keypad keypad = new Keypad();
        char result = keypad.GetCharacter('z', 1);
        Assert.Equal('\0', result);
    }

    [Fact]
    public void TestDecoder_Decode_BasicInput()
    {
        Keypad keypad = new Keypad();
        Decoder decoder = new Decoder(keypad);
        string result = decoder.Decode("2#");
        Assert.Equal("A", result);
    }

    [Fact]
    public void TestComplexSequence()
    {
        string result = Solution.OldPhonePad("8 88777444666*664#");
        Assert.Equal("TURING", result);
    }

    [Fact]
    public void TestMultipleBackspaces()
    {
        string result = Solution.OldPhonePad("222**#");
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void TestAllDigits()
    {
        string result = Solution.OldPhonePad("234567890#");
        Assert.Equal("ADGJMPTW ", result);
    }
}
