using System;
using System.Collections.Generic;
using Domain;
using IoCNinja;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Application
{
    public class TestSetExecutor : ITestSetExecutor, IImplement<ITestSetExecutor>
    {
        #region variables
        private IWebDriver _driver;
        private TestCaseExecutor _executor;
        private List<ITestCase> _testCases;
        #endregion variables

        #region ITestSetExecutor Members
        public void Execute()
        {
            try
            {
                TryExecute();
            }
            catch (Exception e)
            {
                IoC.Get<IPresentation>().TreatException(e);
            }
        }
        #endregion

        #region Execute() - privated methods
        private void TryExecute()
        {
            ConfigValidator.Validate();

            _testCases = IoC.Get<ITestPlanGateway>().GetActiveTestCases();

            if (MySetup.Default.IsToRunInGoogleChrome)
                RunInGoogleChrome();

            if (MySetup.Default.IsToRunInFirefox)
                RunInFirefox();

            if (MySetup.Default.IsToRunInInternetExplorer)
                RunInInternetExplorer();
        }

        private void RunInGoogleChrome()
        {
            SetUp(DriverCreator.BROWSER.CHROME);

            RunTestSetAndThenTearDown();
        }

        private void RunInFirefox()
        {
            SetUp(DriverCreator.BROWSER.FIREFOX);

            RunTestSetAndThenTearDown();
        }

        private void RunInInternetExplorer()
        {
            SetUp(DriverCreator.BROWSER.INTERNET_EXPLORER);

            RunTestSetAndThenTearDown();
        }

        private void RunTestSetAndThenTearDown()
        {
            try
            {
                _testCases.ForEach(tc => _executor.Execute(tc));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                TearDown();
            }
        }

        private void SetUp(DriverCreator.BROWSER browser)
        {
            _driver = DriverCreator.Create(browser);
            var wait = new WebDriverWait(_driver, MySetup.Default.DefaultTimeout);
            _executor = new TestCaseExecutor(GetBrowserShortName(browser), _driver, wait);
        }

        private string GetBrowserShortName(DriverCreator.BROWSER browser)
        {
            if (browser == DriverCreator.BROWSER.CHROME)
                return "GC";
            else if (browser == DriverCreator.BROWSER.FIREFOX)
                return "FF";
            else
                return "IE";
        }

        private void TearDown()
        {
            _driver.Quit();
        }
        #endregion Execute() - privated methods
    }
}
