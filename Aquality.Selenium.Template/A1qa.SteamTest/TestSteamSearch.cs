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
        [TestCase("The Witcher", 10)]
        [TestCase("Fallout", 20)]
        public void TestSteamSeacrh(string game, int amount)
        {
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.State.IsDisplayed);

            mainPage.SearchGame(game);
            SearchPage searchPage = new SearchPage();
            Assert.IsTrue(searchPage.State.IsDisplayed);

            Assert.IsTrue(searchPage.IsGamesListNotEmpty());

            var prices = searchPage.SortGamesInDesc(amount);
            var copy = prices.ToList();
            copy.Sort();
            copy.Reverse();
            Assert.AreEqual(prices, copy);
        }
        [TearDown]
        public void CloseBrowser()
        {
            browser.Quit();
        }
    }
}
