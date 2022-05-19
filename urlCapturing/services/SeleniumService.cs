using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace urlCapturing.services
{
	public class SeleniumService
	{
        static IWebDriver driver;

        public void seleniumScreenShot()
		{
            driver = new ChromeDriver();
            var weburl = "https://bbc.com";
            driver.Navigate().GoToUrl(weburl);
            try
            {
                System.Threading.Thread.Sleep(4000);
                Screenshot TakeScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string imagePath = "./../../../selenium-screenshot.png";
                TakeScreenshot.SaveAsFile(imagePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            driver.Quit();
        }
	}
}

