# AsmX-Interpreter | CSharp

**AsmX-Interpreter** est un exemple d'interpréteur de langage écrit en C#. Ce projet a pour objectif de démontrer les concepts de base de l'interprétation de code, de la lexérisation à l'exécution, en passant par l'analyse syntaxique et sémantique.

## Fonctionnalités

- **Lexeur** : Analyse le texte source et génère des jetons.
- **Tokenisation** : Analyse du lexer, puis tokenisation de celui-ci
- **Analyseur syntaxique** : Transforme les jetons en un arbre syntaxique abstrait (AST).
- **Interpréteur** : Exécute l'AST pour produire des résultats.

- **Syntaxor** : Syntaxor est une classe de TextEditor en CLI utilisant le Syntax Hilighting pour facilité la  lecture.
  - **Sauvegarder** : Sauvegarder du l'input en fichier output.txt
  - **Console** : Possibilité d'interpreter le code directement dans l'editeur.

## Prérequis

- .NET SDK 8.0 ou supérieur

## Installation

1. Clonez le repository :
    ```bash
    git clone https://github.com/Sl00x/asmx-interpreter-lang.git
    ```
2. Accédez au dossier du projet :
    ```bash
    cd asmx-interpreter-lang
    ```
3. Restaurez les dépendances :
    ```bash
    dotnet restore
    ```
4. Compilez le projet :
    ```bash
    dotnet build
    ```
![Capture_decran_2024-06-20_134515](https://github.com/Sl00x/asmx-interpreter-lang/assets/30964327/dfe11c0e-a925-42e8-96eb-ebf140e00997)

