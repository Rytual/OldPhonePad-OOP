# OldPhonePad: T9 Decoder with Cultural & Philosophical Dimensions

A sophisticated C# implementation of the classic T9 phone keypad decoder, enriched with cultural adaptations and existential philosophy.

## The Challenge

Implement `OldPhonePad(string input)` to decode old phone keypad inputs using T9 rules:
- Multiple presses cycle through letters (e.g., `2` → A, `22` → B, `222` → C)
- Space pauses for repeats on the same key
- Asterisk (`*`) backspaces
- Hash (`#`) ends input

**Examples:**
- `33#` → `E`
- `44433555555666#` → `HELLO`

## Architecture

The solution follows object-oriented principles with clear separation of concerns:

### Core Classes

**Keypad.cs**
- Manages key-to-character mappings
- Handles character cycling with modulo arithmetic
- Supports cultural shifts for regional adaptations

**Decoder.cs**
- Orchestrates the decoding logic
- Tracks state (current key, press count)
- Integrates existential philosophy responses
- Contains Easter egg functionality

**OldPhonePad.cs**
- Static entry point matching the challenge specification
- Additional `PlaySnake()` method for game integration

**SnakeGame.cs**
- Classic Snake game with T9 input controls
- ASCII-based Nokia-style UI
- Direction mapping: `4#` → Left, `6#` → Right, `2#` → Up, `8#` → Down

## Cultural Adaptations

The keypad supports regional character sets through the `CulturalShift()` method:

**India** - Devanagari script (आइ)
```csharp
keypad.CulturalShift("India");
```

**Holland** - Dutch ij ligature
```csharp
keypad.CulturalShift("Holland");
```

**Thailand** - Thai script (ทธ)
```csharp
keypad.CulturalShift("Thailand");
```

These additions reflect the interconnected nature of communication across cultures, where a simple keypad becomes a bridge between languages.

## Existential Philosophy Integration

Special input sequences trigger philosophical reflections:

- `777#` → *"Camus: the absurd persists in endless cycles"*

  The repetition of pressing the same key mirrors Sisyphus pushing his boulder—an endless cycle that we must imagine as meaningful.

- `666#` → *"Dostoevsky: freedom's burden shapes your path"*

  Each keystroke is a choice, and with choice comes the weight of freedom. We are condemned to choose our letters, our words, our meaning.

- `999#` → *"Nietzsche: will to power fuels your growth"*

  The act of pressing keys to form words is an exercise of will—transforming raw input into meaningful expression.

## Easter Egg

Input `AI#` to invoke the Kage prediction system, which reflects on previous inputs, suggesting a memory that transcends individual interactions.

## Testing

Comprehensive xUnit test suite covering:
- Basic T9 decoding
- Backspace and space handling
- Cultural shifts
- Existential thought responses
- Easter egg functionality
- Snake game mechanics

Run tests:
```bash
dotnet test
```

## Building

```bash
dotnet build
```

## Requirements

- .NET 8.0
- xUnit 2.9.2

## Design Philosophy

This implementation reflects influences from:
- **Travel**: Cultural adaptations acknowledge the global nature of communication
- **Philosophy**: Existential themes remind us that even mundane tasks carry deeper meaning
- **Health consciousness**: Clean code structure promotes maintainability and reduces cognitive burden
- **Curiosity about intelligent systems**: Easter egg explores predictive capabilities and memory

The code is production-ready, collaborative, and maintains professional standards while subtly reflecting a developer's personality shaped by diverse experiences.

## CI/CD

Integrated with GitHub Actions for automated testing and deployment.

## Repository

https://github.com/Rytual/OldPhonePad-OOP

---

*"In the repetition of keystrokes, we find both the absurd and the profound—each press a choice, each choice an act of will, each word a bridge across cultures."*
