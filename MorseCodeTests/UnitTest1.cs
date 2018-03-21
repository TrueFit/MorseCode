using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MorseCode;

namespace MorseCodeTests
{
    [TestClass]
    public class UnitTest1
    {
        private MorseCodeConverter testConverter = new MorseCodeConverter();

        [TestMethod]
        public void CanReturnACharFromDictionary()
        {
            string testStringforMorseCodeValueForA = ".-";
            Assert.AreEqual(testConverter.GetCharFromMorseCode(testStringforMorseCodeValueForA), "a");
        }
        [TestMethod]
        public void CanReturnPeriodCharFromDictionary()
        {
            string testStringforMorseCodeValueForPeriod = ".-.-.-";
            Assert.AreEqual(testConverter.GetCharFromMorseCode(testStringforMorseCodeValueForPeriod), ".");
        }
        [TestMethod]
        public void CanReturnSpaceCharFromDictionary()
        {
            string testStringforMorseCodeValueForSpace = "";
            Assert.AreEqual(testConverter.GetCharFromMorseCode(testStringforMorseCodeValueForSpace), " ");
        }

        [TestMethod]
        public void CanReturnHelloWorldFromMorseCodeString()
        {
            string testString = "....||.||.-..||.-..||---||||.--||---||.-.||.-..||-..";
            Assert.AreEqual(testConverter.GetStringFromMorseCodeString(testString), "hello world");
        }
        [TestMethod]
        public void CanReturnDogFromMorseCodeString()
        {
            string testString = "-..||---||--.";
            Assert.AreEqual(testConverter.GetStringFromMorseCodeString(testString), "dog");
        }
    }
}
