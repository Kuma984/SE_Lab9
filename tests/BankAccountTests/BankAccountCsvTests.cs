using BankAccountApp;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Xunit;

namespace BankAccountTests
{
    public class BankAccountCsvTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            string fileName = "BankAccountTestData.csv";
            string filePath = File.Exists(fileName) ? fileName : Path.Combine(AppContext.BaseDirectory, fileName);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                foreach (var record in csv.GetRecords<TestData>())
                {
                    yield return new object[]
                    {
                        record.CustomerName,
                        record.InitialBalance,
                        record.DebitAmount,
                        record.ExpectedBalance
                    };
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Debit_CsvData_UpdatesBalance(string customerName, decimal initialBalance, decimal debitAmount, string expectedBalance)
        {
            // Arrange
            var account = new BankAccount(customerName, initialBalance);

            // Act & Assert
            if (expectedBalance.Equals("Insufficient funds", StringComparison.OrdinalIgnoreCase))
            {
                Assert.Throws<InvalidOperationException>(() => account.Debit(debitAmount));
            }
            else
            {
                account.Debit(debitAmount);
                Assert.Equal(decimal.Parse(expectedBalance), account.Balance);
            }
        }

        public class TestData
        {
            public string CustomerName { get; set; } = string.Empty;
            public decimal InitialBalance { get; set; }
            public decimal DebitAmount { get; set; }
            public string ExpectedBalance { get; set; } = string.Empty;
        }
    }
}
