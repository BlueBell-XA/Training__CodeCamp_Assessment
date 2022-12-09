using OpenQA.Selenium;

namespace CodeCamp_Assessment;

public class TabSelector
{
    private readonly IWebDriver _driver;

    public TabSelector(IWebDriver driver)
    {
        this._driver = driver;
    }

    public void ClickTabItem(string desiredItem)
    {
        foreach (var item in _driver.FindElements(By.ClassName("v-tab")))
        {
            if (item.Text.ToLower().Contains(desiredItem.ToLower()))
            {
                item.Click();
                return;
            }
        }

        throw new NotFoundException("Unable to find desired menu item");
    }
}