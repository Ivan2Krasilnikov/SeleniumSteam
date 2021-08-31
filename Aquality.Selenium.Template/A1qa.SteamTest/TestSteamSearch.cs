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
            Assert.IsTrue(mainPage.State.IsDisplayed, "Page is not opened");

            mainPage.SearchGame(game);
            SearchPage searchPage = new SearchPage();
            Assert.IsTrue(searchPage.State.IsDisplayed, "Page is not opened");

            Assert.IsTrue(searchPage.IsGamesListNotEmpty(), "Games list is empty");

            var prices = searchPage.SortGamesInDesc(amount);
            var copy = prices.ToList();
            copy.Sort();
            copy.Reverse();
            Assert.AreEqual(prices, copy, "Games not sorted in descending order");
        }
        [TearDown]
        public void CloseBrowser()
        {
            browser.Quit();
        }
    }
}
