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
    public class MainPage : Form
    {
        private ITextBox Title => ElementFactory.GetTextBox(By.ClassName("home_page_content"), "Title");
        private ITextBox StoreNavSearchTerm => ElementFactory.GetTextBox(By.Id("store_nav_search_term"), "Store navigaation search term");
        private ILink StoreSearchLinkImage => ElementFactory.GetLink(By.XPath("//a[@id='store_search_link']/img"), "Store search link image");

        public MainPage() : base(By.ClassName("home_page_content"), "Title")
        {
        }

        public bool IsMainPageOpened()
        {
            return Title.GetElement().Displayed;
        }
        public void SearchGame()
        {
            StoreNavSearchTerm.SendKeys("The Witcher");
            StoreSearchLinkImage.Click();
        }
    }   
}