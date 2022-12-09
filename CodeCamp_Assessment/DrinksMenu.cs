using System.Diagnostics;
using OpenQA.Selenium;

namespace CodeCamp_Assessment;

public class DrinksMenu
{
    private readonly IWebDriver _driver;
    public DrinksMenu(IWebDriver driver)
    {
        this._driver = driver;
    }

    public void OrderEspressoThickshake()
    {
        foreach (var drink in _driver.FindElements(By.ClassName("drink")))
        {
            if (drink.FindElement(By.ClassName("name")).Text.ToLower() == "espresso thickshake")
            {
                drink.FindElement(By.ClassName("v-btn__content")).Click();
                return;
            }
        }

        throw new NotFoundException("Unable to find desired drink!");
    }
}