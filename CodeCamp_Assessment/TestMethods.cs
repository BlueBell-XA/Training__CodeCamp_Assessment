using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CodeCamp_Assessment
{
    [TestClass]
    public class TestMethods
    {
        #pragma warning disable CS8618
        private IWebDriver _driver;
        #pragma warning restore CS8618

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "website";
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange


            // Act


            // Run

        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange


            // Act


            // Run

        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}