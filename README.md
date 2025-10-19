# OldPhonePad-OOP: Object-Oriented Approach

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

## The Challenge

This tackles the old phone keypad problem using proper object-oriented design. Instead of jamming everything into one function, I split it into separate classes - Keypad for the key mappings, Decoder for the translation logic, and OldPhonePad as a clean API wrapper.

The keypad layout:

```
1: &'(        2: abc       3: def
4: ghi        5: jkl       6: mno
7: pqrs       8: tuv       9: wxyz
*: backspace  0: space     #: send
```

### Examples

- `33#` → `E`
- `227*#` → `B` (type CA, backspace)
- `4433555 555666#` → `HELLO`
- `8 88777444666*664#` → `TURING`

## My Approach

I went with an OOP design that separates concerns:

**Classes:**
- **Keypad**: Knows about key mappings and validates inputs
- **Decoder**: Handles the translation logic, depends on Keypad
- **OldPhonePad**: Static facade that ties it all together

**What works well:**
- Each class has a single responsibility
- Easy to test components separately
- Could swap out Keypad for different layouts
- Follows dependency injection patterns

**What's a bit much:**
- Three files instead of one
- More boilerplate than needed for a simple problem
- Object instantiation overhead (minor)

Works okay for production code that needs to scale. Might be overkill for a quick script. The other implementations are simpler if you just need something that works.

## Getting Started

### Prerequisites

- .NET 8.0 or later

### Running the Code

```bash
# Clone the repository
git clone https://github.com/yourusername/OldPhonePad-OOP.git
cd OldPhonePad-OOP

# Build and test
dotnet build
dotnet test

# For verbose test output
dotnet test --logger "console;verbosity=detailed"
```

### Using the Decoder

```csharp
using OldPhonePad.OOP;

// Simple usage
string result = OldPhonePad.OldPhonePad("33#");
Console.WriteLine(result); // Output: E

// Using individual components
var keypad = new Keypad();
char? letter = keypad.GetCharacter('2', 3); // Returns 'C'

var decoder = new Decoder(keypad);
string message = decoder.Decode("227*#"); // Returns "B"
```

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

## Test Coverage

The project has 40+ tests covering:
- All provided examples
- Edge cases (empty input, backspaces, spaces)
- Single and multiple key presses
- Backspace operations
- Special keys (symbols on key 1, space on key 0)
- Complex scenarios
- Error handling (null input, missing send character)
- OOP-specific tests (custom keypad, component isolation)

## Implementation Details

**Keypad Class**: Encapsulates all knowledge about key mappings. Validates keys, returns characters based on press count, handles bounds checking.

**Decoder Class**: Takes a Keypad instance via dependency injection. Processes input sequences, handles backspaces and spaces, delegates character lookup to Keypad.

**OldPhonePad Class**: Static facade that creates default instances and provides a simple API. Also supports custom keypad injection for testing.

## Project Structure

```
OldPhonePad-OOP/
├── src/
│   ├── Keypad.cs                        # Key mapping logic
│   ├── Decoder.cs                       # Decoding logic
│   ├── OldPhonePad.cs                   # Static API
│   └── OldPhonePad.OOP.csproj
├── tests/
│   ├── KeypadTests.cs                   # Keypad unit tests
│   ├── OldPhonePadTests.cs              # Integration tests
│   └── OldPhonePad.OOP.Tests.csproj
├── .github/
│   └── workflows/
│       └── dotnet.yml                    # CI/CD
├── .gitignore
├── LICENSE
└── README.md
```

## Other Implementations

Check out the other approaches:
- **OldPhonePad-DictionaryState**: Simple dictionary with manual state tracking
- **OldPhonePad-FSM**: Finite state machine with formal state transitions
- **OldPhonePad-Grouping**: Groups consecutive digits before processing
- **OldPhonePad-RegexStack**: Regex preprocessing with stack-based evaluation

Each has different tradeoffs.

## Fun Note

The OOP approach took more setup but made testing way easier. Being able to test the Keypad logic separately from the Decoder logic was nice. At first I tried to make it even more abstract with interfaces, but that felt like overkill. Sometimes three classes is enough.

## License

MIT License - see LICENSE file for details.

---

*Built for the Iron Software coding challenge - October 2025*
