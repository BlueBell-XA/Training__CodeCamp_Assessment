using OpenQA.Selenium;

namespace CodeCamp_Assessment;

public class OrderPage
{
    private readonly IWebDriver _driver;

    public OrderPage(IWebDriver driver)
    {
        this._driver = driver;
    }

    public float GetTotal()
    {
        var totalText = _driver.FindElement(By.ClassName("order-total")).Text;
        return float.Parse(totalText.Split(" ")[1]);
    }
}