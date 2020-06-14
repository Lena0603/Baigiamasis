//using System;
//namespace VcsWebdriver.Tests
//{
//    public class SeleniumTEST
//    {
//        public SeleniumTEST()
//        {
//        }
//    }
//}

//[Test]
//public void varle()
//{
//    // Test name: varle
//    // Step # | name | target | value | comment
//    // 1 | open | / |  | 
//    driver.Navigate().GoToUrl("https://www.varle.lt/");
//    // 2 | setWindowSize | 1974x1254 |  | 
//    driver.Manage().Window.Size = new System.Drawing.Size(1974, 1254);


//    // 3 | click | css=.departments-item:nth-child(3) span |  | 
//    driver.FindElement(By.CssSelector(".departments-item:nth-child(3) span")).Click();  //PASIRENKAME BUITINE TECHNIKA


//    // 4 | click | linkText=Kondicionieriai |  |
//   driver.FindElement(By.LinkText("Kondicionieriai")).Click();  // PASIRENKAME KONDICIONERIUS


//    // 5 | click | css=.filters_v2-filter:nth-child(4) .filters_v2-facet:nth-child(1) label |  | 
//    driver.FindElement(By.CssSelector(".filters_v2-filter:nth-child(4) .filters_v2-facet:nth-child(1) label")).Click();


//    // 6 | click | css=.filters_v2-filter-row:nth-child(2) .has-search > .filters_v2-facet:nth-child(1) label |  | 
//    driver.FindElement(By.CssSelector(".filters_v2-filter-row:nth-child(2) .has-search > .filters_v2-facet:nth-child(1) label")).Click();


//    // 7 | click | css=.filters_v2-filter-row:nth-child(1) > .filters_v2-filter:nth-child(2) .filters_v2-facet:nth-child(2) label |  | 
//    driver.FindElement(By.CssSelector(".filters_v2-filter-row:nth-child(1) > .filters_v2-filter:nth-child(2) .filters_v2-facet:nth-child(2) label")).Click();


//    // 8 | click | css=.filters_v2-current-filters-container |  | 
//    driver.FindElement(By.CssSelector(".filters_v2-current-filters-container")).Click();


//    // 9 | verifyText | css=.filters_v2-current-filter:nth-child(1) | Samsung |
//    Assert.That(driver.FindElement(By.CssSelector(".filters_v2-current-filter:nth-child(1)")).Text, Is.EqualTo("Samsung"));

//    // 10 | close |  |  | 
//    driver.Close();
//}
//}




//_varlePageResult

//private SelectElement GamintojoSarasas => new SelectElement(Driver.FindElement(By.CssSelector(".filters_v2-current-filters-container")));
//private IWebElement RezultatoAtvaizdavimas => Driver.FindElement(By.ClassName("filters_v2-current-filter"));



//public VarlePageResults PasirinktiGamintoja(List<string> elementuValuesKuriuosPasirinksime)
//{
//    foreach (var option in GamintojoSarasas.Options)
//        if (elementuValuesKuriuosPasirinksime.Contains(option.GetAttribute("filters_v2-facet-value")))
//        {
//            ClickNorima(option);
//        }

//    return this;
//}

//public void ClickNorima(IWebElement element)
//{
//    Actions actions = new Actions(Driver);
//    actions.KeyDown(Keys.Control);
//    actions.Click(element);
//    actions.KeyUp(Keys.Control);
//    actions.Build().Perform();
//}




//public VarlePageResults TikrinameKaPasirinkome()
//{
//    var builded = new Actions(Driver);
//    builded.SendKeys(Keys.PageDown);
//    builded.Build().Perform();


//    string rezultatas = RezultatoAtvaizdavimas.Text;

//    IList<IWebElement> pasirinktiElementai = GamintojoSarasas.AllSelectedOptions;
//    foreach (IWebElement pasirinktasModelis in pasirinktiElementai)
//    {
//        Assert.True(rezultatas.Contains(pasirinktasModelis.Text), $"{pasirinktasModelis} nera tarp pasirinktu");
//    }

//    return this;
//}


//public VarlePageResults PazymimeGamintoja(bool pasirinkta)
//{
//    if (!GamintojuCheckBoxai.Selected)
//    {
//        GamintojuCheckBoxai.Click();
//    }

//    return this;
//}