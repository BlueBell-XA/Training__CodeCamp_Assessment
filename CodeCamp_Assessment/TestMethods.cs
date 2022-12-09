using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CodeCamp_Assessment
{
    [TestClass]
    public class TestMethods
    {
        // TODO - Huge amount of refactoring, POM of all menu tiles, find better ways of locating some elements!
        #pragma warning disable CS8618
        private IWebDriver _driver;
        #pragma warning restore CS8618

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://d3nay7txmslpgb.cloudfront.net/#/";
            _driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void OpenMenuPage_LocateVeganPizzas_CheckPrice()
        {
            // Arrange
            new NavigationItem(_driver).ClickMenu();

            // Act
            var pizzaMenu = new PizzaMenu(_driver);
            pizzaMenu.FindVeganPizzas();

            // Run
            Assert.IsTrue(pizzaMenu.PriceOfVeganPizzasEqual(14.99f));
        }

        [TestMethod]
        public void NavigateMenus_OrderItems_CheckOrderCount()
        {
            // Arrange
            var navigation = new NavigationItem(_driver);
            navigation.ClickMenu();
            var tabSelector = new TabSelector(_driver);
            tabSelector.ClickTabItem("Drinks");

            // Act
            new DrinksMenu(_driver).OrderEspressoThickshake();
            tabSelector.ClickTabItem("Pizzas");
            var pizzaMenu = new PizzaMenu(_driver);
            pizzaMenu.Order2Margherita();

            // Run
            Assert.AreEqual(3, navigation.GetOrderCount());
        }

        [TestMethod]
        public void NavigateMenus_OrderItems_CheckOrderTotal()
        {
            // Arrange
            var navigation = new NavigationItem(_driver);
            navigation.ClickMenu();
            var tabSelector = new TabSelector(_driver);
            tabSelector.ClickTabItem("Drinks");
            new DrinksMenu(_driver).OrderEspressoThickshake();
            tabSelector.ClickTabItem("Pizzas");
            var pizzaMenu = new PizzaMenu(_driver);
            pizzaMenu.Order2Margherita();

            // Act
            _driver.Url = "https://d3nay7txmslpgb.cloudfront.net/#/order";
            // TODO fix order button and don't use url
            //navigation.ClickOrders();
            var orderPage = new OrderPage(_driver);


            // Run
            Assert.AreEqual(19.98f, orderPage.GetTotal());
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}