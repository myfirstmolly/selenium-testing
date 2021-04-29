using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace TestingEpam
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string Logo = ".header__logo-container";
        private const string OurWorkTab = ".top-navigation__item:nth-child(3) .top-navigation__item-link";
        private const string SliderTitle = ".title-slider__slide-row";
        private const string ContactUs = ".cta-button__text";
        private const string PhoneNumber = ".color-light-blue b a";
        private const string CookieButton = ".cookie-disclaimer__button .button__content";
        private const string LocationButton = ".location-selector__button";
        private const string RussianLanguage = ".location-selector__item:nth-child(9) .location-selector__link";
        private const string EuropeanOffices = ".tabs__title:nth-child(2) .js-tabs-link";
        private const string Insights = ".top-navigation__item:nth-child(4) .top-navigation__item-link";
        private const string Inst = ".footer__social-item:nth-child(4) .footer__social-link";
        private const string SearchIcon = ".header-search__button.header__icon";
        private const string FrequentSearchItem = "//*[@id='wrapper']/div[2]/div[1]/header/div/ul/li[3]/div/div/form/div/div/ul/li[1]";
        private const string SubmitSearch = ".header-search__submit";
        private const string KeyWordSearch = ".search-results__title-link";
        private const string CareersTab = ".top-navigation__item:nth-child(6) .top-navigation__item-link";

        [FindsBy(How = How.CssSelector, Using = Logo)]
        private IWebElement logoButton;
        [FindsBy(How = How.CssSelector, Using = OurWorkTab)]
        private IWebElement workTabButton;
        [FindsBy(How = How.CssSelector, Using = SliderTitle)]
        private IWebElement homePageCheckerElement;
        [FindsBy(How = How.CssSelector, Using = ContactUs)]
        private IWebElement contactUsButton;
        [FindsBy(How = How.CssSelector, Using = PhoneNumber)]
        private IWebElement phoneNumberElement;
        [FindsBy(How = How.CssSelector, Using = CookieButton)]
        private IWebElement cookieButton;
        [FindsBy(How = How.CssSelector, Using = LocationButton)]
        private IWebElement locationElement;
        [FindsBy(How = How.CssSelector, Using = RussianLanguage)]
        private IWebElement russianLanguageElement;
        [FindsBy(How = How.CssSelector, Using = EuropeanOffices)]
        private IWebElement europeOffice;
        [FindsBy(How = How.CssSelector, Using = Insights)]
        private IWebElement insightsTab;
        [FindsBy(How = How.CssSelector, Using = Inst)]
        private IWebElement instagramButton;
        [FindsBy(How = How.CssSelector, Using = SearchIcon)]
        private IWebElement searchIcon;
        [FindsBy(How = How.CssSelector, Using = KeyWordSearch)]
        private IWebElement keyWordSearch;
        [FindsBy(How = How.CssSelector, Using = SubmitSearch)]
        private IWebElement submitSearch;
        [FindsBy(How = How.XPath, Using = FrequentSearchItem)]
        private IWebElement frequesntSearchItem;
        [FindsBy(How = How.CssSelector, Using = CareersTab)]
        private IWebElement careersTab;

        public HomePage OpenHomePage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(logoButton));
            logoButton.Click();
            return new HomePage(_driver);
        }

        public HomePage OpenWorkPage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(workTabButton));
            workTabButton.Click();
            return new HomePage(_driver);
        }

        public string GetDriverUrl()
        { 
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(homePageCheckerElement));
            string res = _driver.Url;
            return res;
        }

        public HomePage OpenContactUsPage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(contactUsButton));
            contactUsButton.Click();
            return new HomePage(_driver);
        }

        public string FindPhoneNumber()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam.com/about/who-we-are/contact");
            string res = phoneNumberElement.GetAttribute("innerHTML");
            return res;
        }

        public HomePage AgreeWithCookies()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(cookieButton));
            cookieButton.Click();
            return new HomePage(_driver);
        }

        public HomePage ChangeLanguage()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(locationElement));
            locationElement.Click();
            
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(russianLanguageElement));
            russianLanguageElement.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == "https://www.epam-group.ru/");
            return new HomePage(_driver);
        }

        public string FindOffice()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(europeOffice));
            europeOffice.Click();
            string res = europeOffice.GetAttribute("innerHTML");
            return res;
        }

        public HomePage ToInsights()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(insightsTab));
            insightsTab.Click();
            return new HomePage(_driver);
        }

        public string ToInst()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(instagramButton));
            string res = instagramButton.GetAttribute("href");
            return res;
        }

        public string SearchInfo()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(searchIcon));
            searchIcon.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(frequesntSearchItem));
            frequesntSearchItem.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(submitSearch));
            submitSearch.Click();

            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(keyWordSearch));
            string res = keyWordSearch.GetAttribute("innerHTML");
            return res;
        }

        public HomePage ApplyCandidacy()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(careersTab));
            careersTab.Click();

            return new HomePage(_driver);
        }

    }
}