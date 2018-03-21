using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode
{
    public class MorseCodeConverter
    {
        private Dictionary<string, string> _codeDictionary;
        private MorseCodeDictionary mcd = new MorseCodeDictionary();

        public MorseCodeConverter()
        {
            _codeDictionary = mcd.PopulateMorseCodeDictionary();
        }
        public string GetCharFromMorseCode(string morseCode)
        {
            string charFromCode = "";
            if (_codeDictionary.ContainsKey(morseCode))
            {
                charFromCode = _codeDictionary[morseCode];
            }

            return charFromCode;
        }

        public string GetStringFromMorseCodeString(string morseCodeString)
        {
            string[] morseCodeValues = morseCodeString.Replace("||", " ").Split(' ');

            StringBuilder output = new StringBuilder();

            foreach (string s in morseCodeValues)
            {
                output.Append(GetCharFromMorseCode(s));
            }

            return output.ToString();
        }

        public string ConvertFileDataToText(List<string> fileData)
        {
            StringBuilder convertedData = new StringBuilder();

            if (fileData.Any())
            {
                foreach(var code in fileData)
                {
                    convertedData.AppendLine(GetStringFromMorseCodeString(code));
                }
            }
            return convertedData.ToString();
        }
    }
}
