using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    public class VarlePageResults : PageBase
    {


        public VarlePageResults(IWebDriver webdriver) : base(webdriver)
        {
        }

        private IWebElement KainaNuo => Driver.FindElement(By.Id("amount-from"));
        private IWebElement KainaIki => Driver.FindElement(By.Id("amount-to"));

        private IWebElement IsvalytiFiltrus => Driver.FindElement(By.XPath("//*[@id='body']/div[2]/div/div/div[5]/form/div[1]/span/span[1]"));

        private IWebElement GamintojuIvedimoLaukas => Driver.FindElement(By.Name("facet-value-filter"));
        private IWebElement RezultatoAtvaizdavimas => Driver.FindElement(By.CssSelector(".filters_v2-filter-row:nth-child(1) > .filters_v2-filter:nth-child(2) .filters_v2-facet:nth-child(8)"));
        private int KondicioneriuKiekis => Convert.ToInt32(Driver.FindElement(By.XPath("//*[@id='body']/div[2]/div/div/div[5]/form/div[2]/div[1]/div[2]/div/div[3]/label[8]/span[3]"))
                    .Text
                    .Replace("(", "")
                    .Replace(")", ""));


       // private static SelectElement RikiavimasPglPrioriteta => new SelectElement(Driver.FindElement(By.XPath("//*[@id='sort']/select")));


        public VarlePageResults IrasytiKaina(int Nuo, int Iki)
        {

            KainaNuo.SendKeys(Nuo.ToString());
            KainaIki.SendKeys(Iki.ToString());
            return this;
        }


        public VarlePageResults EnterMygtukas()
        {
            Driver.FindElement(By.Id("amount-to")).SendKeys(Keys.Enter);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            return this;
        }

        public VarlePageResults IsvalytiKaIraseme()
        {
            IsvalytiFiltrus.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return this;
        }


        public VarlePageResults IrasomeGamintoja(string gamintojas)
        {
            GamintojuIvedimoLaukas.SendKeys(gamintojas);
            return this;
        }

        

        public VarlePageResults PatikrintiRezultatuKieki(int tiketinasKiekis)
        {
            Assert.GreaterOrEqual(KondicioneriuKiekis, tiketinasKiekis, "Rezultato kiekis ne toks, kokio tikejomes");
            return this;
        }


        







        //private IWebElement GamintojuCheckBoxai => Driver.FindElement(By.ClassName("filters_v2-facet"));
        //private IWebElement RezultatoAtvaizdavimas => Driver.FindElement(By.XPath("//*[@id='crumbs']/li[3]"));


        //public VarlePageResults PazymimeGamintoja()
        //{

        //    GamintojuCheckBoxai.Click();
        //    Thread.Sleep(TimeSpan.FromSeconds(7));
        //    return this;
        //}


        //public void PatikrinameRezultata(string expectedRezultatas)
        //{
        //    var wait = GetWait(25);
        //    wait.Until(c => ExpectedConditions.ElementExists(By.ClassName("filters_v2-facet")));
        //    Assert.True(GamintojuCheckBoxai.Text.Contains(expectedRezultatas), "Tekstas nesutampa!");

        //}

        //public VarlePageResults PatikrintiRezultatuAntraste(string ieskomasZodis)
        //{
        //    var wait = GetWait(5);
        //    wait.Until(c => ExpectedConditions.ElementExists(By.XPath("//*[@id='crumbs']/li[3]")));

        //    Assert.True(RezultatoAtvaizdavimas.Text.Contains(ieskomasZodis));
        //    return this;
        //}





        //private static IWebElement RezultatoZinute => Driver.FindElement(By.ClassName("getall-selected"));
        //private static SelectElement ModelioGamintojoSarasas => new SelectElement(Driver.FindElement(By.Id("multi-select")));









    }
}