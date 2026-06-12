# C & C++ Tools

Una guida essenziale e strutturata ai tool e comandi più utilizzati per la programmazione in C e C++.

## Contenuto

Il repository contiene:

- **`Tool.md`** — Elenco completo di strumenti organizzati per categoria:
  - Compilatori (GCC, Clang, MSVC)
  - Build System (Make, CMake, Ninja, Meson, Bazel)
  - Debugger (GDB, LLDB, Valgrind)
  - Analisi e Profiling (gprof, perf, Sanitizer)
  - Linter e Formattatori (cppcheck, clang-tidy, clang-format)
  - Gestione Dipendenze (vcpkg, Conan, Hunter)
  - Testing (Catch2, Google Test, doctest, CTest)
  - Documentazione (Doxygen, Sphinx)
  - Strumenti Ausiliari

Ogni tool include: nome, descrizione, comando principale, esempio d'uso e note.

## Struttura del file

```markdown
### `nome-tool`
**Descrizione breve.**

- **Comando:** `comando principale`
- **Esempio:** `esempio d'uso`
- **Note:** Note aggiuntive
```

## Requisiti

- **Compilatori:** GCC (MinGW su Windows), Clang o MSVC (Visual Studio)
- **Build System:** make, CMake (a seconda della sezione)
- **Altri strumenti:** Installabili singolarmente

## Licenza

MIT
