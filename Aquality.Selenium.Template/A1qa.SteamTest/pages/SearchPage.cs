using A1qa.SteamTest.utils;
using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1qa.SteamTest.pages
{
    public class SearchPage : Form
    {
        private ITextBox searchResults => ElementFactory.GetTextBox(By.Id("search_resultsRows"), "Search results");
        private ILabel searchForm => ElementFactory.GetLabel(By.Id("advsearchform"), "Search form");
        private IButton sortTrigger => ElementFactory.GetButton(By.Id("sort_by_trigger"), "Sort trigger");
        private IButton priceDescSelector => ElementFactory.GetButton(By.Id("Price_DESC"), "Price desc selector");
        private ILabel searchResultContainer => ElementFactory.GetLabel(By.XPath("//div[@id='search_result_container' and @style='opacity: 0.5;']"), "Result container");
        private IList<ITextBox> finalPrice => ElementFactory.FindElements<ITextBox>(By.XPath("//div[@data-price-final]"));
        public SearchPage() : base(By.Id("advsearchform"), "Search form")
        {
        
        }
        public bool IsGamesListNotEmpty()
        {
            return finalPrice.Count > 0;
        }
        public List<int> SortGamesInDesc(int amount)
        {
            sortTrigger.Click();
            priceDescSelector.Click();
            searchResultContainer.State.WaitForDisplayed();
            searchResultContainer.State.WaitForNotDisplayed();
            List<int> prices = ListUtils.ExtractPricesFromList(finalPrice, amount);
            return prices;
        }
    }
}
