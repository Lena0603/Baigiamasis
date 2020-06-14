using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Pages
{
    public class VarlePagePasirinkimo : PageBase
    {
        private IWebElement NorimosPrekesLinkas => Driver.FindElement(By.LinkText("Kondicionieriai"));

        private IWebElement PaieskosRezultatas => Driver.FindElement(By.Id("crumbs"));

        public VarlePagePasirinkimo(IWebDriver webdriver) : base(webdriver)
        {
        }

        public VarlePagePasirinkimo PaspaudziameNorimosPrekesLinka()
        {
            NorimosPrekesLinkas.Click();
            Thread.Sleep(TimeSpan.FromSeconds(30));
            return this;
        }


        public VarlePageResults PatikrintiKondicioneriuLinka(string ieskomaPreke)
        {
            var wait = GetWait(10);
            wait.Until(c => ExpectedConditions.ElementExists(By.Id("crumbs")));

            Assert.True(PaieskosRezultatas.Text.Contains(ieskomaPreke), $"Paieskos rezultatas [{PaieskosRezultatas.Text}] ne toks {ieskomaPreke}");
            Thread.Sleep(TimeSpan.FromSeconds(25));
            return new VarlePageResults(Driver);
        }





















        //public VarlePageResults PatikrinameRezultatuLinka()
        //{
        //    PaieskosRezultatas.Click();
        //    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);

        //    return new VarlePageResults(Driver);
        //}




        //public VarlePageResults PatikrintiKondicioneriuAntraste(string ieskomaPreke)
        //{
        //    var wait = GetWait(10);
        //    wait.Until(c => ExpectedConditions.ElementExists(By.CssSelector("span >a>span")));

        //    Assert.That(PaieskosRezultatas.Text.Contains(ieskomaPreke), Is.EqualTo("KONDICIONIERIAI"));
        //    return new VarlePageResults(Driver);
        //}










    }
}
