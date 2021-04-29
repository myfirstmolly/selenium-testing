using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace TestingEpam
{
    public class CareersPage
    {
        private readonly IWebDriver _driver;

        public CareersPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private const string SkillList = ".multi-select-filter.validation-focus-target.job-search__departments";
        private const string Skill = "//*[@id='main']/div[1]/div[3]/section/div/div[2]/div/form/div[3]/div/div[2]/div/ul[1]/li[1]/label/span";
        private const string Submit = ".recruiting-search__submit";
        private const string Title = ".search-result__item-name";

        [FindsBy(How = How.CssSelector, Using = SkillList)]
        private IWebElement skillList;
        [FindsBy(How = How.XPath, Using = Skill)]
        private IWebElement skill;
        [FindsBy(How = How.CssSelector, Using = Submit)]
        private IWebElement submit;
        [FindsBy(How = How.CssSelector, Using = Title)]
        private IWebElement title;

        public string GetJobTitle()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(skillList));
            skillList.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(skill));
            skill.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(submit));
            submit.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(title));
            string res = title.GetAttribute("innerHTML");
            return res;
        }

    }
}