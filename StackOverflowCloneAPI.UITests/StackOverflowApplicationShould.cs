using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowCloneAPI.UITests
{
    [Trait("Category", "Applications")]
    public class StackOverflowApplicationShould
    {
        const string homeurl = "https://stackoverflowcloneraklet.azurewebsites.net/";
        const string askQuestionurl = "https://stackoverflowcloneraklet.azurewebsites.net/askQuestions/";

        [Fact]
        public void BeInitiatedFromHomePage_AskQuestionsandBack()
        {


            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeurl);
                DemoHelper.Pause();

                IWebElement askQuestionsButton = driver.FindElement(By.ClassName("ask-button"));
                askQuestionsButton.Click();
                DemoHelper.Pause();

                IWebElement stackOverflowLogo = driver.FindElement(By.ClassName("fa-stack-overflow"));
                stackOverflowLogo.Click();
                DemoHelper.Pause();

                Assert.Equal("Stack Overflow", driver.Title);



            }
        }
        [Fact]
        public void BeInitiatedFromHomePage_LogoPartialLink()
        {
            const string homeurl = "https://stackoverflowcloneraklet.azurewebsites.net/";


            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeurl);
                DemoHelper.Pause();

                IWebElement askQuestionsButton = driver.FindElement(By.ClassName("ask-button"));
                askQuestionsButton.Click();
                DemoHelper.Pause();

                IWebElement stackOverflowLogo = driver.FindElement(By.PartialLinkText("overflow"));
                stackOverflowLogo.Click();
                DemoHelper.Pause();

                Assert.Equal("Stack Overflow", driver.Title);



            }



        }

        [Fact]
        public void BeInitiatedFromHomePage_LogoUsingXPATH()
        {
            const string homeurl = "https://stackoverflowcloneraklet.azurewebsites.net/";


            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeurl);
                DemoHelper.Pause();

                IWebElement askQuestionsButton = driver.FindElement(By.XPath("//*[@id='root']/div/div/div[1]/div[1]/a/a"));
                askQuestionsButton.Click();
                DemoHelper.Pause();

                IWebElement stackOverflowLogo = driver.FindElement(By.PartialLinkText("overflow"));
                stackOverflowLogo.Click();
                DemoHelper.Pause();

                Assert.Equal("Stack Overflow", driver.Title);



            }



        }

        [Fact]
        public void BeInitiatedFromHomePage_ImplicitWait()
        {
            const string homeurl = "https://stackoverflowcloneraklet.azurewebsites.net/";


            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeurl);
                DemoHelper.Pause();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(11));



                IWebElement stackOverflowLogo = driver.FindElement(By.PartialLinkText("overflow"));
                stackOverflowLogo.Click();
                DemoHelper.Pause();

                Assert.Equal("Stack Overflow", driver.Title);

            }

        }

        [Fact]
        public void BeSubmittedWhenValid()
        {
            const string homeurl = "https://stackoverflowcloneraklet.azurewebsites.net/";
            const string sampleTitle = "How to use Selenium Web Drivers";
            const string sampleBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum ";
            const string sampleTag = "Selenium";

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeurl);
                DemoHelper.Pause();

                IWebElement stackOverflowLogo = driver.FindElement(By.ClassName("ask-button"));
                stackOverflowLogo.Click();
                DemoHelper.Pause();


                IWebElement questionTitle = driver.FindElement(By.ClassName("input-box"));
                questionTitle.SendKeys(sampleTitle);
                DemoHelper.Pause();

                IWebElement questionBody = driver.FindElement(By.ClassName("input-box-body"));
                questionBody.SendKeys(sampleBody);
                DemoHelper.Pause();

                IWebElement questionTag = driver.FindElement(By.XPath("//*[@id='root']/div/div/div[2]/div[6]/form/input"));
                questionTag.SendKeys(sampleTag);
                DemoHelper.Pause();

                IWebElement askButton = driver.FindElement(By.ClassName("ask-button"));
                askButton.Click();
                DemoHelper.Pause();
                Assert.Equal("Stack Overflow", driver.Title);

                Assert.NotEmpty(driver.FindElement(By.ClassName("input-box")).Text);
                Assert.NotEmpty(driver.FindElement(By.ClassName("input-box-body")).Text);


                Assert.NotEmpty(driver.FindElement(By.XPath("//*[@id='root']/div/div/div[2]/div[6]/form/input")).Text);

                Assert.Equal(driver.FindElement(By.ClassName("input-box")).Text, sampleTitle);
                Assert.Equal(driver.FindElement(By.ClassName("input-box-body")).Text, sampleBody);
                Assert.Equal(driver.FindElement(By.XPath("//*[@id='root']/div/div/div[2]/div[6]/form/input")).Text, sampleTag);


            }

        }

        [Fact]
        public void NotDisplayCookieUseMessage()
        {



            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeurl);
                driver.Manage().Cookies.AddCookie(new Cookie("acceptedCookies", "true"));

                driver.Navigate().Refresh();

                ReadOnlyCollection<IWebElement> message = driver.FindElements(By.Id("CookiesBeingUsed"));

                DemoHelper.Pause();

                Assert.Empty(message);


            }

        }
        [Fact]
        [UseReporter(typeof(BeyondCompareReporter))]
        public void RenderQuestionsPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeurl);
                ITakesScreenshot screenshotdriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotdriver.GetScreenshot();
                screenshot.SaveAsFile("homepage.bmp", ScreenshotImageFormat.Bmp);
                FileInfo file = new FileInfo("aboutpage.Bmp");
                Approvals.Verify(file);
            }
        }




    }

}

    


