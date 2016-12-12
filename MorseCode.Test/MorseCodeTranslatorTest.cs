using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MorseCode.Lib;

namespace MorseCode.Test
{
    [TestClass]
    public class MorseCodeTranslatorTest
    {
        [TestMethod]
        public void Translate_SampleMorseCodeString_ValidOutput()
        {
            // Arrange
            var nullLogger = new SimpleLogging.Core.NullableLoggingService();
            var translator = new MorseCodeTranslator(nullLogger);
            var input = "-..|---|--.\n....|.|.-..|.-..|---||.--|---|.-.|.-..|-..";

            // Act
            var output = translator.Translate(input);      

            // Assert
            var expected = "dog\nhello world";
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Translate_SampleMorseCodeStringWithBadChars_ValidOutput()
        {
            // Arrange
            var nullLogger = new SimpleLogging.Core.NullableLoggingService();
            var translator = new MorseCodeTranslator(nullLogger);
            var input = "x-..|---|--.\n....|.|.-..|.-..|-x--||.--|---|.-.|.-..|-..x";

            // Act
            var actual = translator.Translate(input);

            // Exception expected
        }

        [TestMethod]
        [DeploymentItem("SampleMorseCode.txt")]
        public void Translate_SampleMorseCodeFile_ValidOutput()
        {
            // Arrange
            var nullLogger = new SimpleLogging.Core.NullableLoggingService();
            var translator = new MorseCodeTranslator(nullLogger);
            var inputFilename = "SampleMorseCode.txt";

            // Act
            var output = translator.TranslateFile(inputFilename);

            // Assert
            var expected = "dog\nhello world";
            Assert.AreEqual(expected, output);
        }

    }
}
