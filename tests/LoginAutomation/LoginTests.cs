using CsvHelper;
using CsvHelper.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using Xunit;

namespace LoginAutomation
{
    public class LoginTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            string fileName = "LoginTestData.csv";
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
                    yield return new object[] { record.Username, record.Password };
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Login_WithValidCredentials_ShouldSucceed(string username, string password)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                string htmlPath = Path.Combine(AppContext.BaseDirectory, "login.html");
                if (!File.Exists(htmlPath))
                {
                    htmlPath = Path.GetFullPath("login.html");
                }
                string fileUrl = new Uri(htmlPath).AbsoluteUri;

                // Navigate to the login page
                driver.Navigate().GoToUrl(fileUrl);

                // Find the username and password fields and fill them
                var userInput = driver.FindElement(By.Id("username"));
                var passInput = driver.FindElement(By.Id("password"));
                var loginBtn = driver.FindElement(By.Id("loginButton"));

                userInput.Clear();
                userInput.SendKeys(username);

                passInput.Clear();
                passInput.SendKeys(password);

                // Click the login button
                loginBtn.Click();

                // Wait briefly to simulate user interaction
                Thread.Sleep(500);

                // Verify the message
                var messageElem = driver.FindElement(By.Id("message"));
                Assert.Contains("Login successful for user: " + username, messageElem.Text);
            }
        }

        public class TestData
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
    }
}
