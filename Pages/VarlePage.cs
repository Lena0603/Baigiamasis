using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using VcsWebdriver.Pages;

namespace VcsWebdriverPages
{
    public class VarlePage : PageBase
    {

        private static IWebElement PrekiuPasirinkimas => Driver.FindElement(By.XPath("/html/body/header/div[3]/div/div/nav/div/div/div/ul/li[3]/a/span"));


        private static IWebElement Prisijungti => Driver.FindElement(By.XPath("//a[@id='login_header']/p"));
        private static IWebElement ElPastas => Driver.FindElement(By.Id("id_username"));
        private static IWebElement Slaptazodis => Driver.FindElement(By.Id("id_password"));
        private static IWebElement PrisijungtiMygtukas => Driver.FindElement(By.XPath("//button[@name='login']"));

        private static IWebElement PaieskosLangas => Driver.FindElement(By.XPath("//input[@name='q']"));
        private static IWebElement PaieskosMygtukas => Driver.FindElement(By.ClassName("search-button"));
        private static IWebElement Rezultatas => Driver.FindElement(By.CssSelector(".box1 > div:nth-child(6)"));

        
        private static IWebElement PranesimasApieNesekmingaPrisijungima => Driver.FindElement(By.CssSelector(".errorlist > li"));


        private static IWebElement TelefonoLangas => Driver.FindElement(By.Id("id_phone"));
        private static IWebElement EmailLangas => Driver.FindElement(By.Id("id_email"));
        private static SelectElement ParduotuviuPasirinkimas => new SelectElement(Driver.FindElement(By.Id("id_store")));
        private static IWebElement IeskauIvedimoLangas => Driver.FindElement(By.Id("id_text"));
        private static IWebElement KlaustiMygtukas => Driver.FindElement(By.CssSelector("button:nth-child(1)"));
        private static IWebElement UzklausosAtsakymas => Driver.FindElement(By.CssSelector("#not-found-form > div:nth-child(2)"));

        public VarlePage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public VarlePage GoToVarlePagrindPuslapis()
        {
            Driver.Url = "https://www.varle.lt/";
            return this;
        }


        public VarlePage PrisijungtiPriePaskyros()
        {
            Prisijungti.Click();
            return this;

        }


        public VarlePage LoginIn()
        {
            var vartotojas = Prisijungti.Text;
            Assert.AreNotEqual(vartotojas.Contains("Labas, Lenavip@Gmail.Com"), "neprisijunges");
            Thread.Sleep(TimeSpan.FromSeconds(7));
            return this;
        }

       

        public VarlePage IvedameSavoDuomenis(string email, string password)
        {
            ElPastas.Clear();
            ElPastas.SendKeys(email);
            Slaptazodis.Clear();
            Slaptazodis.SendKeys(password);
            PrisijungtiMygtukas.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            return this;
        }

        public VarlePage PatikrinameKaiNeteisingasPassw()
        {
            Assert.That(PranesimasApieNesekmingaPrisijungima.Text, Is.EqualTo("Neteisingas el. paštas ir/arba slaptažodis"));
            Thread.Sleep(TimeSpan.FromSeconds(7));
            return this;
        }

        

        public VarlePage PaieskosUzklausaSkaiciais(int irasome)
        {
            PaieskosLangas.SendKeys(irasome.ToString());
            PaieskosMygtukas.Click();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            
            return this;
        }

        public void PatikrintiRezultataSkaiciais(string expectedResult)
        {
            Assert.True(Rezultatas.Text.Contains(expectedResult), $"Rezultatas nera {expectedResult}"); 
        }





        public VarlePage PildomeSavoRekvizitus(string telefonas, string email)
        {
            TelefonoLangas.SendKeys(telefonas);
            EmailLangas.SendKeys(email);

            return this;
        }

        public VarlePage PasirinktiParduotuve(string parduotuve)
        {
            ParduotuviuPasirinkimas.SelectByValue(parduotuve);
            return this;
        }

        public VarlePage RasomeKoieskome(string ieskau)
        {
            IeskauIvedimoLangas.SendKeys(ieskau);
            KlaustiMygtukas.Click();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            return this;
        }

        public VarlePage TikrinameArSekmingaiIssiustaUzklausa()
        {
            Assert.That(UzklausosAtsakymas.Text, Is.EqualTo("Ačiū, Jūsų užklausa buvo išsiųsta."));
            return this;
        }





        public VarlePagePasirinkimo IeskomeNorimuPrekiu(string prekesPavadinimas)
        {
            PrekiuPasirinkimas.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);

            return new VarlePagePasirinkimo(Driver);
        }












    }
}
