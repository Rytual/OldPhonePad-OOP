# OldPhonePad: T9 Decoder with Cultural & Philosophical Dimensions

Texting across India, Holland, and Thailand shaped this keypad. Late-night coding sessions under Bangkok's stars, philosophical musings between Muay Thai rounds, and the universal rhythm of pressing keys to form meaning—this is where travel meets code.

## The Challenge

Implement `OldPhonePad(string input)` to decode old phone keypad inputs using T9 rules:
- Multiple presses cycle through letters (e.g., `2` → A, `22` → B, `222` → C)
- Space pauses for repeats on the same key
- Asterisk (`*`) backspaces
- Hash (`#`) ends input

**Examples:**
- `33#` → `E`
- `44 33 555 555 666#` → `HELLO`

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

Walking through Delhi's markets, cycling Amsterdam's canals, training in Chiang Mai's gyms—each place whispers its characters into the keypad. The `CulturalShift()` method lets you text in Devanagari (आइ) when you're navigating India's railways, switch to Dutch ij ligatures over coffee in Holland, or type Thai script (ทธ) while recovering from a Muay Thai session. A simple keypad becomes a bridge between worlds.

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

This code was written between flights and training sessions, influenced by street food conversations in Mumbai, philosophical debates in Rotterdam cafes, and the discipline of morning runs along the Chao Phraya. Clean code isn't just about maintainability—it's about respecting the next developer's cognitive load, the way you'd respect a sparring partner's energy. The existential themes aren't academic exercises; they're reminders that even writing a T9 decoder at 2 AM carries meaning, choice, and will.

## CI/CD

Integrated with GitHub Actions for automated testing and deployment.

## Repository

https://github.com/Rytual/OldPhonePad-OOP

---

*"In the repetition of keystrokes, we find both the absurd and the profound—each press a choice, each choice an act of will, each word a bridge across cultures."*
