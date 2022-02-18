using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Program
    {
        //Create reference for the browser
        IWebDriver driver = new ChromeDriver();

        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            //Navigate to Google home page
            driver.Navigate().GoToUrl("https://www.google.co.uk");
            Console.WriteLine("Opened URL");
        }

        [Test]
        public void ExecuteTest()
        {
            //Find the Cookie Agree & click
            IWebElement cookie = driver.FindElement(By.Id("L2AGLb"));
            cookie.Click();

            //Find the Search Box element & enter search term
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("Rocktime");

            //Find the I'm Feeling Lucky Button & click
            IWebElement button = driver.FindElement(By.Id("gbqfbb"));
            button.Click();

            Console.WriteLine("Executed Test");
        }


        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            Console.WriteLine("Closed the Browser");
        }


        }

    }