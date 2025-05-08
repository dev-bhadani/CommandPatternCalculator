# CommandPatternCalculator

A C# Console Application implementing the Command Pattern.

Supports undoable commands with full unit and integration tests.

---

## Features

* **Supported Commands:**

  * `increment`: Increase result by 1.
  * `decrement`: Decrease result by 1.
  * `double`: Multiply result by 2.
  * `randadd`: Add random number between 1 and 100.
  * `undo`: Revert the last command.

* **Testing:**

  * Includes unit tests and integration tests using xUnit.

---

## How to Run the Project

### Prerequisites

* Visual Studio 2022 or later.
* .NET 8 SDK or later.

### Steps

1. **Clone the repository:**

   ```bash
   git clone https://github.com/dev-bhadani/CommandPatternCalculator.git
   cd CommandPatternCalculator
   ```

2. **Open the project:**

   * Open `CommandPatternCalculator.sln` in Visual Studio.

3. **Build the project:**

   * Press **Ctrl + Shift + B** or select *Build → Build Solution*.

### Run the application:

**Option 1: Inside Visual Studio**

* You can set a command line argument (e.g., 1 or any integer) in **Project → Properties → Debug → Application arguments**, but if you don't provide one, the program will default to using 1.
* Press **F5** to start.

**Option 2: From command line**

```bash
cd bin/Debug/
./CommandPatternCalculator.exe 1
```

If no argument is provided, the program defaults to initial result value `1`.

---

## Commands

```plaintext
increment
decrement
double
randadd
undo
```

---

## Running Tests

### Inside Visual Studio:

1. Open **Test Explorer**.
2. Click **Run All** to execute unit and integration tests.

### Or via CLI:

```bash
dotnet test
```
