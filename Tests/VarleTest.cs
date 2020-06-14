using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace VcsWebdriver.Tests
{
    public class VarleTest : TestBase
    {
        [Test]
        public static void KondicPaieska()
        {
            _varlePage
                .GoToVarlePagrindPuslapis()
                .IeskomeNorimuPrekiu("Buitinė technika ir elektronika")
                .PaspaudziameNorimosPrekesLinka()
                .PatikrintiKondicioneriuLinka("KONDICIONIERIAI");

        }

        [Test]
        public static void ArVeikiaKainuReziaiIrFiltroValymas()
        {
            _varlePage
                .GoToVarlePagrindPuslapis()
                .IeskomeNorimuPrekiu("Buitinė technika ir elektronika")
                .PaspaudziameNorimosPrekesLinka()
                .PatikrintiKondicioneriuLinka("KONDICIONIERIAI")
                .IrasytiKaina(100, 180)
                .EnterMygtukas()
                .IsvalytiKaIraseme();


        }


        [Test]
        public static void PrisijungtiPriePaskyros()
        {
            _varlePage
                .GoToVarlePagrindPuslapis()
                .PrisijungtiPriePaskyros()
                .IvedameSavoDuomenis("lenavip@gmail.com", "viktorija2008")
                .LoginIn();

        }

        [Test]
        public static void PrisijungtiSuNeteisinguPassw()
        {
            _varlePage
                .GoToVarlePagrindPuslapis()
                .PrisijungtiPriePaskyros()
                .IvedameSavoDuomenis("lenavip@gmail.com", "viktorija")
                .PatikrinameKaiNeteisingasPassw();
                

        }


        [Test]
        public static void PaieskosVariantaiArPriimaVienSkaicius()
        {
            _varlePage
                  .GoToVarlePagrindPuslapis()
                  .PaieskosUzklausaSkaiciais(123456789)
                  .PatikrintiRezultataSkaiciais("Atrodo, kad pagal Jūsų paiešką „123456789“ prekių nebuvo rasta.");

        }

        [Test]
        public static void ArGalimaIssiustiPranesimaDelIeskomosprekes()
        {
            _varlePage
                .GoToVarlePagrindPuslapis()
                .PaieskosUzklausaSkaiciais(123456789)
                .PildomeSavoRekvizitus("860100000", "varle@gmail.com")
                .PasirinktiParduotuve("111")
                .RasomeKoieskome("skaiciuku rinkinio")
                .TikrinameArSekmingaiIssiustaUzklausa();
          
        }



        [Test]
        public static void ArFiltruojaPagalIrasomaGamintoja()
        {
            _varlePage
                .GoToVarlePagrindPuslapis()
                .IeskomeNorimuPrekiu("Buitinė technika ir elektronika")
                .PaspaudziameNorimosPrekesLinka()
                .PatikrintiKondicioneriuLinka("KONDICIONIERIAI")
                .IrasomeGamintoja("Samsung")
                .PatikrintiRezultatuKieki(11);
           
        }






    }
}


//Baigiamojo darbo reikalavimai:
//Minimum 5 prasmingi testai(kiekvienas testas minimum 3 žingsniai)
//Minimum 3 skirtingi puslapiai(tas pats website)

//Page Object Pattern
//Screenshot on test failure
//Paveldėjimas
//SetUp / TearDown panaudojimas
//Darbas įkeltas į GIT
//Explicit Wait panaudojimas !!! (kai persikeliame i kt pslp.):)
//Gražus, skaitomas kodas :)

//TEST1
//1. www.varle.lt -> VarlePage
//2. VISOS PREKES -> spaudziame "Buit.tehn.ir elektronika"-> VarleBuitTechnPage
//3. Oro reguliavimas -> pasirenkame "Kondicioneriai" -> VarlePageKondicioneriai
//4. Isitikiname, kad randa kondicionerius:)

//TEST2
//1. Pasirinkti pgl kaina
//2. Randa  
//3. Isvalo irasytas reiksmes


//TEST3
//1.Prisijungti
//2.Prisiregistruojame kaip vartotojas.
//3.Patikrinti


//TEST4
//1.Prisijungti
//2.Prisiregistruojame su netesingu passw.
//3.Patikriname

//TEST5
//1.Pagrindinis puslapis
//2.Paieska su skaiciais
//3.Paikrinimas

//TEST6
//1.Pagr.pusl.
//2.Paieska
//3.Pildome rekvizitus
//4.Rasome ko ieskome
//5.Isitikiname, kad issiusta


//TEST7
//1.Kondic.
//2.Filtras pgl gamintoja
//3.Rezultatu Kiekis
