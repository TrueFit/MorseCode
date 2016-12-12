using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoderLibrary.MorseCode
{
    public class CodeMappings
    {
        public static readonly char[] legalCharacters = new char[]{'.','-','|'};
        public static readonly char[] separators = new char[]{'|'};

        public static readonly Dictionary<string, string> morseCodes = new Dictionary<String, String>()
        {
            { ".-","a"},
            { "-...","b"},
            { "-.-.","c"},
            { "-..","d"},
            { ".","e"},

            { "..-.","f"},
            { "--.","g"},
            { "....","h"},
            { "..","i"},
            { ".---","j"},

            { "-.-","k"},
            {".-..","l" },
            {"--","m" },
            { "-.","n"},
            {"---","o" },

            { ".--.","p"},
            { "--.-","q"},
            { ".-.","r"},
            { "...","s"},
            { "-","t"},

            { "..-","u"},
            { "...-","v"},
            { ".--","w"},
            {"-..-","x" },
            { "-.--","y"},

            {"--..","z" },

            { ".----","1"},
            { "..---","2"},
            { "...--","3"},
            { "....-","4"},
            { ".....","5"},
            { "-....","6"},
            { "--...","7"},
            { "---..","8"},
            { "----.","9"},
            { "-----","0"},

        };

        private CodeMappings()
        {

        }

    }
}
