using OpenQA.Selenium;
namespace TestAuthorization
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _singInButton = By.XPath("//span[text()='Войти']");
        private readonly By _singInButtonAuth = By.XPath("//button[@data-name='ContinueAuthBtn']");
        private readonly By _AnotherWayButton = By.XPath("//span[text()='Другим способом']");
        private readonly By _AuthInputButton = By.XPath("//input[@name='username']");
        private readonly By _PassInputButton = By.XPath("//input[@name='password']");
        private readonly By _ContinueButton = By.XPath("//span[text()='Продолжить']");
        private const string _login = "vladimir-andreev-2013@yandex.ru";
        private const string _password = "Test_Cian_2022";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Edge.EdgeDriver();
            driver.Navigate().GoToUrl("https://cian.ru");
            driver.Manage().Window.Maximize();
           

        }

        [Test]
        public void TestAuthorization()
        {
            var singIn = driver.FindElement(_singInButton);
            singIn.Click();

            var anotherWay = driver.FindElement(_AnotherWayButton);
            anotherWay.Click();

            var login = driver.FindElement(_AuthInputButton);
            login.SendKeys(_login);

          
            var continueBtn = driver.FindElement(_ContinueButton);
            continueBtn.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var password = driver.FindElement(_PassInputButton);
            password.SendKeys(_password);

            var singInAuth = driver.FindElement(_singInButtonAuth);
            singInAuth.Click();

            Assert.Pass();
        }
        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}