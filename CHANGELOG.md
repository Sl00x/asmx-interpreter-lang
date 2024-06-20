# CHANGELOG

## [1.0.0] - 2024-06-20

### Added
- **Lexer**: Initial implementation for lexical analysis.
- **Parser**: Converts tokens into an abstract syntax tree (AST).
- **Evaluator**: Executes the AST to produce results.
- **Syntaxor**: A CLI-based text editor with syntax highlighting.
  - Save code with `Ctrl + S`.
  - Interpret code with `Ctrl + R`.

### Language Keywords
- `DVAR`: Declare a variable.
- `PRT`: Output text.
- `RET`: Return.

### Operations
- `ADD`: Add a value to a declared variable.
- `SUB`: Subtract a value from a declared variable.
- `MUL`: Multiply a value with a declared variable.
- `DIV`: Divide a value from a declared variable.
