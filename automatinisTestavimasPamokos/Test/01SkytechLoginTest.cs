/*
    2021-11-19, Rimvydas Vainutis
    Baigiamasis darbas, Skytech.lt svetaines funkcionalumo testavimas
    LoginTest
*/

using automatinisTestavimasPamokos.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Test
{
    public class SkytechLoginTest : BaseTest
    {
        // Vartotojas sukurtas butent siam testui
        [TestCase("hohag62978@elastit.com", "gediminas.testauskas123", TestName = "01 Skytech Login Test")]
        public void TestLogin(string elPastoAdresas, string slaptazodisText)
        {
            _skytechLoginPage.NavigateToDefaultPage()
                .ThreadSleep500()
                .ClickLogin()
                .ClickElPastoAdresasLoginInput()
                .ThreadSleep500()
                .InputElPastoAdresasLoginText(elPastoAdresas)
                .ThreadSleep500()
                .ClickSlaptazodisLoginInput()
                .InputSlaptazodisLoginText(slaptazodisText)
                .ThreadSleep500()
                .CheckmarkPrisimintiManeLogin()
                .ThreadSleep500()
                .ClickPrisijungtiButtonLogin()
                .CheckLoginResult();
        }

        // Kad testas butu sekmingas, kiekviena karta reikia keisti el. pasto adresa, nes kuriamas naujas vartotojas
        [TestCase("Osvaldas", "Penikas", "+37061212345", "vasodep174@elastit.com", "patsBaisiusiasFilmas_2021", TestName = "02 Skytech Register Test")]
        public void TestRegister(string vardas, string pavarde, string telNr, string elPastas, string slaptazodis)
        {
            _skytechLoginPage.NavigateToDefaultPage()
                .ThreadSleep500()
                .ClickRegister()
                .ClickVardasRegisterInput()
                .InputVardasTextRegister(vardas)
                .ThreadSleep500()
                .ClickPavardeRegisterInput()
                .InputPavardeTextRegister(pavarde)
                .ThreadSleep500()
                .ClickTelNrRegisterInput()
                .InputTelNrTextRegister(telNr)
                .ThreadSleep500()
                .ClickElPastasRegisterInput()
                .InputElPastasTextRegister(elPastas)
                .ThreadSleep500()
                .ClickSlaptazodisRegisterInput()
                .InputSlaptazodisTextRegister(slaptazodis)
                .ThreadSleep500()
                .ClickSlaptazodisKartotiRegisterInput()
                .InputSlaptazodisKartotiTextRegister(slaptazodis)
                .ThreadSleep500()
                .ClickCheckmarkTaisyklesRegister()
                .ClickCheckPrivatumasRegister()
                .ClickCheckNaujienosRegister()
                .ThreadSleep500()
                .ClickSubmitRegisterButton()
                .CheckRegisterSuccessText();
        }
    }
}