using BasicMath;
using CalculatorApp;
using BankAccountApp;

Console.Title = "SE Lab 9: Software Testing - 524K0021 Trinh Duc Long";
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("========================================================================");
Console.WriteLine("        TON DUC THANG UNIVERSITY - FACULTY OF INFORMATION TECHNOLOGY    ");
Console.WriteLine("                 LAB 09: SOFTWARE TESTING IMPLEMENTATION                 ");
Console.WriteLine("        Student: Trịnh Đức Long | Student ID: 524K0021                   ");
Console.WriteLine("========================================================================\n");
Console.ResetColor();

// --- 1. BasicMath Demo ---
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(">>> [Exercise 1 & 2] BasicMaths & Calculator Functions Execution:");
Console.ResetColor();
var math = new BasicMaths();
Console.WriteLine($"  • Add(10, 20)        = {math.Add(10, 20)}");
Console.WriteLine($"  • Subtract(50, 15)   = {math.Subtract(50, 15)}");
Console.WriteLine($"  • Multiply(6, 7)     = {math.Multiply(6, 7)}");
Console.WriteLine($"  • Divide(100, 4)     = {math.Divide(100, 4)}");

var calc = new Calculator();
Console.WriteLine($"  • Calculator.Add(5, 7) = {calc.Add(5, 7)}");
Console.WriteLine("  [OK] BasicMath classes verified successfully.\n");

// --- 2. BankAccount Demo ---
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(">>> [Exercise 3] BankAccount Operations Execution:");
Console.ResetColor();
var account = new BankAccount("Trịnh Đức Long", 1000m);
Console.WriteLine($"  • Account created: {account.CustomerName} | Initial Balance: ${account.Balance:N2}");

account.Credit(500m);
Console.WriteLine($"  • Credit $500.00:  New Balance = ${account.Balance:N2}");

account.Debit(200m);
Console.WriteLine($"  • Debit $200.00:   New Balance = ${account.Balance:N2}");

try
{
    Console.WriteLine("  • Attempting to withdraw $2,000.00 (exceeding balance)...");
    account.Withdraw(2000m);
}
catch (InvalidOperationException ex)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"  • [Expected Exception Caught]: {ex.Message}");
    Console.ResetColor();
}
Console.WriteLine("  [OK] BankAccount operations verified successfully.\n");

// --- 3. Instructions for running tests ---
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("========================================================================");
Console.WriteLine(">>> HOW TO EXECUTE ALL 70 AUTOMATED UNIT & SELENIUM TESTS:");
Console.ResetColor();
Console.WriteLine("  Option 1 (Visual Studio Top Menu):");
Console.WriteLine("    -> Click 'Test' menu > 'Run All Tests' (Shortcut: Ctrl+R, A)");
Console.WriteLine("  Option 2 (Test Explorer Window):");
Console.WriteLine("    -> Click 'Test' menu > 'Test Explorer' > Click 'Run All' icon");
Console.WriteLine("  Option 3 (Terminal / CLI):");
Console.WriteLine("    -> Run: dotnet test SE_Lab9_524K0021.sln");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("========================================================================");
Console.ResetColor();

if (!Console.IsInputRedirected)
{
    Console.WriteLine("\n[Window will stay open] Press Enter to exit...");
    try { Console.ReadLine(); } catch { }
}
