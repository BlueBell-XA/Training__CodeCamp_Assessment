using System.Diagnostics;
using OpenQA.Selenium;

namespace CodeCamp_Assessment;

public class PizzaMenu
{
    private IWebDriver _driver;
    private List<IWebElement> VeganPizzas;
    public PizzaMenu(IWebDriver driver)
    {
        this._driver = driver;
        VeganPizzas = new List<IWebElement>();
    }

    public void FindVeganPizzas()
    {
        //List<IWebElement> veganPizzas = new List<IWebElement>();
        var listOfPizzas = _driver.FindElements(By.ClassName("pizza"));
        foreach (var pizza in listOfPizzas)
        {
            if (pizza.GetAttribute("innerText").ToLower().Contains("vegan"))
            {
                Trace.WriteLine("adding vegan");
                VeganPizzas.Add(pizza);
            }
        }
    }

    public bool PriceOfVeganPizzasEqual(float expectedPrice)
    {
        return VeganPizzas.All(pizza => float.Parse(pizza.FindElement(By.ClassName("price")).Text.Split("$")[1]) == expectedPrice);
    }

    public void Order2Margherita()
    {
        foreach (var pizza in _driver.FindElements(By.ClassName("pizza")))
        {
            if (pizza.FindElement(By.ClassName("name")).Text.ToLower() != "margherita") continue;
            var order = pizza.FindElement(By.ClassName("v-btn__content"));
            order.Click();
            order.Click();
            return;
        }
    }
}