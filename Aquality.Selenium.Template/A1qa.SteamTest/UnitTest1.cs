using A1qa.SteamTest.pages;
using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System.Linq;
using System.Threading;

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
            Assert.IsTrue(searchPage.IsSearchPageOpened());

            
            var prices = searchPage.SortGamesInDesc();
            var copy = prices.ToList();
            copy.Sort();
            copy.Reverse();
            Assert.That(prices, Is.EquivalentTo(copy));

        }
        [TearDown]
        public void CloseBrowser()
        {
            browser.Quit();
        }
    }
}