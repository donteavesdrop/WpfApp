using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace WpfApp122
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://mail.ru");
            List<IWebElement> wrapsElements = chromeDriver.FindElements(By.TagName("a")).ToList();
            foreach (var item in wrapsElements)
            {
                if (!item.Displayed)
                    continue;
                if (!item.Text.Trim().ToLower().Equals("создать почту"))
                    continue;
                item.Click();
                break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://account.mail.ru/signup?from=main&rf=auth.mail.ru&app_id_mytracker=58519");
            Registration.SetTextInField(chromeDriver, "fname", "Алек", "сандр");
            Registration.SetTextInField(chromeDriver, "lname", "Наха", "бенко");
            Registration.SetDateByField(chromeDriver, "/html/body/div[1]/div[3]/div[3]/div[4]/div/div/div/div/form/div[9]/div[2]/div/div/div/div[1]/div/div", "react-select-2-option-2");
            Registration.SetDateByField(chromeDriver, "/html/body/div[1]/div[3]/div[3]/div[4]/div/div/div/div/form/div[9]/div[2]/div/div/div/div[3]/div", "react-select-3-option-5");
            Registration.SetDateByField(chromeDriver, "/html/body/div[1]/div[3]/div[3]/div[4]/div/div/div/div/form/div[9]/div[2]/div/div/div/div[5]/div/div", "react-select-4-option-19");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument(@"user-data-dir=C:\Users\student\AppData\Local\Google\Chrome\User Data");
            ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
            chromeDriver.Navigate().GoToUrl("https://vk.com/feed");

            //IWebElement imageParent = chromeDriver.FindElement(By.Id("page_post_sixed_thumbs"));
            //if (imageParent == null || !imageParent.Displayed)
              //  return;
            //List<IWebElement> images = imageParent.FindElements(By.TagName("aria-label")).ToList();

            //IWebElement hrefParent = chromeDriver.FindElement(By.Id("post_author"));
           // if (hrefParent == null || !hrefParent.Displayed)
              //  return;
            //List<IWebElement> hrefs = imageParent.FindElements(By.TagName("href")).ToList();

           // IWebElement countParent = chromeDriver.FindElement(By.Id("post_author"));
           // if (countParent == null || !countParent.Displayed)
               // return;
            //List<IWebElement> count = imageParent.FindElements(By.TagName("href")).ToList();

            IWebElement webElementParent = chromeDriver.FindElement(By.Id("feed_rows"));
            if (webElementParent == null || !webElementParent.Displayed)
                return;
            List<IWebElement> webElements = webElementParent.FindElements(By.TagName("div")).ToList();
            foreach (var item in webElements)
            {  
                if (!item.Displayed)
                    continue;
                if(item.GetAttribute("class") == null)
                    continue;
                if(!item.GetAttribute("class").Trim().Equals("feed_row"))
                    continue;
                IWebElement webElementImg = item.FindElement(By.TagName("aria-label"));
                if (!item.GetAttribute("class").Trim().Equals("page_post_sixed_thumbs"))
                    continue;
                IWebElement webElementId = item.FindElement(By.TagName("div"));
                if (!item.GetAttribute("class").Trim().Equals("post_author"))
                    continue;
                IWebElement webElementHref = item.FindElement(By.TagName("href"));
                if (webElementId == null)
                    continue;
                if (webElementId.GetAttribute("id") == null)
                    continue;
                if (webElementImg == null)
                    continue;
                if (webElementImg.GetAttribute("id") == null)
                    continue;
                if (webElementHref == null)
                    continue;
                if (webElementHref.GetAttribute("id") == null)
                    continue;

                News news = new News() { Id = webElementId.GetAttribute("id"), 
                    Text = item.Text, 
                    Img = new string[] {webElementId.GetAttribute("aria-label")}, 
                    Href = new string[] { webElementId.GetAttribute("href") } };
                //дозаполнить поля экземпляра класса news
            }
        }
    }
}
