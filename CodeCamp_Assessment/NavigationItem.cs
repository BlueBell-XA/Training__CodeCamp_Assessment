using OpenQA.Selenium;

namespace CodeCamp_Assessment;

public class NavigationItem
{
    private readonly IWebDriver _driver;
    public NavigationItem(IWebDriver driver)
    {
        this._driver = driver;
    }
    public void ClickMenu()
    {
        _driver.FindElement((By.CssSelector("[aria-label=\"menu\"]"))).Click();
    }

    public int GetOrderCount()
    {
        // TODO find more concrete way of locating order count
        return int.Parse(_driver.FindElements(By.ClassName("order-count"))[1].GetAttribute("innerText"));
    }

    public void ClickOrders()
    {
        // TODO find more concrete way of locating order count
        _driver.FindElement((By.CssSelector("aria-label=\"your order\"]"))).Click();
    }
}