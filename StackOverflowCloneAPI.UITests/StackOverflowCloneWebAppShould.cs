using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowCloneAPI.UITests
{

    public class StackOverflowCloneWebAppShould
    {
        const string homeurl = "https://stackoverflowcloneraklet.azurewebsites.net/";
        const string homeTitle = "Stack Overflow";
        const string askQuestionurl = "https://stackoverflowcloneraklet.azurewebsites.net/askQuestions/";

        [Fact]
        [Trait("Category","Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(homeurl);
                DemoHelper.Pause();
                string pageTitle = driver.Title;
                Assert.Equal(homeTitle, driver.Title);
                Assert.Equal(homeurl, driver.Url);
            }

        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(homeurl);
                DemoHelper.Pause();
                driver.Navigate().Refresh();
                string pageTitle = driver.Title;
                Assert.Equal(homeTitle, driver.Title);
            }

        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(homeurl);
                DemoHelper.Pause();
                driver.Navigate().GoToUrl(askQuestionurl);
                DemoHelper.Pause();
                driver.Navigate().Back();
                DemoHelper.Pause();


                Assert.Equal(homeTitle, driver.Title);
                Assert.Equal(homeurl, driver.Url);

            }

        }


        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnForward()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(askQuestionurl);
                DemoHelper.Pause();

                driver.Navigate().GoToUrl(homeurl);
                DemoHelper.Pause();

                driver.Navigate().Back();
                DemoHelper.Pause();

                driver.Navigate().Forward();
                DemoHelper.Pause();


                Assert.Equal(homeTitle, driver.Title);
                Assert.Equal(homeurl, driver.Url);

            }

        }
    }
}
