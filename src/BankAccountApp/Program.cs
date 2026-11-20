using BankAccountApp;

Console.WriteLine("=== SE Lab 9: BankAccount Demo ===");
Console.WriteLine("Student: Trịnh Đức Long (524K0021)");

var account = new BankAccount("Trinh Duc Long", 1000m);
Console.WriteLine($"Created account for {account.CustomerName} with balance: ${account.Balance}");

account.Credit(500m);
Console.WriteLine($"After Crediting $500: ${account.Balance}");

account.Debit(200m);
Console.WriteLine($"After Debiting $200: ${account.Balance}");

try
{
    Console.WriteLine("Attempting to withdraw $2000 (exceeding balance)...");
    account.Withdraw(2000m);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Expected exception caught: {ex.Message}");
}

Console.WriteLine("BankAccount demonstration complete!");

if (!Console.IsInputRedirected)
{
    Console.WriteLine("\nPress Enter to exit...");
    try { Console.ReadLine(); } catch { }
}
