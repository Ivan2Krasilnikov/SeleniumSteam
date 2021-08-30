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
        private ITextBox SearchResults => ElementFactory.GetTextBox(By.Id("search_resultsRows"), "Search results");
        private ILabel SearchForm => ElementFactory.GetLabel(By.Id("advsearchform"), "Search form");
        public SearchPage() : base(By.Id("advsearchform"), "Search form")
        {
        
        }

    }
}
