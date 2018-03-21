using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    public class MorseCodeDictionary
    {
        //handles the creation of the morse code dictionary
        public Dictionary<string,string> _morseCodeList;

        public MorseCodeDictionary()
        {
            _morseCodeList = new Dictionary<string, string>();
        }

        //Support for a-z, 0-9, and simple punctuation
        public Dictionary<string,string> PopulateMorseCodeDictionary()
        {
            Dictionary<string,string> morseCodes = new Dictionary<string,string>();
            morseCodes.Add(".-", "a");
            morseCodes.Add("-...", "b");
            morseCodes.Add("-.-.", "c");
            morseCodes.Add("-..", "d"); 
            morseCodes.Add(".", "e");
            morseCodes.Add("..-.", "f");
            morseCodes.Add("--.", "g");
            morseCodes.Add("....", "h");
            morseCodes.Add("..", "i");
            morseCodes.Add(".---", "j");
            morseCodes.Add("-.-", "k");
            morseCodes.Add(".-..", "l");
            morseCodes.Add("--", "m");
            morseCodes.Add("-.", "n");
            morseCodes.Add("---", "o");
            morseCodes.Add(".--.", "p");
            morseCodes.Add("--.-", "q");
            morseCodes.Add(".-.", "r");
            morseCodes.Add("...", "s");
            morseCodes.Add("-", "t");
            morseCodes.Add("..-", "u");
            morseCodes.Add("...-", "v");
            morseCodes.Add(".--", "w");
            morseCodes.Add("-..-", "x");
            morseCodes.Add("-.--", "y");
            morseCodes.Add("--..", "z");
            morseCodes.Add("-----", "0");
            morseCodes.Add(".----", "1");
            morseCodes.Add("..---", "2");
            morseCodes.Add("...--", "3");
            morseCodes.Add("....-", "4");
            morseCodes.Add(".....", "5");
            morseCodes.Add("-....", "6");
            morseCodes.Add("--...", "7");
            morseCodes.Add("---..", "8");
            morseCodes.Add("----.", "9");
            morseCodes.Add(".-.-.-", ".");
            morseCodes.Add("--..--", ",");
            morseCodes.Add("..--..", "?");
            morseCodes.Add("-.-.--", "!");
            morseCodes.Add(" ", " ");
            morseCodes.Add("", " ");

            return morseCodes;
        }
    }
}
