using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace TestingEpam
{
    public class RusPage
    {
        private readonly IWebDriver _driver;

        public RusPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string Russian = ".top-navigation__item:nth-child(1) .top-navigation__item-link";

        [FindsBy(How = How.CssSelector, Using = Russian)]
        private IWebElement russianWordElement;

        public string GetRussianWord()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(russianWordElement));
            string res = russianWordElement.GetAttribute("innerHTML");
            return res;
        }
    }
}