using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoderLibrary;

namespace DecoderLibrary.MorseCode
{
    /// <summary>
    /// MorseCodeInterpreter    Converts morse code encoded string to alphanumeric string.
    ///                         Words will be separated by single space. Leading/Trailing space removed.  
    ///                         numbers may be used separately or as part of word. 
    /// </summary>
    public class MorseCodeInterpreter: Interpreter

    {
        bool _LastWasNull = false; // used to help pare down all blanks to be one space

        /// <summary>
        /// Translate - converts string of morse codes and converts each to alphanumeric. 
        /// 
        /// </summary>
        /// <param name="sourceString">contains morse code symbols separated by break character(|)</param>
        /// <returns>decoded alphanumeric string with a blank between words</returns>
        public string Translate(String sourceString)
        {
            if (String.IsNullOrEmpty(sourceString))
                return "";

            string[] s = sourceString.Split(CodeMappings.separators);
            StringBuilder decodedString = new StringBuilder();

            foreach(string str in s)
            {
                var decodedLetter = Decode(str);
                decodedString.Append(decodedLetter);
            }
            return decodedString.ToString().Trim();

        }

        /// <summary>
        /// Decode one encoded alphanumerica at a time. 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string Decode(string code)
        {

            string decodedChar  = "";
            if (String.IsNullOrEmpty(code) )
            {
                if (_LastWasNull)
                {
                    return "";
                }
                else
                {
                    _LastWasNull = true;
                    return " ";
                }
            }
            _LastWasNull = false;

            try
            {
                ValidateCharacters(code);

                decodedChar = CodeMappings.morseCodes[code];

            }
            catch (KeyNotFoundException e)
            {
                var newException  = new UnknownCodeException( "Unknown Code " + code, e );
                newException.UnknownCode = code;
                //would normally log this here. 

                throw newException;
            }
            catch(Exception )
            {
                //would normally log this here. 
                throw;
            }

            return decodedChar;
        }

        /// <summary>
        /// ValidateCharacters  Check tha only encoding characters used are in legal list
        /// </summary>
        /// <param name="code"></param>
        private void ValidateCharacters(string code)
        {
            foreach (var checkChar in code)
            {
            if (!CodeMappings.legalCharacters.Any(x=> x.Equals(checkChar) ))
            {
                var newException = new UnknownCharacterException("Unknown character,''" + checkChar +"'', in code ");
                newException.UnknownCharacter = checkChar;
                //would normally log this here. 
                throw newException;
            }

            }
            return;
        }

    }
}
