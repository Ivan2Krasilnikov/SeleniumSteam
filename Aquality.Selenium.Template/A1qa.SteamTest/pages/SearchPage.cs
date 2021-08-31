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
        //private ITextBox finalPrice => ElementFactory.GetTextBox(By.XPath("//div[@data-price-final]"), "Final price");
        private IList<ITextBox> finalPrice => ElementFactory.FindElements<ITextBox>(By.XPath("//div[@data-price-final]"));
        public SearchPage() : base(By.Id("advsearchform"), "Search form")
        {
        
        }
        public bool IsSearchPageOpened()
        {
            return searchForm.GetElement().Displayed;
        }
        public List<string> SortGamesInDesc()
        {
            sortTrigger.Click();
            priceDescSelector.Click();
            List<string> prices = ExtractPricesFromList(finalPrice);
            return prices;
        }
        public static List<string> ExtractPricesFromList(IList<ITextBox> rawPrices)
        {
            List<string> priceList = new List<string>();
            foreach (ITextBox price in rawPrices.ToList())
            {
                priceList.Add(price.GetAttribute("data-price-final"));
            }
            return priceList;
        }

    }
}
