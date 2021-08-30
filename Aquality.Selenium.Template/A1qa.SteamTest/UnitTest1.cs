using A1qa.SteamTest.pages;
using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace A1qa.SteamTest
{
    public class Tests
    {
        Browser browser;
        [SetUp]
        public void Setup()
        {
            browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo("https://store.steampowered.com/");
            browser.WaitForPageToLoad();
        }

        [Test]
        public void TestSteamSeacrh()
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsMainPageOpened());

            mainPage.SearchGame();
            SearchPage searchPage = new SearchPage();

        }
        [TearDown]
        public void CloseBrowser()
        {
            browser.Quit();
        }
    }
}