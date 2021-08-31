using Aquality.Selenium.Elements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1qa.SteamTest.utils
{
    class ListUtils
    {
        public static List<int> ExtractPricesFromList(IList<ITextBox> rawPrices, int amount)
        {
            List<string> priceList = new List<string>();
            foreach (ITextBox price in rawPrices.ToList())
            {
                priceList.Add(price.GetAttribute("data-price-final"));
            }
            List<int> priceListInt = priceList.Select(int.Parse).Take(amount).ToList();
            return priceListInt;
        }
    }
}
