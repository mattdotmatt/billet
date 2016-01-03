namespace Billet.Tests.Features.Steps
{
    using System;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using TechTalk.SpecFlow;
    using Xunit;

    [Binding]
    public class BillSteps : Steps
    {
        private static ChromeDriver _driver;
        private string accountId;

        [BeforeFeature()]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
        }

        [Given(@"I have an account '(.*)'")]
        public void GivenIHaveAnAccount(string id)
        {
            accountId = id;
        }

        [When(@"I request my summary")]
        public void WhenIRequestMySummary()
        {
            _driver.Navigate().GoToUrl("http://localhost/billet");
            _driver.FindElement(By.Id("txtAccountId")).SendKeys(accountId);
            _driver.FindElement(By.Id("btnLogin")).Click();
        }

        [When(@"I request my package breakdown")]
        public void WhenIRequestMyPackageBreakdown()
        {
            When("I request my summary");
            _driver.FindElement(By.Id("packageTotal")).Click();

        }

        [When(@"I request my store breakdown")]
        public void WhenIRequestMyStoreBreakdown()
        {
            When("I request my summary");
            _driver.FindElement(By.Id("skystoreTotal")).Click();

        }

        [When(@"I request my calls breakdown")]
        public void WhenIRequestMyCallsBreakdown()
        {
            When("I request my summary");
            _driver.FindElement(By.Id("callsTotal")).Click();

        }

        [Then(@"the summary should contain")]
        public void ThenTheSummaryShouldContain(Table table)
        {
            foreach (var row in table.Rows)
            {
                Assert.Equal(row["Value"], _driver.FindElement(By.Id(row["Field"])).Text);
            }
        }

        [Then(@"the package breakdown should contain")]
        public void ThenThePackageBreakdownShouldContain(Table table)
        {
            foreach (var row in table.Rows)
            {
                var by = By.XPath(string.Format("//td[contains(text(),'{0}')]/../td", row["Name"]));

                var breakdownRow = _driver.FindElements(by).ToList();
                Assert.Equal(row["Name"], breakdownRow[0].Text);
                Assert.Equal(row["Cost"], breakdownRow[1].Text);
                Assert.Equal(row["Type"], breakdownRow[2].Text);
            }
        }

        [Then(@"the store breakdown should contain")]
        public void ThenTheStoreBreakdownShouldContain(Table table)
        {
            foreach (var row in table.Rows)
            {
                var by = By.XPath(string.Format(@"//td[contains(text(),""{0}"")]/../td", row["Title"]));

                var breakdownRow = _driver.FindElements(by).ToList();
                Assert.Equal(row["Title"], breakdownRow[0].Text);
                Assert.Equal(row["Cost"], breakdownRow[1].Text);
            }
        }

        [Then(@"the calls breakdown should contain")]
        public void ThenTheCallsBreakdownShouldContain(Table table)
        {
            foreach (var row in table.Rows)
            {
                var by = By.XPath(string.Format("//td[contains(text(),'{0}')]/../td", row["Called"]));

                var breakdownRow = _driver.FindElements(by).ToList();
                Assert.Equal(row["Called"], breakdownRow[0].Text);
                Assert.Equal(row["Cost"], breakdownRow[1].Text);
                Assert.Equal(row["Duration"], breakdownRow[2].Text);
            }
        }

        [Then(@"I should see an error '(.*)'")]
        public void ThenIShouldSeeAnError(string error)
        {
            Assert.Equal(error, _driver.FindElement(By.ClassName("alert-warning")).Text);
        }

        [AfterFeature()]
        public static void FixtureTearDown()
        {
            if (_driver == null) return;

            _driver.Quit();
            _driver.Dispose();
        }
    }
}