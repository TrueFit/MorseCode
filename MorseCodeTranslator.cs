using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCodeTranslator
{
    /// <summary>
    /// This class will serve as a translation engine between English and Morse Code
    /// Static class has been used so that we can simply reference this functionality through 
    /// an extension method by adding a using to our calling code
    /// </summary>
    public static class MorseCodeTranslator
    {
        /// <summary>
        /// This dictionary contains the morse code to english translation.  It is compiled and not a configuration item since morse code should never change 
        /// </summary>
        public static readonly Dictionary<string, char> MorseCodeDictionary = new Dictionary<string, char>()
            {
                {".-",'A' },
                {"-...",'B' },
                {"-.-.",'C' },
                {"-..",'D'},
                {".",'E' },
                {"..-.",'F'},
                {"--.",'G'  },
                {"....",'H'  },
                {"..",'I'},
                {".---",'J' },
                {"-.-",'K' },
                {".-..",'L'},
                {"--",'M'},
                {"-.",'N'},
                {"---",'O'},
                {".--.",'P'  },
                {"--.-",'Q'},
                {".-.",'R'},
                {"...",'S'},
                {"-",'T'},
                {"..-",'U'},
                {"...-",'V' },
                {".--",'W'},
                {"-..-",'X'},
                {"-.--",'Y'},
                {"--..",'Z'},
                {"-----",'0'},
                {".----",'1'},
                {"..---",'2'},
                {"...--",'3'},
                {"....-",'4'},
                {".....",'5'},
                {"-....",'6'},
                {"--...",'7'},
                {"---..",'8'},
                {"----.",'9'},
                {"",' '},
            };

        /// <summary>
        /// This static method will convert Morse Code strings to English
        /// </summary>
        /// <param name="MorseCode"></param>
        /// <returns></returns>
        public static string ToEnglish (this string MorseCode)
        {
            //Return value.  Stringbuilder used 
            var translation = new StringBuilder();

            try
            {
                //Loop through each line in the file
                foreach (var line in MorseCode.Split(new string[]{"\r\n"},StringSplitOptions.RemoveEmptyEntries))
                {
                    //Loop through each letter seperated by a pipe
                    foreach (var letter in line.Split(new char[] {'|'}))
	                {
                        //If not a valid translation, throw an exception
                        if (!MorseCodeDictionary.ContainsKey(letter))
                            throw new Exception(string.Format("Invalid code found '{0}'", letter));
                        
                        //otherwise, append the sequence
                        translation.Append(MorseCodeDictionary[letter]);                    
	                }
                    //on line change, append a new line
                    translation.AppendLine();
                }
                //return the results
                return translation.ToString();
            }
            catch (Exception)
            {
                //throw/return any errors
                throw;
            }
        }
    }
}
