using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using VcsWebdriver.Drivers;
using VcsWebdriver.Pages;
using VcsWebdriver.Tools;
using VcsWebdriverPages;

namespace VcsWebdriver.Tests
{
    public class TestBase
    {
        public static IWebDriver _driver;



        public static VarlePage _varlePage;
        public static VarlePagePasirinkimo _varlePagePasirink;
        public static VarlePageResults _varlePageResults;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            _driver = CustomDrivers.GetChromeWithOptions();




            _varlePage = new VarlePage(_driver);
            _varlePagePasirink = new VarlePagePasirinkimo(_driver);
            _varlePageResults = new VarlePageResults(_driver);
        }

        // vykdomas kaskart po kiekvieno testo
        [TearDown]
        public static void SingleTestTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                // cia mes padarysime screenshota
                MyScreenshot.MakePhoto(_driver);
            }
        }

        // vykdomas viena karta po visu testu
        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
