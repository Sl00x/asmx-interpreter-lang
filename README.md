# AsmX-Interpreter | CSharp

**AsmX-Interpreter** is a sample language interpreter written in C#. This project aims to demonstrate the basic concepts of code interpretation, from lexing to execution, including syntax and semantic analysis.

## Features

- **Lexer**: Analyzes the source text and generates tokens.
- **Tokenization**: Analyzes the lexer's output and tokenizes it.
- **Parser**: Transforms tokens into an abstract syntax tree (AST).
- **Interpreter**: Executes the AST to produce results.
- **Syntaxor**: Syntaxor is a CLI-based TextEditor class that uses syntax highlighting to facilitate reading.
  - **Save**: Save the input as an output.txt file.
  - **Console**: Allows interpreting code directly in the editor.

## Prerequisites

- .NET SDK 8.0 or higher

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/Sl00x/asmx-interpreter-lang.git
    ```
2. Navigate to the project directory:
    ```bash
    cd asmx-interpreter-lang
    ```
3. Restore dependencies:
    ```bash
    dotnet restore
    ```
4. Build the project:
    ```bash
    dotnet build
    ```

![Screenshot](https://github.com/Sl00x/asmx-interpreter-lang/assets/30964327/dfe11c0e-a925-42e8-96eb-ebf140e00997)

## Contribution

Contributions are welcome! Please read our [Contribution Guide](CONTRIBUTING.md) for details on the process of submitting pull requests.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
