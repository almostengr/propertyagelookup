using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Almostengr.PropertyAgeLookup.Logic
{
    public class PropertyLookup
    {
        public static void PerformLookup(string enteredAddress)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            try
            {
                driver.Navigate().GoToUrl("https://revco.mc-ala.org/CAPortal/CAPortal_MainPage.aspx");

                driver.FindElement(By.Id("PTCInfo")).Click();

                // switch frame
                driver.FindElements(By.TagName("iframe"));
                driver.SwitchTo().Frame("iframe1");

                driver.FindElement(By.Id("SearchText")).SendKeys(enteredAddress);

                driver.FindElement(By.Id("SearchByPropAddr")).Click();

                driver.FindElement(By.Id("Search")).Click();

                IWebElement bodyTable = driver.FindElement(By.Id("BodyTable"));

                foreach (var element in bodyTable.FindElements(By.TagName("span")))
                {
                    element.Click();
                    break;
                }

                driver.SwitchTo().Frame("iframe2");

                driver.FindElement(By.Name("Buildings")).Click();

                driver.SwitchTo().ParentFrame();
                driver.SwitchTo().Frame("iframe1");
                IWebElement generalFs = driver.FindElement(By.Id("GeneralFS"));

                System.Collections.ObjectModel.ReadOnlyCollection<IWebElement>
                                 tableCells = generalFs.FindElements(By.TagName("td"));

                for (int i = 0; i < tableCells.Count; i++)
                {
                    Console.WriteLine(tableCells[i].Text);
                    // if (tableCells[i].Text.Contains("Built"))
                    // {
                    //     // tableCells[i + 1].Text.Substring(tableCells[i + 1].Text.IndexOf(" ["));
                    //     // int year = Int32.Parse(tableCells[i + 1].Text.Substring(tableCells[i + 1].Text.IndexOf(" [")));
                    //     Console.WriteLine("Year built: {0}", tableCells[i + 1].Text);
                    //     break;
                    // }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} {1}", ex.GetType().ToString(), ex.Message);
            }

            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}