using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DecoderLibrary;
using DecoderLibrary.MorseCode;

namespace MorseCodeLibraryTests
{
    [TestClass]
    public class MorseCodeTranslationTests
    {

        MorseCodeInterpreter _Decoder;

        [TestInitialize]
        public void Setup()
        {
            _Decoder = new MorseCodeInterpreter();
        
        }

        [TestMethod]
        public void CanDecodeDog()
        {

            var encodedString = "-..|---|--.";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("dog", decodedString);

        }

        [TestMethod]
        public void CanDecodeHello_Space_World()
        {

            var encodedString = "....|.|.-..|.-..|---||.--|---|.-.|.-..|-..";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("hello world", decodedString);

        }
        [TestMethod]
        public void ThrowExceptionWhenUnknownCharacterEncountered()
        {

            try
            {
                var encodedString = "_..";
                var decodedString = _Decoder.Translate(encodedString);
            }
            catch (UnknownCharacterException e)
            {
                Assert.AreEqual('_',e.UnknownCharacter);
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message));
            }
        }

        [TestMethod]
        public void ThrowExceptionWhenUnknownCodeEncountered()
        {
            var encodedString = ".......";
            try
            {
                
                var decodedString = _Decoder.Translate(encodedString);

            }
            catch (UnknownCodeException e)
            {
                Assert.AreEqual(encodedString, e.UnknownCode);
            }
            catch (Exception e)
            {
                Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}",
                            e.GetType(), e.Message));
            }            
        }

        [TestMethod]
        public void SingleWordReturnedWhenNoDoubleBreaksInString()
        {
            var encodedString = "....|.|.-..|.-..|---|.--|---|.-.|.-..|-..";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("helloworld", decodedString);

        }

        [TestMethod]
        public void NullOrEmptyStringReturnsEmptyString()
        {
            var encodedString = "";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("", decodedString);

        }

        [TestMethod]
        public void ExtraSpacesRemovedBetweenWords()
        {
            var encodedString = "....|.|.-..|.-..|---||....|.|.-..|.-..|---|||....|.|.-..|.-..|---";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("hello hello hello", decodedString);
        }

        [TestMethod]
        public void LeadingSpacesAreRemoved()
        {
            var encodedString = "|||....|.";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("he", decodedString);
        }

        [TestMethod]
        public void TrailingSpacesAreRemoved()
        {
            var encodedString = "....|.|||";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("he", decodedString);
        }


        [TestMethod]
        public void NumbersCanBeEmbeddedInWord()
        {
            var encodedString = "....|.|.-..|.-..|---|.----|....|.|.-..|.-..|---|||....|.|.-..|.-..|---";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("hello1hello hello", decodedString);
        }

        [TestMethod]
        public void NumbersCanStandAloneAsWord()
        {
            var encodedString = "....|.|.-..|.-..|---||.----||....|.|.-..|.-..|---|||....|.|.-..|.-..|---";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("hello 1 hello hello", decodedString);
        }

        [TestMethod]
        public void NumbersCanHaveMultipleDigits()
        {
            var encodedString = "....|.|.-..|.-..|---||.----|..---|-----||....|.|.-..|.-..|---|||....|.|.-..|.-..|---";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("hello 120 hello hello", decodedString);
        }

        [TestMethod]
        public void StringCanBeNumbersOnly()
        {
            var encodedString = ".----|..---|-----";
            var decodedString = _Decoder.Translate(encodedString);
            Assert.AreEqual("120", decodedString);
        }
        
        /* quick test to see that values.  Helps a little with initially entering codes*/
        [TestMethod]
        public void TestValidateCodes()
        {
            Assert.AreEqual("a", CodeMappings.morseCodes[".-"]);
            Assert.AreEqual("b", CodeMappings.morseCodes["-..."]);
            Assert.AreEqual("c", CodeMappings.morseCodes["-.-."]);
            Assert.AreEqual("d", CodeMappings.morseCodes["-.."]);
            Assert.AreEqual("e", CodeMappings.morseCodes["."]);

            Assert.AreEqual("f", CodeMappings.morseCodes["..-."]);
            Assert.AreEqual("g", CodeMappings.morseCodes["--."]);
            Assert.AreEqual("h", CodeMappings.morseCodes["...."]);
            Assert.AreEqual("i", CodeMappings.morseCodes[".."]);
            Assert.AreEqual("j", CodeMappings.morseCodes[".---"]);

            Assert.AreEqual("k", CodeMappings.morseCodes["-.-"]);
            Assert.AreEqual("l", CodeMappings.morseCodes[".-.."]);
            Assert.AreEqual("m", CodeMappings.morseCodes["--"]);
            Assert.AreEqual("n", CodeMappings.morseCodes["-."]);
            Assert.AreEqual("o", CodeMappings.morseCodes["---"]);

            Assert.AreEqual("p", CodeMappings.morseCodes[".--."]);
            Assert.AreEqual("q", CodeMappings.morseCodes["--.-"]);
            Assert.AreEqual("r", CodeMappings.morseCodes[".-."]);
            Assert.AreEqual("s", CodeMappings.morseCodes["..."]);
            Assert.AreEqual("t", CodeMappings.morseCodes["-"]);

            Assert.AreEqual("u", CodeMappings.morseCodes["..-"]);
            Assert.AreEqual("v", CodeMappings.morseCodes["...-"]);
            Assert.AreEqual("w", CodeMappings.morseCodes[".--"]);
            Assert.AreEqual("x", CodeMappings.morseCodes["-..-"]);
            Assert.AreEqual("y", CodeMappings.morseCodes["-.--"]);

            Assert.AreEqual("z", CodeMappings.morseCodes["--.."]);

            Assert.AreEqual("1", CodeMappings.morseCodes[".----"]);
            Assert.AreEqual("2", CodeMappings.morseCodes["..---"]);
            Assert.AreEqual("3", CodeMappings.morseCodes["...--"]);
            Assert.AreEqual("4", CodeMappings.morseCodes["....-"]);
            Assert.AreEqual("5", CodeMappings.morseCodes["....."]);
            Assert.AreEqual("6", CodeMappings.morseCodes["-...."]);
            Assert.AreEqual("7", CodeMappings.morseCodes["--..."]);
            Assert.AreEqual("8", CodeMappings.morseCodes["---.."]);
            Assert.AreEqual("9", CodeMappings.morseCodes["----."]);
            Assert.AreEqual("0", CodeMappings.morseCodes["-----"]);
            
        }
    }
}
