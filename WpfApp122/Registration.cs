using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace WpfApp122
{
    class Registration
    {
        public static void SetTextInField(ChromeDriver chromeDriver, string Id, string ValueFirstPart, string ValueSecondPart)
        {
            List<IWebElement> webElements = chromeDriver.FindElements(By.Id(Id)).ToList();
            Random random = new Random();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                foreach (var letter in ValueFirstPart)
                {
                    item.SendKeys(letter.ToString());
                    Thread.Sleep(random.Next(100,300));
                }
                foreach (var letter in ValueSecondPart)
                {
                    item.SendKeys(letter.ToString());
                    Thread.Sleep(random.Next(100, 300));
                }
                //случайная задержка при вводе каждой буквы 100-300 мс
            }
        }
        public static void SetDateByField(ChromeDriver chromeDriver, string XPath, string Id)
        {
            List<IWebElement> webElements = chromeDriver.FindElements(By.XPath(XPath)).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                item.Click();
                break;
            }
            webElements = chromeDriver.FindElements(By.Id(Id)).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                item.Click();
                break;
            }
        }
    }
}
