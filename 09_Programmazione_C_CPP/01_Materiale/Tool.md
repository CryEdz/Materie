# C & C++ Tools — Guida Essenziale

Elenco completo dei tool e comandi più utilizzati per la programmazione in C e C++, organizzati per categoria. Ogni tool include descrizione, comando principale, esempio d'uso e note.

---

## Indice

1. [Compilatori](#1-compilatori)
2. [Build System](#2-build-system)
3. [Debugger](#3-debugger)
4. [Analisi e Profiling](#4-analisi-e-profiling)
5. [Linter e Formattatori](#5-linter-e-formattatori)
6. [Gestione Dipendenze](#6-gestione-dipendenze)
7. [Testing](#7-testing)
8. [Documentazione](#8-documentazione)
9. [Strumenti Ausiliari](#9-strumenti-ausiliari)

---

## 1. Compilatori

### `gcc` (GNU C Compiler)
**Compilatore C standard del progetto GNU.**

- **Comando:** `gcc [opzioni] <file.c> -o <output>`
- **Esempio:** `gcc -Wall -Wextra -O2 -std=c17 main.c -o programma`
- **Opzioni:** `-Wall` (warning), `-O2` (ottimizzazione), `-g` (debug symbols), `-std=c17`

### `g++` (GNU C++ Compiler)
**Compilatore C++ del progetto GNU.**

- **Comando:** `g++ [opzioni] <file.cpp> -o <output>`
- **Esempio:** `g++ -Wall -Wextra -O2 -std=c++20 main.cpp -o programma`
- **Opzioni:** `-std=c++20`, `-std=c++23`, `-fmodules-ts` (moduli C++20)

### `clang`
**Compilatore C/C++ del progetto LLVM (veloce, messaggi di errore chiari).**

- **Comando:** `clang [opzioni] <file.c> -o <output>`
- **Esempio:** `clang -Wall -Wextra -O2 -std=c17 main.c -o programma`
- **Note:** `clang++` per C++; compatibile con GCC a livello di opzioni

### `clang-cl`
**Interfaccia compatibile con MSVC per Clang su Windows.**

- **Comando:** `clang-cl [opzioni] <file.c>`
- **Esempio:** `clang-cl /Wall /O2 main.c`

### `cl.exe` (MSVC)
**Compilatore C/C++ di Microsoft su Windows.**

- **Comando:** `cl [opzioni] <file.c>`
- **Esempio:** `cl /W4 /O2 /std:c17 main.c`
- **Note:** Incluso in Visual Studio Build Tools; `/EHsc` per eccezioni C++

### `cc` (alias)
**Alias di sistema per il compilatore C predefinito (solitamente gcc o clang).**

- **Comando:** `cc <file.c> -o <output>`
- **Esempio:** `cc -std=c99 -Wall main.c -o prog`

### `c++` (alias)
**Alias di sistema per il compilatore C++ predefinito.**

- **Comando:** `c++ <file.cpp> -o <output>`
- **Esempio:** `c++ -std=c++20 -O2 main.cpp -o prog`

### `cross-compiler`
**Compilazione per architetture diverse (ARM, AVR, RISC-V, ecc.).**

- **Esempio (ARM):** `arm-none-eabi-gcc -mcpu=cortex-m4 main.c -o firmware.elf`
- **Esempio (AVR):** `avr-gcc -mmcu=atmega328p main.c -o firmware.hex`

---

## 2. Build System

### `make`
**Tool di build classico basato su regole e dipendenze in Makefile.**

- **Comando:** `make [opzioni] [target]`
- **Esempio:** `make clean && make -j$(nproc)`
- **Makefile minimo:**
  ```makefile
  CXX = g++
  CXXFLAGS = -std=c++20 -Wall -O2
  TARGET = programma
  all: $(TARGET)
  $(TARGET): main.o utils.o
      $(CXX) $(CXXFLAGS) -o $@ $^
  clean:
      rm -f *.o $(TARGET)
  ```

### `CMake`
**Build system multi-piattaforma che genera Makefile o progetti IDE.**

- **Comando:** `cmake [opzioni] <directory-sorgente>`
- **Esempio:**
  ```
  cmake -B build -DCMAKE_BUILD_TYPE=Release
  cmake --build build -j$(nproc)
  ```
- **CMakeLists.txt minimo:**
  ```cmake
  cmake_minimum_required(VERSION 3.20)
  project(MyApp CXX)
  set(CMAKE_CXX_STANDARD 20)
  add_executable(programma main.cpp utils.cpp)
  ```

### `Autotools` (autoconf/automake)
**Sistema di build tradizionale per progetti Unix.**

- **Comando:**
  ```
  ./configure
  make
  make install
  ```
- **Note:** Usa `configure.ac`, `Makefile.am`; genera Makefile portabili

### `Ninja`
**Build system veloce (alternativa a make, usato spesso con CMake).**

- **Comando:** `ninja [opzioni] [target]`
- **Esempio:** `cmake -B build -G Ninja && ninja -C build`

### `Meson`
**Build system moderno con sintassi Python-like.**

- **Comando:** `meson setup <builddir> && meson compile -C <builddir>`
- **Esempio:**
  ```meson
  project('myapp', 'cpp', default_options: ['cpp_std=c++20'])
  executable('programma', 'main.cpp', 'utils.cpp')
  ```

### `Bazel`
**Build system di Google per progetti grandi e multi-linguaggio.**

- **Comando:** `bazel build //main:programma`
- **Note:** Usa file `BUILD`; supporta caching distribuito

### `Premake`
**Build system descrittivo con script Lua.**

- **Comando:** `premake5 gmake` (genera Makefile)
- **Esempio:** `premake5 vs2022` (genera soluzione Visual Studio)

---

## 3. Debugger

### `gdb` (GNU Debugger)
**Debugger classico per programmi C/C++ su Unix/Linux.**

- **Comando:** `gdb [opzioni] [programma] [core]`
- **Esempio:**
  ```
  gcc -g main.c -o programma
  gdb ./programma
  (gdb) break main
  (gdb) run
  (gdb) next
  (gdb) print variabile
  (gdb) backtrace
  (gdb) watch variabile
  ```
- **Comandi principali:** `break` (punto di arresto), `run` (esegui), `next` (passo), `step` (entra), `continue`, `print`, `backtrace`, `list`, `info locals`, `frame`

### `lldb`
**Debugger del progetto LLVM (alternativa moderna a GDB).**

- **Comando:** `lldb [opzioni] [programma]`
- **Esempio:**
  ```
  lldb ./programma
  (lldb) breakpoint set --name main
  (lldb) run
  (lldb) next
  (lldb) frame variable
  (lldb) bt
  ```
- **Note:** Sintassi simile a GDB ma più moderna; scriptable in Python

### `cgdb`
**Interfaccia TUI per GDB (split screen: codice + debugger).**

- **Comando:** `cgdb [opzioni] [programma]`
- **Esempio:** `cgdb ./programma`

### `gdbgui`
**Interfaccia web per GDB.**

- **Comando:** `gdbgui [opzioni] [programma]`
- **Installazione:** `pip install gdbgui`

### `valgrind` (memcheck)
**Analisi di memoria avanzata: memory leak, buffer overflow, uso di memoria non inizializzata.**

- **Comando:** `valgrind [opzioni] <programma> [args]`
- **Esempio:** `valgrind --leak-check=full --show-leak-kinds=all ./programma`
- **Altri tool Valgrind:** `callgrind` (profiling), `cachegrind` (cache), `helgrind` (race condition)

### `DrMemory`
**Tool di analisi memoria per Windows e Linux (alternativa a Valgrind).**

- **Comando:** `drmemory [opzioni] -- <programma> [args]`
- **Esempio:** `drmemory -- ./programma`

### `AddressSanitizer` (ASan)
**Rilevamento errori di memoria a compile-time (gcc/clang).**

- **Comando:** `gcc -fsanitize=address -g main.c -o programma`
- **Esempio:** `gcc -fsanitize=address,undefined -g main.c -o programma`
- **Note:** Rileva buffer overflow, use-after-free, memory leak (con `LSAN`)

### `UndefinedBehaviorSanitizer` (UBSan)
**Rilevamento di comportamenti indefiniti a runtime.**

- **Comando:** `gcc -fsanitize=undefined -g main.c -o programma`
- **Esempio:** `gcc -fsanitize=undefined -fsanitize-trap main.c`

### `ThreadSanitizer` (TSan)
**Rilevamento di race condition nei programmi multi-thread.**

- **Comando:** `gcc -fsanitize=thread -g -pthread main.c -o programma`
- **Esempio:** `gcc -fsanitize=thread -g -pthread main.c -o programma`

---

## 4. Analisi e Profiling

### `gprof`
**Profiler GNU che analizza il tempo speso in ogni funzione.**

- **Comando:**
  ```
  gcc -pg -O2 main.c -o programma
  ./programma
  gprof programma gmon.out > analisi.txt
  ```

### `perf` (Linux)
**Analisi di performance a livello kernel (campionamento, eventi CPU).**

- **Comando:** `perf record ./programma && perf report`
- **Esempio:** `perf stat ./programma` (statistiche generali)
- **Esempio:** `perf top` (monitoraggio live dei processi)

### `callgrind` (Valgrind)
**Profiler che traccia chiamate a funzioni e costi delle cache.**

- **Comando:** `valgrind --tool=callgrind ./programma`
- **Analisi:** `callgrind_annotate callgrind.out.1234`

### `FlameGraph`
**Visualizzazione di profili di performance come flame graph.**

- **Comando:**
  ```
  perf script | stackcollapse-perf.pl | flamegraph.pl > profile.svg
  ```

### `hotspot`
**Interfaccia GUI per visualizzare output di perf (Linux).**

- **Comando:** `hotspot perf.data`

### `heaptrack` (Linux)
**Heap profiler con tracciamento di allocazioni e deallocazioni.**

- **Comando:** `heaptrack ./programma`
- **Analisi:** `heaptrack_print <file>.gz`

### `Massif` (Valgrind)
**Analisi dell'uso della memoria heap nel tempo.**

- **Comando:** `valgrind --tool=massif ./programma`
- **Analisi:** `ms_print massif.out.1234`

---

## 5. Linter e Formattatori

### `cppcheck`
**Analisi statica del codice C/C++ per bug, stile e sicurezza.**

- **Comando:** `cppcheck [opzioni] <file>`
- **Esempio:** `cppcheck --enable=all --suppress=missingIncludeSystem src/`
- **Note:** Rileva: overflow, memory leak, stile, performance

### `clang-tidy`
**Linter avanzato basato su Clang con correzioni automatiche.**

- **Comando:** `clang-tidy [opzioni] <file>`
- **Esempio:** `clang-tidy --checks='clang-analyzer-*,bugprone-*' main.cpp -- -std=c++20`
- **Note:** Supporta `--fix` per correzioni automatiche

### `clang-format`
**Formattatore automatico di codice C/C++ (altamente configurabile).**

- **Comando:** `clang-format [opzioni] <file>`
- **Esempio:** `clang-format -i src/*.cpp src/*.h` (formatta in-place)
- **Configurazione:** File `.clang-format` (generabile con `clang-format -style=lllvm -dump-config`)

### `include-what-you-use` (IWYU)
**Tool per ottimizzare gli #include nei file C/C++.**

- **Comando:** `include-what-you-use -std=c++20 main.cpp`
- **Note:** Suggerisce inclusioni mancanti e ridondanti

### `cpplint`
**Linter per stile Google C++ Style Guide.**

- **Comando:** `cpplint [opzioni] <file>`
- **Installazione:** `pip install cpplint`
- **Esempio:** `cpplint --filter=-build/include_order src/*.cpp`

### `flint` (Facebook)
**Linter C++ usato da Meta per grandi codebase.**

- **Comando:** `flint <file>`
- **Note:** Fork di cpplint con regole aggiuntive

---

## 6. Gestione Dipendenze

### `vcpkg`
**Package manager C++ di Microsoft (multi-piattaforma).**

- **Comando:** `vcpkg install <pacchetto>`
- **Esempio:** `vcpkg install boost fmt nlohmann-json`
- **Integrazione CMake:** `cmake -B build -DCMAKE_TOOLCHAIN_FILE=<vcpkg>/scripts/buildsystems/vcpkg.cmake`

### `Conan`
**Package manager decentralizzato per C/C++ con supporto multi-compilatore.**

- **Comando:** `conan install <pacchetto> [opzioni]`
- **Esempio:**
  ```
  conan install . --output-folder=build --build=missing
  conan create . --user=myuser --channel=stable
  ```
- **Configurazione:** File `conanfile.py` o `conanfile.txt`

### `hunter`
**Package manager CMake integrato (git-based).**

- **Esempio CMakeLists.txt:**
  ```cmake
  include(cmake/HunterGate.cmake)
  HunterGate(URL "https://github.com/cpp-pm/hunter/archive/v0.23.251.tar.gz")
  hunter_add_package(Boost COMPONENTS filesystem)
  target_link_libraries(myapp Boost::filesystem)
  ```

### `build2`
**Build system + package manager per C/C++ moderno.**

- **Comando:** `bdep init -C ../gcc && b update`
- **Note:** Integra build, test e gestione dipendenze

---

## 7. Testing

### `Catch2`
**Framework di testing header-only per C++ moderno.**

- **Esempio:**
  ```cpp
  #include <catch2/catch_test_macros.hpp>
  TEST_CASE("test somma", "[math]") {
      REQUIRE(add(2, 3) == 5);
      CHECK(add(-1, 1) == 0);
  }
  ```
- **Esecuzione:** `./test --success --verbosity high`

### `Google Test` (gtest)
**Framework di testing di Google per C++.**

- **Esempio:**
  ```cpp
  #include <gtest/gtest.h>
  TEST(MathTest, Somma) {
      EXPECT_EQ(add(2, 3), 5);
      ASSERT_TRUE(add(0, 0) == 0);
  }
  ```
- **Esecuzione:** `./test --gtest_filter=MathTest.*`

### `doctest`
**Framework testing header-only, leggero e veloce (alternativa a Catch2).**

- **Esempio:**
  ```cpp
  #define DOCTEST_CONFIG_IMPLEMENT
  #include <doctest/doctest.h>
  TEST_CASE("test") { CHECK(1 + 1 == 2); }
  ```

### `CUnit`
**Framework di testing per C puro.**

- **Esempio:**
  ```c
  #include <CUnit/Basic.h>
  void test_somma(void) { CU_ASSERT(add(2, 3) == 5); }
  ```

### `CTest`
**Driver di test integrato con CMake.**

- **Comando:** `ctest --output-on-failure -j$(nproc)`
- **Note:** Scopre automaticamente test registrati con `add_test()` in CMakeLists.txt

### `Fuzzing` (libFuzzer / AFL)
**Test tramite input casuali alla ricerca di bug di sicurezza.**

- **Esempio (libFuzzer):**
  ```
  clang -fsanitize=fuzzer,address -g -o fuzz_test fuzz_test.c
  ./fuzz_test
  ```

---

## 8. Documentazione

### `Doxygen`
**Generatore di documentazione da commenti nel codice.**

- **Comando:** `doxygen [opzioni] [config_file]`
- **Esempio:**
  ```
  doxygen -g Doxyfile    (genera configurazione)
  doxygen Doxyfile       (genera documentazione HTML/LaTeX/XML)
  ```
- **Commento Doxygen:**
  ```cpp
  /// Calcola la somma di due interi.
  /// @param a Primo addendo
  /// @param b Secondo addendo
  /// @return La somma a + b
  int add(int a, int b);
  ```

### `Sphinx` + Breathe
**Documentazione moderna usando Sphinx con commenti Doxygen.**

- **Comando:** `sphinx-build -b html source/ build/`
- **Note:** `breathe` plugin collega Doxygen XML a Sphinx

### `codedocs`
**Documentazione C++ online (simile a docs.rs per Rust).**

- **Note:** Servizio CI che genera e pubblica documentazione Doxygen

---

## 9. Strumenti Ausiliari

### `indent`
**Formattatore di codice C classico (GNU indent).**

- **Comando:** `indent [opzioni] <file>`
- **Esempio:** `indent -kr -i4 main.c` (stile Kernel Linux, indentazione 4)

### `astyle` (Artistic Style)
**Formattatore di codice C/C++/Java/C# con vari stili.**

- **Comando:** `astyle [opzioni] <file>`
- **Esempio:** `astyle --style=allman --indent=spaces=4 src/*.cpp`

### `cflow`
**Genera grafi di chiamata (call graph) da codice C.**

- **Comando:** `cflow <file.c>`
- **Esempio:** `cflow --tree main.c | less`

### `ctags`
**Genera file tag per navigazione nel codice (indici di funzioni, variabili, classi).**

- **Comando:** `ctags [opzioni] <file/directory>`
- **Esempio:** `ctags -R src/` (genera `tags` per editor Vim/Emacs)

### `cscope`
**Browser di codice C/C++ per ricerca di simboli, chiamanti, assegnazioni.**

- **Comando:** `cscope -R -b` (genera database) && `cscope -d` (query)
- **Note:** Integrabile con Vim, Emacs, editor vari

### `ltrace`
**Traccia le chiamate a librerie dinamiche di un programma.**

- **Comando:** `ltrace [opzioni] <programma>`
- **Esempio:** `ltrace -e malloc+free ./programma`

### `strace`
**Traccia le system call di un programma.**

- **Comando:** `strace [opzioni] <programma>`
- **Esempio:** `strace -e open,read,write ./programma`

### `nm` / `objdump` / `readelf`
**Ispezione di file oggetto e binari.**

- **Esempio:**
  ```
  nm programma           (simboli)
  objdump -d programma   (disassembla)
  readelf -h programma   (header ELF)
  ```

### `ldd`
**Mostra le librerie dinamiche richieste da un eseguibile.**

- **Comando:** `ldd <eseguibile>`
- **Esempio:** `ldd programma`

### `xxd` / `hexdump`
**Visualizzazione esadecimale di file binari.**

- **Esempio:** `xxd programma | head -20`

### `compiler-explorer` (godbolt.org)
**Esploratore di compilatori online per vedere l'assembly generato.**

- **URL:** https://godbolt.org
- **Note:** Supporta GCC, Clang, MSVC, ICC e molti altri

### `CppReference`
**Riferimento online completo per librerie C e C++ standard.**

- **URL:** https://en.cppreference.com

---

## Licenza

MIT
