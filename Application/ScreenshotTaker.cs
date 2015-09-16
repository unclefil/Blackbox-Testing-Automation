using System.Drawing.Imaging;
using OpenQA.Selenium;

namespace Application
{
    public static class ScreenshotTaker
    {
        public static void GetAndSaveScreenshot(IWebDriver driver, string filePath, ImageFormat format)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(filePath, format);
        }
    }
}
