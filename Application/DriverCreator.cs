using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Application
{
    public static class DriverCreator
    {
        #region Drivers
        public enum BROWSER { INTERNET_EXPLORER, FIREFOX, CHROME };
        #endregion Drivers

        public static IWebDriver Create(BROWSER browser)
        {
            if (browser == BROWSER.INTERNET_EXPLORER)
                return CreateIEDriver();
            else if (browser == BROWSER.CHROME)
                return CreateChromeDriver();
            else
                return CreateFFDriver();
        }

        #region InternetExplorerDriver
        public static InternetExplorerDriver CreateIEDriver()
        {
            var driver = CreateInternetExplorerDriver(MySetup.Default.DriversFolder + MySetup.Default.IEDriverFolder, CreateInternetExplorerOptions(true));

            SetDriverTimeouts(driver, MySetup.Default.DefaultTimeout);

            return driver;
        }

        private static InternetExplorerDriver CreateInternetExplorerDriver(string webDriverUrl, InternetExplorerOptions options)
        {
            try
            {
                return new InternetExplorerDriver(@webDriverUrl, options);
            }
            catch (Exception ex)
            {
                if (ex is DriverServiceNotFoundException)
                    throw new IESeleniumDriverNotFound(@webDriverUrl);

                throw ex;
            }
        }

        private static InternetExplorerOptions CreateInternetExplorerOptions(bool introduceInstabilityByIgnoringProtectedModeSettings)
        {
            try
            {
                return new InternetExplorerOptions
                {
                    IntroduceInstabilityByIgnoringProtectedModeSettings = introduceInstabilityByIgnoringProtectedModeSettings
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GoogleChromeDriver
        public static ChromeDriver CreateChromeDriver()
        {

            var driver = CreateGoogleChromeDriver(MySetup.Default.DriversFolder + MySetup.Default.ChromeDriverFolder, CreateChromeOptions(false));

            SetDriverTimeouts(driver, MySetup.Default.DefaultTimeout);

            return driver;
        }

        private static ChromeDriver CreateGoogleChromeDriver(string webDriverUrl, ChromeOptions options)
        {
            try
            {
                return new ChromeDriver(@webDriverUrl, options);
            }
            catch (Exception ex)
            {
                if (ex is DriverServiceNotFoundException)
                    throw new ChromeSeleniumDriverNotFound(@webDriverUrl);

                throw ex;
            }
        }

        private static ChromeOptions CreateChromeOptions(bool leaveBrowserRunning)
        {
            try
            {
                var options = new ChromeOptions
                {
                    LeaveBrowserRunning = leaveBrowserRunning
                };

                options.AddArguments("start-maximized");

                return options;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FirefoxDriver
        public static FirefoxDriver CreateFFDriver()
        {
            var driver = CreateFirefoxDriver(MySetup.Default.DriversFolder + MySetup.Default.FFDriverFolder);

            SetDriverTimeouts(driver, MySetup.Default.DefaultTimeout);

            return driver;
        }

        private static FirefoxDriver CreateFirefoxDriver(string webDriverUrl)
        {
            try
            {
                return new FirefoxDriver();
            }
            catch (Exception ex)
            {
                if (ex is DriverServiceNotFoundException)
                    throw new FirefoxSeleniumDriverNotFound(@webDriverUrl);

                throw ex;
            }
        }
        #endregion

        private static void SetDriverTimeouts(IWebDriver driver, TimeSpan timeout)
        {
            /*driver.Manage().Timeouts().ImplicitlyWait(timeout);
            driver.Manage().Timeouts().SetScriptTimeout(timeout);
            driver.Manage().Timeouts().SetPageLoadTimeout(timeout);*/
        }
    }


    #region Exceptions
    public class IESeleniumDriverNotFound : Exception
    {
        public IESeleniumDriverNotFound(string path)
            : base("Error: The IE SeleniumDriver was not found in the following path: " + path) { }
    }

    public class ChromeSeleniumDriverNotFound : Exception
    {
        public ChromeSeleniumDriverNotFound(string path)
            : base("Error: The Chrome SeleniumDriver was not found in the following path: " + path) { }
    }

    public class FirefoxSeleniumDriverNotFound : Exception
    {
        public FirefoxSeleniumDriverNotFound(string path)
            : base("Error: The Firefox SeleniumDriver was not found in the following path: " + path) { }
    }
    #endregion
}
