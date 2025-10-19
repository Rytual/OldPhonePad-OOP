# OldPhonePad-OOP: The Object-Oriented Approach

```
┌─────────────────────────────────────┐
│  When Everything Became an Object  │
│                                     │
│  ┌───────┐    uses    ┌─────────┐  │
│  │Decoder├────────────►│ Keypad  │  │
│  └───┬───┘            └─────────┘  │
│      │ decodes                     │
│      ▼                             │
│  "44 33 555 555 666#"              │
│      │                             │
│      ▼                             │
│    "HELLO"                         │
└─────────────────────────────────────┘
```

[![.NET Build](https://github.com/ironsoftware/OldPhonePad-OOP/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ironsoftware/OldPhonePad-OOP/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

> *Remember when the Gang of Four told us everything should be an object? We took it seriously. Maybe too seriously. But hey, at least now our keypad has proper encapsulation.*

## The Philosophy: Separation of Concerns

This implementation takes a disciplined object-oriented approach to the old phone keypad problem. Instead of cramming everything into one function, we've modeled the problem domain with distinct classes that each have a single responsibility:

- **Keypad**: Represents the physical keypad with its key mappings
- **Decoder**: Handles the logic of translating key sequences into text
- **OldPhonePad**: Provides a clean static API for consumers

It's like we're building a digital twin of that Nokia 3310 you dropped down the stairs (twice) and it still worked.

## Class Architecture

```
┌──────────────────────────────────────────────────────────┐
│                     OldPhonePad                          │
│                   (Static Facade)                        │
│  ┌────────────────────────────────────────────────────┐  │
│  │ + OldPhonePad(string input): string                │  │
│  │ + OldPhonePad(string input, Keypad keypad): string │  │
│  └────────────────────────────────────────────────────┘  │
└─────────────────────┬────────────────────────────────────┘
                      │ uses
                      ▼
         ┌────────────────────────┐
         │       Decoder          │
         ├────────────────────────┤
         │ - keypad: Keypad       │
         ├────────────────────────┤
         │ + Decode(input): str   │
         └──────────┬─────────────┘
                    │ uses
                    ▼
         ┌────────────────────────────────────┐
         │           Keypad                   │
         ├────────────────────────────────────┤
         │ - keyMappings: Dictionary          │
         ├────────────────────────────────────┤
         │ + GetCharacter(key, count): char?  │
         │ + GetAvailableCharacters(key): str │
         │ + GetMaxPressCount(key): int       │
         │ + IsValidKey(key): bool            │
         └────────────────────────────────────┘
```

## Key Features

- **Clean Separation**: Each class has a single, well-defined responsibility
- **Testability**: Easy to unit test each component independently
- **Extensibility**: Want a different keypad layout? Just extend Keypad
- **Dependency Injection**: Decoder accepts a Keypad instance, following SOLID principles
- **Null Safety**: Uses nullable types appropriately with C# 8+ nullable reference types
- **Full Documentation**: Every public method has XML documentation

## Installation

```bash
git clone https://github.com/ironsoftware/OldPhonePad-OOP.git
cd OldPhonePad-OOP
dotnet build
dotnet test
```

## Usage

### Basic Usage

```csharp
using OldPhonePad.OOP;

// Simple decoding
string result = OldPhonePad.OldPhonePad("33#");
Console.WriteLine(result); // Output: E

// More complex message
result = OldPhonePad.OldPhonePad("4433555 555666#");
Console.WriteLine(result); // Output: HELLO
```

### Using Individual Components

```csharp
using OldPhonePad.OOP;

// Direct keypad usage
var keypad = new Keypad();
char? letter = keypad.GetCharacter('2', 3); // Returns 'C'
string available = keypad.GetAvailableCharacters('7'); // Returns "PQRS"
int maxPresses = keypad.GetMaxPressCount('9'); // Returns 4

// Using the decoder directly
var decoder = new Decoder(keypad);
string message = decoder.Decode("227*#"); // Returns "B"
```

### Custom Keypad Configuration

```csharp
// You can extend Keypad for custom layouts
var customKeypad = new Keypad();
var decoder = new Decoder(customKeypad);
string result = decoder.Decode("2#");
```

## The Keypad Class

The `Keypad` class encapsulates all knowledge about key mappings:

```csharp
public class Keypad
{
    // Get a character by key and press count
    char? GetCharacter(char key, int pressCount);

    // Get all available characters on a key
    string GetAvailableCharacters(char key);

    // Get maximum number of presses for a key
    int GetMaxPressCount(char key);

    // Validate if a key is valid
    bool IsValidKey(char key);
}
```

**Design Rationale**: By isolating key mappings in their own class, we can easily:
- Test the mapping logic independently
- Support alternative keypad layouts (international, T9 variations)
- Validate key presses without duplicating logic

## The Decoder Class

The `Decoder` class handles the translation logic:

```csharp
public class Decoder
{
    public Decoder(Keypad keypad);
    public string Decode(string input);
}
```

**Design Rationale**: The decoder depends on an abstraction (Keypad) rather than concrete implementations. This follows the Dependency Inversion Principle and makes the code highly testable and extensible.

## Running the Tests

We have solid test coverage across two test classes:

```bash
# Run all tests
dotnet test

# Run with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run with coverage (requires coverlet)
dotnet test /p:CollectCoverage=true
```

### Test Structure

- **KeypadTests.cs**: 50+ tests validating the Keypad class in isolation
- **OldPhonePadTests.cs**: 40+ integration tests for end-to-end scenarios

## Advantages of This Approach

**Single Responsibility Principle**
Each class has one reason to change:
- Keypad changes only if key mappings change
- Decoder changes only if decoding logic changes
- OldPhonePad changes only if the public API needs to change

**Testability**
You can test each component in isolation:
```csharp
[Fact]
public void Keypad_GetCharacter_ValidInput_ReturnsCorrectChar()
{
    var keypad = new Keypad();
    var result = keypad.GetCharacter('2', 2);
    Assert.Equal('B', result.Value);
}
```

**Extensibility**
Need a different keypad? Just inherit:
```csharp
public class InternationalKeypad : Keypad
{
    public InternationalKeypad() : base()
    {
        // Override mappings for international characters
    }
}
```

**Maintainability**
Clear separation makes the code easy to understand and modify. Future developers (or future you) will thank you.

## Disadvantages (Because We're Honest)

**More Files**
Three classes instead of one function means more files to navigate. Your solution explorer is getting crowded.

**Slight Performance Overhead**
Object instantiation and method calls add microseconds. For a kata exercise this is negligible. For encoding War and Peace via T9, maybe think twice.

**Potential Over-Engineering**
For a simple kata problem this might be overkill. But for production code that needs to scale and evolve, it's just right.

## When to Use This Approach

**Good for:**
- Production codebases
- Code that needs long-term maintenance
- Supporting variations like different keypad layouts
- When testability matters
- Team projects where clear interfaces help

**Overkill for:**
- Quick prototypes
- One-off scripts
- When performance is absolutely critical
- Solo 50-line programs

## Nostalgic Tech Corner

Remember when design patterns were the hottest thing in software development? We had:
- Factories making objects
- Singletons ensuring loneliness
- Decorators wrapping things like Christmas presents
- Observers watching everything like your paranoid neighbor

This implementation is a love letter to those days when we read "Design Patterns" cover to cover and tried to use every pattern in every project. Sometimes we went too far. Sometimes we didn't go far enough. But we learned and that's what matters.

The beauty of OOP isn't just about objects - it's about organizing complexity in a way that mirrors how we think about the real world. A keypad is a thing. A decoder is a thing. They work together but they're separate concerns. That's not over-engineering, that's just good engineering.

## Related Repositories

This is part of a collection exploring different approaches to the same problem:

- [OldPhonePad-Simple](https://github.com/ironsoftware/OldPhonePad-Simple) - The straightforward approach
- [OldPhonePad-Functional](https://github.com/ironsoftware/OldPhonePad-Functional) - Pure functional approach
- [OldPhonePad-StateMachine](https://github.com/ironsoftware/OldPhonePad-StateMachine) - Finite state machine implementation
- **OldPhonePad-OOP** - You are here! (Object-oriented design)
- [OldPhonePad-RegexStack](https://github.com/ironsoftware/OldPhonePad-RegexStack) - Regex preprocessing with Stack

Each repository demonstrates different programming paradigms and trade-offs. Good for:
- Learning different architectural approaches
- Comparing performance characteristics
- Understanding when to use which pattern
- Preparing for technical interviews
- Showing off your versatility to colleagues

## Contributing

Found a way to make the OOP design even cleaner? Have a suggestion for better abstraction? PRs welcome!

Make sure:
- All tests pass (`dotnet test`)
- Code follows C# conventions
- XML documentation is complete
- You've added tests for new functionality

## License

MIT License - See [LICENSE](LICENSE) file for details.

---

*Built with SOLID principles, design patterns and a healthy dose of nostalgia for the days when we thought inheritance hierarchies 10 levels deep were a good idea. (They weren't.)*

**Remember**: Objects are great but sometimes a function is just a function and that's okay too. Choose the right tool for the job, not the fanciest one.
