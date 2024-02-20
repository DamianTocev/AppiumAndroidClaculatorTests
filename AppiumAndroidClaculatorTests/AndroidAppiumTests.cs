using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AndroidAppiumTests
{
    public class AndroidAppiumCalculatorTests
    {
        private const string appiumUrl = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"D:\RABOTNA\CODING\Projects\QA_Automation\APK-Fiels\com.example.androidappsummator.apk";
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            this.options = new AppiumOptions();
            options.AddAdditionalCapability("app", appLocation);
            //options.AddAdditionalCapability("deviceName", "MOB30X");
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumUrl), options);
        }

        [TearDown]
        public void Close_Aplication()
        {
            driver.Dispose();
        }


        [Test]
        public void Test_Try_To_Start()
        {
            Assert.Pass();
        }

        [Test]
        public void Test_Calculate_Two_Positive_Numbers()
        {
            // Arange
            var firstInput = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondInput = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

            // Act
            firstInput.Clear();
            secondInput.Clear();
            firstInput.SendKeys("5");
            secondInput.SendKeys("15");
            calcButton.Click();
            var result = resultField.Text;

            // Assert
            Assert.That(result, Is.EqualTo("20"));

        }

        [Test]
        public void Test_Uncorect_Imput()
        {
            // Arange
            var firstInput = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondInput = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

            // Act
            firstInput.Clear();
            secondInput.Clear();
            firstInput.SendKeys("5");
            secondInput.SendKeys("alabala");
            calcButton.Click();
            var result = resultField.Text;

            // Assert
            Assert.That(result, Is.EqualTo("error"));

        }


    }
}