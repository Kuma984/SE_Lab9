# Lab 09 - Software Testing

## Requirements
- .NET 8.0 SDK
- Visual Studio 2022
- Google Chrome

## Project Structure
- `src/BasicMath`: Console app demonstrating basic arithmetic operations (Exercise 1 & 2)
- `tests/BasicMathTests`: Unit tests for BasicMath using CSV datasets (Exercise 1 & 2 - 50 tests)
- `src/BankAccountApp`: BankAccount domain class and operations (Exercise 3)
- `tests/BankAccountTests`: Unit tests for BankAccount using CSV datasets (Exercise 3 - 16 tests)
- `tests/LoginAutomation`: Automated UI test for login page using Selenium WebDriver (Exercise 4 - 4 tests)

## How to Run

### 1. Visual Studio
1. Open `SE_Lab9_524K0021.sln`.
2. **Run Demo Console App:** Press **F5** (`BasicMath` is set as the startup project).
3. **Run All Unit Tests:** Open **Test** -> **Test Explorer** (`Ctrl + E, T`), then click **Run All Tests in View** (`Ctrl + R, A`).
4. **Run Exercise 4 (Selenium):** In Test Explorer, right-click `LoginAutomation` -> select **Run**.

---

### 2. Command Line (CLI)
Open a terminal in the project root:

- **Run demo console app:**
  ```bash
  dotnet run --project src/BasicMath
  ```

- **Run all 70 test cases:**
  ```bash
  dotnet test
  ```

- **Run individual test suites:**
  ```bash
  dotnet test tests/BasicMathTests
  dotnet test tests/BankAccountTests
  dotnet test tests/LoginAutomation
  ```

---

### Note for Exercise 4 (Selenium WebDriver)
By default, the Selenium test runs in headless mode (background). If you want to see the Chrome browser open, type credentials, and click login visibly:
Open `tests/LoginAutomation/LoginTests.cs`, comment out line 43:
```csharp
// options.AddArgument("--headless=new");
```
Then rerun the test.
